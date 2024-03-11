namespace school_management_system_model.Forms.transactions.StudentEnrollment
{
    partial class frm_select_students
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
            this.panelTask = new System.Windows.Forms.Panel();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // panelTask
            // 
            this.panelTask.Location = new System.Drawing.Point(12, 12);
            this.panelTask.Name = "panelTask";
            this.panelTask.Size = new System.Drawing.Size(820, 434);
            this.panelTask.TabIndex = 0;
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.CornerRoundingRadius = 10F;
            this.kryptonButton4.Location = new System.Drawing.Point(366, 452);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(114, 41);
            this.kryptonButton4.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.kryptonButton4.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.kryptonButton4.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonButton4.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.kryptonButton4.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton4.StateCommon.Border.Rounding = 10F;
            this.kryptonButton4.StateCommon.Border.Width = 2;
            this.kryptonButton4.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton4.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonButton4.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton4.TabIndex = 99;
            this.kryptonButton4.Values.Text = "Select";
            this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
            // 
            // frm_select_students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 505);
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.panelTask);
            this.Name = "frm_select_students";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_select_student";
            this.Load += new System.EventHandler(this.frm_select_student_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTask;
        private Krypton.Toolkit.KryptonButton kryptonButton4;
    }
}