namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    partial class frm_input_grade
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
            this.tTitle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tInsructor = new System.Windows.Forms.Label();
            this.tDescriptiveTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tGrade = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tRemarks = new System.Windows.Forms.Label();
            this.btnEnroll = new Krypton.Toolkit.KryptonButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tTitle
            // 
            this.tTitle.AutoSize = true;
            this.tTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.tTitle.Location = new System.Drawing.Point(12, 9);
            this.tTitle.Name = "tTitle";
            this.tTitle.Size = new System.Drawing.Size(111, 20);
            this.tTitle.TabIndex = 114;
            this.tTitle.Text = "0000-0-0000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tInsructor);
            this.groupBox1.Controls.Add(this.tDescriptiveTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Location = new System.Drawing.Point(16, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(639, 129);
            this.groupBox1.TabIndex = 115;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Subject Details";
            // 
            // tInsructor
            // 
            this.tInsructor.AutoSize = true;
            this.tInsructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tInsructor.ForeColor = System.Drawing.SystemColors.Control;
            this.tInsructor.Location = new System.Drawing.Point(160, 68);
            this.tInsructor.Name = "tInsructor";
            this.tInsructor.Size = new System.Drawing.Size(96, 15);
            this.tInsructor.TabIndex = 119;
            this.tInsructor.Text = "Descriptive Title:";
            // 
            // tDescriptiveTitle
            // 
            this.tDescriptiveTitle.AutoSize = true;
            this.tDescriptiveTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tDescriptiveTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.tDescriptiveTitle.Location = new System.Drawing.Point(160, 27);
            this.tDescriptiveTitle.Name = "tDescriptiveTitle";
            this.tDescriptiveTitle.Size = new System.Drawing.Size(96, 15);
            this.tDescriptiveTitle.TabIndex = 118;
            this.tDescriptiveTitle.Text = "Descriptive Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(11, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 117;
            this.label2.Text = "Instructor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 15);
            this.label1.TabIndex = 116;
            this.label1.Text = "Descriptive Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(205, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 20);
            this.label3.TabIndex = 120;
            this.label3.Text = "Grade:";
            // 
            // tGrade
            // 
            this.tGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tGrade.Location = new System.Drawing.Point(295, 175);
            this.tGrade.Name = "tGrade";
            this.tGrade.Size = new System.Drawing.Size(121, 29);
            this.tGrade.TabIndex = 121;
            this.tGrade.TextChanged += new System.EventHandler(this.tGrade_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(205, 241);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 122;
            this.label4.Text = "Remarks:";
            // 
            // tRemarks
            // 
            this.tRemarks.AutoSize = true;
            this.tRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRemarks.ForeColor = System.Drawing.SystemColors.Control;
            this.tRemarks.Location = new System.Drawing.Point(291, 241);
            this.tRemarks.Name = "tRemarks";
            this.tRemarks.Size = new System.Drawing.Size(68, 20);
            this.tRemarks.TabIndex = 123;
            this.tRemarks.Text = "Passed";
            // 
            // btnEnroll
            // 
            this.btnEnroll.CornerRoundingRadius = 10F;
            this.btnEnroll.Location = new System.Drawing.Point(539, 291);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(116, 34);
            this.btnEnroll.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnEnroll.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.btnEnroll.StateCommon.Border.Color1 = System.Drawing.Color.Green;
            this.btnEnroll.StateCommon.Border.Color2 = System.Drawing.Color.Green;
            this.btnEnroll.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEnroll.StateCommon.Border.Rounding = 10F;
            this.btnEnroll.StateCommon.Border.Width = 2;
            this.btnEnroll.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnEnroll.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnEnroll.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.TabIndex = 124;
            this.btnEnroll.Values.Text = "Confirm";
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // frm_input_grade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(667, 337);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.tRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tGrade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tTitle);
            this.CornerRoundingRadius = 10F;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_input_grade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 10F;
            this.Text = "frm_input_grade";
            this.Load += new System.EventHandler(this.frm_input_grade_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_input_grade_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tTitle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tInsructor;
        private System.Windows.Forms.Label tDescriptiveTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label tRemarks;
        private Krypton.Toolkit.KryptonButton btnEnroll;
    }
}