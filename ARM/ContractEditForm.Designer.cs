namespace ARM {
    partial class ContractEditForm {
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
            this.gbFilm = new System.Windows.Forms.GroupBox();
            this.cbFilm = new System.Windows.Forms.ComboBox();
            this.gbActor = new System.Windows.Forms.GroupBox();
            this.cbActor = new System.Windows.Forms.ComboBox();
            this.gbHonorarium = new System.Windows.Forms.GroupBox();
            this.tbActorHonorarium = new System.Windows.Forms.TextBox();
            this.bActorSave = new System.Windows.Forms.Button();
            this.bActorCancel = new System.Windows.Forms.Button();
            this.gbFilm.SuspendLayout();
            this.gbActor.SuspendLayout();
            this.gbHonorarium.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFilm
            // 
            this.gbFilm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbFilm.Controls.Add(this.cbFilm);
            this.gbFilm.Location = new System.Drawing.Point(15, 12);
            this.gbFilm.Name = "gbFilm";
            this.gbFilm.Size = new System.Drawing.Size(563, 51);
            this.gbFilm.TabIndex = 1;
            this.gbFilm.TabStop = false;
            this.gbFilm.Text = "Фильм";
            // 
            // cbFilm
            // 
            this.cbFilm.FormattingEnabled = true;
            this.cbFilm.Location = new System.Drawing.Point(7, 21);
            this.cbFilm.Name = "cbFilm";
            this.cbFilm.Size = new System.Drawing.Size(551, 24);
            this.cbFilm.TabIndex = 1;
            // 
            // gbActor
            // 
            this.gbActor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbActor.Controls.Add(this.cbActor);
            this.gbActor.Location = new System.Drawing.Point(15, 69);
            this.gbActor.Name = "gbActor";
            this.gbActor.Size = new System.Drawing.Size(563, 51);
            this.gbActor.TabIndex = 2;
            this.gbActor.TabStop = false;
            this.gbActor.Text = "Актёр";
            // 
            // cbActor
            // 
            this.cbActor.FormattingEnabled = true;
            this.cbActor.Location = new System.Drawing.Point(6, 21);
            this.cbActor.Name = "cbActor";
            this.cbActor.Size = new System.Drawing.Size(551, 24);
            this.cbActor.TabIndex = 2;
            // 
            // gbHonorarium
            // 
            this.gbHonorarium.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbHonorarium.Controls.Add(this.tbActorHonorarium);
            this.gbHonorarium.Location = new System.Drawing.Point(15, 126);
            this.gbHonorarium.Name = "gbHonorarium";
            this.gbHonorarium.Size = new System.Drawing.Size(563, 51);
            this.gbHonorarium.TabIndex = 2;
            this.gbHonorarium.TabStop = false;
            this.gbHonorarium.Text = "Гонорар актёра";
            // 
            // tbActorHonorarium
            // 
            this.tbActorHonorarium.Location = new System.Drawing.Point(7, 21);
            this.tbActorHonorarium.Name = "tbActorHonorarium";
            this.tbActorHonorarium.Size = new System.Drawing.Size(550, 22);
            this.tbActorHonorarium.TabIndex = 0;
            // 
            // bActorSave
            // 
            this.bActorSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bActorSave.ForeColor = System.Drawing.Color.Green;
            this.bActorSave.Location = new System.Drawing.Point(313, 183);
            this.bActorSave.Name = "bActorSave";
            this.bActorSave.Size = new System.Drawing.Size(121, 61);
            this.bActorSave.TabIndex = 8;
            this.bActorSave.Text = "Принять";
            this.bActorSave.UseVisualStyleBackColor = true;
            this.bActorSave.Click += new System.EventHandler(this.bActorSave_Click);
            // 
            // bActorCancel
            // 
            this.bActorCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bActorCancel.ForeColor = System.Drawing.Color.Red;
            this.bActorCancel.Location = new System.Drawing.Point(457, 183);
            this.bActorCancel.Name = "bActorCancel";
            this.bActorCancel.Size = new System.Drawing.Size(121, 61);
            this.bActorCancel.TabIndex = 7;
            this.bActorCancel.Text = "Отмена";
            this.bActorCancel.UseVisualStyleBackColor = true;
            this.bActorCancel.Click += new System.EventHandler(this.bActorCancel_Click);
            // 
            // ContractEditForm
            // 
            this.AcceptButton = this.bActorSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 253);
            this.Controls.Add(this.bActorSave);
            this.Controls.Add(this.bActorCancel);
            this.Controls.Add(this.gbHonorarium);
            this.Controls.Add(this.gbActor);
            this.Controls.Add(this.gbFilm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ContractEditForm";
            this.Text = "ContractEditForm";
            this.gbFilm.ResumeLayout(false);
            this.gbActor.ResumeLayout(false);
            this.gbHonorarium.ResumeLayout(false);
            this.gbHonorarium.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFilm;
        private System.Windows.Forms.GroupBox gbActor;
        private System.Windows.Forms.ComboBox cbFilm;
        private System.Windows.Forms.ComboBox cbActor;
        private System.Windows.Forms.GroupBox gbHonorarium;
        private System.Windows.Forms.TextBox tbActorHonorarium;
        private System.Windows.Forms.Button bActorSave;
        private System.Windows.Forms.Button bActorCancel;
    }
}