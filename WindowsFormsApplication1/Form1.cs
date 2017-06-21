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
                InterceptMouse.startRecording(this.combo_stop_hotkey.Text, this.cb_record_all.Checked, this.cb_keep_time.Checked);
            }
        }

        private void cb_record_all_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_record_all.Checked)
            {
                this.cb_keep_time.Visible = false;
            }else
            {
                this.cb_keep_time.Visible = true;
            }
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            string path;
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "easy macro files (*.ema)|*.ema|All files (*.*)|*.*";
            if (file.ShowDialog() == DialogResult.OK)
            {
                path = file.FileName;
                InterceptMouse.LoadMacroFromFile(path);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "easy macro files (*.ema)|*.ema|All files (*.*)|*.*";
            sf.AddExtension = true;
            // Feed the dummy name to the save dialog

            if (sf.ShowDialog() == DialogResult.OK)
            {
                // Now here's our save folder
                Console.WriteLine("Saving to : " + sf.FileName);
                InterceptMouse.SaveMacroToFile(sf.FileName);
                //string savePath = Path.GetDirectoryName(sf.FileName);
                // Do whatever
            }
        }
    }
}