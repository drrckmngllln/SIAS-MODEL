namespace school_management_system_model.Forms.settings
{
    partial class frm_levels
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.btn_clear = new Krypton.Toolkit.KryptonButton();
            this.btn_save = new Krypton.Toolkit.KryptonButton();
            this.t3 = new Krypton.Toolkit.KryptonComboBox();
            this.t2 = new Krypton.Toolkit.KryptonRichTextBox();
            this.t1 = new Krypton.Toolkit.KryptonTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.t3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 15F;
            this.kryptonButton1.Location = new System.Drawing.Point(117, 373);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(133, 44);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 15F;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 25;
            this.kryptonButton1.Values.Text = "Delete";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.CornerRoundingRadius = 15F;
            this.btn_clear.Location = new System.Drawing.Point(191, 323);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(133, 44);
            this.btn_clear.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_clear.StateCommon.Border.Rounding = 15F;
            this.btn_clear.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.TabIndex = 24;
            this.btn_clear.Values.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.CornerRoundingRadius = 15F;
            this.btn_save.Location = new System.Drawing.Point(52, 323);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(133, 44);
            this.btn_save.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_save.StateCommon.Border.Rounding = 15F;
            this.btn_save.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.TabIndex = 23;
            this.btn_save.Values.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // t3
            // 
            this.t3.CornerRoundingRadius = -1F;
            this.t3.CueHint.CueHintText = "Status";
            this.t3.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t3.DropDownWidth = 196;
            this.t3.IntegralHeight = false;
            this.t3.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.t3.Location = new System.Drawing.Point(25, 247);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(196, 21);
            this.t3.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.t3.TabIndex = 22;
            // 
            // t2
            // 
            this.t2.CueHint.CueHintText = "Description";
            this.t2.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t2.Location = new System.Drawing.Point(25, 140);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(327, 101);
            this.t2.TabIndex = 21;
            this.t2.Text = "";
            // 
            // t1
            // 
            this.t1.CueHint.CueHintText = "Code";
            this.t1.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t1.Location = new System.Drawing.Point(25, 111);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(258, 23);
            this.t1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 19;
            this.label1.Text = "Levels";
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
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgv.Location = new System.Drawing.Point(393, 111);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 40;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(895, 653);
            this.dgv.TabIndex = 18;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // frm_levels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 776);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_levels";
            this.Text = "frm_levels";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_levels_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_levels_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.t3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonComboBox t3;
        private Krypton.Toolkit.KryptonRichTextBox t2;
        private Krypton.Toolkit.KryptonTextBox t1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
    }
}