namespace school_management_system_model.Reports
{
    partial class frm_print_receipt
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
            this.crv = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // crv
            // 
            this.crv.Location = new System.Drawing.Point(12, 70);
            this.crv.Name = "crv";
            this.crv.ServerReport.BearerToken = null;
            this.crv.Size = new System.Drawing.Size(1117, 459);
            this.crv.TabIndex = 0;
            // 
            // frm_print_receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 612);
            this.Controls.Add(this.crv);
            this.Name = "frm_print_receipt";
            this.Text = "frm_print_receipt";
            this.Load += new System.EventHandler(this.frm_print_receipt_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer crv;
    }
}