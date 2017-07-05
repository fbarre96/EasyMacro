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

        public Form1(string arg = "")
        {
            
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 5; i < 201; i+=5)
            {
                this.combo_delay_strokes.Items.Add("" + i);
            }
            this.combo_delay_strokes.Text = "20";
            try
            {
                string[] lines = System.IO.File.ReadAllLines("RegHotkeys.cfg");
                foreach(string line in lines)
                {
                    if (line != "\n" && line != "")
                    {
                        string[] parts = line.Split('|');
                        bool continuous = (parts[2].Trim() == "True");
                        grid_hotkey.Rows.Add(parts[0].Trim(), parts[1].Trim(), continuous);
                    }
                }
                InterceptMouse.UpdateHotKeysFromView();
            }
            catch (System.IO.FileNotFoundException ex)
            {
                Console.WriteLine(ex);
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Dispose();
        }
        private void btn_record_macro_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Start recording");
            if (!this.combo_stop_hotkey.Text.StartsWith("F"))
            {
                MessageBox.Show("Select a hotkey to stop macro recording !", "EasyMacro", MessageBoxButtons.OK);
            }
            else {
                InterceptMouse.startRecording(this.combo_stop_hotkey.Text, this.cb_record_all.Checked, this.cb_keep_time.Checked, int.Parse(this.combo_delay_strokes.Text));
            }
        }

        private void cb_record_all_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_record_all.Checked)
            {
                this.cb_keep_time.Visible = false;
                this.lbl_delay_strokes.Visible = false;
                this.combo_delay_strokes.Visible = false;
            }else
            {
                this.cb_keep_time.Visible = true;
                this.lbl_delay_strokes.Visible = true;
                this.combo_delay_strokes.Visible = true;
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

        private void btn_play_macro_Click(object sender, EventArgs e)
        {
            this.Hide();
            InterceptMouse.playMacro();
            this.Show();
        }

        private void btn_play_macro_until_stop_Click(object sender, EventArgs e)
        {
            if (!this.combo_stop_hotkey.Text.StartsWith("F"))
            {
                MessageBox.Show("Select a hotkey to stop macro playing !", "EasyMacro", MessageBoxButtons.OK);
            }
            else
            {
                InterceptMouse.startPlaying(this.combo_stop_hotkey.Text);
            }
        }

        private void cb_keep_time_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_keep_time.Checked)
            {
                this.lbl_delay_strokes.Visible = false;
                this.combo_delay_strokes.Visible = false;
            }
            else
            {
                this.lbl_delay_strokes.Visible = true;
                this.combo_delay_strokes.Visible = true;
            }
        }

        private void btn_quit_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void btn_add_hotkey_Click(object sender, EventArgs e)
        {
            EnterHotkey dialog = new EnterHotkey();
            DialogResult val = dialog.ShowDialog();
            if (val == DialogResult.OK)
            {
                if (dialog.returnValue5.StartsWith("Target"))
                {
                    string path;
                    OpenFileDialog file = new OpenFileDialog();
                    file.Filter = "easy macro files (*.ema)|*.ema|All files (*.*)|*.*";
                    if (file.ShowDialog() == DialogResult.OK)
                    {
                        path = file.FileName;
                        InterceptMouse.addHotkey(dialog.returnValue1, dialog.returnValue2, dialog.returnValue3, dialog.returnValue4, path, dialog.returnValue6);
                    }
                }
                else
                {
                    InterceptMouse.addHotkey(dialog.returnValue1, dialog.returnValue2, dialog.returnValue3, dialog.returnValue4, "Stop", false);
                }
                

            }

        }

        private void btn_start_listening_Click(object sender, EventArgs e)
        {
            InterceptMouse.toogleListeningForHotkeys();
        }

    }
}