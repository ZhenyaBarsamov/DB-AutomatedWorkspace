namespace ARM {
    partial class CompanyEditForm {
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
            this.gbCompanyName = new System.Windows.Forms.GroupBox();
            this.tbCompanyName = new System.Windows.Forms.TextBox();
            this.gbCompanyFoundationYear = new System.Windows.Forms.GroupBox();
            this.tbCompanyFoundationYear = new System.Windows.Forms.TextBox();
            this.gbCompanyAdress = new System.Windows.Forms.GroupBox();
            this.tbCompanyAdress = new System.Windows.Forms.TextBox();
            this.bCompanySave = new System.Windows.Forms.Button();
            this.bCompanyCancel = new System.Windows.Forms.Button();
            this.gbCompanyName.SuspendLayout();
            this.gbCompanyFoundationYear.SuspendLayout();
            this.gbCompanyAdress.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCompanyName
            // 
            this.gbCompanyName.Controls.Add(this.tbCompanyName);
            this.gbCompanyName.Location = new System.Drawing.Point(15, 12);
            this.gbCompanyName.Name = "gbCompanyName";
            this.gbCompanyName.Size = new System.Drawing.Size(563, 51);
            this.gbCompanyName.TabIndex = 1;
            this.gbCompanyName.TabStop = false;
            this.gbCompanyName.Text = "Название";
            // 
            // tbCompanyName
            // 
            this.tbCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCompanyName.Location = new System.Drawing.Point(3, 18);
            this.tbCompanyName.Name = "tbCompanyName";
            this.tbCompanyName.Size = new System.Drawing.Size(557, 22);
            this.tbCompanyName.TabIndex = 0;
            // 
            // gbCompanyFoundationYear
            // 
            this.gbCompanyFoundationYear.Controls.Add(this.tbCompanyFoundationYear);
            this.gbCompanyFoundationYear.Location = new System.Drawing.Point(15, 69);
            this.gbCompanyFoundationYear.Name = "gbCompanyFoundationYear";
            this.gbCompanyFoundationYear.Size = new System.Drawing.Size(563, 51);
            this.gbCompanyFoundationYear.TabIndex = 2;
            this.gbCompanyFoundationYear.TabStop = false;
            this.gbCompanyFoundationYear.Text = "Год основания";
            // 
            // tbCompanyFoundationYear
            // 
            this.tbCompanyFoundationYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCompanyFoundationYear.Location = new System.Drawing.Point(3, 18);
            this.tbCompanyFoundationYear.Name = "tbCompanyFoundationYear";
            this.tbCompanyFoundationYear.Size = new System.Drawing.Size(557, 22);
            this.tbCompanyFoundationYear.TabIndex = 0;
            // 
            // gbCompanyAdress
            // 
            this.gbCompanyAdress.Controls.Add(this.tbCompanyAdress);
            this.gbCompanyAdress.Location = new System.Drawing.Point(15, 126);
            this.gbCompanyAdress.Name = "gbCompanyAdress";
            this.gbCompanyAdress.Size = new System.Drawing.Size(563, 51);
            this.gbCompanyAdress.TabIndex = 3;
            this.gbCompanyAdress.TabStop = false;
            this.gbCompanyAdress.Text = "Адрес";
            // 
            // tbCompanyAdress
            // 
            this.tbCompanyAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCompanyAdress.Location = new System.Drawing.Point(3, 18);
            this.tbCompanyAdress.Name = "tbCompanyAdress";
            this.tbCompanyAdress.Size = new System.Drawing.Size(557, 22);
            this.tbCompanyAdress.TabIndex = 0;
            // 
            // bCompanySave
            // 
            this.bCompanySave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCompanySave.ForeColor = System.Drawing.Color.Green;
            this.bCompanySave.Location = new System.Drawing.Point(310, 194);
            this.bCompanySave.Name = "bCompanySave";
            this.bCompanySave.Size = new System.Drawing.Size(121, 61);
            this.bCompanySave.TabIndex = 6;
            this.bCompanySave.Text = "Принять";
            this.bCompanySave.UseVisualStyleBackColor = true;
            this.bCompanySave.Click += new System.EventHandler(this.bCompanySave_Click);
            // 
            // bCompanyCancel
            // 
            this.bCompanyCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCompanyCancel.ForeColor = System.Drawing.Color.Red;
            this.bCompanyCancel.Location = new System.Drawing.Point(454, 194);
            this.bCompanyCancel.Name = "bCompanyCancel";
            this.bCompanyCancel.Size = new System.Drawing.Size(121, 61);
            this.bCompanyCancel.TabIndex = 5;
            this.bCompanyCancel.Text = "Отмена";
            this.bCompanyCancel.UseVisualStyleBackColor = true;
            this.bCompanyCancel.Click += new System.EventHandler(this.bCompanyCancel_Click);
            // 
            // CompanyEditForm
            // 
            this.AcceptButton = this.bCompanySave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 270);
            this.Controls.Add(this.bCompanySave);
            this.Controls.Add(this.bCompanyCancel);
            this.Controls.Add(this.gbCompanyAdress);
            this.Controls.Add(this.gbCompanyFoundationYear);
            this.Controls.Add(this.gbCompanyName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CompanyEditForm";
            this.Text = "Компания";
            this.gbCompanyName.ResumeLayout(false);
            this.gbCompanyName.PerformLayout();
            this.gbCompanyFoundationYear.ResumeLayout(false);
            this.gbCompanyFoundationYear.PerformLayout();
            this.gbCompanyAdress.ResumeLayout(false);
            this.gbCompanyAdress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCompanyName;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.GroupBox gbCompanyFoundationYear;
        private System.Windows.Forms.TextBox tbCompanyFoundationYear;
        private System.Windows.Forms.GroupBox gbCompanyAdress;
        private System.Windows.Forms.TextBox tbCompanyAdress;
        private System.Windows.Forms.Button bCompanySave;
        private System.Windows.Forms.Button bCompanyCancel;
    }
}