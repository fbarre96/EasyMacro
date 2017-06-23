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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_record_all = new System.Windows.Forms.CheckBox();
            this.lbl_delay_strokes = new System.Windows.Forms.Label();
            this.btn_record_macro = new System.Windows.Forms.Button();
            this.combo_delay_strokes = new System.Windows.Forms.ComboBox();
            this.cb_keep_time = new System.Windows.Forms.CheckBox();
            this.btn_play_macro_until_stop = new System.Windows.Forms.Button();
            this.grid_macro_event = new System.Windows.Forms.DataGridView();
            this.btn_play_macro = new System.Windows.Forms.Button();
            this.combo_stop_hotkey = new System.Windows.Forms.ComboBox();
            this.lbl_stop_hotkey = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_start_listening = new System.Windows.Forms.Button();
            this.btn_add_hotkey = new System.Windows.Forms.Button();
            this.grid_hotkey = new System.Windows.Forms.DataGridView();
            this.Hotkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Macro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_quit = new System.Windows.Forms.Button();
            this.Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Event = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdParam1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdParam2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_macro_event)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_hotkey)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 346);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btn_play_macro_until_stop);
            this.tabPage1.Controls.Add(this.grid_macro_event);
            this.tabPage1.Controls.Add(this.btn_play_macro);
            this.tabPage1.Controls.Add(this.combo_stop_hotkey);
            this.tabPage1.Controls.Add(this.lbl_stop_hotkey);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(520, 320);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Macros";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_load);
            this.groupBox2.Controls.Add(this.btn_save);
            this.groupBox2.Location = new System.Drawing.Point(358, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 80);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Macro Files";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(14, 19);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(146, 23);
            this.btn_load.TabIndex = 16;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(12, 48);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(145, 23);
            this.btn_save.TabIndex = 17;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_record_all);
            this.groupBox1.Controls.Add(this.lbl_delay_strokes);
            this.groupBox1.Controls.Add(this.btn_record_macro);
            this.groupBox1.Controls.Add(this.combo_delay_strokes);
            this.groupBox1.Controls.Add(this.cb_keep_time);
            this.groupBox1.Location = new System.Drawing.Point(358, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 143);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record Macro";
            // 
            // cb_record_all
            // 
            this.cb_record_all.AutoSize = true;
            this.cb_record_all.Location = new System.Drawing.Point(6, 19);
            this.cb_record_all.Name = "cb_record_all";
            this.cb_record_all.Size = new System.Drawing.Size(165, 17);
            this.cb_record_all.TabIndex = 18;
            this.cb_record_all.Text = "Record all mouse movements";
            this.cb_record_all.UseVisualStyleBackColor = true;
            this.cb_record_all.CheckedChanged += new System.EventHandler(this.cb_record_all_CheckedChanged);
            // 
            // lbl_delay_strokes
            // 
            this.lbl_delay_strokes.AutoSize = true;
            this.lbl_delay_strokes.Location = new System.Drawing.Point(9, 62);
            this.lbl_delay_strokes.Name = "lbl_delay_strokes";
            this.lbl_delay_strokes.Size = new System.Drawing.Size(148, 13);
            this.lbl_delay_strokes.TabIndex = 25;
            this.lbl_delay_strokes.Text = "Delay between strokes (in ms)";
            // 
            // btn_record_macro
            // 
            this.btn_record_macro.Location = new System.Drawing.Point(9, 114);
            this.btn_record_macro.Name = "btn_record_macro";
            this.btn_record_macro.Size = new System.Drawing.Size(151, 23);
            this.btn_record_macro.TabIndex = 13;
            this.btn_record_macro.Text = "Start Record Macro";
            this.btn_record_macro.UseVisualStyleBackColor = true;
            this.btn_record_macro.Click += new System.EventHandler(this.btn_record_macro_Click);
            // 
            // combo_delay_strokes
            // 
            this.combo_delay_strokes.FormattingEnabled = true;
            this.combo_delay_strokes.Location = new System.Drawing.Point(9, 78);
            this.combo_delay_strokes.Name = "combo_delay_strokes";
            this.combo_delay_strokes.Size = new System.Drawing.Size(148, 21);
            this.combo_delay_strokes.TabIndex = 24;
            // 
            // cb_keep_time
            // 
            this.cb_keep_time.AutoSize = true;
            this.cb_keep_time.Location = new System.Drawing.Point(6, 42);
            this.cb_keep_time.Name = "cb_keep_time";
            this.cb_keep_time.Size = new System.Drawing.Size(73, 17);
            this.cb_keep_time.TabIndex = 19;
            this.cb_keep_time.Text = "Keep time";
            this.cb_keep_time.UseVisualStyleBackColor = true;
            this.cb_keep_time.CheckedChanged += new System.EventHandler(this.cb_keep_time_CheckedChanged);
            // 
            // btn_play_macro_until_stop
            // 
            this.btn_play_macro_until_stop.Location = new System.Drawing.Point(131, 296);
            this.btn_play_macro_until_stop.Name = "btn_play_macro_until_stop";
            this.btn_play_macro_until_stop.Size = new System.Drawing.Size(120, 23);
            this.btn_play_macro_until_stop.TabIndex = 23;
            this.btn_play_macro_until_stop.Text = "Play Macro Until Stop";
            this.btn_play_macro_until_stop.UseVisualStyleBackColor = true;
            this.btn_play_macro_until_stop.Click += new System.EventHandler(this.btn_play_macro_until_stop_Click);
            // 
            // grid_macro_event
            // 
            this.grid_macro_event.AllowUserToOrderColumns = true;
            this.grid_macro_event.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_macro_event.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Delay,
            this.Event,
            this.IdEvent,
            this.Info,
            this.IdParam1,
            this.IdParam2});
            this.grid_macro_event.Location = new System.Drawing.Point(6, 35);
            this.grid_macro_event.Name = "grid_macro_event";
            this.grid_macro_event.Size = new System.Drawing.Size(344, 255);
            this.grid_macro_event.TabIndex = 22;
            // 
            // btn_play_macro
            // 
            this.btn_play_macro.Location = new System.Drawing.Point(257, 296);
            this.btn_play_macro.Name = "btn_play_macro";
            this.btn_play_macro.Size = new System.Drawing.Size(95, 23);
            this.btn_play_macro.TabIndex = 21;
            this.btn_play_macro.Text = "Play Macro";
            this.btn_play_macro.UseVisualStyleBackColor = true;
            this.btn_play_macro.Click += new System.EventHandler(this.btn_play_macro_Click);
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
            this.combo_stop_hotkey.Location = new System.Drawing.Point(89, 6);
            this.combo_stop_hotkey.Name = "combo_stop_hotkey";
            this.combo_stop_hotkey.Size = new System.Drawing.Size(121, 21);
            this.combo_stop_hotkey.TabIndex = 15;
            // 
            // lbl_stop_hotkey
            // 
            this.lbl_stop_hotkey.AutoSize = true;
            this.lbl_stop_hotkey.Location = new System.Drawing.Point(5, 9);
            this.lbl_stop_hotkey.Name = "lbl_stop_hotkey";
            this.lbl_stop_hotkey.Size = new System.Drawing.Size(67, 13);
            this.lbl_stop_hotkey.TabIndex = 14;
            this.lbl_stop_hotkey.Text = "Stop HotKey";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_start_listening);
            this.tabPage2.Controls.Add(this.btn_add_hotkey);
            this.tabPage2.Controls.Add(this.grid_hotkey);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(520, 320);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Setup Hotkeys";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_start_listening
            // 
            this.btn_start_listening.Location = new System.Drawing.Point(439, 285);
            this.btn_start_listening.Name = "btn_start_listening";
            this.btn_start_listening.Size = new System.Drawing.Size(75, 23);
            this.btn_start_listening.TabIndex = 2;
            this.btn_start_listening.Text = "Start";
            this.btn_start_listening.UseVisualStyleBackColor = true;
            this.btn_start_listening.Click += new System.EventHandler(this.btn_start_listening_Click);
            // 
            // btn_add_hotkey
            // 
            this.btn_add_hotkey.Location = new System.Drawing.Point(439, 19);
            this.btn_add_hotkey.Name = "btn_add_hotkey";
            this.btn_add_hotkey.Size = new System.Drawing.Size(75, 23);
            this.btn_add_hotkey.TabIndex = 1;
            this.btn_add_hotkey.Text = "Add Hotkey";
            this.btn_add_hotkey.UseVisualStyleBackColor = true;
            this.btn_add_hotkey.Click += new System.EventHandler(this.btn_add_hotkey_Click);
            // 
            // grid_hotkey
            // 
            this.grid_hotkey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid_hotkey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hotkey,
            this.Macro});
            this.grid_hotkey.Location = new System.Drawing.Point(3, 0);
            this.grid_hotkey.Name = "grid_hotkey";
            this.grid_hotkey.Size = new System.Drawing.Size(430, 314);
            this.grid_hotkey.TabIndex = 0;
            // 
            // Hotkey
            // 
            this.Hotkey.HeaderText = "Hotkey";
            this.Hotkey.Name = "Hotkey";
            // 
            // Macro
            // 
            this.Macro.HeaderText = "Macro file";
            this.Macro.Name = "Macro";
            this.Macro.ReadOnly = true;
            this.Macro.Width = 285;
            // 
            // btn_quit
            // 
            this.btn_quit.Location = new System.Drawing.Point(415, 355);
            this.btn_quit.Name = "btn_quit";
            this.btn_quit.Size = new System.Drawing.Size(113, 23);
            this.btn_quit.TabIndex = 20;
            this.btn_quit.Text = "Quit";
            this.btn_quit.UseVisualStyleBackColor = true;
            this.btn_quit.Click += new System.EventHandler(this.btn_quit_Click_1);
            // 
            // Delay
            // 
            this.Delay.HeaderText = "Delay";
            this.Delay.Name = "Delay";
            // 
            // Event
            // 
            this.Event.HeaderText = "Event";
            this.Event.Name = "Event";
            this.Event.ReadOnly = true;
            // 
            // IdEvent
            // 
            this.IdEvent.HeaderText = "IdEvent";
            this.IdEvent.Name = "IdEvent";
            this.IdEvent.ReadOnly = true;
            this.IdEvent.Visible = false;
            // 
            // Info
            // 
            this.Info.HeaderText = "Info";
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            // 
            // IdParam1
            // 
            this.IdParam1.HeaderText = "IdParam1";
            this.IdParam1.Name = "IdParam1";
            this.IdParam1.ReadOnly = true;
            this.IdParam1.Visible = false;
            // 
            // IdParam2
            // 
            this.IdParam2.HeaderText = "IdParam2";
            this.IdParam2.Name = "IdParam2";
            this.IdParam2.ReadOnly = true;
            this.IdParam2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 385);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_quit);
            this.Name = "Form1";
            this.Text = "EasyMacro";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_macro_event)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid_hotkey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_play_macro_until_stop;
        public System.Windows.Forms.DataGridView grid_macro_event;
        private System.Windows.Forms.Button btn_play_macro;
        private System.Windows.Forms.CheckBox cb_keep_time;
        private System.Windows.Forms.CheckBox cb_record_all;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.ComboBox combo_stop_hotkey;
        private System.Windows.Forms.Label lbl_stop_hotkey;
        private System.Windows.Forms.Button btn_record_macro;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Label lbl_delay_strokes;
        private System.Windows.Forms.ComboBox combo_delay_strokes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.DataGridView grid_hotkey;
        private System.Windows.Forms.Button btn_add_hotkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hotkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Macro;
        public System.Windows.Forms.Button btn_start_listening;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delay;
        private System.Windows.Forms.DataGridViewTextBoxColumn Event;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdParam1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdParam2;
    }
}