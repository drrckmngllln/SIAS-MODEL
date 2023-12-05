namespace school_management_system_model.Forms.settings
{
    partial class frm_campuses
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.t1 = new Krypton.Toolkit.KryptonTextBox();
            this.t2 = new Krypton.Toolkit.KryptonRichTextBox();
            this.t3 = new Krypton.Toolkit.KryptonTextBox();
            this.t4 = new Krypton.Toolkit.KryptonComboBox();
            this.btn_save = new Krypton.Toolkit.KryptonButton();
            this.btn_clear = new Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.t4)).BeginInit();
            this.SuspendLayout();
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
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 40;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(876, 643);
            this.dgv.TabIndex = 0;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Campuses";
            // 
            // t1
            // 
            this.t1.CueHint.CueHintText = "Code";
            this.t1.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t1.Location = new System.Drawing.Point(26, 111);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(258, 23);
            this.t1.TabIndex = 2;
            // 
            // t2
            // 
            this.t2.CueHint.CueHintText = "Description";
            this.t2.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t2.Location = new System.Drawing.Point(26, 140);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(327, 101);
            this.t2.TabIndex = 3;
            this.t2.Text = "";
            // 
            // t3
            // 
            this.t3.CueHint.CueHintText = "Address";
            this.t3.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t3.Location = new System.Drawing.Point(26, 247);
            this.t3.Name = "t3";
            this.t3.Size = new System.Drawing.Size(327, 23);
            this.t3.TabIndex = 4;
            // 
            // t4
            // 
            this.t4.CornerRoundingRadius = -1F;
            this.t4.CueHint.CueHintText = "Status";
            this.t4.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.t4.DropDownWidth = 196;
            this.t4.IntegralHeight = false;
            this.t4.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.t4.Location = new System.Drawing.Point(26, 276);
            this.t4.Name = "t4";
            this.t4.Size = new System.Drawing.Size(196, 21);
            this.t4.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.t4.TabIndex = 5;
            // 
            // btn_save
            // 
            this.btn_save.CornerRoundingRadius = 15F;
            this.btn_save.Location = new System.Drawing.Point(53, 323);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(133, 44);
            this.btn_save.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_save.StateCommon.Border.Rounding = 15F;
            this.btn_save.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.TabIndex = 6;
            this.btn_save.Values.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.CornerRoundingRadius = 15F;
            this.btn_clear.Location = new System.Drawing.Point(192, 323);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(133, 44);
            this.btn_clear.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_clear.StateCommon.Border.Rounding = 15F;
            this.btn_clear.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.TabIndex = 7;
            this.btn_clear.Values.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 15F;
            this.kryptonButton1.Location = new System.Drawing.Point(118, 373);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(133, 44);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 15F;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 8;
            this.kryptonButton1.Values.Text = "Delete";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click_1);
            // 
            // frm_campuses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 766);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.t4);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_campuses";
            this.Text = "frm_campuses";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_campuses_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_campuses_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.t4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private Krypton.Toolkit.KryptonTextBox t1;
        private Krypton.Toolkit.KryptonRichTextBox t2;
        private Krypton.Toolkit.KryptonTextBox t3;
        private Krypton.Toolkit.KryptonComboBox t4;
        private Krypton.Toolkit.KryptonButton btn_save;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}