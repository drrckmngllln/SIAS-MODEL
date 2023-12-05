namespace school_management_system_model.Forms.transactions
{
    partial class frm_student_application
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsearch = new Krypton.Toolkit.KryptonTextBox();
            this.btn_save = new Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btnView = new Krypton.Toolkit.KryptonButton();
            this.btnEdit = new Krypton.Toolkit.KryptonButton();
            this.tIDNumber = new Krypton.Toolkit.KryptonTextBox();
            this.tlastname = new Krypton.Toolkit.KryptonTextBox();
            this.tfirstname = new Krypton.Toolkit.KryptonTextBox();
            this.tmiddlename = new Krypton.Toolkit.KryptonTextBox();
            this.tdateofbirth = new Krypton.Toolkit.KryptonTextBox();
            this.tplaceofbirth = new Krypton.Toolkit.KryptonTextBox();
            this.tnationality = new Krypton.Toolkit.KryptonTextBox();
            this.treligion = new Krypton.Toolkit.KryptonTextBox();
            this.tsemester = new Krypton.Toolkit.KryptonComboBox();
            this.tgender = new Krypton.Toolkit.KryptonComboBox();
            this.tcivilstatus = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonDateTimePicker1 = new Krypton.Toolkit.KryptonDateTimePicker();
            this.tstatus = new Krypton.Toolkit.KryptonTextBox();
            this.btnEnrol = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton2 = new Krypton.Toolkit.KryptonButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tinfoStatus = new System.Windows.Forms.Label();
            this.btnAssessment = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsemester)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcivilstatus)).BeginInit();
            this.SuspendLayout();
            // 
            // tsearch
            // 
            this.tsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsearch.CueHint.CueHintText = "Search...";
            this.tsearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tsearch.Location = new System.Drawing.Point(991, 82);
            this.tsearch.Name = "tsearch";
            this.tsearch.Size = new System.Drawing.Size(258, 23);
            this.tsearch.TabIndex = 83;
            this.tsearch.TextChanged += new System.EventHandler(this.tsearch_TextChanged);
            // 
            // btn_save
            // 
            this.btn_save.CornerRoundingRadius = 15F;
            this.btn_save.Location = new System.Drawing.Point(67, 481);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(133, 34);
            this.btn_save.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_save.StateCommon.Border.Rounding = 15F;
            this.btn_save.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.TabIndex = 78;
            this.btn_save.Values.Text = "Create Account";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 24);
            this.label1.TabIndex = 82;
            this.label1.Text = "Student Accounts";
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
            this.dgv.Location = new System.Drawing.Point(472, 111);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 60;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(777, 665);
            this.dgv.TabIndex = 81;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // btnView
            // 
            this.btnView.CornerRoundingRadius = 15F;
            this.btnView.Location = new System.Drawing.Point(67, 521);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(133, 34);
            this.btnView.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnView.StateCommon.Border.Rounding = 15F;
            this.btnView.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.TabIndex = 84;
            this.btnView.Values.Text = "Approve Account";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.CornerRoundingRadius = 15F;
            this.btnEdit.Location = new System.Drawing.Point(217, 481);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(133, 34);
            this.btnEdit.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEdit.StateCommon.Border.Rounding = 15F;
            this.btnEdit.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.TabIndex = 85;
            this.btnEdit.Values.Text = "New Account";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tIDNumber
            // 
            this.tIDNumber.CueHint.CueHintText = "ID Number";
            this.tIDNumber.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tIDNumber.Enabled = false;
            this.tIDNumber.Location = new System.Drawing.Point(53, 138);
            this.tIDNumber.Name = "tIDNumber";
            this.tIDNumber.Size = new System.Drawing.Size(351, 23);
            this.tIDNumber.TabIndex = 86;
            // 
            // tlastname
            // 
            this.tlastname.CueHint.CueHintText = "Last Name";
            this.tlastname.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tlastname.Location = new System.Drawing.Point(53, 167);
            this.tlastname.Name = "tlastname";
            this.tlastname.Size = new System.Drawing.Size(351, 23);
            this.tlastname.TabIndex = 87;
            // 
            // tfirstname
            // 
            this.tfirstname.CueHint.CueHintText = "First Name";
            this.tfirstname.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tfirstname.Location = new System.Drawing.Point(53, 196);
            this.tfirstname.Name = "tfirstname";
            this.tfirstname.Size = new System.Drawing.Size(351, 23);
            this.tfirstname.TabIndex = 88;
            // 
            // tmiddlename
            // 
            this.tmiddlename.CueHint.CueHintText = "Middle Name";
            this.tmiddlename.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tmiddlename.Location = new System.Drawing.Point(53, 225);
            this.tmiddlename.Name = "tmiddlename";
            this.tmiddlename.Size = new System.Drawing.Size(351, 23);
            this.tmiddlename.TabIndex = 89;
            // 
            // tdateofbirth
            // 
            this.tdateofbirth.CueHint.CueHintText = "Date of Birth";
            this.tdateofbirth.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tdateofbirth.Location = new System.Drawing.Point(53, 308);
            this.tdateofbirth.Name = "tdateofbirth";
            this.tdateofbirth.Size = new System.Drawing.Size(319, 23);
            this.tdateofbirth.TabIndex = 92;
            // 
            // tplaceofbirth
            // 
            this.tplaceofbirth.CueHint.CueHintText = "Place of Birth";
            this.tplaceofbirth.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tplaceofbirth.Location = new System.Drawing.Point(53, 335);
            this.tplaceofbirth.Name = "tplaceofbirth";
            this.tplaceofbirth.Size = new System.Drawing.Size(351, 23);
            this.tplaceofbirth.TabIndex = 93;
            // 
            // tnationality
            // 
            this.tnationality.CueHint.CueHintText = "Nationality";
            this.tnationality.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tnationality.Location = new System.Drawing.Point(53, 364);
            this.tnationality.Name = "tnationality";
            this.tnationality.Size = new System.Drawing.Size(351, 23);
            this.tnationality.TabIndex = 94;
            // 
            // treligion
            // 
            this.treligion.CueHint.CueHintText = "Religion";
            this.treligion.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.treligion.Location = new System.Drawing.Point(53, 393);
            this.treligion.Name = "treligion";
            this.treligion.Size = new System.Drawing.Size(351, 23);
            this.treligion.TabIndex = 95;
            // 
            // tsemester
            // 
            this.tsemester.CornerRoundingRadius = -1F;
            this.tsemester.CueHint.CueHintText = "Select Semester";
            this.tsemester.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tsemester.DropDownWidth = 229;
            this.tsemester.IntegralHeight = false;
            this.tsemester.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.tsemester.Location = new System.Drawing.Point(53, 111);
            this.tsemester.Name = "tsemester";
            this.tsemester.Size = new System.Drawing.Size(229, 21);
            this.tsemester.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tsemester.TabIndex = 97;
            this.tsemester.SelectedIndexChanged += new System.EventHandler(this.tsemester_SelectedIndexChanged);
            // 
            // tgender
            // 
            this.tgender.CornerRoundingRadius = -1F;
            this.tgender.CueHint.CueHintText = "Gender";
            this.tgender.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tgender.DropDownWidth = 229;
            this.tgender.IntegralHeight = false;
            this.tgender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.tgender.Location = new System.Drawing.Point(53, 254);
            this.tgender.Name = "tgender";
            this.tgender.Size = new System.Drawing.Size(229, 21);
            this.tgender.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tgender.TabIndex = 98;
            // 
            // tcivilstatus
            // 
            this.tcivilstatus.CornerRoundingRadius = -1F;
            this.tcivilstatus.CueHint.CueHintText = "Civil Status";
            this.tcivilstatus.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tcivilstatus.DropDownWidth = 229;
            this.tcivilstatus.IntegralHeight = false;
            this.tcivilstatus.Items.AddRange(new object[] {
            "Single",
            "Married",
            "Widowed"});
            this.tcivilstatus.Location = new System.Drawing.Point(53, 281);
            this.tcivilstatus.Name = "tcivilstatus";
            this.tcivilstatus.Size = new System.Drawing.Size(229, 21);
            this.tcivilstatus.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tcivilstatus.TabIndex = 99;
            // 
            // kryptonDateTimePicker1
            // 
            this.kryptonDateTimePicker1.CornerRoundingRadius = -1F;
            this.kryptonDateTimePicker1.Location = new System.Drawing.Point(378, 308);
            this.kryptonDateTimePicker1.Name = "kryptonDateTimePicker1";
            this.kryptonDateTimePicker1.Size = new System.Drawing.Size(18, 21);
            this.kryptonDateTimePicker1.TabIndex = 100;
            this.kryptonDateTimePicker1.ValueChanged += new System.EventHandler(this.kryptonDateTimePicker1_ValueChanged);
            // 
            // tstatus
            // 
            this.tstatus.CueHint.CueHintText = "Status";
            this.tstatus.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tstatus.Enabled = false;
            this.tstatus.Location = new System.Drawing.Point(53, 422);
            this.tstatus.Name = "tstatus";
            this.tstatus.Size = new System.Drawing.Size(351, 23);
            this.tstatus.TabIndex = 101;
            this.tstatus.Text = "Pending";
            // 
            // btnEnrol
            // 
            this.btnEnrol.CornerRoundingRadius = 15F;
            this.btnEnrol.Location = new System.Drawing.Point(67, 636);
            this.btnEnrol.Name = "btnEnrol";
            this.btnEnrol.Size = new System.Drawing.Size(283, 52);
            this.btnEnrol.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnEnrol.StateCommon.Border.Rounding = 15F;
            this.btnEnrol.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnrol.TabIndex = 102;
            this.btnEnrol.Values.Text = "Proceed to Enrollment";
            this.btnEnrol.Visible = false;
            this.btnEnrol.Click += new System.EventHandler(this.btnEnrol_Click);
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.CornerRoundingRadius = 15F;
            this.kryptonButton2.Location = new System.Drawing.Point(217, 521);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(133, 34);
            this.kryptonButton2.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton2.StateCommon.Border.Rounding = 15F;
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton2.TabIndex = 103;
            this.kryptonButton2.Values.Text = "View Grades";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 104;
            this.label2.Text = "Status:";
            // 
            // tinfoStatus
            // 
            this.tinfoStatus.AutoSize = true;
            this.tinfoStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tinfoStatus.Location = new System.Drawing.Point(515, 92);
            this.tinfoStatus.Name = "tinfoStatus";
            this.tinfoStatus.Size = new System.Drawing.Size(19, 13);
            this.tinfoStatus.TabIndex = 105;
            this.tinfoStatus.Text = "...";
            // 
            // btnAssessment
            // 
            this.btnAssessment.CornerRoundingRadius = 15F;
            this.btnAssessment.Location = new System.Drawing.Point(67, 561);
            this.btnAssessment.Name = "btnAssessment";
            this.btnAssessment.Size = new System.Drawing.Size(133, 34);
            this.btnAssessment.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnAssessment.StateCommon.Border.Rounding = 15F;
            this.btnAssessment.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssessment.TabIndex = 106;
            this.btnAssessment.Values.Text = "Assessment";
            
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 15F;
            this.kryptonButton1.Location = new System.Drawing.Point(217, 561);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(133, 34);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 15F;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 107;
            this.kryptonButton1.Values.Text = "View Subjects";
            // 
            // frm_student_application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 788);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.btnAssessment);
            this.Controls.Add(this.tinfoStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.btnEnrol);
            this.Controls.Add(this.tstatus);
            this.Controls.Add(this.kryptonDateTimePicker1);
            this.Controls.Add(this.tcivilstatus);
            this.Controls.Add(this.tgender);
            this.Controls.Add(this.tsemester);
            this.Controls.Add(this.treligion);
            this.Controls.Add(this.tnationality);
            this.Controls.Add(this.tplaceofbirth);
            this.Controls.Add(this.tdateofbirth);
            this.Controls.Add(this.tmiddlename);
            this.Controls.Add(this.tfirstname);
            this.Controls.Add(this.tlastname);
            this.Controls.Add(this.tIDNumber);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.tsearch);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_student_application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_student_application_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tsemester)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tgender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcivilstatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonTextBox tsearch;
        private Krypton.Toolkit.KryptonButton btn_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private Krypton.Toolkit.KryptonButton btnView;
        private Krypton.Toolkit.KryptonButton btnEdit;
        private Krypton.Toolkit.KryptonTextBox tIDNumber;
        private Krypton.Toolkit.KryptonTextBox tlastname;
        private Krypton.Toolkit.KryptonTextBox tfirstname;
        private Krypton.Toolkit.KryptonTextBox tmiddlename;
        private Krypton.Toolkit.KryptonTextBox tdateofbirth;
        private Krypton.Toolkit.KryptonTextBox tplaceofbirth;
        private Krypton.Toolkit.KryptonTextBox tnationality;
        private Krypton.Toolkit.KryptonTextBox treligion;
        private Krypton.Toolkit.KryptonComboBox tsemester;
        private Krypton.Toolkit.KryptonComboBox tgender;
        private Krypton.Toolkit.KryptonComboBox tcivilstatus;
        private Krypton.Toolkit.KryptonDateTimePicker kryptonDateTimePicker1;
        private Krypton.Toolkit.KryptonTextBox tstatus;
        private Krypton.Toolkit.KryptonButton btnEnrol;
        private Krypton.Toolkit.KryptonButton kryptonButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tinfoStatus;
        private Krypton.Toolkit.KryptonButton btnAssessment;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}