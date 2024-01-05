namespace school_management_system_model.Toastr
{
    partial class frm_toastr
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_toastr));
            this.toastColor = new System.Windows.Forms.Panel();
            this.tType = new System.Windows.Forms.Label();
            this.tMessage = new System.Windows.Forms.Label();
            this.icon = new System.Windows.Forms.PictureBox();
            this.toastTimer = new System.Windows.Forms.Timer(this.components);
            this.toastHide = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // toastColor
            // 
            this.toastColor.BackColor = System.Drawing.Color.DarkGreen;
            this.toastColor.Location = new System.Drawing.Point(-5, -2);
            this.toastColor.Name = "toastColor";
            this.toastColor.Size = new System.Drawing.Size(24, 65);
            this.toastColor.TabIndex = 0;
            // 
            // tType
            // 
            this.tType.AutoSize = true;
            this.tType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tType.ForeColor = System.Drawing.SystemColors.Control;
            this.tType.Location = new System.Drawing.Point(79, 9);
            this.tType.Name = "tType";
            this.tType.Size = new System.Drawing.Size(73, 21);
            this.tType.TabIndex = 2;
            this.tType.Text = "Success!";
            // 
            // tMessage
            // 
            this.tMessage.AutoSize = true;
            this.tMessage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tMessage.ForeColor = System.Drawing.SystemColors.Control;
            this.tMessage.Location = new System.Drawing.Point(79, 30);
            this.tMessage.Name = "tMessage";
            this.tMessage.Size = new System.Drawing.Size(71, 21);
            this.tMessage.TabIndex = 3;
            this.tMessage.Text = "Message";
            // 
            // icon
            // 
            this.icon.Image = ((System.Drawing.Image)(resources.GetObject("icon.Image")));
            this.icon.Location = new System.Drawing.Point(25, 9);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(48, 42);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon.TabIndex = 1;
            this.icon.TabStop = false;
            // 
            // toastTimer
            // 
            this.toastTimer.Enabled = true;
            this.toastTimer.Interval = 10;
            this.toastTimer.Tick += new System.EventHandler(this.toastTimer_Tick);
            // 
            // toastHide
            // 
            this.toastHide.Enabled = true;
            this.toastHide.Interval = 10;
            this.toastHide.Tick += new System.EventHandler(this.toastHide_Tick);
            // 
            // frm_toastr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(441, 61);
            this.Controls.Add(this.tMessage);
            this.Controls.Add(this.tType);
            this.Controls.Add(this.icon);
            this.Controls.Add(this.toastColor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_toastr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "toastr_success";
            this.Load += new System.EventHandler(this.toastr_success_Load);
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel toastColor;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label tType;
        private System.Windows.Forms.Label tMessage;
        private System.Windows.Forms.Timer toastTimer;
        private System.Windows.Forms.Timer toastHide;
    }
}