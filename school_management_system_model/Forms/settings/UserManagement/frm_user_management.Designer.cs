namespace school_management_system_model.Forms.settings.UserManagement
{
    partial class frm_user_management
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
            this.label2 = new System.Windows.Forms.Label();
            this.tEmployeeId = new System.Windows.Forms.TextBox();
            this.tsearch = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.btn_clear = new Krypton.Toolkit.KryptonButton();
            this.btn_save = new Krypton.Toolkit.KryptonButton();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tLastname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tFirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tMiddlename = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tPassword = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tAccessLevel = new System.Windows.Forms.ComboBox();
            this.txtSearch = new Krypton.Toolkit.KryptonTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cAdministrator = new System.Windows.Forms.CheckBox();
            this.cDelete = new System.Windows.Forms.CheckBox();
            this.cEdit = new System.Windows.Forms.CheckBox();
            this.cAdd = new System.Windows.Forms.CheckBox();
            this.tDepartment = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 144;
            this.label2.Text = "ID Number:";
            // 
            // tEmployeeId
            // 
            this.tEmployeeId.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tEmployeeId.Location = new System.Drawing.Point(120, 111);
            this.tEmployeeId.Name = "tEmployeeId";
            this.tEmployeeId.Size = new System.Drawing.Size(236, 21);
            this.tEmployeeId.TabIndex = 143;
            // 
            // tsearch
            // 
            this.tsearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tsearch.CueHint.CueHintText = "Search...";
            this.tsearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.tsearch.Location = new System.Drawing.Point(1162, 82);
            this.tsearch.Name = "tsearch";
            this.tsearch.Size = new System.Drawing.Size(186, 23);
            this.tsearch.TabIndex = 142;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.CornerRoundingRadius = 15F;
            this.kryptonButton1.Location = new System.Drawing.Point(123, 533);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(133, 44);
            this.kryptonButton1.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.kryptonButton1.StateCommon.Border.Rounding = 15F;
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kryptonButton1.TabIndex = 139;
            this.kryptonButton1.Values.Text = "Delete";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // btn_clear
            // 
            this.btn_clear.CornerRoundingRadius = 15F;
            this.btn_clear.Location = new System.Drawing.Point(197, 483);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(133, 44);
            this.btn_clear.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_clear.StateCommon.Border.Rounding = 15F;
            this.btn_clear.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_clear.TabIndex = 138;
            this.btn_clear.Values.Text = "Clear";
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // btn_save
            // 
            this.btn_save.CornerRoundingRadius = 15F;
            this.btn_save.Location = new System.Drawing.Point(58, 483);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(133, 44);
            this.btn_save.StateCommon.Border.DrawBorders = ((Krypton.Toolkit.PaletteDrawBorders)((((Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom) 
            | Krypton.Toolkit.PaletteDrawBorders.Left) 
            | Krypton.Toolkit.PaletteDrawBorders.Right)));
            this.btn_save.StateCommon.Border.Rounding = 15F;
            this.btn_save.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.TabIndex = 137;
            this.btn_save.Values.Text = "Save";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 141;
            this.label1.Text = "User Management";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgv.Size = new System.Drawing.Size(749, 581);
            this.dgv.TabIndex = 140;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 146;
            this.label3.Text = "Last Name:";
            // 
            // tLastname
            // 
            this.tLastname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLastname.Location = new System.Drawing.Point(120, 138);
            this.tLastname.Name = "tLastname";
            this.tLastname.Size = new System.Drawing.Size(236, 21);
            this.tLastname.TabIndex = 145;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 148;
            this.label4.Text = "First Name:";
            // 
            // tFirstname
            // 
            this.tFirstname.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tFirstname.Location = new System.Drawing.Point(120, 165);
            this.tFirstname.Name = "tFirstname";
            this.tFirstname.Size = new System.Drawing.Size(236, 21);
            this.tFirstname.TabIndex = 147;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 150;
            this.label5.Text = "Middle Name:";
            // 
            // tMiddlename
            // 
            this.tMiddlename.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tMiddlename.Location = new System.Drawing.Point(120, 192);
            this.tMiddlename.Name = "tMiddlename";
            this.tMiddlename.Size = new System.Drawing.Size(236, 21);
            this.tMiddlename.TabIndex = 149;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 15);
            this.label6.TabIndex = 152;
            this.label6.Text = "E-Mail:";
            // 
            // tEmail
            // 
            this.tEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tEmail.Location = new System.Drawing.Point(120, 219);
            this.tEmail.Name = "tEmail";
            this.tEmail.Size = new System.Drawing.Size(236, 21);
            this.tEmail.TabIndex = 151;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(29, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 15);
            this.label7.TabIndex = 154;
            this.label7.Text = "Password:";
            // 
            // tPassword
            // 
            this.tPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPassword.Location = new System.Drawing.Point(120, 246);
            this.tPassword.Name = "tPassword";
            this.tPassword.PasswordChar = '●';
            this.tPassword.Size = new System.Drawing.Size(236, 21);
            this.tPassword.TabIndex = 153;
            this.tPassword.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 15);
            this.label8.TabIndex = 156;
            this.label8.Text = "Access Level:";
            // 
            // tAccessLevel
            // 
            this.tAccessLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAccessLevel.FormattingEnabled = true;
            this.tAccessLevel.Items.AddRange(new object[] {
            "Administrator",
            "User"});
            this.tAccessLevel.Location = new System.Drawing.Point(120, 302);
            this.tAccessLevel.Name = "tAccessLevel";
            this.tAccessLevel.Size = new System.Drawing.Size(236, 23);
            this.tAccessLevel.TabIndex = 157;
            this.tAccessLevel.SelectedIndexChanged += new System.EventHandler(this.tAccessLevel_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.CueHint.CueHintText = "Search";
            this.txtSearch.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.txtSearch.Location = new System.Drawing.Point(922, 82);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 23);
            this.txtSearch.TabIndex = 158;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cAdministrator);
            this.groupBox1.Controls.Add(this.cDelete);
            this.groupBox1.Controls.Add(this.cEdit);
            this.groupBox1.Controls.Add(this.cAdd);
            this.groupBox1.Location = new System.Drawing.Point(120, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 98);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Control";
            // 
            // cAdministrator
            // 
            this.cAdministrator.AutoSize = true;
            this.cAdministrator.Location = new System.Drawing.Point(131, 19);
            this.cAdministrator.Name = "cAdministrator";
            this.cAdministrator.Size = new System.Drawing.Size(86, 17);
            this.cAdministrator.TabIndex = 163;
            this.cAdministrator.Text = "Administrator";
            this.cAdministrator.UseVisualStyleBackColor = true;
            this.cAdministrator.CheckedChanged += new System.EventHandler(this.cAdministrator_CheckedChanged);
            // 
            // cDelete
            // 
            this.cDelete.AutoSize = true;
            this.cDelete.Location = new System.Drawing.Point(18, 65);
            this.cDelete.Name = "cDelete";
            this.cDelete.Size = new System.Drawing.Size(65, 17);
            this.cDelete.TabIndex = 162;
            this.cDelete.Text = "Deleting";
            this.cDelete.UseVisualStyleBackColor = true;
            this.cDelete.CheckedChanged += new System.EventHandler(this.cDelete_CheckedChanged);
            // 
            // cEdit
            // 
            this.cEdit.AutoSize = true;
            this.cEdit.Location = new System.Drawing.Point(18, 42);
            this.cEdit.Name = "cEdit";
            this.cEdit.Size = new System.Drawing.Size(58, 17);
            this.cEdit.TabIndex = 161;
            this.cEdit.Text = "Editing";
            this.cEdit.UseVisualStyleBackColor = true;
            this.cEdit.CheckedChanged += new System.EventHandler(this.cEdit_CheckedChanged);
            // 
            // cAdd
            // 
            this.cAdd.AutoSize = true;
            this.cAdd.Location = new System.Drawing.Point(18, 19);
            this.cAdd.Name = "cAdd";
            this.cAdd.Size = new System.Drawing.Size(59, 17);
            this.cAdd.TabIndex = 160;
            this.cAdd.Text = "Adding";
            this.cAdd.UseVisualStyleBackColor = true;
            this.cAdd.CheckedChanged += new System.EventHandler(this.cAdd_CheckedChanged);
            // 
            // tDepartment
            // 
            this.tDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tDepartment.FormattingEnabled = true;
            this.tDepartment.Items.AddRange(new object[] {
            "Finance",
            "Registrar",
            "Dean",
            "Campaign"});
            this.tDepartment.Location = new System.Drawing.Point(120, 273);
            this.tDepartment.Name = "tDepartment";
            this.tDepartment.Size = new System.Drawing.Size(236, 23);
            this.tDepartment.TabIndex = 161;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(29, 276);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 160;
            this.label9.Text = "Department:";
            // 
            // frm_user_management
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 704);
            this.Controls.Add(this.tDepartment);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.tAccessLevel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tPassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tEmail);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tMiddlename);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tFirstname);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tLastname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tEmployeeId);
            this.Controls.Add(this.tsearch);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.btn_clear);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_user_management";
            this.Text = "frm_user_management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_user_management_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tEmployeeId;
        private Krypton.Toolkit.KryptonTextBox tsearch;
        private Krypton.Toolkit.KryptonButton kryptonButton1;
        private Krypton.Toolkit.KryptonButton btn_clear;
        private Krypton.Toolkit.KryptonButton btn_save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tLastname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tFirstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tMiddlename;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tEmail;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox tAccessLevel;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cDelete;
        private System.Windows.Forms.CheckBox cEdit;
        private System.Windows.Forms.CheckBox cAdd;
        private System.Windows.Forms.ComboBox tDepartment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cAdministrator;
    }
}