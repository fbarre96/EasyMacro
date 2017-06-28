namespace WindowsFormsApplication1
{
    partial class EnterHotkey
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cb_ctrl = new System.Windows.Forms.CheckBox();
            this.cb_shift = new System.Windows.Forms.CheckBox();
            this.cb_alt = new System.Windows.Forms.CheckBox();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combo_htotkey = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.combo_action = new System.Windows.Forms.ComboBox();
            this.cb_play_until = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_ctrl
            // 
            this.cb_ctrl.AutoSize = true;
            this.cb_ctrl.Location = new System.Drawing.Point(17, 19);
            this.cb_ctrl.Name = "cb_ctrl";
            this.cb_ctrl.Size = new System.Drawing.Size(41, 17);
            this.cb_ctrl.TabIndex = 1;
            this.cb_ctrl.Text = "Ctrl";
            this.cb_ctrl.UseVisualStyleBackColor = true;
            // 
            // cb_shift
            // 
            this.cb_shift.AutoSize = true;
            this.cb_shift.Location = new System.Drawing.Point(114, 19);
            this.cb_shift.Name = "cb_shift";
            this.cb_shift.Size = new System.Drawing.Size(47, 17);
            this.cb_shift.TabIndex = 3;
            this.cb_shift.Text = "Shift";
            this.cb_shift.UseVisualStyleBackColor = true;
            // 
            // cb_alt
            // 
            this.cb_alt.AutoSize = true;
            this.cb_alt.Location = new System.Drawing.Point(70, 19);
            this.cb_alt.Name = "cb_alt";
            this.cb_alt.Size = new System.Drawing.Size(38, 17);
            this.cb_alt.TabIndex = 4;
            this.cb_alt.Text = "Alt";
            this.cb_alt.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(113, 203);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(85, 23);
            this.btn_ok.TabIndex = 5;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(12, 203);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(92, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_play_until);
            this.groupBox1.Controls.Add(this.combo_htotkey);
            this.groupBox1.Controls.Add(this.cb_alt);
            this.groupBox1.Controls.Add(this.cb_ctrl);
            this.groupBox1.Controls.Add(this.cb_shift);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 114);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hotkey Modifiers";
            // 
            // combo_htotkey
            // 
            this.combo_htotkey.FormattingEnabled = true;
            this.combo_htotkey.Items.AddRange(new object[] {
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12"});
            this.combo_htotkey.Location = new System.Drawing.Point(56, 42);
            this.combo_htotkey.Name = "combo_htotkey";
            this.combo_htotkey.Size = new System.Drawing.Size(52, 21);
            this.combo_htotkey.TabIndex = 9;
            this.combo_htotkey.Text = "F9";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.combo_action);
            this.groupBox2.Location = new System.Drawing.Point(25, 142);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(172, 55);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // combo_action
            // 
            this.combo_action.ForeColor = System.Drawing.Color.Black;
            this.combo_action.FormattingEnabled = true;
            this.combo_action.Items.AddRange(new object[] {
            "Target macro file",
            "Stop hotkey listening"});
            this.combo_action.Location = new System.Drawing.Point(6, 19);
            this.combo_action.Name = "combo_action";
            this.combo_action.Size = new System.Drawing.Size(160, 21);
            this.combo_action.TabIndex = 9;
            this.combo_action.Text = "Target macro file";
            this.combo_action.SelectedIndexChanged += new System.EventHandler(this.combo_action_SelectedIndexChanged);
            // 
            // cb_play_until
            // 
            this.cb_play_until.AutoSize = true;
            this.cb_play_until.Location = new System.Drawing.Point(42, 79);
            this.cb_play_until.Name = "cb_play_until";
            this.cb_play_until.Size = new System.Drawing.Size(79, 17);
            this.cb_play_until.TabIndex = 10;
            this.cb_play_until.Text = "Continuous";
            this.cb_play_until.UseVisualStyleBackColor = true;
            // 
            // EnterHotkey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 238);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Name = "EnterHotkey";
            this.Text = "Hotkey";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox cb_ctrl;
        private System.Windows.Forms.CheckBox cb_shift;
        private System.Windows.Forms.CheckBox cb_alt;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox combo_htotkey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox combo_action;
        private System.Windows.Forms.CheckBox cb_play_until;
    }
}