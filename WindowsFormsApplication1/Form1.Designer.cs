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
            this.SuspendLayout();
            // 
            // btn_record_macro
            // 
            this.btn_record_macro.Location = new System.Drawing.Point(281, 111);
            this.btn_record_macro.Name = "btn_record_macro";
            this.btn_record_macro.Size = new System.Drawing.Size(120, 23);
            this.btn_record_macro.TabIndex = 0;
            this.btn_record_macro.Text = "Start Record Macro";
            this.btn_record_macro.UseVisualStyleBackColor = true;
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
            this.combo_stop_hotkey.Select(8, 1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 135);
            this.Controls.Add(this.combo_stop_hotkey);
            this.Controls.Add(this.lbl_stop_hotkey);
            this.Controls.Add(this.btn_record_macro);
            this.Name = "Form1";
            this.Text = "Maqueraux";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_record_macro;
        private System.Windows.Forms.Label lbl_stop_hotkey;
        private System.Windows.Forms.ComboBox combo_stop_hotkey;
    }
}