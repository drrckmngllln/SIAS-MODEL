namespace school_management_system_model.Forms.transactions.Collection
{
    partial class frm_payment_message
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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tChange = new System.Windows.Forms.Label();
            this.btnConfirmPayment = new Krypton.Toolkit.KryptonButton();
            this.crv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(133, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Confirmed";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::school_management_system_model.Properties.Resources.check;
            this.pictureBox1.Location = new System.Drawing.Point(86, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(156, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Change:";
            // 
            // tChange
            // 
            this.tChange.AutoSize = true;
            this.tChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tChange.ForeColor = System.Drawing.SystemColors.Control;
            this.tChange.Location = new System.Drawing.Point(263, 84);
            this.tChange.Name = "tChange";
            this.tChange.Size = new System.Drawing.Size(50, 25);
            this.tChange.TabIndex = 3;
            this.tChange.Text = "00.0";
            // 
            // btnConfirmPayment
            // 
            this.btnConfirmPayment.CornerRoundingRadius = 10F;
            this.btnConfirmPayment.Location = new System.Drawing.Point(126, 129);
            this.btnConfirmPayment.Name = "btnConfirmPayment";
            this.btnConfirmPayment.Size = new System.Drawing.Size(118, 40);
            this.btnConfirmPayment.StateCommon.Back.Color1 = System.Drawing.Color.DarkGreen;
            this.btnConfirmPayment.StateCommon.Back.Color2 = System.Drawing.Color.DarkGreen;
            this.btnConfirmPayment.StateCommon.Border.Color1 = System.Drawing.Color.DarkGreen;
            this.btnConfirmPayment.StateCommon.Border.Color2 = System.Drawing.Color.DarkGreen;
            this.btnConfirmPayment.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btnConfirmPayment.StateCommon.Border.Rounding = 10F;
            this.btnConfirmPayment.StateCommon.Border.Width = 2;
            this.btnConfirmPayment.StateCommon.Content.ShortText.Color1 = System.Drawing.SystemColors.Control;
            this.btnConfirmPayment.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmPayment.TabIndex = 173;
            this.btnConfirmPayment.Values.Text = "Print Receipt";
            this.btnConfirmPayment.Click += new System.EventHandler(this.btnConfirmPayment_Click);
            // 
            // crv
            // 
            this.crv.Location = new System.Drawing.Point(42, 194);
            this.crv.Name = "crv";
            this.crv.ServerReport.BearerToken = null;
            this.crv.Size = new System.Drawing.Size(396, 246);
            this.crv.TabIndex = 174;
            this.crv.Visible = false;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 10F;
            this.kryptonButton1.Location = new System.Drawing.Point(250, 129);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(118, 40);
            this.kryptonButton1.StateCommon.Back.Color1 = System.Drawing.Color.Maroon;
            this.kryptonButton1.StateCommon.Back.Color2 = System.Drawing.Color.Maroon;
            this.kryptonButton1.StateCommon.Border.Color1 = System.Drawing.Color.Maroon;
            this.kryptonButton1.StateCommon.Border.Color2 = System.Drawing.Color.Maroon;
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 10F;
            this.kryptonButton1.StateCommon.Border.Width = 2;
            this.kryptonButton1.StateCommon.Content.ShortText.Color1 = System.Drawing.SystemColors.Control;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 175;
            this.kryptonButton1.Values.Text = "Close";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // frm_payment_message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(497, 190);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.crv);
            this.Controls.Add(this.btnConfirmPayment);
            this.Controls.Add(this.tChange);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.CornerRoundingRadius = 10F;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_payment_message";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.StateCommon.Border.Rounding = 10F;
            this.Text = "frm_payment_message";
            this.Load += new System.EventHandler(this.frm_payment_message_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_payment_message_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label tChange;
        private Krypton.Toolkit.KryptonButton btnConfirmPayment;
        private Microsoft.Reporting.WinForms.ReportViewer crv;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
    }
}