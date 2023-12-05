namespace school_management_system_model.Forms.settings
{
    partial class frm_sections
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
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.btn_clear = new Krypton.Toolkit.KryptonButton();
            this.btn_save = new Krypton.Toolkit.KryptonButton();
            this.tstatus = new Krypton.Toolkit.KryptonComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tsectioncode = new Krypton.Toolkit.KryptonTextBox();
            this.tcourse = new Krypton.Toolkit.KryptonComboBox();
            this.tnumberofstudents = new Krypton.Toolkit.KryptonTextBox();
            this.tmaxstudents = new Krypton.Toolkit.KryptonTextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tyearlevel = new Krypton.Toolkit.KryptonTextBox();
            this.tsection = new Krypton.Toolkit.KryptonTextBox();
            this.btnSubjects = new Krypton.Toolkit.KryptonButton();
            this.tRemarks = new Krypton.Toolkit.KryptonComboBox();
            this.tSemester = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcourse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRemarks)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 15F;
            this.kryptonButton1.Location = new System.Drawing.Point(113, 436);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(133, 44);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 15F;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 9;
            this.kryptonButton1.Values.Text = "Delete";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.CornerRoundingRadius = 15F;
            this.btn_clear.Location = new System.Drawing.Point(187, 386);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(133, 44);
            this.btn_clear.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_clear.StateCommon.Border.Rounding = 15F;
            this.btn_clear.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.TabIndex = 8;
            this.btn_clear.Values.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.CornerRoundingRadius = 15F;
            this.btn_save.Location = new System.Drawing.Point(48, 386);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(133, 44);
            this.btn_save.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_save.StateCommon.Border.Rounding = 15F;
            this.btn_save.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.TabIndex = 7;
            this.btn_save.Values.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tstatus
            // 
            this.tstatus.CornerRoundingRadius = -1F;
            this.tstatus.CueHint.CueHintText = "Status";
            this.tstatus.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tstatus.DropDownWidth = 196;
            this.tstatus.IntegralHeight = false;
            this.tstatus.Items.AddRange(new object[] {
            "Available",
            "Full"});
            this.tstatus.Location = new System.Drawing.Point(30, 312);
            this.tstatus.Name = "tstatus";
            this.tstatus.Size = new System.Drawing.Size(196, 21);
            this.tstatus.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tstatus.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "Sections";
            // 
            // tsectioncode
            // 
            this.tsectioncode.CueHint.CueHintText = "Section Code";
            this.tsectioncode.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tsectioncode.Location = new System.Drawing.Point(30, 111);
            this.tsectioncode.Name = "tsectioncode";
            this.tsectioncode.Size = new System.Drawing.Size(258, 23);
            this.tsectioncode.TabIndex = 2;
            // 
            // tcourse
            // 
            this.tcourse.CornerRoundingRadius = -1F;
            this.tcourse.CueHint.CueHintText = "Course";
            this.tcourse.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tcourse.DropDownWidth = 196;
            this.tcourse.IntegralHeight = false;
            this.tcourse.Location = new System.Drawing.Point(30, 140);
            this.tcourse.Name = "tcourse";
            this.tcourse.Size = new System.Drawing.Size(196, 21);
            this.tcourse.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tcourse.TabIndex = 3;
            this.tcourse.SelectedIndexChanged += new System.EventHandler(this.tcourse_SelectedIndexChanged);
            // 
            // tnumberofstudents
            // 
            this.tnumberofstudents.CueHint.CueHintText = "Number of Students";
            this.tnumberofstudents.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tnumberofstudents.Location = new System.Drawing.Point(30, 254);
            this.tnumberofstudents.Name = "tnumberofstudents";
            this.tnumberofstudents.Size = new System.Drawing.Size(258, 23);
            this.tnumberofstudents.TabIndex = 4;
            this.tnumberofstudents.Text = "0";
            // 
            // tmaxstudents
            // 
            this.tmaxstudents.CueHint.CueHintText = "Max Number of Students";
            this.tmaxstudents.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tmaxstudents.Location = new System.Drawing.Point(30, 283);
            this.tmaxstudents.Name = "tmaxstudents";
            this.tmaxstudents.Size = new System.Drawing.Size(258, 23);
            this.tmaxstudents.TabIndex = 5;
            this.tmaxstudents.Text = "50";
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.dgv.Location = new System.Drawing.Point(372, 111);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 40;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(887, 665);
            this.dgv.TabIndex = 38;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // tyearlevel
            // 
            this.tyearlevel.CueHint.CueHintText = "Year Level";
            this.tyearlevel.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tyearlevel.Location = new System.Drawing.Point(30, 167);
            this.tyearlevel.Name = "tyearlevel";
            this.tyearlevel.Size = new System.Drawing.Size(258, 23);
            this.tyearlevel.TabIndex = 39;
            this.tyearlevel.TextChanged += new System.EventHandler(this.tyearlevel_TextChanged);
            // 
            // tsection
            // 
            this.tsection.CueHint.CueHintText = "Section";
            this.tsection.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tsection.Location = new System.Drawing.Point(30, 196);
            this.tsection.Name = "tsection";
            this.tsection.Size = new System.Drawing.Size(258, 23);
            this.tsection.TabIndex = 40;
            this.tsection.TextChanged += new System.EventHandler(this.tsection_TextChanged);
            // 
            // btnSubjects
            // 
            this.btnSubjects.CornerRoundingRadius = 15F;
            this.btnSubjects.Location = new System.Drawing.Point(48, 486);
            this.btnSubjects.Name = "btnSubjects";
            this.btnSubjects.Size = new System.Drawing.Size(272, 44);
            this.btnSubjects.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSubjects.StateCommon.Border.Rounding = 15F;
            this.btnSubjects.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjects.TabIndex = 41;
            this.btnSubjects.Values.Text = "Subjects";
            this.btnSubjects.Click += new System.EventHandler(this.btnSubjects_Click);
            // 
            // tRemarks
            // 
            this.tRemarks.CornerRoundingRadius = -1F;
            this.tRemarks.CueHint.CueHintText = "Remarks";
            this.tRemarks.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tRemarks.DropDownWidth = 196;
            this.tRemarks.IntegralHeight = false;
            this.tRemarks.Items.AddRange(new object[] {
            "Regular",
            "Irregular"});
            this.tRemarks.Location = new System.Drawing.Point(30, 339);
            this.tRemarks.Name = "tRemarks";
            this.tRemarks.Size = new System.Drawing.Size(196, 21);
            this.tRemarks.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tRemarks.TabIndex = 46;
            // 
            // tSemester
            // 
            this.tSemester.CueHint.CueHintText = "Semester";
            this.tSemester.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tSemester.Location = new System.Drawing.Point(30, 225);
            this.tSemester.Name = "tSemester";
            this.tSemester.Size = new System.Drawing.Size(258, 23);
            this.tSemester.TabIndex = 47;
            // 
            // frm_sections
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 788);
            this.Controls.Add(this.tSemester);
            this.Controls.Add(this.tRemarks);
            this.Controls.Add(this.btnSubjects);
            this.Controls.Add(this.tsection);
            this.Controls.Add(this.tyearlevel);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tmaxstudents);
            this.Controls.Add(this.tnumberofstudents);
            this.Controls.Add(this.tcourse);
            this.Controls.Add(this.tsectioncode);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tstatus);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_sections";
            this.Text = "frm_sections";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_sections_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_sections_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcourse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRemarks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonComboBox tstatus;
        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonTextBox tsectioncode;
        private Krypton.Toolkit.KryptonComboBox tcourse;
        private Krypton.Toolkit.KryptonTextBox tnumberofstudents;
        private Krypton.Toolkit.KryptonTextBox tmaxstudents;
        private System.Windows.Forms.DataGridView dgv;
        private Krypton.Toolkit.KryptonTextBox tyearlevel;
        private Krypton.Toolkit.KryptonTextBox tsection;
        private Krypton.Toolkit.KryptonButton btnSubjects;
        private Krypton.Toolkit.KryptonComboBox tRemarks;
        private Krypton.Toolkit.KryptonTextBox tSemester;
    }
}