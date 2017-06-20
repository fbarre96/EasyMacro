using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;

namespace WindowsFormsApplication1
{


    public partial class Form1 : Form
    {

        private bool continuerAHooker = true;
        InputSimulator inputer = new InputSimulator();
        private MouseHookListener m_mouseListener;

        // Subroutine for activating the hook
        public void Subscribe()
        {
            // Note: for an application hook, use the AppHooker class instead
            m_mouseListener = new MouseHookListener(new AppHooker());

            // The listener is not enabled by default
            m_mouseListener.Enabled = true;

            // Set the event handler
            // recommended to use the Extended handlers, which allow input suppression among other additional information
            m_mouseListener.MouseDownExt += MouseListener_MouseDownExt;
        }
        public void Unsubscribe()
        {
            m_mouseListener.Dispose();
        }
        private void MouseListener_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            // log the mouse click
            lbl_stop_hotkey.Text = (string.Format("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp));

            // uncommenting the following line with suppress a middle mouse button click
            // if (e.Buttons == MouseButtons.Middle) { e.Handled = true; }
        }
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Subscribe();
            while (continuerAHooker)
            {
                System.Threading.Thread.Sleep(50);
            }
            Unsubscribe();

        }

    }
}