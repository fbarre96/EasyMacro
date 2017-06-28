using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class EnterHotkey : Form
    {
        public string returnValue1;
        public bool returnValue2;
        public bool returnValue3;
        public bool returnValue4;
        public bool returnValue6;
        public string returnValue5;
        public EnterHotkey()
        {
            InitializeComponent();
        }


        private void btn_ok_Click(object sender, EventArgs e)
        {
            returnValue1 = combo_htotkey.Text;
            returnValue2 = cb_ctrl.Checked;
            returnValue3 = cb_shift.Checked;
            returnValue4 = cb_alt.Checked;
            returnValue5 = combo_action.Text;
            returnValue6 = cb_play_until.Checked;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void combo_action_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;

            // Save the selected employee's name, because we will remove
            // the employee's name from the list.
            string selectedEmployee = (string)combo_action.SelectedItem;
            if (selectedEmployee.StartsWith("Target"))
            {
                cb_play_until.Visible = true;
            }
            else
            {
                cb_play_until.Visible = false;
            }
        }
    }
}
