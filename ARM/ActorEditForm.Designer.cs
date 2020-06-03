namespace ARM {
    partial class ActorEditForm {
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
            this.gbActorName = new System.Windows.Forms.GroupBox();
            this.tbActorName = new System.Windows.Forms.TextBox();
            this.gbActorBirthday = new System.Windows.Forms.GroupBox();
            this.dtpActorBirthday = new System.Windows.Forms.DateTimePicker();
            this.gbActorCountry = new System.Windows.Forms.GroupBox();
            this.cbActorCountry = new System.Windows.Forms.ComboBox();
            this.gbActorDescription = new System.Windows.Forms.GroupBox();
            this.tbActorDescription = new System.Windows.Forms.TextBox();
            this.bActorSave = new System.Windows.Forms.Button();
            this.bActorCancel = new System.Windows.Forms.Button();
            this.gbActorName.SuspendLayout();
            this.gbActorBirthday.SuspendLayout();
            this.gbActorCountry.SuspendLayout();
            this.gbActorDescription.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbActorName
            // 
            this.gbActorName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbActorName.Controls.Add(this.tbActorName);
            this.gbActorName.Location = new System.Drawing.Point(15, 12);
            this.gbActorName.Name = "gbActorName";
            this.gbActorName.Size = new System.Drawing.Size(563, 51);
            this.gbActorName.TabIndex = 0;
            this.gbActorName.TabStop = false;
            this.gbActorName.Text = "Имя";
            // 
            // tbActorName
            // 
            this.tbActorName.Location = new System.Drawing.Point(7, 21);
            this.tbActorName.Name = "tbActorName";
            this.tbActorName.Size = new System.Drawing.Size(550, 22);
            this.tbActorName.TabIndex = 0;
            // 
            // gbActorBirthday
            // 
            this.gbActorBirthday.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbActorBirthday.Controls.Add(this.dtpActorBirthday);
            this.gbActorBirthday.Location = new System.Drawing.Point(15, 69);
            this.gbActorBirthday.Name = "gbActorBirthday";
            this.gbActorBirthday.Size = new System.Drawing.Size(563, 51);
            this.gbActorBirthday.TabIndex = 1;
            this.gbActorBirthday.TabStop = false;
            this.gbActorBirthday.Text = "Дата рождения";
            // 
            // dtpActorBirthday
            // 
            this.dtpActorBirthday.Location = new System.Drawing.Point(7, 22);
            this.dtpActorBirthday.Name = "dtpActorBirthday";
            this.dtpActorBirthday.Size = new System.Drawing.Size(550, 22);
            this.dtpActorBirthday.TabIndex = 0;
            // 
            // gbActorCountry
            // 
            this.gbActorCountry.Controls.Add(this.cbActorCountry);
            this.gbActorCountry.Location = new System.Drawing.Point(15, 126);
            this.gbActorCountry.Name = "gbActorCountry";
            this.gbActorCountry.Size = new System.Drawing.Size(563, 51);
            this.gbActorCountry.TabIndex = 3;
            this.gbActorCountry.TabStop = false;
            this.gbActorCountry.Text = "Страна";
            // 
            // cbActorCountry
            // 
            this.cbActorCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbActorCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActorCountry.FormattingEnabled = true;
            this.cbActorCountry.Location = new System.Drawing.Point(3, 18);
            this.cbActorCountry.Name = "cbActorCountry";
            this.cbActorCountry.Size = new System.Drawing.Size(557, 24);
            this.cbActorCountry.TabIndex = 0;
            // 
            // gbActorDescription
            // 
            this.gbActorDescription.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbActorDescription.Controls.Add(this.tbActorDescription);
            this.gbActorDescription.Location = new System.Drawing.Point(15, 183);
            this.gbActorDescription.Name = "gbActorDescription";
            this.gbActorDescription.Size = new System.Drawing.Size(563, 51);
            this.gbActorDescription.TabIndex = 1;
            this.gbActorDescription.TabStop = false;
            this.gbActorDescription.Text = "Описание";
            // 
            // tbActorDescription
            // 
            this.tbActorDescription.Location = new System.Drawing.Point(7, 21);
            this.tbActorDescription.Name = "tbActorDescription";
            this.tbActorDescription.Size = new System.Drawing.Size(550, 22);
            this.tbActorDescription.TabIndex = 0;
            // 
            // bActorSave
            // 
            this.bActorSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bActorSave.ForeColor = System.Drawing.Color.Green;
            this.bActorSave.Location = new System.Drawing.Point(313, 240);
            this.bActorSave.Name = "bActorSave";
            this.bActorSave.Size = new System.Drawing.Size(121, 61);
            this.bActorSave.TabIndex = 6;
            this.bActorSave.Text = "Принять";
            this.bActorSave.UseVisualStyleBackColor = true;
            this.bActorSave.Click += new System.EventHandler(this.bActorSave_Click);
            // 
            // bActorCancel
            // 
            this.bActorCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bActorCancel.ForeColor = System.Drawing.Color.Red;
            this.bActorCancel.Location = new System.Drawing.Point(457, 240);
            this.bActorCancel.Name = "bActorCancel";
            this.bActorCancel.Size = new System.Drawing.Size(121, 61);
            this.bActorCancel.TabIndex = 5;
            this.bActorCancel.Text = "Отмена";
            this.bActorCancel.UseVisualStyleBackColor = true;
            this.bActorCancel.Click += new System.EventHandler(this.bActorCancel_Click);
            // 
            // ActorEditForm
            // 
            this.AcceptButton = this.bActorSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 312);
            this.Controls.Add(this.bActorSave);
            this.Controls.Add(this.bActorCancel);
            this.Controls.Add(this.gbActorDescription);
            this.Controls.Add(this.gbActorCountry);
            this.Controls.Add(this.gbActorBirthday);
            this.Controls.Add(this.gbActorName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ActorEditForm";
            this.Text = "ActorEditForm";
            this.gbActorName.ResumeLayout(false);
            this.gbActorName.PerformLayout();
            this.gbActorBirthday.ResumeLayout(false);
            this.gbActorCountry.ResumeLayout(false);
            this.gbActorDescription.ResumeLayout(false);
            this.gbActorDescription.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbActorName;
        private System.Windows.Forms.TextBox tbActorName;
        private System.Windows.Forms.GroupBox gbActorBirthday;
        private System.Windows.Forms.DateTimePicker dtpActorBirthday;
        private System.Windows.Forms.GroupBox gbActorCountry;
        private System.Windows.Forms.ComboBox cbActorCountry;
        private System.Windows.Forms.GroupBox gbActorDescription;
        private System.Windows.Forms.TextBox tbActorDescription;
        private System.Windows.Forms.Button bActorSave;
        private System.Windows.Forms.Button bActorCancel;
    }
}