﻿//namespace school_management_system_model.Forms.transactions
//{
//    partial class frm_student_accounts
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
//            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
//            this.label1 = new System.Windows.Forms.Label();
//            this.dgv = new System.Windows.Forms.DataGridView();
//            this.btnCreate = new Krypton.Toolkit.KryptonButton();
//            this.groupBox1 = new System.Windows.Forms.GroupBox();
//            this.label3 = new System.Windows.Forms.Label();
//            this.tSemester = new System.Windows.Forms.Label();
//            this.label2 = new System.Windows.Forms.Label();
//            this.tSchoolYear = new System.Windows.Forms.Label();
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.label4 = new System.Windows.Forms.Label();
//            this.tTotal = new System.Windows.Forms.Label();
//            this.timerTotal = new System.Windows.Forms.Timer(this.components);
//            this.groupBox3 = new System.Windows.Forms.GroupBox();
//            this.btnPrev = new System.Windows.Forms.Button();
//            this.btnNext = new System.Windows.Forms.Button();
//            this.tPageSize = new System.Windows.Forms.Label();
//            this.tSearch = new Krypton.Toolkit.KryptonTextBox();
//            this.btnApprove = new Krypton.Toolkit.KryptonButton();
//            this.btnReset = new Krypton.Toolkit.KryptonButton();
//            this.btnEnroll = new Krypton.Toolkit.KryptonButton();
//            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
//            this.btnCancelEnrollment = new Krypton.Toolkit.KryptonButton();
//            this.btnSYoptions = new Krypton.Toolkit.KryptonButton();
//            this.btnStudentDetails = new Krypton.Toolkit.KryptonButton();
//            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
//            this.groupBox1.SuspendLayout();
//            this.groupBox2.SuspendLayout();
//            this.groupBox3.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // label1
//            // 
//            this.label1.AutoSize = true;
//            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label1.Location = new System.Drawing.Point(12, 9);
//            this.label1.Name = "label1";
//            this.label1.Size = new System.Drawing.Size(158, 24);
//            this.label1.TabIndex = 103;
//            this.label1.Text = "Student Accounts";
//            // 
//            // dgv
//            // 
//            this.dgv.AllowUserToAddRows = false;
//            this.dgv.AllowUserToDeleteRows = false;
//            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
//            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
//            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
//            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
//            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
//            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
//            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
//            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
//            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
//            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
//            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
//            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
//            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
//            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
//            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
//            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
//            this.dgv.Location = new System.Drawing.Point(6, 60);
//            this.dgv.Name = "dgv";
//            this.dgv.ReadOnly = true;
//            this.dgv.RowHeadersVisible = false;
//            this.dgv.RowHeadersWidth = 60;
//            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.dgv.RowTemplate.Height = 30;
//            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
//            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgv.Size = new System.Drawing.Size(1258, 338);
//            this.dgv.TabIndex = 102;
//            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
//            // 
//            // btnCreate
//            // 
//            this.btnCreate.CornerRoundingRadius = 10F;
//            this.btnCreate.Location = new System.Drawing.Point(18, 90);
//            this.btnCreate.Name = "btnCreate";
//            this.btnCreate.Size = new System.Drawing.Size(154, 34);
//            this.btnCreate.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
//            this.btnCreate.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
//            this.btnCreate.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
//            this.btnCreate.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(50)))));
//            this.btnCreate.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
//            | Krypton.Toolkit.PaletteDrawBorders.Left) 
//            | Krypton.Toolkit.PaletteDrawBorders.Right)));
//            this.btnCreate.StateCommon.Border.Rounding = 10F;
//            this.btnCreate.StateCommon.Border.Width = 2;
//            this.btnCreate.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
//            this.btnCreate.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
//            this.btnCreate.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnCreate.TabIndex = 104;
//            this.btnCreate.Values.Text = "Create Account";
//            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
//            // 
//            // groupBox1
//            // 
//            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.groupBox1.Controls.Add(this.label3);
//            this.groupBox1.Controls.Add(this.tSemester);
//            this.groupBox1.Controls.Add(this.label2);
//            this.groupBox1.Controls.Add(this.tSchoolYear);
//            this.groupBox1.Location = new System.Drawing.Point(987, 12);
//            this.groupBox1.Name = "groupBox1";
//            this.groupBox1.Size = new System.Drawing.Size(251, 56);
//            this.groupBox1.TabIndex = 105;
//            this.groupBox1.TabStop = false;
//            this.groupBox1.Text = "School Year";
//            // 
//            // label3
//            // 
//            this.label3.AutoSize = true;
//            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label3.Location = new System.Drawing.Point(3, 17);
//            this.label3.Name = "label3";
//            this.label3.Size = new System.Drawing.Size(25, 15);
//            this.label3.TabIndex = 3;
//            this.label3.Text = "SY:";
//            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // tSemester
//            // 
//            this.tSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.tSemester.Location = new System.Drawing.Point(72, 32);
//            this.tSemester.Name = "tSemester";
//            this.tSemester.Size = new System.Drawing.Size(173, 16);
//            this.tSemester.TabIndex = 2;
//            this.tSemester.Text = "...";
//            this.tSemester.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label2.Location = new System.Drawing.Point(3, 32);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(63, 15);
//            this.label2.TabIndex = 1;
//            this.label2.Text = "Semester:";
//            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
//            // 
//            // tSchoolYear
//            // 
//            this.tSchoolYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.tSchoolYear.Location = new System.Drawing.Point(72, 16);
//            this.tSchoolYear.Name = "tSchoolYear";
//            this.tSchoolYear.Size = new System.Drawing.Size(173, 16);
//            this.tSchoolYear.TabIndex = 0;
//            this.tSchoolYear.Text = "...";
//            this.tSchoolYear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
//            this.groupBox2.Controls.Add(this.label4);
//            this.groupBox2.Controls.Add(this.tTotal);
//            this.groupBox2.Location = new System.Drawing.Point(1180, 569);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Size = new System.Drawing.Size(105, 39);
//            this.groupBox2.TabIndex = 106;
//            this.groupBox2.TabStop = false;
//            this.groupBox2.Text = "Total";
//            // 
//            // label4
//            // 
//            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.label4.Location = new System.Drawing.Point(3, 16);
//            this.label4.Name = "label4";
//            this.label4.Size = new System.Drawing.Size(99, 20);
//            this.label4.TabIndex = 1;
//            this.label4.Text = "0000";
//            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // tTotal
//            // 
//            this.tTotal.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.tTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.tTotal.Location = new System.Drawing.Point(3, 16);
//            this.tTotal.Name = "tTotal";
//            this.tTotal.Size = new System.Drawing.Size(99, 20);
//            this.tTotal.TabIndex = 0;
//            this.tTotal.Text = "0000";
//            this.tTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            // 
//            // timerTotal
//            // 
//            this.timerTotal.Enabled = true;
//            this.timerTotal.Tick += new System.EventHandler(this.timerTotal_Tick);
//            // 
//            // groupBox3
//            // 
//            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
//            | System.Windows.Forms.AnchorStyles.Left) 
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.groupBox3.Controls.Add(this.btnPrev);
//            this.groupBox3.Controls.Add(this.btnNext);
//            this.groupBox3.Controls.Add(this.tPageSize);
//            this.groupBox3.Controls.Add(this.tSearch);
//            this.groupBox3.Controls.Add(this.dgv);
//            this.groupBox3.Location = new System.Drawing.Point(12, 130);
//            this.groupBox3.Name = "groupBox3";
//            this.groupBox3.Size = new System.Drawing.Size(1270, 433);
//            this.groupBox3.TabIndex = 107;
//            this.groupBox3.TabStop = false;
//            this.groupBox3.Text = "Student Accounts";
//            // 
//            // btnPrev
//            // 
//            this.btnPrev.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnPrev.Location = new System.Drawing.Point(593, 407);
//            this.btnPrev.Name = "btnPrev";
//            this.btnPrev.Size = new System.Drawing.Size(26, 23);
//            this.btnPrev.TabIndex = 106;
//            this.btnPrev.Text = "<";
//            this.btnPrev.UseVisualStyleBackColor = true;
//            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
//            // 
//            // btnNext
//            // 
//            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnNext.Location = new System.Drawing.Point(646, 407);
//            this.btnNext.Name = "btnNext";
//            this.btnNext.Size = new System.Drawing.Size(26, 23);
//            this.btnNext.TabIndex = 105;
//            this.btnNext.Text = ">";
//            this.btnNext.UseVisualStyleBackColor = true;
//            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
//            // 
//            // tPageSize
//            // 
//            this.tPageSize.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
//            this.tPageSize.AutoSize = true;
//            this.tPageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.tPageSize.Location = new System.Drawing.Point(625, 410);
//            this.tPageSize.Name = "tPageSize";
//            this.tPageSize.Size = new System.Drawing.Size(15, 15);
//            this.tPageSize.TabIndex = 104;
//            this.tPageSize.Text = "1";
//            this.tPageSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
//            this.tPageSize.Click += new System.EventHandler(this.tPageSize_Click);
//            // 
//            // tSearch
//            // 
//            this.tSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.tSearch.CueHint.CueHintText = "Search...";
//            this.tSearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
//            this.tSearch.Location = new System.Drawing.Point(1002, 28);
//            this.tSearch.Name = "tSearch";
//            this.tSearch.Size = new System.Drawing.Size(262, 23);
//            this.tSearch.TabIndex = 103;
//            this.tSearch.TextChanged += new System.EventHandler(this.tSearch_TextChanged);
//            // 
//            // btnApprove
//            // 
//            this.btnApprove.CornerRoundingRadius = 10F;
//            this.btnApprove.Location = new System.Drawing.Point(178, 90);
//            this.btnApprove.Name = "btnApprove";
//            this.btnApprove.Size = new System.Drawing.Size(154, 34);
//            this.btnApprove.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
//            this.btnApprove.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
//            this.btnApprove.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
//            this.btnApprove.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
//            this.btnApprove.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
//            | Krypton.Toolkit.PaletteDrawBorders.Left) 
//            | Krypton.Toolkit.PaletteDrawBorders.Right)));
//            this.btnApprove.StateCommon.Border.Rounding = 10F;
//            this.btnApprove.StateCommon.Border.Width = 2;
//            this.btnApprove.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
//            this.btnApprove.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
//            this.btnApprove.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnApprove.TabIndex = 108;
//            this.btnApprove.Values.Text = "Approve";
//            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
//            // 
//            // btnReset
//            // 
//            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.btnReset.CornerRoundingRadius = 10F;
//            this.btnReset.Location = new System.Drawing.Point(1221, 90);
//            this.btnReset.Name = "btnReset";
//            this.btnReset.Size = new System.Drawing.Size(55, 34);
//            this.btnReset.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
//            this.btnReset.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
//            this.btnReset.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
//            this.btnReset.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
//            this.btnReset.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
//            | Krypton.Toolkit.PaletteDrawBorders.Left) 
//            | Krypton.Toolkit.PaletteDrawBorders.Right)));
//            this.btnReset.StateCommon.Border.Rounding = 10F;
//            this.btnReset.StateCommon.Border.Width = 2;
//            this.btnReset.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
//            this.btnReset.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
//            this.btnReset.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnReset.TabIndex = 109;
//            this.btnReset.Values.Text = "Reset";
//            this.btnReset.Click += new System.EventHandler(this.kryptonButton2_Click);
//            // 
//            // btnEnroll
//            // 
//            this.btnEnroll.CornerRoundingRadius = 10F;
//            this.btnEnroll.Location = new System.Drawing.Point(338, 90);
//            this.btnEnroll.Name = "btnEnroll";
//            this.btnEnroll.Size = new System.Drawing.Size(154, 34);
//            this.btnEnroll.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
//            this.btnEnroll.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
//            this.btnEnroll.StateCommon.Border.Color1 = System.Drawing.Color.DarkGoldenrod;
//            this.btnEnroll.StateCommon.Border.Color2 = System.Drawing.Color.DarkGoldenrod;
//            this.btnEnroll.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
//            | Krypton.Toolkit.PaletteDrawBorders.Left) 
//            | Krypton.Toolkit.PaletteDrawBorders.Right)));
//            this.btnEnroll.StateCommon.Border.Rounding = 10F;
//            this.btnEnroll.StateCommon.Border.Width = 2;
//            this.btnEnroll.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
//            this.btnEnroll.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
//            this.btnEnroll.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnEnroll.TabIndex = 110;
//            this.btnEnroll.Values.Text = "Enroll Student";
//            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
//            // 
//            // kryptonButton1
//            // 
//            this.kryptonButton1.CornerRoundingRadius = 10F;
//            this.kryptonButton1.Location = new System.Drawing.Point(658, 90);
//            this.kryptonButton1.Name = "kryptonButton1";
//            this.kryptonButton1.Size = new System.Drawing.Size(154, 34);
//            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
//            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
//            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.DarkGoldenrod;
//            this.kryptonButton1.StateCommon.Border.Color2 = System.Drawing.Color.DarkGoldenrod;
//            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
//            | Krypton.Toolkit.PaletteDrawBorders.Left) 
//            | Krypton.Toolkit.PaletteDrawBorders.Right)));
//            this.kryptonButton1.StateCommon.Border.Rounding = 10F;
//            this.kryptonButton1.StateCommon.Border.Width = 2;
//            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
//            this.kryptonButton1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
//            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.kryptonButton1.TabIndex = 111;
//            this.kryptonButton1.Values.Text = "View Subjects Enrolled";
//            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
//            // 
//            // btnCancelEnrollment
//            // 
//            this.btnCancelEnrollment.CornerRoundingRadius = 10F;
//            this.btnCancelEnrollment.Location = new System.Drawing.Point(818, 90);
//            this.btnCancelEnrollment.Name = "btnCancelEnrollment";
//            this.btnCancelEnrollment.Size = new System.Drawing.Size(154, 34);
//            this.btnCancelEnrollment.StateCommon.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
//            this.btnCancelEnrollment.StateCommon.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
//            this.btnCancelEnrollment.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
//            this.btnCancelEnrollment.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
//            this.btnCancelEnrollment.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
//            | Krypton.Toolkit.PaletteDrawBorders.Left) 
//            | Krypton.Toolkit.PaletteDrawBorders.Right)));
//            this.btnCancelEnrollment.StateCommon.Border.Rounding = 10F;
//            this.btnCancelEnrollment.StateCommon.Border.Width = 2;
//            this.btnCancelEnrollment.StateCommon.Content.ShortText.Color1 = System.Drawing.SystemColors.Control;
//            this.btnCancelEnrollment.StateCommon.Content.ShortText.Color2 = System.Drawing.SystemColors.Control;
//            this.btnCancelEnrollment.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnCancelEnrollment.TabIndex = 113;
//            this.btnCancelEnrollment.Values.Text = "Cancel Enrollment";
//            // 
//            // btnSYoptions
//            // 
//            this.btnSYoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.btnSYoptions.CornerRoundingRadius = 10F;
//            this.btnSYoptions.Location = new System.Drawing.Point(1241, 18);
//            this.btnSYoptions.Name = "btnSYoptions";
//            this.btnSYoptions.Size = new System.Drawing.Size(44, 50);
//            this.btnSYoptions.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
//            this.btnSYoptions.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
//            this.btnSYoptions.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
//            this.btnSYoptions.StateCommon.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
//            this.btnSYoptions.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
//            | Krypton.Toolkit.PaletteDrawBorders.Left) 
//            | Krypton.Toolkit.PaletteDrawBorders.Right)));
//            this.btnSYoptions.StateCommon.Border.Rounding = 10F;
//            this.btnSYoptions.StateCommon.Border.Width = 2;
//            this.btnSYoptions.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
//            this.btnSYoptions.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
//            this.btnSYoptions.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnSYoptions.TabIndex = 114;
//            this.btnSYoptions.Values.Text = "...";
//            this.btnSYoptions.Click += new System.EventHandler(this.btnSYoptions_Click);
//            // 
//            // btnStudentDetails
//            // 
//            this.btnStudentDetails.CornerRoundingRadius = 10F;
//            this.btnStudentDetails.Location = new System.Drawing.Point(498, 90);
//            this.btnStudentDetails.Name = "btnStudentDetails";
//            this.btnStudentDetails.Size = new System.Drawing.Size(154, 34);
//            this.btnStudentDetails.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
//            this.btnStudentDetails.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
//            this.btnStudentDetails.StateCommon.Border.Color1 = System.Drawing.Color.DarkGoldenrod;
//            this.btnStudentDetails.StateCommon.Border.Color2 = System.Drawing.Color.DarkGoldenrod;
//            this.btnStudentDetails.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
//            | Krypton.Toolkit.PaletteDrawBorders.Left) 
//            | Krypton.Toolkit.PaletteDrawBorders.Right)));
//            this.btnStudentDetails.StateCommon.Border.Rounding = 10F;
//            this.btnStudentDetails.StateCommon.Border.Width = 2;
//            this.btnStudentDetails.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
//            this.btnStudentDetails.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
//            this.btnStudentDetails.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnStudentDetails.TabIndex = 115;
//            this.btnStudentDetails.Values.Text = "Student Details";
//            this.btnStudentDetails.Click += new System.EventHandler(this.btnStudentDetails_Click);
//            // 
//            // frm_student_accounts
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(1297, 620);
//            this.Controls.Add(this.btnStudentDetails);
//            this.Controls.Add(this.btnSYoptions);
//            this.Controls.Add(this.btnCancelEnrollment);
//            this.Controls.Add(this.kryptonButton1);
//            this.Controls.Add(this.btnEnroll);
//            this.Controls.Add(this.btnReset);
//            this.Controls.Add(this.btnApprove);
//            this.Controls.Add(this.groupBox3);
//            this.Controls.Add(this.groupBox2);
//            this.Controls.Add(this.groupBox1);
//            this.Controls.Add(this.btnCreate);
//            this.Controls.Add(this.label1);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.KeyPreview = true;
//            this.Name = "frm_student_accounts";
//            this.Text = "frm_student_accounts";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.Load += new System.EventHandler(this.frm_student_accounts_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
//            this.groupBox1.ResumeLayout(false);
//            this.groupBox1.PerformLayout();
//            this.groupBox2.ResumeLayout(false);
//            this.groupBox3.ResumeLayout(false);
//            this.groupBox3.PerformLayout();
//            this.ResumeLayout(false);
//            this.PerformLayout();

//        }

//        #endregion

//        private System.Windows.Forms.Label label1;
//        private System.Windows.Forms.DataGridView dgv;
//        private Krypton.Toolkit.KryptonButton btnCreate;
//        private System.Windows.Forms.GroupBox groupBox1;
//        private System.Windows.Forms.Label tSchoolYear;
//        private System.Windows.Forms.GroupBox groupBox2;
//        private System.Windows.Forms.Label tTotal;
//        private System.Windows.Forms.Timer timerTotal;
//        private System.Windows.Forms.GroupBox groupBox3;
//        private Krypton.Toolkit.KryptonTextBox tSearch;
//        private Krypton.Toolkit.KryptonButton btnApprove;
//        private Krypton.Toolkit.KryptonButton btnReset;
//        private Krypton.Toolkit.KryptonButton btnEnroll;
//        private Krypton.Toolkit.KryptonButton kryptonButton1;
//        private Krypton.Toolkit.KryptonButton btnCancelEnrollment;
//        private Krypton.Toolkit.KryptonButton btnSYoptions;
//        private System.Windows.Forms.Label label2;
//        private System.Windows.Forms.Label tSemester;
//        private System.Windows.Forms.Label label3;
//        private System.Windows.Forms.Label label4;
//        private System.Windows.Forms.Label tPageSize;
//        private System.Windows.Forms.Button btnNext;
//        private System.Windows.Forms.Button btnPrev;
//        private Krypton.Toolkit.KryptonButton btnStudentDetails;
//    }
//}