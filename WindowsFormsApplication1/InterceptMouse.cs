using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Utilities;
using WindowsInput;
using System.Timers;
using System.IO;

namespace WindowsFormsApplication1
{
    class InterceptMouse

    {
        public static InputSimulator inputer = new InputSimulator();
        private static LowLevelMouseProc _proc = HookCallback;
        private static POINT posMouse;
        private static IntPtr _hookID = IntPtr.Zero;
        private static globalKeyboardHook gkh = new globalKeyboardHook();
        private static string stopHotKey = "";
        
        public enum Mode { none , recording, recordingAll,
            playingUntil
        }
        private static Mode mode = Mode.none;
        private static Stopwatch stopwatch = new Stopwatch();
        private static List<MacroEvent> recordedEvents;
        private static Form1 window;
        private static bool keepTime;

        [STAThread]
        public static void Main()

        {
            string[] args = Environment.GetCommandLineArgs();
            /*Console.WriteLine("Commande: argc:"+args.Length);
            for(int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine(args[i]);
            }
            */
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

            UnhookWindowsHookEx(_hookID);

        }

        internal static void startRecording(string hotkey, bool record_all, bool keep_time)
        {
            inputer.Mouse.MoveMouseTo(65535 / 2.0, 65535 / 2.0);

            window.WindowState = FormWindowState.Minimized;
            stopHotKey = hotkey;
            if (record_all) {
                mode = Mode.recordingAll;
            }
            else { 
                mode = Mode.recording;
                keepTime = keep_time;
            }
            Console.WriteLine("Start recording : stop key " + hotkey + "( warp !" + (SystemInformation.VirtualScreen.Width / 2.0));
            //inputer.Mouse.MoveMouseTo(10,10);
            stopwatch.Start();
            //recordedEvents.Clear();
            window.grid_macro_event.Rows.Clear();
            recordedEvents = new List<MacroEvent>();

        }
        internal static void stopRecording()
        {
            stopHotKey = "";
            mode = Mode.none;
            stopwatch.Stop();
            Console.WriteLine("Stop recording !");
            window.WindowState = FormWindowState.Normal;

        }
        internal static void startPlaying(string hotkey)
        {
            stopHotKey = hotkey;
            mode = Mode.playingUntil;
            //Console.WriteLine("Start playing : stop key " + hotkey + "( warp !" + (SystemInformation.VirtualScreen.Width / 2.0));
            
            while (mode == Mode.playingUntil)
            {
                window.WindowState = FormWindowState.Minimized;
                playMacro();
                Console.WriteLine("mode : " + mode);
                window.WindowState = FormWindowState.Normal;
            }
        }

        internal static void playMacro()
        {
            
            inputer.Mouse.MoveMouseTo(65535 / 2, 65535 / 2);
            double width = SystemInformation.VirtualScreen.Width;
            double height = SystemInformation.VirtualScreen.Height;
            for (int i = 0; i < recordedEvents.Count; i++)
            {
                System.Threading.Thread.Sleep((int)recordedEvents[i].Seconds);
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
           
        }

        internal static void updateEvent(int rowIndex, int columnIndex)
        {
            if(recordedEvents != null)
                recordedEvents[rowIndex].Seconds = long.Parse((string) window.grid_macro_event.Rows[rowIndex].Cells[columnIndex].Value);
        }

        private static void RecordEvent(MacroEvent.EventType t, int p1, int p2)
        {
            long sec = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            stopwatch.Reset();
            stopwatch.Start();
            if (!keepTime)
            {
                sec = 50;
            }
            MacroEvent e = new MacroEvent(sec, t, p1, p2);
            recordedEvents.Add(e);
            Console.WriteLine(e.ToString());
            window.grid_macro_event.Rows.Add(e.ToStrings());
        }
        public static void LoadMacroFromFile(string path)
        {
            BinaryReader br;
            List<MacroEvent> ret = new List<MacroEvent>();
            try
            {
                br = new BinaryReader(new FileStream(path, FileMode.Open));
                try
                {
                    window.grid_macro_event.Rows.Clear();
                    recordedEvents = new List<MacroEvent>();
                    while (true)
                    {
                        MacroEvent cur = new MacroEvent(br.ReadInt64(), (MacroEvent.EventType)br.ReadByte(), br.ReadInt32(), br.ReadInt32());
                        recordedEvents.Add(cur);
                        window.grid_macro_event.Rows.Add(cur.ToStrings());
                    }
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
        }
        public static void SaveMacroToFile(string path)
        {
            // save to file
            BinaryWriter bw = new BinaryWriter(new FileStream(path, FileMode.Create));
            for (int i = 0; i < recordedEvents.Count; ++i)
            {
                MacroEvent cur = recordedEvents[i];
                bw.Write(cur.Seconds);
                bw.Write((byte)cur.Type);
                bw.Write((int)cur.Param1);
                bw.Write((int)cur.Param2);
            }
            bw.Close();
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

        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        //EVENT KEY UP
        public static void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("Up\t" + e.KeyCode.ToString());
            if (mode == Mode.recording || mode == Mode.recordingAll)
            {
                RecordEvent(MacroEvent.EventType.keyUp,(int) e.KeyCode, (int)e.KeyCode);
            }
            e.Handled = false;
        }
        //EVENT KEY DOWN
        public static void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("Down\t" + e.KeyCode.ToString());
            if (e.KeyCode.ToString() == stopHotKey && (mode == Mode.recording || mode == Mode.recordingAll))
            {
                stopRecording();
            }
            else if(e.KeyCode.ToString() == stopHotKey && mode == Mode.playingUntil)
            {
                Console.WriteLine("Stoppppp!!!");
                mode = Mode.none;
            }
            else if (mode == Mode.recording || mode == Mode.recordingAll)
            {
                RecordEvent(MacroEvent.EventType.keyDown, (int)e.KeyCode, (int)e.KeyCode);
            }
            e.Handled = false;
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
            //gkh.HookedKeys.Add(Keys.N); //Faisait parti de l'ancienne appli pour hook que N
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);
            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)

            {

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