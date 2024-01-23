namespace school_management_system_model.Forms.settings
{
    partial class frm_courses
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
            this.tMaxUnits = new Krypton.Toolkit.KryptonTextBox();
            this.tCode = new Krypton.Toolkit.KryptonTextBox();
            this.tsearch = new Krypton.Toolkit.KryptonTextBox();
            this.tStatus = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.btn_clear = new Krypton.Toolkit.KryptonButton();
            this.btn_save = new Krypton.Toolkit.KryptonButton();
            this.tDescription = new Krypton.Toolkit.KryptonRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tLevel = new Krypton.Toolkit.KryptonComboBox();
            this.tCampus = new Krypton.Toolkit.KryptonComboBox();
            this.tDepartment = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.tStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCampus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDepartment)).BeginInit();
            this.SuspendLayout();
            // 
            // tMaxUnits
            // 
            this.tMaxUnits.CueHint.CueHintText = "Max Units";
            this.tMaxUnits.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tMaxUnits.Location = new System.Drawing.Point(26, 328);
            this.tMaxUnits.Name = "tMaxUnits";
            this.tMaxUnits.Size = new System.Drawing.Size(258, 23);
            this.tMaxUnits.TabIndex = 62;
            // 
            // tCode
            // 
            this.tCode.CueHint.CueHintText = "Code";
            this.tCode.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tCode.Location = new System.Drawing.Point(26, 111);
            this.tCode.Name = "tCode";
            this.tCode.Size = new System.Drawing.Size(258, 23);
            this.tCode.TabIndex = 56;
            // 
            // tsearch
            // 
            this.tsearch.CueHint.CueHintText = "Search...";
            this.tsearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tsearch.Location = new System.Drawing.Point(388, 82);
            this.tsearch.Name = "tsearch";
            this.tsearch.Size = new System.Drawing.Size(258, 23);
            this.tsearch.TabIndex = 70;
            this.tsearch.TextChanged += new System.EventHandler(this.tsearch_TextChanged);
            // 
            // tStatus
            // 
            this.tStatus.CornerRoundingRadius = -1F;
            this.tStatus.CueHint.CueHintText = "Status";
            this.tStatus.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tStatus.DropDownWidth = 196;
            this.tStatus.IntegralHeight = false;
            this.tStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.tStatus.Location = new System.Drawing.Point(26, 357);
            this.tStatus.Name = "tStatus";
            this.tStatus.Size = new System.Drawing.Size(196, 21);
            this.tStatus.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tStatus.TabIndex = 64;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 15F;
            this.kryptonButton1.Location = new System.Drawing.Point(130, 471);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(133, 44);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 15F;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 67;
            this.kryptonButton1.Values.Text = "Delete";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.CornerRoundingRadius = 15F;
            this.btn_clear.Location = new System.Drawing.Point(204, 421);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(133, 44);
            this.btn_clear.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_clear.StateCommon.Border.Rounding = 15F;
            this.btn_clear.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.TabIndex = 66;
            this.btn_clear.Values.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.CornerRoundingRadius = 15F;
            this.btn_save.Location = new System.Drawing.Point(65, 421);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(133, 44);
            this.btn_save.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_save.StateCommon.Border.Rounding = 15F;
            this.btn_save.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.TabIndex = 65;
            this.btn_save.Values.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // tDescription
            // 
            this.tDescription.CueHint.CueHintText = "Description";
            this.tDescription.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tDescription.Location = new System.Drawing.Point(26, 140);
            this.tDescription.Name = "tDescription";
            this.tDescription.Size = new System.Drawing.Size(327, 101);
            this.tDescription.TabIndex = 58;
            this.tDescription.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 69;
            this.label1.Text = "Courses";
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
            this.dgv.Location = new System.Drawing.Point(388, 111);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 60;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(953, 665);
            this.dgv.TabIndex = 68;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // tLevel
            // 
            this.tLevel.CornerRoundingRadius = -1F;
            this.tLevel.CueHint.CueHintText = "Level";
            this.tLevel.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tLevel.DropDownWidth = 196;
            this.tLevel.IntegralHeight = false;
            this.tLevel.Location = new System.Drawing.Point(26, 247);
            this.tLevel.Name = "tLevel";
            this.tLevel.Size = new System.Drawing.Size(196, 21);
            this.tLevel.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tLevel.TabIndex = 71;
            // 
            // tCampus
            // 
            this.tCampus.CornerRoundingRadius = -1F;
            this.tCampus.CueHint.CueHintText = "Campus";
            this.tCampus.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tCampus.DropDownWidth = 196;
            this.tCampus.IntegralHeight = false;
            this.tCampus.Location = new System.Drawing.Point(26, 274);
            this.tCampus.Name = "tCampus";
            this.tCampus.Size = new System.Drawing.Size(196, 21);
            this.tCampus.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tCampus.TabIndex = 72;
            // 
            // tDepartment
            // 
            this.tDepartment.CornerRoundingRadius = -1F;
            this.tDepartment.CueHint.CueHintText = "Department";
            this.tDepartment.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tDepartment.DropDownWidth = 196;
            this.tDepartment.IntegralHeight = false;
            this.tDepartment.Location = new System.Drawing.Point(26, 301);
            this.tDepartment.Name = "tDepartment";
            this.tDepartment.Size = new System.Drawing.Size(196, 21);
            this.tDepartment.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.tDepartment.TabIndex = 73;
            // 
            // frm_courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 788);
            this.Controls.Add(this.tDepartment);
            this.Controls.Add(this.tCampus);
            this.Controls.Add(this.tLevel);
            this.Controls.Add(this.tMaxUnits);
            this.Controls.Add(this.tCode);
            this.Controls.Add(this.tsearch);
            this.Controls.Add(this.tStatus);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_courses";
            this.Text = "frm_courses";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_courses_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_courses_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tCampus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDepartment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonTextBox tMaxUnits;
        private Krypton.Toolkit.KryptonTextBox tCode;
        private Krypton.Toolkit.KryptonTextBox tsearch;
        private Krypton.Toolkit.KryptonComboBox tStatus;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonRichTextBox tDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private Krypton.Toolkit.KryptonComboBox tLevel;
        private Krypton.Toolkit.KryptonComboBox tCampus;
        private Krypton.Toolkit.KryptonComboBox tDepartment;
    }
}