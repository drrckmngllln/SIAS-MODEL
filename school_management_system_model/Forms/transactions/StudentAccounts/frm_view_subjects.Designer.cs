namespace school_management_system_model.Forms.transactions.StudentAccounts
{
    partial class frm_view_subjects
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnEnroll = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.tIdNumber = new System.Windows.Forms.Label();
            this.tSchoolYear = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv.Location = new System.Drawing.Point(12, 94);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 60;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(939, 411);
            this.dgv.TabIndex = 103;
            // 
            // btnEnroll
            // 
            this.btnEnroll.CornerRoundingRadius = 10F;
            this.btnEnroll.Location = new System.Drawing.Point(713, 511);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(116, 34);
            this.btnEnroll.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnEnroll.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.btnEnroll.StateCommon.Border.Color1 = System.Drawing.Color.DarkGoldenrod;
            this.btnEnroll.StateCommon.Border.Color2 = System.Drawing.Color.DarkGoldenrod;
            this.btnEnroll.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEnroll.StateCommon.Border.Rounding = 10F;
            this.btnEnroll.StateCommon.Border.Width = 2;
            this.btnEnroll.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnEnroll.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnEnroll.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnroll.TabIndex = 111;
            this.btnEnroll.Values.Text = "Add Subject";
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 10F;
            this.kryptonButton1.Location = new System.Drawing.Point(835, 511);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(116, 34);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kryptonButton1.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 10F;
            this.kryptonButton1.StateCommon.Border.Width = 2;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 112;
            this.kryptonButton1.Values.Text = "Close";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // tIdNumber
            // 
            this.tIdNumber.AutoSize = true;
            this.tIdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIdNumber.ForeColor = System.Drawing.SystemColors.Control;
            this.tIdNumber.Location = new System.Drawing.Point(12, 9);
            this.tIdNumber.Name = "tIdNumber";
            this.tIdNumber.Size = new System.Drawing.Size(111, 20);
            this.tIdNumber.TabIndex = 113;
            this.tIdNumber.Text = "0000-0-0000";
            // 
            // tSchoolYear
            // 
            this.tSchoolYear.FormattingEnabled = true;
            this.tSchoolYear.Location = new System.Drawing.Point(769, 67);
            this.tSchoolYear.Name = "tSchoolYear";
            this.tSchoolYear.Size = new System.Drawing.Size(182, 21);
            this.tSchoolYear.TabIndex = 104;
            this.tSchoolYear.SelectedIndexChanged += new System.EventHandler(this.tSchoolYear_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(695, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 105;
            this.label1.Text = "School Year:";
            // 
            // frm_view_subjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(963, 557);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tSchoolYear);
            this.Controls.Add(this.tIdNumber);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.btnEnroll);
            this.CornerRoundingRadius = 10F;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_view_subjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 10F;
            this.Text = "frm_view_subjects";
            this.Load += new System.EventHandler(this.frm_view_subjects_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private Krypton.Toolkit.KryptonButton btnEnroll;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private System.Windows.Forms.Label tIdNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tSchoolYear;
    }
}