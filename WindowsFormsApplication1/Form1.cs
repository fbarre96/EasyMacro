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

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btn_record_macro_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start recording");
            if (!this.combo_stop_hotkey.Text.StartsWith("F"))
            {
                MessageBox.Show("Select a hotkey to stop macro recording !", "EasyMacro", MessageBoxButtons.OK);
            }
            else {
                this.WindowState = FormWindowState.Minimized;
                InterceptMouse.startRecording(this.combo_stop_hotkey.Text);
            }
        }
    }
}