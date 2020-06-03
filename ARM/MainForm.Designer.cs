namespace ARM {
    partial class MainForm {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent() {
            this.tcTableViewer = new System.Windows.Forms.TabControl();
            this.tpFilms = new System.Windows.Forms.TabPage();
            this.lvFilms = new System.Windows.Forms.ListView();
            this.msFilmsFunctions = new System.Windows.Forms.MenuStrip();
            this.bAddFilm = new System.Windows.Forms.ToolStripMenuItem();
            this.bEditFilm = new System.Windows.Forms.ToolStripMenuItem();
            this.bDeleteFilm = new System.Windows.Forms.ToolStripMenuItem();
            this.tpActors = new System.Windows.Forms.TabPage();
            this.lvActors = new System.Windows.Forms.ListView();
            this.msActorsFunctions = new System.Windows.Forms.MenuStrip();
            this.bAddActor = new System.Windows.Forms.ToolStripMenuItem();
            this.bEditActor = new System.Windows.Forms.ToolStripMenuItem();
            this.bDeleteActor = new System.Windows.Forms.ToolStripMenuItem();
            this.tpActorContracts = new System.Windows.Forms.TabPage();
            this.lvContracts = new System.Windows.Forms.ListView();
            this.msContractsFunctions = new System.Windows.Forms.MenuStrip();
            this.bAddContract = new System.Windows.Forms.ToolStripMenuItem();
            this.bEditContract = new System.Windows.Forms.ToolStripMenuItem();
            this.bDeleteContract = new System.Windows.Forms.ToolStripMenuItem();
            this.tpCompanies = new System.Windows.Forms.TabPage();
            this.lvCompanies = new System.Windows.Forms.ListView();
            this.msCompaniesFunctions = new System.Windows.Forms.MenuStrip();
            this.bAddCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.bEditCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.bDeleteCompany = new System.Windows.Forms.ToolStripMenuItem();
            this.tpUsers = new System.Windows.Forms.TabPage();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.msUsersFunctions = new System.Windows.Forms.MenuStrip();
            this.bAddUser = new System.Windows.Forms.ToolStripMenuItem();
            this.bEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.bDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.gbUserData = new System.Windows.Forms.GroupBox();
            this.lCurrentUserShowing = new System.Windows.Forms.Label();
            this.lCurrentUser = new System.Windows.Forms.Label();
            this.bChangeUser = new System.Windows.Forms.Button();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.bFindFilmsForActor = new System.Windows.Forms.Button();
            this.bFindActorsForFilm = new System.Windows.Forms.Button();
            this.tcTableViewer.SuspendLayout();
            this.tpFilms.SuspendLayout();
            this.msFilmsFunctions.SuspendLayout();
            this.tpActors.SuspendLayout();
            this.msActorsFunctions.SuspendLayout();
            this.tpActorContracts.SuspendLayout();
            this.msContractsFunctions.SuspendLayout();
            this.tpCompanies.SuspendLayout();
            this.msCompaniesFunctions.SuspendLayout();
            this.tpUsers.SuspendLayout();
            this.msUsersFunctions.SuspendLayout();
            this.gbUserData.SuspendLayout();
            this.gbSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTableViewer
            // 
            this.tcTableViewer.Controls.Add(this.tpFilms);
            this.tcTableViewer.Controls.Add(this.tpActors);
            this.tcTableViewer.Controls.Add(this.tpActorContracts);
            this.tcTableViewer.Controls.Add(this.tpCompanies);
            this.tcTableViewer.Controls.Add(this.tpUsers);
            this.tcTableViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcTableViewer.Location = new System.Drawing.Point(0, 53);
            this.tcTableViewer.Name = "tcTableViewer";
            this.tcTableViewer.SelectedIndex = 0;
            this.tcTableViewer.Size = new System.Drawing.Size(1482, 644);
            this.tcTableViewer.TabIndex = 0;
            // 
            // tpFilms
            // 
            this.tpFilms.Controls.Add(this.lvFilms);
            this.tpFilms.Controls.Add(this.msFilmsFunctions);
            this.tpFilms.Location = new System.Drawing.Point(4, 25);
            this.tpFilms.Name = "tpFilms";
            this.tpFilms.Padding = new System.Windows.Forms.Padding(3);
            this.tpFilms.Size = new System.Drawing.Size(1474, 615);
            this.tpFilms.TabIndex = 0;
            this.tpFilms.Text = "Фильмы";
            this.tpFilms.UseVisualStyleBackColor = true;
            // 
            // lvFilms
            // 
            this.lvFilms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFilms.Location = new System.Drawing.Point(3, 31);
            this.lvFilms.Name = "lvFilms";
            this.lvFilms.Size = new System.Drawing.Size(1468, 581);
            this.lvFilms.TabIndex = 2;
            this.lvFilms.UseCompatibleStateImageBehavior = false;
            this.lvFilms.View = System.Windows.Forms.View.Details;
            // 
            // msFilmsFunctions
            // 
            this.msFilmsFunctions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msFilmsFunctions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAddFilm,
            this.bEditFilm,
            this.bDeleteFilm});
            this.msFilmsFunctions.Location = new System.Drawing.Point(3, 3);
            this.msFilmsFunctions.Name = "msFilmsFunctions";
            this.msFilmsFunctions.Size = new System.Drawing.Size(1468, 28);
            this.msFilmsFunctions.TabIndex = 1;
            this.msFilmsFunctions.Text = "menuStrip1";
            // 
            // bAddFilm
            // 
            this.bAddFilm.Name = "bAddFilm";
            this.bAddFilm.Size = new System.Drawing.Size(88, 24);
            this.bAddFilm.Text = "Добавить";
            this.bAddFilm.Click += new System.EventHandler(this.bAddFilm_Click);
            // 
            // bEditFilm
            // 
            this.bEditFilm.Name = "bEditFilm";
            this.bEditFilm.Size = new System.Drawing.Size(123, 24);
            this.bEditFilm.Text = "Редактировать";
            this.bEditFilm.Click += new System.EventHandler(this.bEditFilm_Click);
            // 
            // bDeleteFilm
            // 
            this.bDeleteFilm.Name = "bDeleteFilm";
            this.bDeleteFilm.Size = new System.Drawing.Size(77, 24);
            this.bDeleteFilm.Text = "Удалить";
            this.bDeleteFilm.Click += new System.EventHandler(this.bDeleteFilm_Click);
            // 
            // tpActors
            // 
            this.tpActors.Controls.Add(this.lvActors);
            this.tpActors.Controls.Add(this.msActorsFunctions);
            this.tpActors.Location = new System.Drawing.Point(4, 25);
            this.tpActors.Name = "tpActors";
            this.tpActors.Padding = new System.Windows.Forms.Padding(3);
            this.tpActors.Size = new System.Drawing.Size(1474, 615);
            this.tpActors.TabIndex = 1;
            this.tpActors.Text = "Актёры";
            this.tpActors.UseVisualStyleBackColor = true;
            // 
            // lvActors
            // 
            this.lvActors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvActors.Location = new System.Drawing.Point(3, 31);
            this.lvActors.Name = "lvActors";
            this.lvActors.Size = new System.Drawing.Size(1468, 581);
            this.lvActors.TabIndex = 3;
            this.lvActors.UseCompatibleStateImageBehavior = false;
            this.lvActors.View = System.Windows.Forms.View.Details;
            // 
            // msActorsFunctions
            // 
            this.msActorsFunctions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msActorsFunctions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAddActor,
            this.bEditActor,
            this.bDeleteActor});
            this.msActorsFunctions.Location = new System.Drawing.Point(3, 3);
            this.msActorsFunctions.Name = "msActorsFunctions";
            this.msActorsFunctions.Size = new System.Drawing.Size(1468, 28);
            this.msActorsFunctions.TabIndex = 1;
            this.msActorsFunctions.Text = "menuStrip1";
            // 
            // bAddActor
            // 
            this.bAddActor.Name = "bAddActor";
            this.bAddActor.Size = new System.Drawing.Size(88, 24);
            this.bAddActor.Text = "Добавить";
            this.bAddActor.Click += new System.EventHandler(this.bAddActor_Click);
            // 
            // bEditActor
            // 
            this.bEditActor.Name = "bEditActor";
            this.bEditActor.Size = new System.Drawing.Size(123, 24);
            this.bEditActor.Text = "Редактировать";
            this.bEditActor.Click += new System.EventHandler(this.bEditActor_Click);
            // 
            // bDeleteActor
            // 
            this.bDeleteActor.Name = "bDeleteActor";
            this.bDeleteActor.Size = new System.Drawing.Size(77, 24);
            this.bDeleteActor.Text = "Удалить";
            this.bDeleteActor.Click += new System.EventHandler(this.bDeleteActor_Click);
            // 
            // tpActorContracts
            // 
            this.tpActorContracts.Controls.Add(this.lvContracts);
            this.tpActorContracts.Controls.Add(this.msContractsFunctions);
            this.tpActorContracts.Location = new System.Drawing.Point(4, 25);
            this.tpActorContracts.Name = "tpActorContracts";
            this.tpActorContracts.Size = new System.Drawing.Size(1474, 615);
            this.tpActorContracts.TabIndex = 4;
            this.tpActorContracts.Text = "Актёрские контракты";
            this.tpActorContracts.UseVisualStyleBackColor = true;
            // 
            // lvContracts
            // 
            this.lvContracts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvContracts.Location = new System.Drawing.Point(0, 28);
            this.lvContracts.Name = "lvContracts";
            this.lvContracts.Size = new System.Drawing.Size(1474, 587);
            this.lvContracts.TabIndex = 5;
            this.lvContracts.UseCompatibleStateImageBehavior = false;
            this.lvContracts.View = System.Windows.Forms.View.Details;
            // 
            // msContractsFunctions
            // 
            this.msContractsFunctions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msContractsFunctions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAddContract,
            this.bEditContract,
            this.bDeleteContract});
            this.msContractsFunctions.Location = new System.Drawing.Point(0, 0);
            this.msContractsFunctions.Name = "msContractsFunctions";
            this.msContractsFunctions.Size = new System.Drawing.Size(1474, 28);
            this.msContractsFunctions.TabIndex = 4;
            this.msContractsFunctions.Text = "menuStrip1";
            // 
            // bAddContract
            // 
            this.bAddContract.Name = "bAddContract";
            this.bAddContract.Size = new System.Drawing.Size(88, 24);
            this.bAddContract.Text = "Добавить";
            this.bAddContract.Click += new System.EventHandler(this.bAddContract_Click);
            // 
            // bEditContract
            // 
            this.bEditContract.Name = "bEditContract";
            this.bEditContract.Size = new System.Drawing.Size(123, 24);
            this.bEditContract.Text = "Редактировать";
            this.bEditContract.Click += new System.EventHandler(this.bEditContract_Click);
            // 
            // bDeleteContract
            // 
            this.bDeleteContract.Name = "bDeleteContract";
            this.bDeleteContract.Size = new System.Drawing.Size(77, 24);
            this.bDeleteContract.Text = "Удалить";
            this.bDeleteContract.Click += new System.EventHandler(this.bDeleteContract_Click);
            // 
            // tpCompanies
            // 
            this.tpCompanies.Controls.Add(this.lvCompanies);
            this.tpCompanies.Controls.Add(this.msCompaniesFunctions);
            this.tpCompanies.Location = new System.Drawing.Point(4, 25);
            this.tpCompanies.Name = "tpCompanies";
            this.tpCompanies.Size = new System.Drawing.Size(1474, 615);
            this.tpCompanies.TabIndex = 2;
            this.tpCompanies.Text = "Кинокомпании";
            this.tpCompanies.UseVisualStyleBackColor = true;
            // 
            // lvCompanies
            // 
            this.lvCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCompanies.Location = new System.Drawing.Point(0, 28);
            this.lvCompanies.Name = "lvCompanies";
            this.lvCompanies.Size = new System.Drawing.Size(1474, 587);
            this.lvCompanies.TabIndex = 3;
            this.lvCompanies.UseCompatibleStateImageBehavior = false;
            this.lvCompanies.View = System.Windows.Forms.View.Details;
            // 
            // msCompaniesFunctions
            // 
            this.msCompaniesFunctions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msCompaniesFunctions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAddCompany,
            this.bEditCompany,
            this.bDeleteCompany});
            this.msCompaniesFunctions.Location = new System.Drawing.Point(0, 0);
            this.msCompaniesFunctions.Name = "msCompaniesFunctions";
            this.msCompaniesFunctions.Size = new System.Drawing.Size(1474, 28);
            this.msCompaniesFunctions.TabIndex = 2;
            this.msCompaniesFunctions.Text = "menuStrip1";
            // 
            // bAddCompany
            // 
            this.bAddCompany.Name = "bAddCompany";
            this.bAddCompany.Size = new System.Drawing.Size(88, 24);
            this.bAddCompany.Text = "Добавить";
            this.bAddCompany.Click += new System.EventHandler(this.bAddCompany_Click);
            // 
            // bEditCompany
            // 
            this.bEditCompany.Name = "bEditCompany";
            this.bEditCompany.Size = new System.Drawing.Size(123, 24);
            this.bEditCompany.Text = "Редактировать";
            this.bEditCompany.Click += new System.EventHandler(this.bEditCompany_Click);
            // 
            // bDeleteCompany
            // 
            this.bDeleteCompany.Name = "bDeleteCompany";
            this.bDeleteCompany.Size = new System.Drawing.Size(77, 24);
            this.bDeleteCompany.Text = "Удалить";
            this.bDeleteCompany.Click += new System.EventHandler(this.bDeleteCompany_Click);
            // 
            // tpUsers
            // 
            this.tpUsers.Controls.Add(this.lvUsers);
            this.tpUsers.Controls.Add(this.msUsersFunctions);
            this.tpUsers.Location = new System.Drawing.Point(4, 25);
            this.tpUsers.Name = "tpUsers";
            this.tpUsers.Size = new System.Drawing.Size(1474, 615);
            this.tpUsers.TabIndex = 3;
            this.tpUsers.Text = "Пользователи";
            this.tpUsers.UseVisualStyleBackColor = true;
            // 
            // lvUsers
            // 
            this.lvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUsers.Location = new System.Drawing.Point(0, 28);
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(1474, 587);
            this.lvUsers.TabIndex = 4;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            // 
            // msUsersFunctions
            // 
            this.msUsersFunctions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msUsersFunctions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bAddUser,
            this.bEditUser,
            this.bDeleteUser});
            this.msUsersFunctions.Location = new System.Drawing.Point(0, 0);
            this.msUsersFunctions.Name = "msUsersFunctions";
            this.msUsersFunctions.Size = new System.Drawing.Size(1474, 28);
            this.msUsersFunctions.TabIndex = 3;
            this.msUsersFunctions.Text = "menuStrip1";
            // 
            // bAddUser
            // 
            this.bAddUser.Name = "bAddUser";
            this.bAddUser.Size = new System.Drawing.Size(88, 24);
            this.bAddUser.Text = "Добавить";
            this.bAddUser.Click += new System.EventHandler(this.bAddUser_Click);
            // 
            // bEditUser
            // 
            this.bEditUser.Name = "bEditUser";
            this.bEditUser.Size = new System.Drawing.Size(123, 24);
            this.bEditUser.Text = "Редактировать";
            this.bEditUser.Click += new System.EventHandler(this.bEditUser_Click);
            // 
            // bDeleteUser
            // 
            this.bDeleteUser.Name = "bDeleteUser";
            this.bDeleteUser.Size = new System.Drawing.Size(77, 24);
            this.bDeleteUser.Text = "Удалить";
            this.bDeleteUser.Click += new System.EventHandler(this.bDeleteUser_Click);
            // 
            // gbUserData
            // 
            this.gbUserData.Controls.Add(this.lCurrentUserShowing);
            this.gbUserData.Controls.Add(this.lCurrentUser);
            this.gbUserData.Controls.Add(this.bChangeUser);
            this.gbUserData.Location = new System.Drawing.Point(743, 0);
            this.gbUserData.Name = "gbUserData";
            this.gbUserData.Size = new System.Drawing.Size(735, 47);
            this.gbUserData.TabIndex = 1;
            this.gbUserData.TabStop = false;
            this.gbUserData.Text = "Пользователь";
            // 
            // lCurrentUserShowing
            // 
            this.lCurrentUserShowing.AutoSize = true;
            this.lCurrentUserShowing.Location = new System.Drawing.Point(178, 24);
            this.lCurrentUserShowing.Name = "lCurrentUserShowing";
            this.lCurrentUserShowing.Size = new System.Drawing.Size(0, 17);
            this.lCurrentUserShowing.TabIndex = 2;
            // 
            // lCurrentUser
            // 
            this.lCurrentUser.AutoSize = true;
            this.lCurrentUser.Location = new System.Drawing.Point(7, 24);
            this.lCurrentUser.Name = "lCurrentUser";
            this.lCurrentUser.Size = new System.Drawing.Size(165, 17);
            this.lCurrentUser.TabIndex = 1;
            this.lCurrentUser.Text = "Текущий пользователь:";
            // 
            // bChangeUser
            // 
            this.bChangeUser.Location = new System.Drawing.Point(522, 12);
            this.bChangeUser.Name = "bChangeUser";
            this.bChangeUser.Size = new System.Drawing.Size(207, 29);
            this.bChangeUser.TabIndex = 0;
            this.bChangeUser.Text = "Сменить пользователя";
            this.bChangeUser.UseVisualStyleBackColor = true;
            this.bChangeUser.Click += new System.EventHandler(this.bChangeUser_Click);
            // 
            // gbSearch
            // 
            this.gbSearch.Controls.Add(this.bFindFilmsForActor);
            this.gbSearch.Controls.Add(this.bFindActorsForFilm);
            this.gbSearch.Location = new System.Drawing.Point(4, 0);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(733, 47);
            this.gbSearch.TabIndex = 2;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Стандартный поиск";
            // 
            // bFindFilmsForActor
            // 
            this.bFindFilmsForActor.Location = new System.Drawing.Point(160, 12);
            this.bFindFilmsForActor.Name = "bFindFilmsForActor";
            this.bFindFilmsForActor.Size = new System.Drawing.Size(266, 29);
            this.bFindFilmsForActor.TabIndex = 1;
            this.bFindFilmsForActor.Text = "Все фильмы конкретного актёра";
            this.bFindFilmsForActor.UseVisualStyleBackColor = true;
            this.bFindFilmsForActor.Click += new System.EventHandler(this.bFindFilmsForActor_Click);
            // 
            // bFindActorsForFilm
            // 
            this.bFindActorsForFilm.Location = new System.Drawing.Point(445, 12);
            this.bFindActorsForFilm.Name = "bFindActorsForFilm";
            this.bFindActorsForFilm.Size = new System.Drawing.Size(266, 29);
            this.bFindActorsForFilm.TabIndex = 0;
            this.bFindActorsForFilm.Text = "Все актёры конкретного фильма";
            this.bFindActorsForFilm.UseVisualStyleBackColor = true;
            this.bFindActorsForFilm.Click += new System.EventHandler(this.bFindActorsForFilm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 697);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.gbUserData);
            this.Controls.Add(this.tcTableViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Автоматизированное Рабочее Место";
            this.tcTableViewer.ResumeLayout(false);
            this.tpFilms.ResumeLayout(false);
            this.tpFilms.PerformLayout();
            this.msFilmsFunctions.ResumeLayout(false);
            this.msFilmsFunctions.PerformLayout();
            this.tpActors.ResumeLayout(false);
            this.tpActors.PerformLayout();
            this.msActorsFunctions.ResumeLayout(false);
            this.msActorsFunctions.PerformLayout();
            this.tpActorContracts.ResumeLayout(false);
            this.tpActorContracts.PerformLayout();
            this.msContractsFunctions.ResumeLayout(false);
            this.msContractsFunctions.PerformLayout();
            this.tpCompanies.ResumeLayout(false);
            this.tpCompanies.PerformLayout();
            this.msCompaniesFunctions.ResumeLayout(false);
            this.msCompaniesFunctions.PerformLayout();
            this.tpUsers.ResumeLayout(false);
            this.tpUsers.PerformLayout();
            this.msUsersFunctions.ResumeLayout(false);
            this.msUsersFunctions.PerformLayout();
            this.gbUserData.ResumeLayout(false);
            this.gbUserData.PerformLayout();
            this.gbSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcTableViewer;
        private System.Windows.Forms.TabPage tpFilms;
        private System.Windows.Forms.TabPage tpActors;
        private System.Windows.Forms.GroupBox gbUserData;
        private System.Windows.Forms.Button bChangeUser;
        private System.Windows.Forms.Label lCurrentUser;
        private System.Windows.Forms.Label lCurrentUserShowing;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.TabPage tpCompanies;
        private System.Windows.Forms.TabPage tpUsers;
        private System.Windows.Forms.TabPage tpActorContracts;
        private System.Windows.Forms.MenuStrip msActorsFunctions;
        private System.Windows.Forms.ToolStripMenuItem bAddActor;
        private System.Windows.Forms.ToolStripMenuItem bEditActor;
        private System.Windows.Forms.ToolStripMenuItem bDeleteActor;
        private System.Windows.Forms.MenuStrip msCompaniesFunctions;
        private System.Windows.Forms.ToolStripMenuItem bAddCompany;
        private System.Windows.Forms.ToolStripMenuItem bEditCompany;
        private System.Windows.Forms.ToolStripMenuItem bDeleteCompany;
        private System.Windows.Forms.MenuStrip msUsersFunctions;
        private System.Windows.Forms.ToolStripMenuItem bAddUser;
        private System.Windows.Forms.ToolStripMenuItem bEditUser;
        private System.Windows.Forms.ToolStripMenuItem bDeleteUser;
        private System.Windows.Forms.MenuStrip msFilmsFunctions;
        private System.Windows.Forms.ToolStripMenuItem bAddFilm;
        private System.Windows.Forms.ToolStripMenuItem bEditFilm;
        private System.Windows.Forms.ToolStripMenuItem bDeleteFilm;
        private System.Windows.Forms.MenuStrip msContractsFunctions;
        private System.Windows.Forms.ToolStripMenuItem bAddContract;
        private System.Windows.Forms.ToolStripMenuItem bEditContract;
        private System.Windows.Forms.ToolStripMenuItem bDeleteContract;
        private System.Windows.Forms.ListView lvFilms;
        private System.Windows.Forms.ListView lvActors;
        private System.Windows.Forms.ListView lvContracts;
        private System.Windows.Forms.ListView lvCompanies;
        private System.Windows.Forms.ListView lvUsers;
        private System.Windows.Forms.Button bFindFilmsForActor;
        private System.Windows.Forms.Button bFindActorsForFilm;
    }
}

