namespace school_management_system_model.Forms.transactions
{
    partial class frm_select_student
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
            this.tSearch = new Krypton.Toolkit.KryptonTextBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.tTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // tSearch
            // 
            this.tSearch.CueHint.CueHintText = "Search...";
            this.tSearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tSearch.Location = new System.Drawing.Point(12, 32);
            this.tSearch.Name = "tSearch";
            this.tSearch.Size = new System.Drawing.Size(745, 23);
            this.tSearch.TabIndex = 1;
            this.tSearch.TextChanged += new System.EventHandler(this.tSearch_TextChanged);
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
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 61);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowHeadersWidth = 60;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.Height = 30;
            this.dgv.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(745, 423);
            this.dgv.TabIndex = 130;
            // 
            // tTitle
            // 
            this.tTitle.AutoSize = true;
            this.tTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTitle.ForeColor = System.Drawing.Color.White;
            this.tTitle.Location = new System.Drawing.Point(12, 9);
            this.tTitle.Name = "tTitle";
            this.tTitle.Size = new System.Drawing.Size(129, 20);
            this.tTitle.TabIndex = 131;
            this.tTitle.Text = "Select Student";
            // 
            // frm_select_student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(769, 496);
            this.Controls.Add(this.tTitle);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.tSearch);
            this.CornerRoundingRadius = 15F;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_select_student";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 15F;
            this.Text = "frm_select_student";
            this.Load += new System.EventHandler(this.frm_select_student_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_select_student_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonTextBox tSearch;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label tTitle;
    }
}