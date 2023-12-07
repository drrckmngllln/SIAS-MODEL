namespace school_management_system_model.Forms.settings.FeeSetup
{
    partial class frm_link_subjects
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tsearch = new Krypton.Toolkit.KryptonTextBox();
            this.tTitle = new System.Windows.Forms.Label();
            this.kryptonButton3 = new Krypton.Toolkit.KryptonButton();
            this.btnSelect = new Krypton.Toolkit.KryptonButton();
            this.btnRemove = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv.Location = new System.Drawing.Point(12, 65);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 60;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(894, 381);
            this.dgv.TabIndex = 119;
            // 
            // tsearch
            // 
            this.tsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsearch.CueHint.CueHintText = "Search...";
            this.tsearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tsearch.Location = new System.Drawing.Point(12, 36);
            this.tsearch.Name = "tsearch";
            this.tsearch.Size = new System.Drawing.Size(894, 23);
            this.tsearch.TabIndex = 121;
            this.tsearch.TextChanged += new System.EventHandler(this.tsearch_TextChanged);
            // 
            // tTitle
            // 
            this.tTitle.AutoSize = true;
            this.tTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTitle.ForeColor = System.Drawing.SystemColors.Control;
            this.tTitle.Location = new System.Drawing.Point(12, 9);
            this.tTitle.Name = "tTitle";
            this.tTitle.Size = new System.Drawing.Size(130, 24);
            this.tTitle.TabIndex = 122;
            this.tTitle.Text = "Select Subject";
            // 
            // kryptonButton3
            // 
            this.kryptonButton3.CornerRoundingRadius = 10F;
            this.kryptonButton3.Location = new System.Drawing.Point(760, 452);
            this.kryptonButton3.Name = "kryptonButton3";
            this.kryptonButton3.Size = new System.Drawing.Size(146, 35);
            this.kryptonButton3.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.kryptonButton3.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.kryptonButton3.StateCommon.Border.Color1 = System.Drawing.Color.DarkRed;
            this.kryptonButton3.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.kryptonButton3.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton3.StateCommon.Border.Rounding = 10F;
            this.kryptonButton3.StateCommon.Border.Width = 2;
            this.kryptonButton3.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton3.TabIndex = 136;
            this.kryptonButton3.Values.Text = "Close";
            this.kryptonButton3.Click += new System.EventHandler(this.kryptonButton3_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.CornerRoundingRadius = 10F;
            this.btnSelect.Location = new System.Drawing.Point(608, 452);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(146, 35);
            this.btnSelect.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnSelect.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.btnSelect.StateCommon.Border.Color1 = System.Drawing.Color.Green;
            this.btnSelect.StateCommon.Border.Color2 = System.Drawing.Color.Green;
            this.btnSelect.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnSelect.StateCommon.Border.Rounding = 10F;
            this.btnSelect.StateCommon.Border.Width = 2;
            this.btnSelect.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.TabIndex = 137;
            this.btnSelect.Values.Text = "Select";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.CornerRoundingRadius = 10F;
            this.btnRemove.Location = new System.Drawing.Point(12, 452);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(146, 35);
            this.btnRemove.StateCommon.Back.Color1 = System.Drawing.SystemColors.Control;
            this.btnRemove.StateCommon.Back.Color2 = System.Drawing.SystemColors.Control;
            this.btnRemove.StateCommon.Border.Color1 = System.Drawing.Color.DarkRed;
            this.btnRemove.StateCommon.Border.Color2 = System.Drawing.Color.DarkRed;
            this.btnRemove.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnRemove.StateCommon.Border.Rounding = 10F;
            this.btnRemove.StateCommon.Border.Width = 2;
            this.btnRemove.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.TabIndex = 138;
            this.btnRemove.Values.Text = "Remove";
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // frm_link_subjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(918, 499);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.kryptonButton3);
            this.Controls.Add(this.tTitle);
            this.Controls.Add(this.tsearch);
            this.Controls.Add(this.dgv);
            this.CornerRoundingRadius = 10F;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_link_subjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 10F;
            this.Text = "frm_link_subjects";
            this.Load += new System.EventHandler(this.frm_link_subjects_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_link_subjects_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private Krypton.Toolkit.KryptonTextBox tsearch;
        private System.Windows.Forms.Label tTitle;
        private Krypton.Toolkit.KryptonButton kryptonButton3;
        private Krypton.Toolkit.KryptonButton btnSelect;
        private Krypton.Toolkit.KryptonButton btnRemove;
    }
}