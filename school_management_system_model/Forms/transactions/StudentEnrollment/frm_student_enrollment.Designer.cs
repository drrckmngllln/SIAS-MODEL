namespace school_management_system_model.Forms.transactions
{
    partial class frm_student_enrollment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.kryptonButton4 = new Krypton.Toolkit.KryptonButton();
            this.label7 = new System.Windows.Forms.Label();
            this.tTotalUnits = new System.Windows.Forms.Label();
            this.tIdNumber = new System.Windows.Forms.TextBox();
            this.tYearLevel = new System.Windows.Forms.TextBox();
            this.tSemester = new System.Windows.Forms.TextBox();
            this.tCurriculum = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tStudentName = new System.Windows.Forms.Label();
            this.tLectureUnits = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tLabUnits = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.timerCounter = new System.Windows.Forms.Timer(this.components);
            this.tCampus = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tCourse = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tSection = new System.Windows.Forms.TextBox();
            this.tLoading = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Location = new System.Drawing.Point(494, 54);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 60;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(601, 549);
            this.dgv.TabIndex = 82;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 83;
            this.label1.Text = "ID Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 85;
            this.label2.Text = "Course:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(54, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 15);
            this.label3.TabIndex = 87;
            this.label3.Text = "Curriculum: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 89;
            this.label4.Text = "Year Level:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(54, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 91;
            this.label5.Text = "Section:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 15);
            this.label6.TabIndex = 94;
            this.label6.Text = "Semester:";
            // 
            // kryptonButton4
            // 
            this.kryptonButton4.CornerRoundingRadius = 10F;
            this.kryptonButton4.Location = new System.Drawing.Point(165, 353);
            this.kryptonButton4.Name = "kryptonButton4";
            this.kryptonButton4.Size = new System.Drawing.Size(159, 48);
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
            this.kryptonButton4.TabIndex = 98;
            this.kryptonButton4.Values.Text = "Enroll Subjects";
            this.kryptonButton4.Click += new System.EventHandler(this.kryptonButton4_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(491, 606);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 99;
            this.label7.Text = "Total Units:";
            // 
            // tTotalUnits
            // 
            this.tTotalUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tTotalUnits.AutoSize = true;
            this.tTotalUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTotalUnits.Location = new System.Drawing.Point(577, 606);
            this.tTotalUnits.Name = "tTotalUnits";
            this.tTotalUnits.Size = new System.Drawing.Size(23, 17);
            this.tTotalUnits.TabIndex = 100;
            this.tTotalUnits.Text = "...";
            // 
            // tIdNumber
            // 
            this.tIdNumber.Location = new System.Drawing.Point(174, 119);
            this.tIdNumber.Name = "tIdNumber";
            this.tIdNumber.Size = new System.Drawing.Size(225, 20);
            this.tIdNumber.TabIndex = 101;
            // 
            // tYearLevel
            // 
            this.tYearLevel.Location = new System.Drawing.Point(174, 145);
            this.tYearLevel.Name = "tYearLevel";
            this.tYearLevel.Size = new System.Drawing.Size(225, 20);
            this.tYearLevel.TabIndex = 102;
            this.tYearLevel.TextChanged += new System.EventHandler(this.tYearLevel_TextChanged);
            // 
            // tSemester
            // 
            this.tSemester.Location = new System.Drawing.Point(174, 249);
            this.tSemester.Name = "tSemester";
            this.tSemester.Size = new System.Drawing.Size(225, 20);
            this.tSemester.TabIndex = 106;
            this.tSemester.TextChanged += new System.EventHandler(this.tSemester_TextChanged);
            // 
            // tCurriculum
            // 
            this.tCurriculum.FormattingEnabled = true;
            this.tCurriculum.Location = new System.Drawing.Point(174, 223);
            this.tCurriculum.Name = "tCurriculum";
            this.tCurriculum.Size = new System.Drawing.Size(225, 21);
            this.tCurriculum.TabIndex = 107;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tStudentName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 70);
            this.groupBox1.TabIndex = 110;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Student Name";
            // 
            // tStudentName
            // 
            this.tStudentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tStudentName.Location = new System.Drawing.Point(3, 19);
            this.tStudentName.Name = "tStudentName";
            this.tStudentName.Size = new System.Drawing.Size(461, 48);
            this.tStudentName.TabIndex = 0;
            this.tStudentName.Text = "Student Name";
            // 
            // tLectureUnits
            // 
            this.tLectureUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tLectureUnits.AutoSize = true;
            this.tLectureUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLectureUnits.Location = new System.Drawing.Point(733, 606);
            this.tLectureUnits.Name = "tLectureUnits";
            this.tLectureUnits.Size = new System.Drawing.Size(23, 17);
            this.tLectureUnits.TabIndex = 112;
            this.tLectureUnits.Text = "...";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(635, 606);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 17);
            this.label9.TabIndex = 111;
            this.label9.Text = "Lecture Units";
            // 
            // tLabUnits
            // 
            this.tLabUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tLabUnits.AutoSize = true;
            this.tLabUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLabUnits.Location = new System.Drawing.Point(861, 606);
            this.tLabUnits.Name = "tLabUnits";
            this.tLabUnits.Size = new System.Drawing.Size(23, 17);
            this.tLabUnits.TabIndex = 114;
            this.tLabUnits.Text = "...";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(783, 606);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 113;
            this.label11.Text = "Lab Units:";
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 10F;
            this.kryptonButton1.Location = new System.Drawing.Point(494, 10);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(104, 38);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(25)))), ((int)(((byte)(0)))));
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 10F;
            this.kryptonButton1.StateCommon.Border.Width = 2;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 115;
            this.kryptonButton1.Values.Text = "Add Subject";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click_1);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.CornerRoundingRadius = 10F;
            this.kryptonButton2.Location = new System.Drawing.Point(604, 10);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(104, 38);
            this.kryptonButton2.StateCommon.Back.Color1 = System.Drawing.Color.White;
            this.kryptonButton2.StateCommon.Back.Color2 = System.Drawing.Color.White;
            this.kryptonButton2.StateCommon.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(25)))), ((int)(((byte)(0)))));
            this.kryptonButton2.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton2.StateCommon.Border.Rounding = 10F;
            this.kryptonButton2.StateCommon.Border.Width = 2;
            this.kryptonButton2.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.kryptonButton2.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton2.TabIndex = 116;
            this.kryptonButton2.Values.Text = "Remove Subject";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // timerCounter
            // 
            this.timerCounter.Enabled = true;
            this.timerCounter.Tick += new System.EventHandler(this.timerCounter_Tick);
            // 
            // tCampus
            // 
            this.tCampus.Location = new System.Drawing.Point(174, 197);
            this.tCampus.Name = "tCampus";
            this.tCampus.Size = new System.Drawing.Size(225, 20);
            this.tCampus.TabIndex = 118;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(54, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 15);
            this.label8.TabIndex = 117;
            this.label8.Text = "Campus";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(405, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 19);
            this.button1.TabIndex = 119;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tCourse
            // 
            this.tCourse.Location = new System.Drawing.Point(174, 170);
            this.tCourse.Name = "tCourse";
            this.tCourse.Size = new System.Drawing.Size(225, 20);
            this.tCourse.TabIndex = 120;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(405, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 19);
            this.button2.TabIndex = 121;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tSection
            // 
            this.tSection.Location = new System.Drawing.Point(174, 275);
            this.tSection.Name = "tSection";
            this.tSection.Size = new System.Drawing.Size(225, 20);
            this.tSection.TabIndex = 122;
            // 
            // tLoading
            // 
            this.tLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tLoading.AutoSize = true;
            this.tLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLoading.Location = new System.Drawing.Point(763, 303);
            this.tLoading.Name = "tLoading";
            this.tLoading.Size = new System.Drawing.Size(132, 20);
            this.tLoading.TabIndex = 123;
            this.tLoading.Text = "Loading Data...";
            this.tLoading.Visible = false;
            // 
            // frm_student_enrollment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 632);
            this.Controls.Add(this.tLoading);
            this.Controls.Add(this.tSection);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tCourse);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tCampus);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.tLabUnits);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tLectureUnits);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tCurriculum);
            this.Controls.Add(this.tSemester);
            this.Controls.Add(this.tYearLevel);
            this.Controls.Add(this.tIdNumber);
            this.Controls.Add(this.tTotalUnits);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.kryptonButton4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.CornerRoundingRadius = 10F;
            this.Name = "frm_student_enrollment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateActive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateActive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Header.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Header.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateActive.Header.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateActive.Header.Content.ShortText.Color1 = System.Drawing.SystemColors.Control;
            this.StateActive.Header.Content.ShortText.Color2 = System.Drawing.SystemColors.Control;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 10F;
            this.StateInactive.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateInactive.Header.Back.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Header.Back.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Header.Border.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Header.Border.Color2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.StateInactive.Header.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.Text = "frm_student_enrollment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_student_enrollment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Krypton.Toolkit.KryptonButton kryptonButton4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label tTotalUnits;
        private System.Windows.Forms.TextBox tIdNumber;
        private System.Windows.Forms.TextBox tYearLevel;
        private System.Windows.Forms.TextBox tSemester;
        private System.Windows.Forms.ComboBox tCurriculum;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label tStudentName;
        private System.Windows.Forms.Label tLectureUnits;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label tLabUnits;
        private System.Windows.Forms.Label label11;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private System.Windows.Forms.Timer timerCounter;
        private System.Windows.Forms.TextBox tCampus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tCourse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tSection;
        private System.Windows.Forms.Label tLoading;
    }
}