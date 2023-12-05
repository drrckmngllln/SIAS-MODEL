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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.t6 = new Krypton.Toolkit.KryptonTextBox();
            this.t1 = new Krypton.Toolkit.KryptonTextBox();
            this.tsearch = new Krypton.Toolkit.KryptonTextBox();
            this.t7 = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.btn_clear = new Krypton.Toolkit.KryptonButton();
            this.btn_save = new Krypton.Toolkit.KryptonButton();
            this.t2 = new Krypton.Toolkit.KryptonRichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.t3 = new Krypton.Toolkit.KryptonComboBox();
            this.t4 = new Krypton.Toolkit.KryptonComboBox();
            this.t5 = new Krypton.Toolkit.KryptonComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.t7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t5)).BeginInit();
            this.SuspendLayout();
            // 
            // t6
            // 
            this.t6.CueHint.CueHintText = "Max Units";
            this.t6.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t6.Location = new System.Drawing.Point(26, 328);
            this.t6.Name = "t6";
            this.t6.Size = new System.Drawing.Size(258, 23);
            this.t6.TabIndex = 62;
            // 
            // t1
            // 
            this.t1.CueHint.CueHintText = "Code";
            this.t1.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t1.Location = new System.Drawing.Point(26, 111);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(258, 23);
            this.t1.TabIndex = 56;
            // 
            // tsearch
            // 
            this.tsearch.CueHint.CueHintText = "Search...";
            this.tsearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tsearch.Location = new System.Drawing.Point(388, 82);
            this.tsearch.Name = "tsearch";
            this.tsearch.Size = new System.Drawing.Size(258, 23);
            this.tsearch.TabIndex = 70;
            // 
            // t7
            // 
            this.t7.CornerRoundingRadius = -1F;
            this.t7.CueHint.CueHintText = "Status";
            this.t7.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t7.DropDownWidth = 196;
            this.t7.IntegralHeight = false;
            this.t7.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.t7.Location = new System.Drawing.Point(26, 357);
            this.t7.Name = "t7";
            this.t7.Size = new System.Drawing.Size(196, 21);
            this.t7.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.t7.TabIndex = 64;
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
            // t2
            // 
            this.t2.CueHint.CueHintText = "Description";
            this.t2.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t2.Location = new System.Drawing.Point(26, 140);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(327, 101);
            this.t2.TabIndex = 58;
            this.t2.Text = "";
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
            // t3
            // 
            this.t3.CornerRoundingRadius = -1F;
            this.t3.CueHint.CueHintText = "Level";
            this.t3.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t3.DropDownWidth = 196;
            this.t3.IntegralHeight = false;
            this.t3.Location = new System.Drawing.Point(26, 247);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(196, 21);
            this.t3.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.t3.TabIndex = 71;
            // 
            // t4
            // 
            this.t4.CornerRoundingRadius = -1F;
            this.t4.CueHint.CueHintText = "Campus";
            this.t4.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t4.DropDownWidth = 196;
            this.t4.IntegralHeight = false;
            this.t4.Location = new System.Drawing.Point(26, 274);
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(196, 21);
            this.t4.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.t4.TabIndex = 72;
            // 
            // t5
            // 
            this.t5.CornerRoundingRadius = -1F;
            this.t5.CueHint.CueHintText = "Department";
            this.t5.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t5.DropDownWidth = 196;
            this.t5.IntegralHeight = false;
            this.t5.Location = new System.Drawing.Point(26, 301);
            this.t5.Name = "t5";
            this.t5.Size = new System.Drawing.Size(196, 21);
            this.t5.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.t5.TabIndex = 73;
            // 
            // frm_courses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 788);
            this.Controls.Add(this.t5);
            this.Controls.Add(this.t4);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t6);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.tsearch);
            this.Controls.Add(this.t7);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_courses";
            this.Text = "frm_courses";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_courses_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_courses_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.t7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonTextBox t6;
        private Krypton.Toolkit.KryptonTextBox t1;
        private Krypton.Toolkit.KryptonTextBox tsearch;
        private Krypton.Toolkit.KryptonComboBox t7;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonRichTextBox t2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private Krypton.Toolkit.KryptonComboBox t3;
        private Krypton.Toolkit.KryptonComboBox t4;
        private Krypton.Toolkit.KryptonComboBox t5;
    }
}