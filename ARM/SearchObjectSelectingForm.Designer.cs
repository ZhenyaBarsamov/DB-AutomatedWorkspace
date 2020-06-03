namespace ARM {
    partial class SearchObjectSelectingForm {
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
            this.gbItems = new System.Windows.Forms.GroupBox();
            this.cbItems = new System.Windows.Forms.ComboBox();
            this.bAccept = new System.Windows.Forms.Button();
            this.gbItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbItems
            // 
            this.gbItems.Controls.Add(this.cbItems);
            this.gbItems.Location = new System.Drawing.Point(12, 12);
            this.gbItems.Name = "gbItems";
            this.gbItems.Size = new System.Drawing.Size(569, 56);
            this.gbItems.TabIndex = 0;
            this.gbItems.TabStop = false;
            this.gbItems.Text = "Объекты";
            // 
            // cbItems
            // 
            this.cbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbItems.FormattingEnabled = true;
            this.cbItems.Location = new System.Drawing.Point(6, 21);
            this.cbItems.Name = "cbItems";
            this.cbItems.Size = new System.Drawing.Size(557, 24);
            this.cbItems.TabIndex = 0;
            // 
            // bAccept
            // 
            this.bAccept.ForeColor = System.Drawing.Color.LimeGreen;
            this.bAccept.Location = new System.Drawing.Point(453, 74);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(122, 52);
            this.bAccept.TabIndex = 1;
            this.bAccept.Text = "Поиск";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // SearchObjectSelectingForm
            // 
            this.AcceptButton = this.bAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 137);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.gbItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SearchObjectSelectingForm";
            this.Text = "SearchObjectSelectingForm";
            this.gbItems.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbItems;
        private System.Windows.Forms.ComboBox cbItems;
        private System.Windows.Forms.Button bAccept;
    }
}