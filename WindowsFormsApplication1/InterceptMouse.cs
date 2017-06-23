using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Utilities;
using WindowsInput;
using System.Timers;
using System.IO;
using System.ComponentModel;

namespace WindowsFormsApplication1
{
    class InterceptMouse

    {
        public class HotMacro
        {
            public string hotkey { get; set; }
            public string target { get; set; }
            public HotMacro(string h, string t)
            {
                hotkey = h;
                target = t;
            }
        }
        public static InputSimulator inputer = new InputSimulator();
        private static LowLevelMouseProc _proc = HookCallback;
        private static POINT posMouse;
        private static IntPtr _hookID = IntPtr.Zero;
        private static globalKeyboardHook gkh = new globalKeyboardHook();
        private static List<HotMacro> hotKeys = new List<HotMacro>();
        private static string stopHotKey = "";
        private static KeyEventHandler newKeyEventHandlerUp;
        private static KeyEventHandler newKeyEventHandlerDown;
        public enum Mode { none , recording, recordingAll,   playingUntil,
            listening
        }
        private static Mode mode = Mode.none;
        private static Stopwatch stopwatch = new Stopwatch();
        private static List<MacroEvent> recordedEvents;
        private static Dictionary<string, bool> modKeys = new Dictionary<string, bool>();
        private static Form1 window;
        private static bool keepTime;
        private static int delayBetweenStrokes;
        [STAThread]
        public static void Main()

        {
            Console.WriteLine("Debut Main");
            string[] args = Environment.GetCommandLineArgs();
            Microsoft.Win32.Registry.SetValue("HKEY_CURRENT_USER\\Control Panel\\Desktop", "LowLevelHooksTimeout", 15000);
            /*Console.WriteLine("Commande: argc:"+args.Length);
            for(int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine(args[i]);
            }
            */
            modKeys["Ctrl"] = false;
            modKeys["Alt"] = false;
            modKeys["Shift"] = false;
            _hookID = SetHook(_proc);
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 50;
            aTimer.Enabled = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            window = new Form1();
            if (args.Length == 2)
            {
                Console.WriteLine("Chargement du fichier: " + args[1]);
                LoadMacroFromFile(args[1]);

            }
            Application.Run(window);
            //Application.Run();
            bool ret = UnhookWindowsHookEx(_hookID);

        }

        internal static void startRecording(string hotkey, bool record_all, bool keep_time, int delay=50)
        {
            Console.WriteLine("Debut startRecording");
            inputer.Mouse.MoveMouseTo(65535 / 2.0, 65535 / 2.0);

            window.Hide();
            stopHotKey = hotkey;
            if (record_all) {
                mode = Mode.recordingAll;
            }
            else { 
                mode = Mode.recording;
                keepTime = keep_time;
                delayBetweenStrokes = delay; 
            }
            Console.WriteLine("Start recording : stop key " + hotkey + "( warp !" + (SystemInformation.VirtualScreen.Width / 2.0));
            //inputer.Mouse.MoveMouseTo(10,10);
            stopwatch.Start();
            //recordedEvents.Clear();
            window.grid_macro_event.Rows.Clear();
            //recordedEvents = new List<MacroEvent>();
            Console.WriteLine("Fin startRecording");
        }
        internal static void stopRecording()
        {
            Console.WriteLine("Debut stopRecording");
            stopHotKey = "";
            mode = Mode.none;
            stopwatch.Stop();
            Console.WriteLine("Stop recording !");
            window.Show();
            Console.WriteLine("Fin stopRecording");
        }
        internal static void startPlaying(string hotkey)
        {
            Console.WriteLine("Debut startPlaying");
            stopHotKey = hotkey;
            mode = Mode.playingUntil;
            //Console.WriteLine("Start playing : stop key " + hotkey + "( warp !" + (SystemInformation.VirtualScreen.Width / 2.0));
            window.Hide();
            while (mode == Mode.playingUntil)
            {
                
                playMacro();
                Console.WriteLine("mode : " + mode);
                
            }
            window.Show();
            stopHotKey = "";
            Console.WriteLine("Fin startPlaying");
        }

        internal static void playMacro(bool alreadyLoaded=false)
        {
            Console.WriteLine("Debut playMacro");
            POINT depart = posMouse;
            inputer.Mouse.MoveMouseTo(65535 / 2, 65535 / 2);
            double width = SystemInformation.VirtualScreen.Width;
            double height = SystemInformation.VirtualScreen.Height;
            if (!alreadyLoaded)
            {
                recordedEvents = new List<MacroEvent>();
                for (int i = 0; i < window.grid_macro_event.Rows.Count - 1; i++)
                {
                    long vsec = long.Parse((string)window.grid_macro_event.Rows[i].Cells[0].Value);
                    byte vtype = byte.Parse((string)window.grid_macro_event.Rows[i].Cells[2].Value);
                    int vParam1 = int.Parse((string)window.grid_macro_event.Rows[i].Cells[4].Value);
                    int vParam2 = int.Parse((string)window.grid_macro_event.Rows[i].Cells[5].Value);
                    recordedEvents.Add(new MacroEvent(vsec, (MacroEvent.EventType)vtype, vParam1, vParam2));
                }
            }
            for (int i = 0; i < recordedEvents.Count; i++)
            {
                System.Threading.Thread.Sleep((int)recordedEvents[i].Seconds);
                Console.WriteLine("Playing : " + recordedEvents[i].Seconds + ";" + recordedEvents[i].Type + ";" + recordedEvents[i].Param1 + ";" + recordedEvents[i].Param2);
                if(recordedEvents[i].Type == MacroEvent.EventType.keyDown)
                {
                    inputer.Keyboard.KeyDown((WindowsInput.Native.VirtualKeyCode)recordedEvents[i].Param1);
                }
                else if(recordedEvents[i].Type == MacroEvent.EventType.keyUp)
                {
                    inputer.Keyboard.KeyUp((WindowsInput.Native.VirtualKeyCode)recordedEvents[i].Param1);
                }
                else if(recordedEvents[i].Type == MacroEvent.EventType.wheel)
                {
                    inputer.Keyboard.Mouse.VerticalScroll(recordedEvents[i].Param1);
                }
                else
                {
                    double posX = (65535 * recordedEvents[i].Param1) / width;
                    double posY = (65535 * recordedEvents[i].Param2) / height;
                    inputer.Mouse.MoveMouseToPositionOnVirtualDesktop(posX, posY);
                    if (recordedEvents[i].Type == MacroEvent.EventType.lDown)
                    {
                        inputer.Mouse.LeftButtonDown();
                    }
                    else if(recordedEvents[i].Type == MacroEvent.EventType.lUp)
                    {
                        inputer.Mouse.LeftButtonUp();
                    }
                    else if (recordedEvents[i].Type == MacroEvent.EventType.rDown)
                    {
                        inputer.Mouse.RightButtonDown();
                    }
                    else if (recordedEvents[i].Type == MacroEvent.EventType.rUp)
                    {
                        inputer.Mouse.RightButtonUp();
                    }
                    
                }
            }
            double posrX = (65535 * depart.x) / width;
            double posrY = (65535 * depart.y) / height;
            inputer.Mouse.MoveMouseToPositionOnVirtualDesktop(posrX, posrY);
            Console.WriteLine("Fin playMacro");
        }

        internal static void listeningForHotkeys()
        {
            if (mode == Mode.none)
            {
                Console.WriteLine("Listening for hk");
                for (int i = 0; i < window.grid_hotkey.RowCount; i++)
                {
                    hotKeys.Add(new HotMacro((string)window.grid_hotkey.Rows[i].Cells[0].Value, (string)window.grid_hotkey.Rows[i].Cells[1].Value));
                }
                mode = Mode.listening;
                window.btn_start_listening.Text = "Stop";
            }
            else
            {
                Console.WriteLine("Stop Listening for hk");
                hotKeys.Clear();
                mode = Mode.none;
                window.btn_start_listening.Text = "Start";
            }
        }

        internal static void addHotkey(string hotkey, bool ctrlMd, bool shiftMd, bool altMd, string path)
        {

            string ligne = "";
            if (ctrlMd)
                ligne = "Ctrl+";
            if(shiftMd)
                ligne += "Shift+";
            if (altMd)
                ligne += "Alt+";
            ligne += hotkey;
            window.grid_hotkey.Rows.Add(ligne, path);
        }

        private static void RecordEvent(MacroEvent.EventType t, int p1, int p2)
        {
            Console.WriteLine("Debut RecordEvent");
            long sec = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            if (!keepTime && mode == Mode.recording)
            {
                sec = delayBetweenStrokes;
            }
            MacroEvent e = new MacroEvent(sec, t, p1, p2);
            //recordedEvents.Add(e);
            Console.WriteLine(e.ToString());
            window.grid_macro_event.Rows.Add(e.ToStrings());
            Console.WriteLine("Fin RecordEvent");
        }
        public static void LoadMacroFromFile(string path)
        {
            Console.WriteLine("Debut LoadMacroFromFile");
            BinaryReader br;
            try
            {
                FileStream inFile = new FileStream(path, FileMode.Open);
                br = new BinaryReader(inFile);
                try
                {
                    window.grid_macro_event.Rows.Clear();
                    //recordedEvents = new List<MacroEvent>();
                    while (inFile.Position != inFile.Length)
                    {
                        Console.WriteLine("LOADING...");
                        MacroEvent cur = new MacroEvent(br.ReadInt64(), (MacroEvent.EventType)br.ReadByte(), br.ReadInt32(), br.ReadInt32());
                        Console.WriteLine("LOADING2...");
                        //recordedEvents.Add(cur);
                        window.grid_macro_event.Rows.Add(cur.ToStrings());
                        Console.WriteLine("LOADING3...");

                    }
                    br.Close();
                }
                catch (IOException e)
                {
                    br.Close();
                    Console.WriteLine(e.Message + "\n Cannot read from file.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
            }
            Console.WriteLine("Fin LoadMacroFromFile");
        }
        public static void SaveMacroToFile(string path)
        {
            Console.WriteLine("Debut SaveMacroToFile");
            // save to file
            BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create));
            for (int i = 0; i < window.grid_macro_event.RowCount-1; ++i)
            {
                long vsec = long.Parse((string)window.grid_macro_event.Rows[i].Cells[0].Value);
                byte vtype = byte.Parse((string)window.grid_macro_event.Rows[i].Cells[2].Value);
                int vParam1 = int.Parse((string)window.grid_macro_event.Rows[i].Cells[4].Value);
                int vParam2 = int.Parse((string)window.grid_macro_event.Rows[i].Cells[5].Value);
                bw.Write(vsec);
                bw.Write(vtype);
                bw.Write(vParam1);
                bw.Write(vParam2);
            }
            bw.Close();
            Console.WriteLine("Fin SaveMacroToFile");
        }

        // EVENT EVERY 10 ms
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            posMouse.x = Cursor.Position.X;
            posMouse.y = Cursor.Position.Y;
            //Console.WriteLine(posMouse.x + ", " + posMouse.y);
            if(mode == Mode.recordingAll)
            {
                RecordEvent(MacroEvent.EventType.mouseMoved, posMouse.x, posMouse.y);
            }
            // Random r = new Random();
            //inputer.Mouse.LeftButtonDown();
            //inputer.Mouse.MoveMouseBy(ak47_recoil[compteurBalle].X, ak47_recoil[compteurBalle].Y + change);
         //   Console.WriteLine("Fin OnTimedEvent");
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //EVENT KEY UP
        public static void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("Debut gkh_KeyUp");
            //Console.WriteLine("Up\t" + e.KeyCode.ToString());
            if (mode == Mode.recording || mode == Mode.recordingAll)
            {
                RecordEvent(MacroEvent.EventType.keyUp,(int) e.KeyCode, (int)e.KeyCode);
            }
            else if(mode == Mode.listening)
            {
                Console.WriteLine("Mode Listening key up");
                if (e.KeyCode == Keys.LControlKey)
                    modKeys["Ctrl"] = false;
                else if (e.KeyCode == Keys.LShiftKey)
                    modKeys["Shift"] = false;
                else if (e.KeyCode == Keys.Alt)
                    modKeys["Alt"] = false;
                for (int i = 0; i < hotKeys.Count-1; i++)
                {
                    List<string> keysNeeded = new List<string>(hotKeys[i].hotkey.Split("+".ToCharArray()));
                    Console.WriteLine("Registered hot key:" + hotKeys[i].hotkey + "("+ keysNeeded[keysNeeded.Count - 1] + ")");
                    if (e.KeyCode.ToString() == keysNeeded[keysNeeded.Count - 1]) {
                        if(modKeys["Ctrl"] == keysNeeded.Contains("Ctrl") && modKeys["Shift"] == keysNeeded.Contains("Shift") && modKeys["Alt"] == keysNeeded.Contains("Alt"))
                        {
                            Console.WriteLine("Hotkey pressed !");
                            BackgroundWorker bw = new BackgroundWorker();
                            bw.DoWork += new DoWorkEventHandler(
                                delegate (object o, DoWorkEventArgs args)
                                {
                                    BackgroundWorker b = o as BackgroundWorker;
                                    string target = (string)args.Argument;
                                    Console.WriteLine("target : " + target);
                                    LoadMacroFromFileNoGUI(target);
                                    playMacro(true);
                                }
                            );
                            bw.RunWorkerAsync(hotKeys[i].target);
                        }
                    }
                }
                e.Handled = true;
            }
            e.Handled = false;
            //Console.WriteLine("Fin gkh_KeyUp");
        }
        private static void LoadMacroFromFileNoGUI(string path)
        {
            Console.WriteLine("Debut LoadMacroFromFileNOGUI");
            BinaryReader br;
            try
            {
                FileStream inFile = new FileStream(path, FileMode.Open);
                br = new BinaryReader(inFile);
                try
                {
                    //window.grid_macro_event.Rows.Clear();
                    recordedEvents = new List<MacroEvent>();
                    while (inFile.Position != inFile.Length)
                    {
                        Console.WriteLine("LOADING...");
                        MacroEvent cur = new MacroEvent(br.ReadInt64(), (MacroEvent.EventType)br.ReadByte(), br.ReadInt32(), br.ReadInt32());
                        Console.WriteLine("LOADING2...");
                        recordedEvents.Add(cur);
                        //window.grid_macro_event.Rows.Add(cur.ToStrings());
                        Console.WriteLine("LOADING3...");

                    }
                    br.Close();
                }
                catch (IOException e)
                {
                    br.Close();
                    Console.WriteLine(e.Message + "\n Cannot read from file.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message + "\n Cannot open file.");
            }
            Console.WriteLine("Fin LoadMacroFromFile");
        }

        //EVENT KEY DOWN
        public static void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            //eConsole.WriteLine("Debut gkh_KeyDown");
            if (e.KeyCode == Keys.LControlKey)
                modKeys["Ctrl"] = true;
            else if (e.KeyCode == Keys.LShiftKey)
                modKeys["Shift"] = true;
            else if (e.KeyCode == Keys.Alt)
                modKeys["Alt"] = true;
            Console.WriteLine("Down\t" + e.KeyCode.ToString());
            if (e.KeyCode.ToString() != stopHotKey && (mode == Mode.recording || mode == Mode.recordingAll))
            {
                RecordEvent(MacroEvent.EventType.keyDown, (int)e.KeyCode, (int)e.KeyCode);
            }
            else if (e.KeyCode.ToString() == stopHotKey && (mode == Mode.recording || mode == Mode.recordingAll))
            {
                stopRecording();
            }
            else if(e.KeyCode.ToString() == stopHotKey && mode == Mode.playingUntil)
            {
                Console.WriteLine("Stoppppp!!!");
                mode = Mode.none;
            }
            e.Handled = false;
            //Console.WriteLine("Fin gkh_KeyDown");
        }
        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        //MOUSE EVENTS
        private const int WH_MOUSE_LL = 14;
        

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }
        //MOUSE EVENTS HANDLE
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)

        {
            //Console.WriteLine("Debut HookCallback");
            MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
               // Console.WriteLine("Left down");
                if (mode == Mode.recording || mode == Mode.recordingAll)
                {
                    RecordEvent(MacroEvent.EventType.lDown, posMouse.x, posMouse.y);
                }
                //return (IntPtr)1;
                /* if (mode == 1)
                 {
                     setRecoil(true);
                     // return (IntPtr)1;
                 }*/
            }
            else if (nCode >= 0 && MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
            {
               // Console.WriteLine("Left up");
                if (mode == Mode.recording || mode == Mode.recordingAll)
                {
                    RecordEvent(MacroEvent.EventType.lUp, posMouse.x, posMouse.y);
                }
                //return (IntPtr)1;
                /* if (mode == 1)
                 {
                     setRecoil(false);
                     // return (IntPtr)1;
                 }*/
            }
            else if (nCode >= 0 && MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam)
            {
                //Console.WriteLine("right down");
                if (mode == Mode.recording || mode == Mode.recordingAll)
                {
                    RecordEvent(MacroEvent.EventType.rDown, posMouse.x, posMouse.y);
                }
                //return (IntPtr)1;
                /* if (mode == 1)
                 {
                     setRecoil(false);
                     // return (IntPtr)1;
                 }*/
            }
            else if (nCode >= 0 && MouseMessages.WM_RBUTTONUP == (MouseMessages)wParam)
            {
                //Console.WriteLine("right up");
                if (mode == Mode.recording || mode == Mode.recordingAll)
                {
                    RecordEvent(MacroEvent.EventType.rUp, posMouse.x, posMouse.y);
                }
                //return (IntPtr)1;
                /* if (mode == 1)
                 {
                     setRecoil(false);
                     // return (IntPtr)1;
                 }*/
            }
            else if (nCode >= 0 && MouseMessages.WM_MOUSEWHEEL == (MouseMessages)wParam)
            {
                uint temp = hookStruct.mouseData >> 16;
                short zDelta = (short)(temp & (0xFFFF));
                //Console.WriteLine("Mouse wheely:"+ zDelta);
                if (mode == Mode.recording || mode == Mode.recordingAll)
                {
                    RecordEvent(MacroEvent.EventType.wheel, zDelta, zDelta);
                }
                //return (IntPtr)1;
                /* if (mode == 1)
                 {
                     setRecoil(false);
                     // return (IntPtr)1;
                 }*/
            }
            /* else if (nCode >= 0 && MouseMessages.WM_MOUSEMOVE == (MouseMessages)wParam)
             {
                 Console.WriteLine("Mouse move:" + posMouse.x + "," + posMouse.y);
             }*/
            //Console.WriteLine("Fin HookCallback");
            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }



        [StructLayout(LayoutKind.Sequential)]

        private struct POINT

        {

            public int x;

            public int y;

        }

        [StructLayout(LayoutKind.Sequential)]

        private struct MSLLHOOKSTRUCT

        {

            public POINT pt;

            public uint mouseData;

            public uint flags;

            public uint time;

            public IntPtr dwExtraInfo;

        }
        private static IntPtr SetHook(LowLevelMouseProc proc)

        {
            Console.WriteLine("Debut SetHook");
            newKeyEventHandlerDown = new KeyEventHandler(gkh_KeyDown);
            newKeyEventHandlerUp = new KeyEventHandler(gkh_KeyUp);
            //gkh.HookedKeys.Add(Keys.N); //Faisait parti de l'ancienne appli pour hook que N
            gkh.KeyDown += newKeyEventHandlerDown;
            gkh.KeyUp += newKeyEventHandlerUp;
            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)

            {
                Console.WriteLine("Fin SetHook");
                return SetWindowsHookEx(WH_MOUSE_LL, proc,

                    GetModuleHandle(curModule.ModuleName), 0);

            }
            

        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int idHook,

            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr GetModuleHandle(string lpModuleName);

    }

}