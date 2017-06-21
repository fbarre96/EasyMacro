namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_record_macro = new System.Windows.Forms.Button();
            this.lbl_stop_hotkey = new System.Windows.Forms.Label();
            this.combo_stop_hotkey = new System.Windows.Forms.ComboBox();
            this.list_macro_event = new System.Windows.Forms.ListBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.cb_record_all = new System.Windows.Forms.CheckBox();
            this.cb_keep_time = new System.Windows.Forms.CheckBox();
            this.btn_quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_record_macro
            // 
            this.btn_record_macro.Location = new System.Drawing.Point(520, 215);
            this.btn_record_macro.Name = "btn_record_macro";
            this.btn_record_macro.Size = new System.Drawing.Size(120, 23);
            this.btn_record_macro.TabIndex = 0;
            this.btn_record_macro.Text = "Start Record Macro";
            this.btn_record_macro.UseVisualStyleBackColor = true;
            this.btn_record_macro.Click += new System.EventHandler(this.btn_record_macro_Click);
            // 
            // lbl_stop_hotkey
            // 
            this.lbl_stop_hotkey.AutoSize = true;
            this.lbl_stop_hotkey.Location = new System.Drawing.Point(12, 15);
            this.lbl_stop_hotkey.Name = "lbl_stop_hotkey";
            this.lbl_stop_hotkey.Size = new System.Drawing.Size(67, 13);
            this.lbl_stop_hotkey.TabIndex = 1;
            this.lbl_stop_hotkey.Text = "Stop HotKey";
            // 
            // combo_stop_hotkey
            // 
            this.combo_stop_hotkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combo_stop_hotkey.FormattingEnabled = true;
            this.combo_stop_hotkey.Items.AddRange(new object[] {
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
            this.combo_stop_hotkey.Location = new System.Drawing.Point(96, 12);
            this.combo_stop_hotkey.Name = "combo_stop_hotkey";
            this.combo_stop_hotkey.Size = new System.Drawing.Size(121, 21);
            this.combo_stop_hotkey.TabIndex = 2;
            // 
            // list_macro_event
            // 
            this.list_macro_event.Cursor = System.Windows.Forms.Cursors.Default;
            this.list_macro_event.FormattingEnabled = true;
            this.list_macro_event.Location = new System.Drawing.Point(15, 45);
            this.list_macro_event.Name = "list_macro_event";
            this.list_macro_event.Size = new System.Drawing.Size(499, 251);
            this.list_macro_event.TabIndex = 3;
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(520, 244);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(120, 23);
            this.btn_load.TabIndex = 4;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(520, 273);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(120, 23);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cb_record_all
            // 
            this.cb_record_all.AutoSize = true;
            this.cb_record_all.Location = new System.Drawing.Point(248, 14);
            this.cb_record_all.Name = "cb_record_all";
            this.cb_record_all.Size = new System.Drawing.Size(165, 17);
            this.cb_record_all.TabIndex = 6;
            this.cb_record_all.Text = "Record all mouse movements";
            this.cb_record_all.UseVisualStyleBackColor = true;
            this.cb_record_all.CheckedChanged += new System.EventHandler(this.cb_record_all_CheckedChanged);
            // 
            // cb_keep_time
            // 
            this.cb_keep_time.AutoSize = true;
            this.cb_keep_time.Location = new System.Drawing.Point(419, 16);
            this.cb_keep_time.Name = "cb_keep_time";
            this.cb_keep_time.Size = new System.Drawing.Size(73, 17);
            this.cb_keep_time.TabIndex = 7;
            this.cb_keep_time.Text = "Keep time";
            this.cb_keep_time.UseVisualStyleBackColor = true;
            // 
            // btn_quit
            // 
            this.btn_quit.Location = new System.Drawing.Point(527, 328);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(113, 23);
            this.btn_quit.TabIndex = 8;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 363);
            this.Controls.Add(this.btn_quit);
            this.Controls.Add(this.cb_keep_time);
            this.Controls.Add(this.cb_record_all);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.list_macro_event);
            this.Controls.Add(this.combo_stop_hotkey);
            this.Controls.Add(this.lbl_stop_hotkey);
            this.Controls.Add(this.btn_record_macro);
            this.Name = "Form1";
            this.Text = "EasyMacro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_record_macro;
        private System.Windows.Forms.Label lbl_stop_hotkey;
        private System.Windows.Forms.ComboBox combo_stop_hotkey;
        public System.Windows.Forms.ListBox list_macro_event;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.CheckBox cb_record_all;
        private System.Windows.Forms.CheckBox cb_keep_time;
        private System.Windows.Forms.Button btn_quit;
    }
}