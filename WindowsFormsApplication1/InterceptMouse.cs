using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Utilities;
using WindowsInput;
using System.Timers;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class InterceptMouse

    {
        private static InputSimulator inputer = new InputSimulator();
        private static LowLevelMouseProc _proc = HookCallback;
        private static POINT posMouse;
        private static IntPtr _hookID = IntPtr.Zero;
        private static globalKeyboardHook gkh = new globalKeyboardHook();
        private static List<Point> points = new List<Point>();
        public static void Main()

        {
            points.Add(new Point(0,0));
            _hookID = SetHook(_proc);
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 10;
            aTimer.Enabled = true;
            
           
            Application.Run();

            UnhookWindowsHookEx(_hookID);

        }
        // EVENT EVERY 10 ms
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            posMouse.x = Cursor.Position.X;
            posMouse.y = Cursor.Position.Y;
                Random r = new Random();
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
            Console.WriteLine("Up\t" + e.KeyCode.ToString());  
            if(e.KeyCode.ToString() == "N")
            {
                //
            }
            if(e.KeyCode.ToString() == "F11")
            {
                //mode = -1;
            }
            e.Handled = false;
        }
        //EVENT KEY DOWN
        public static void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine("Down\t" + e.KeyCode.ToString());
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
            
            if(nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                if (mode == 1)
                {
                    setRecoil(true);
                    // return (IntPtr)1;
                }
            }
            else if(nCode >= 0 && MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
            {
                if(mode == 1)
                {
                    setRecoil(false);
                   // return (IntPtr)1;
                }
            }
            
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
            gkh.HookedKeys.Add(Keys.N);
            //Sgkh.HookedKeys.Add(Keys.Shift);
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
