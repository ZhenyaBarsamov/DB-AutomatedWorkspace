namespace ARM {
    partial class UserEditForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.gbNewPassword = new System.Windows.Forms.GroupBox();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.gbSalt = new System.Windows.Forms.GroupBox();
            this.tbSalt = new System.Windows.Forms.TextBox();
            this.gbRegistrationDate = new System.Windows.Forms.GroupBox();
            this.dtpRegistrationDate = new System.Windows.Forms.DateTimePicker();
            this.bApply = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.gbRole = new System.Windows.Forms.GroupBox();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.gbLogin.SuspendLayout();
            this.gbNewPassword.SuspendLayout();
            this.gbSalt.SuspendLayout();
            this.gbRegistrationDate.SuspendLayout();
            this.gbRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLogin
            // 
            this.gbLogin.AutoSize = true;
            this.gbLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbLogin.Controls.Add(this.tbLogin);
            this.gbLogin.Location = new System.Drawing.Point(12, 12);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(569, 64);
            this.gbLogin.TabIndex = 0;
            this.gbLogin.TabStop = false;
            this.gbLogin.Text = "Логин";
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(6, 21);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(557, 22);
            this.tbLogin.TabIndex = 0;
            // 
            // gbNewPassword
            // 
            this.gbNewPassword.AutoSize = true;
            this.gbNewPassword.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbNewPassword.Controls.Add(this.tbNewPassword);
            this.gbNewPassword.Location = new System.Drawing.Point(12, 82);
            this.gbNewPassword.Name = "gbNewPassword";
            this.gbNewPassword.Size = new System.Drawing.Size(569, 64);
            this.gbNewPassword.TabIndex = 1;
            this.gbNewPassword.TabStop = false;
            this.gbNewPassword.Text = "Новый пароль";
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Location = new System.Drawing.Point(6, 21);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.Size = new System.Drawing.Size(557, 22);
            this.tbNewPassword.TabIndex = 0;
            // 
            // gbSalt
            // 
            this.gbSalt.AutoSize = true;
            this.gbSalt.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbSalt.Controls.Add(this.tbSalt);
            this.gbSalt.Location = new System.Drawing.Point(12, 152);
            this.gbSalt.Name = "gbSalt";
            this.gbSalt.Size = new System.Drawing.Size(569, 64);
            this.gbSalt.TabIndex = 2;
            this.gbSalt.TabStop = false;
            this.gbSalt.Text = "Соль";
            // 
            // tbSalt
            // 
            this.tbSalt.Location = new System.Drawing.Point(6, 21);
            this.tbSalt.Name = "tbSalt";
            this.tbSalt.Size = new System.Drawing.Size(557, 22);
            this.tbSalt.TabIndex = 0;
            // 
            // gbRegistrationDate
            // 
            this.gbRegistrationDate.AutoSize = true;
            this.gbRegistrationDate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbRegistrationDate.Controls.Add(this.dtpRegistrationDate);
            this.gbRegistrationDate.Location = new System.Drawing.Point(12, 222);
            this.gbRegistrationDate.Name = "gbRegistrationDate";
            this.gbRegistrationDate.Size = new System.Drawing.Size(569, 64);
            this.gbRegistrationDate.TabIndex = 3;
            this.gbRegistrationDate.TabStop = false;
            this.gbRegistrationDate.Text = "Дата регистрации";
            // 
            // dtpRegistrationDate
            // 
            this.dtpRegistrationDate.Location = new System.Drawing.Point(6, 21);
            this.dtpRegistrationDate.Name = "dtpRegistrationDate";
            this.dtpRegistrationDate.Size = new System.Drawing.Size(557, 22);
            this.dtpRegistrationDate.TabIndex = 0;
            // 
            // bApply
            // 
            this.bApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bApply.ForeColor = System.Drawing.Color.Green;
            this.bApply.Location = new System.Drawing.Point(316, 362);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(121, 61);
            this.bApply.TabIndex = 6;
            this.bApply.Text = "Принять";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.ForeColor = System.Drawing.Color.Red;
            this.bCancel.Location = new System.Drawing.Point(460, 362);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(121, 61);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Отмена";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // gbRole
            // 
            this.gbRole.AutoSize = true;
            this.gbRole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbRole.Controls.Add(this.cbRole);
            this.gbRole.Location = new System.Drawing.Point(12, 292);
            this.gbRole.Name = "gbRole";
            this.gbRole.Size = new System.Drawing.Size(569, 66);
            this.gbRole.TabIndex = 3;
            this.gbRole.TabStop = false;
            this.gbRole.Text = "Роль";
            // 
            // cbRole
            // 
            this.cbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(6, 21);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(557, 24);
            this.cbRole.TabIndex = 1;
            // 
            // UserEditForm
            // 
            this.AcceptButton = this.bApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 437);
            this.Controls.Add(this.gbRole);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.gbRegistrationDate);
            this.Controls.Add(this.gbSalt);
            this.Controls.Add(this.gbNewPassword);
            this.Controls.Add(this.gbLogin);
            this.MaximizeBox = false;
            this.Name = "UserEditForm";
            this.Text = "UserEditForm";
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            this.gbNewPassword.ResumeLayout(false);
            this.gbNewPassword.PerformLayout();
            this.gbSalt.ResumeLayout(false);
            this.gbSalt.PerformLayout();
            this.gbRegistrationDate.ResumeLayout(false);
            this.gbRole.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.GroupBox gbNewPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.GroupBox gbSalt;
        private System.Windows.Forms.TextBox tbSalt;
        private System.Windows.Forms.GroupBox gbRegistrationDate;
        private System.Windows.Forms.DateTimePicker dtpRegistrationDate;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.GroupBox gbRole;
        private System.Windows.Forms.ComboBox cbRole;
    }
}