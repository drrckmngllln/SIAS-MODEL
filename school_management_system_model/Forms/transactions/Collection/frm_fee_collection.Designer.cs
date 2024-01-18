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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFeeBreakdown = new System.Windows.Forms.DataGridView();
            this.label12 = new System.Windows.Forms.Label();
            this.tAmount = new System.Windows.Forms.TextBox();
            this.btnConfirmPayment = new Krypton.Toolkit.KryptonButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tCampus = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tSemester = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tYearLevel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tCourse = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tStudentName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tIdNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tParticulars = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tSchoolYear = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cPayment = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tAmountPayable = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dgvAssessmentBreakdown = new System.Windows.Forms.DataGridView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnSet = new Krypton.Toolkit.KryptonButton();
            this.tOrNumberSet = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tOrNumber = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tTime = new System.Windows.Forms.Label();
            this.timerTime = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeBreakdown)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessmentBreakdown)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Location = new System.Drawing.Point(12, 105);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(943, 382);
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
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            this.dgv.Size = new System.Drawing.Size(931, 357);
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
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dgvFeeBreakdown);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(479, 496);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 361);
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
            this.dgvFeeBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeeBreakdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFeeBreakdown.Location = new System.Drawing.Point(3, 17);
            this.dgvFeeBreakdown.Name = "dgvFeeBreakdown";
            this.dgvFeeBreakdown.ReadOnly = true;
            this.dgvFeeBreakdown.RowHeadersVisible = false;
            this.dgvFeeBreakdown.RowHeadersWidth = 60;
            this.dgvFeeBreakdown.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFeeBreakdown.RowTemplate.Height = 30;
            this.dgvFeeBreakdown.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFeeBreakdown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeeBreakdown.Size = new System.Drawing.Size(470, 341);
            this.dgvFeeBreakdown.TabIndex = 158;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 15);
            this.label12.TabIndex = 170;
            this.label12.Text = "Amount:";
            // 
            // tAmount
            // 
            this.tAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAmount.Location = new System.Drawing.Point(91, 14);
            this.tAmount.Name = "tAmount";
            this.tAmount.Size = new System.Drawing.Size(248, 21);
            this.tAmount.TabIndex = 171;
            this.tAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.CornerRoundingRadius = 10F;
            this.btnConfirmPayment.Location = new System.Drawing.Point(119, 168);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(123, 38);
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
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tCampus);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.button1);
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
            this.groupBox3.Controls.Add(this.tIdNumber);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(961, 46);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 227);
            this.groupBox3.TabIndex = 173;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Student Information";
            // 
            // tCampus
            // 
            this.tCampus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCampus.Location = new System.Drawing.Point(128, 163);
            this.tCampus.Name = "tCampus";
            this.tCampus.Size = new System.Drawing.Size(210, 20);
            this.tCampus.TabIndex = 192;
            this.tCampus.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 191;
            this.label4.Text = "Campus:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 20);
            this.button1.TabIndex = 181;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tStatus
            // 
            this.tStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStatus.Location = new System.Drawing.Point(128, 193);
            this.tStatus.Name = "tStatus";
            this.tStatus.Size = new System.Drawing.Size(210, 20);
            this.tStatus.TabIndex = 190;
            this.tStatus.Text = "...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 189;
            this.label3.Text = "Status:";
            // 
            // tSemester
            // 
            this.tSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSemester.Location = new System.Drawing.Point(129, 130);
            this.tSemester.Name = "tSemester";
            this.tSemester.Size = new System.Drawing.Size(268, 20);
            this.tSemester.TabIndex = 188;
            this.tSemester.Text = "...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(7, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 15);
            this.label11.TabIndex = 187;
            this.label11.Text = "Semester:";
            // 
            // tYearLevel
            // 
            this.tYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tYearLevel.Location = new System.Drawing.Point(128, 106);
            this.tYearLevel.Name = "tYearLevel";
            this.tYearLevel.Size = new System.Drawing.Size(211, 20);
            this.tYearLevel.TabIndex = 186;
            this.tYearLevel.Text = "...";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 185;
            this.label9.Text = "Year Level:";
            // 
            // tCourse
            // 
            this.tCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCourse.Location = new System.Drawing.Point(128, 80);
            this.tCourse.Name = "tCourse";
            this.tCourse.Size = new System.Drawing.Size(211, 20);
            this.tCourse.TabIndex = 184;
            this.tCourse.Text = "...";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 15);
            this.label18.TabIndex = 183;
            this.label18.Text = "Course:";
            // 
            // tStudentName
            // 
            this.tStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStudentName.Location = new System.Drawing.Point(128, 56);
            this.tStudentName.Name = "tStudentName";
            this.tStudentName.Size = new System.Drawing.Size(268, 20);
            this.tStudentName.TabIndex = 182;
            this.tStudentName.Text = "...";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(6, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(89, 15);
            this.label16.TabIndex = 181;
            this.label16.Text = "Student Name:";
            // 
            // tIdNumber
            // 
            this.tIdNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIdNumber.Location = new System.Drawing.Point(102, 19);
            this.tIdNumber.Name = "tIdNumber";
            this.tIdNumber.Size = new System.Drawing.Size(205, 21);
            this.tIdNumber.TabIndex = 179;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 15);
            this.label13.TabIndex = 174;
            this.label13.Text = "ID Number:";
            // 
            // tParticulars
            // 
            this.tParticulars.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tParticulars.Location = new System.Drawing.Point(91, 93);
            this.tParticulars.Multiline = true;
            this.tParticulars.Name = "tParticulars";
            this.tParticulars.Size = new System.Drawing.Size(248, 69);
            this.tParticulars.TabIndex = 178;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 15);
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
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cPayment);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tAmountPayable);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.tAmount);
            this.groupBox4.Controls.Add(this.btnConfirmPayment);
            this.groupBox4.Controls.Add(this.tParticulars);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(961, 279);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(348, 224);
            this.groupBox4.TabIndex = 181;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Collect";
            // 
            // cPayment
            // 
            this.cPayment.AutoSize = true;
            this.cPayment.Location = new System.Drawing.Point(91, 41);
            this.cPayment.Name = "cPayment";
            this.cPayment.Size = new System.Drawing.Size(163, 19);
            this.cPayment.TabIndex = 181;
            this.cPayment.Text = "Collect all given amount?";
            this.cPayment.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 180;
            this.label2.Text = "Payable:";
            // 
            // tAmountPayable
            // 
            this.tAmountPayable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAmountPayable.Location = new System.Drawing.Point(91, 66);
            this.tAmountPayable.Name = "tAmountPayable";
            this.tAmountPayable.Size = new System.Drawing.Size(248, 21);
            this.tAmountPayable.TabIndex = 179;
            this.tAmountPayable.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.dgvAssessmentBreakdown);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(12, 493);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(461, 364);
            this.groupBox5.TabIndex = 182;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Assessment Breakdown";
            // 
            // dgvAssessmentBreakdown
            // 
            this.dgvAssessmentBreakdown.AllowUserToAddRows = false;
            this.dgvAssessmentBreakdown.AllowUserToDeleteRows = false;
            this.dgvAssessmentBreakdown.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAssessmentBreakdown.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvAssessmentBreakdown.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvAssessmentBreakdown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssessmentBreakdown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAssessmentBreakdown.Location = new System.Drawing.Point(3, 17);
            this.dgvAssessmentBreakdown.Name = "dgvAssessmentBreakdown";
            this.dgvAssessmentBreakdown.ReadOnly = true;
            this.dgvAssessmentBreakdown.RowHeadersVisible = false;
            this.dgvAssessmentBreakdown.RowHeadersWidth = 60;
            this.dgvAssessmentBreakdown.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvAssessmentBreakdown.RowTemplate.Height = 30;
            this.dgvAssessmentBreakdown.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAssessmentBreakdown.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssessmentBreakdown.Size = new System.Drawing.Size(455, 344);
            this.dgvAssessmentBreakdown.TabIndex = 158;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.btnSet);
            this.groupBox6.Controls.Add(this.tOrNumberSet);
            this.groupBox6.Location = new System.Drawing.Point(388, 46);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(293, 53);
            this.groupBox6.TabIndex = 183;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Set OR Number";
            // 
            // btnSet
            // 
            this.btnSet.CornerRoundingRadius = 10F;
            this.btnSet.Location = new System.Drawing.Point(230, 19);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(57, 21);
            this.btnSet.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSet.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.btnSet.StateCommon.Border.Color1 = System.Drawing.Color.DarkGreen;
            this.btnSet.StateCommon.Border.Color2 = System.Drawing.Color.DarkGreen;
            this.btnSet.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSet.StateCommon.Border.Rounding = 10F;
            this.btnSet.StateCommon.Border.Width = 2;
            this.btnSet.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSet.TabIndex = 194;
            this.btnSet.Values.Text = "Set";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // tOrNumberSet
            // 
            this.tOrNumberSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tOrNumberSet.Location = new System.Drawing.Point(6, 19);
            this.tOrNumberSet.Name = "tOrNumberSet";
            this.tOrNumberSet.Size = new System.Drawing.Size(218, 21);
            this.tOrNumberSet.TabIndex = 193;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.tOrNumber);
            this.groupBox7.Location = new System.Drawing.Point(687, 46);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(268, 53);
            this.groupBox7.TabIndex = 195;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "OR Number";
            // 
            // tOrNumber
            // 
            this.tOrNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tOrNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tOrNumber.Location = new System.Drawing.Point(3, 16);
            this.tOrNumber.Name = "tOrNumber";
            this.tOrNumber.Size = new System.Drawing.Size(262, 34);
            this.tOrNumber.TabIndex = 182;
            this.tOrNumber.Text = "...";
            this.tOrNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::school_management_system_model.Properties.Resources.Untitled_design;
            this.pictureBox1.Location = new System.Drawing.Point(961, 509);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 320);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 196;
            this.pictureBox1.TabStop = false;
            // 
            // tTime
            // 
            this.tTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTime.Location = new System.Drawing.Point(1006, 775);
            this.tTime.Name = "tTime";
            this.tTime.Size = new System.Drawing.Size(262, 54);
            this.tTime.TabIndex = 197;
            this.tTime.Text = "hh:mm:ss tt";
            this.tTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerTime
            // 
            this.timerTime.Enabled = true;
            this.timerTime.Tick += new System.EventHandler(this.timerTime_Tick);
            // 
            // frm_fee_collection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 869);
            this.Controls.Add(this.tTime);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.tSchoolYear);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox3);
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
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssessmentBreakdown)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.TextBox tParticulars;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label tStudentName;
        private System.Windows.Forms.Label label16;
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label tCampus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dgvAssessmentBreakdown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tAmountPayable;
        private System.Windows.Forms.CheckBox cPayment;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox tOrNumberSet;
        private Krypton.Toolkit.KryptonButton btnSet;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label tOrNumber;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label tTime;
        private System.Windows.Forms.Timer timerTime;
    }
}