namespace school_management_system_model.Forms.transactions.Collection
{
    partial class frm_fee_collection
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFeeBreakdown = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.tAmount = new System.Windows.Forms.TextBox();
            this.btnConfirmPayment = new Krypton.Toolkit.KryptonButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tSemester = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tYearLevel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tCourse = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tStudentName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tSearch = new Krypton.Toolkit.KryptonButton();
            this.tIdNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tPrint = new Krypton.Toolkit.KryptonButton();
            this.tParticulars = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tSchoolYear = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeBreakdown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Location = new System.Drawing.Point(12, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1297, 381);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statement of Account";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(6, 19);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 60;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(1285, 362);
            this.dgv.TabIndex = 157;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 24);
            this.label1.TabIndex = 158;
            this.label1.Text = "Fee Collection";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvFeeBreakdown);
            this.groupBox2.Location = new System.Drawing.Point(928, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 240);
            this.groupBox2.TabIndex = 159;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fee Breakdown";
            // 
            // dgvFeeBreakdown
            // 
            this.dgvFeeBreakdown.AllowUserToAddRows = false;
            this.dgvFeeBreakdown.AllowUserToDeleteRows = false;
            this.dgvFeeBreakdown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFeeBreakdown.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvFeeBreakdown.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeeBreakdown.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFeeBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeeBreakdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFeeBreakdown.Location = new System.Drawing.Point(3, 16);
            this.dgvFeeBreakdown.Name = "dgvFeeBreakdown";
            this.dgvFeeBreakdown.ReadOnly = true;
            this.dgvFeeBreakdown.RowHeadersVisible = false;
            this.dgvFeeBreakdown.RowHeadersWidth = 60;
            this.dgvFeeBreakdown.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFeeBreakdown.RowTemplate.Height = 30;
            this.dgvFeeBreakdown.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFeeBreakdown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeeBreakdown.Size = new System.Drawing.Size(369, 221);
            this.dgvFeeBreakdown.TabIndex = 158;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 20);
            this.label12.TabIndex = 170;
            this.label12.Text = "Amount:";
            // 
            // tAmount
            // 
            this.tAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAmount.Location = new System.Drawing.Point(128, 66);
            this.tAmount.Name = "tAmount";
            this.tAmount.Size = new System.Drawing.Size(320, 26);
            this.tAmount.TabIndex = 171;
            this.tAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.CornerRoundingRadius = 10F;
            this.btnConfirmPayment.Location = new System.Drawing.Point(124, 199);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(156, 38);
            this.btnConfirmPayment.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnConfirmPayment.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.btnConfirmPayment.StateCommon.Border.Color1 = System.Drawing.Color.DarkGreen;
            this.btnConfirmPayment.StateCommon.Border.Color2 = System.Drawing.Color.DarkGreen;
            this.btnConfirmPayment.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnConfirmPayment.StateCommon.Border.Rounding = 10F;
            this.btnConfirmPayment.StateCommon.Border.Width = 2;
            this.btnConfirmPayment.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmPayment.TabIndex = 172;
            this.btnConfirmPayment.Values.Text = "Confirm Payment";
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tStatus);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tSemester);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.tYearLevel);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tCourse);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.tStudentName);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.tSearch);
            this.groupBox3.Controls.Add(this.tIdNumber);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(520, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(402, 240);
            this.groupBox3.TabIndex = 173;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Student Information";
            // 
            // tSemester
            // 
            this.tSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSemester.Location = new System.Drawing.Point(128, 172);
            this.tSemester.Name = "tSemester";
            this.tSemester.Size = new System.Drawing.Size(268, 20);
            this.tSemester.TabIndex = 188;
            this.tSemester.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 187;
            this.label11.Text = "Semester:";
            // 
            // tYearLevel
            // 
            this.tYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tYearLevel.Location = new System.Drawing.Point(128, 133);
            this.tYearLevel.Name = "tYearLevel";
            this.tYearLevel.Size = new System.Drawing.Size(268, 20);
            this.tYearLevel.TabIndex = 186;
            this.tYearLevel.Text = "...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 20);
            this.label9.TabIndex = 185;
            this.label9.Text = "Year Level:";
            // 
            // tCourse
            // 
            this.tCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCourse.Location = new System.Drawing.Point(128, 95);
            this.tCourse.Name = "tCourse";
            this.tCourse.Size = new System.Drawing.Size(268, 20);
            this.tCourse.TabIndex = 184;
            this.tCourse.Text = "...";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 20);
            this.label18.TabIndex = 183;
            this.label18.Text = "Course:";
            // 
            // tStudentName
            // 
            this.tStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStudentName.Location = new System.Drawing.Point(128, 56);
            this.tStudentName.Name = "tStudentName";
            this.tStudentName.Size = new System.Drawing.Size(268, 20);
            this.tStudentName.TabIndex = 182;
            this.tStudentName.Text = "...";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(116, 20);
            this.label16.TabIndex = 181;
            this.label16.Text = "Student Name:";
            // 
            // tSearch
            // 
            this.tSearch.CornerRoundingRadius = 10F;
            this.tSearch.Location = new System.Drawing.Point(313, 19);
            this.tSearch.Name = "tSearch";
            this.tSearch.Size = new System.Drawing.Size(83, 26);
            this.tSearch.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.tSearch.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.tSearch.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.tSearch.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.tSearch.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tSearch.StateCommon.Border.Rounding = 10F;
            this.tSearch.StateCommon.Border.Width = 2;
            this.tSearch.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSearch.TabIndex = 180;
            this.tSearch.Values.Text = "Search";
            this.tSearch.Click += new System.EventHandler(this.tSearch_Click);
            // 
            // tIdNumber
            // 
            this.tIdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIdNumber.Location = new System.Drawing.Point(102, 19);
            this.tIdNumber.Name = "tIdNumber";
            this.tIdNumber.Size = new System.Drawing.Size(205, 26);
            this.tIdNumber.TabIndex = 179;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 20);
            this.label13.TabIndex = 174;
            this.label13.Text = "ID Number:";
            // 
            // tPrint
            // 
            this.tPrint.CornerRoundingRadius = 10F;
            this.tPrint.Location = new System.Drawing.Point(292, 199);
            this.tPrint.Name = "tPrint";
            this.tPrint.Size = new System.Drawing.Size(156, 38);
            this.tPrint.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.tPrint.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.tPrint.StateCommon.Border.Color1 = System.Drawing.Color.DarkBlue;
            this.tPrint.StateCommon.Border.Color2 = System.Drawing.Color.DarkBlue;
            this.tPrint.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.tPrint.StateCommon.Border.Rounding = 10F;
            this.tPrint.StateCommon.Border.Width = 2;
            this.tPrint.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPrint.TabIndex = 174;
            this.tPrint.Values.Text = "Print Receipt";
            // 
            // tParticulars
            // 
            this.tParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tParticulars.Location = new System.Drawing.Point(128, 98);
            this.tParticulars.Multiline = true;
            this.tParticulars.Name = "tParticulars";
            this.tParticulars.Size = new System.Drawing.Size(320, 95);
            this.tParticulars.TabIndex = 178;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(14, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 20);
            this.label15.TabIndex = 177;
            this.label15.Text = "Particulars:";
            // 
            // tSchoolYear
            // 
            this.tSchoolYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSchoolYear.FormattingEnabled = true;
            this.tSchoolYear.Location = new System.Drawing.Point(989, 12);
            this.tSchoolYear.Name = "tSchoolYear";
            this.tSchoolYear.Size = new System.Drawing.Size(320, 28);
            this.tSchoolYear.TabIndex = 180;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(869, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.TabIndex = 179;
            this.label7.Text = "School Year:";
            // 
            // tStatus
            // 
            this.tStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStatus.Location = new System.Drawing.Point(128, 217);
            this.tStatus.Name = "tStatus";
            this.tStatus.Size = new System.Drawing.Size(268, 20);
            this.tStatus.TabIndex = 190;
            this.tStatus.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 189;
            this.label3.Text = "Status:";
            // 
            // frm_fee_collection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 689);
            this.Controls.Add(this.tSchoolYear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tParticulars);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tPrint);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.tAmount);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_fee_collection";
            this.Text = "frm_fee_collection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_fee_collection_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeBreakdown)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tAmount;
        private Krypton.Toolkit.KryptonButton btnConfirmPayment;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private Krypton.Toolkit.KryptonButton tPrint;
        private System.Windows.Forms.TextBox tParticulars;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label tStudentName;
        private System.Windows.Forms.Label label16;
        private Krypton.Toolkit.KryptonButton tSearch;
        private System.Windows.Forms.TextBox tIdNumber;
        private System.Windows.Forms.Label tCourse;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox tSchoolYear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label tSemester;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label tYearLevel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvFeeBreakdown;
        private System.Windows.Forms.Label tStatus;
        private System.Windows.Forms.Label label3;
    }
}