using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ARM.MyWorkClasses;

namespace ARM {
    public partial class MainForm : Form {
        //Выбранный пользователь
        user CurrentUser { get; set; }
        //Скрываемая вкладка таблицы пользователей
        TabPage tpUsersHiding;
        //Класс для работы с интерфейсом
        InterfaceManager interfaceManager;
        //Класс для работы с БД
        DataManager dataManager;
        //Список стран из БД
        List<string> countyNames;

        //Разрешение изменять основные таблицы
        public void IsMainDataEditable(bool f) {
            msFilmsFunctions.Enabled = f;
            msActorsFunctions.Enabled = f;
            msContractsFunctions.Enabled = f;
            msCompaniesFunctions.Enabled = f;
        }

        //Дать юзеру соответствующий функционал
        public void GiveUserHisFunctions() {
            if (CurrentUser.role == "admin") {
                //Таблица юзеров
                if (!tcTableViewer.TabPages.Contains(tpUsersHiding))
                    tcTableViewer.TabPages.Add(tpUsersHiding);
                //Редактирование основных таблиц
                IsMainDataEditable(true);
            }
            else if (CurrentUser.role == "guest") {
                //Таблица юзеров
                if (tcTableViewer.TabPages.Contains(tpUsersHiding))
                    tcTableViewer.TabPages.Remove(tpUsersHiding);
                //Редактирование основных таблиц
                IsMainDataEditable(false);
            }
            else {
                //Таблица юзеров
                if (tcTableViewer.TabPages.Contains(tpUsersHiding))
                    tcTableViewer.TabPages.Remove(tpUsersHiding);
                //Редактирование основных таблиц
                IsMainDataEditable(true);
            }
        }

        //Конструктор (авторизация, инициализация таблиц)
        public MainForm() {
            InitializeComponent();
            //Аутентификация (регистрация)
            AuthForm authForm = new AuthForm();
            if (authForm.ShowDialog() == DialogResult.OK) {
                CurrentUser = authForm.AuthenticatedUser;
                lCurrentUserShowing.Text = CurrentUser.login;
                MessageBox.Show(string.Format("Добро пожаловать, {0} !", CurrentUser.login), "Приветствие");
            }
            else {
                Environment.Exit(0);
            }
            //Захватываем и убираем вкладку таблицы юзеров
            tpUsersHiding = tcTableViewer.TabPages["tpUsers"];
            tcTableViewer.TabPages.Remove(tpUsersHiding);
            //Определяем функционал в соответствии с правами юзера
            GiveUserHisFunctions();
            //Инициализация
            interfaceManager = new InterfaceManager();
            dataManager = new DataManager();
            using (var ctx = new DataContext()) {
                //Инициализируем таблицы
                interfaceManager.InitializeActorsTable(lvActors, ctx.actors);
                interfaceManager.InitializeFilmTable(lvFilms, ctx.films.ToList());
                interfaceManager.InitializeContractsTable(lvContracts, ctx.films_and_actors.ToList());
                interfaceManager.InitializeCompanyTable(lvCompanies, ctx.companies);
                interfaceManager.InitializeUsersTable(lvUsers, ctx.users);
                //Запоминаем названия стран из БД - для подсказки
                countyNames = new List<string>();
                foreach (var c in ctx.countries) {
                    countyNames.Add(c.name);
                }
                countyNames.Sort();
            }
        }

        //Смена пользователя
        private void bChangeUser_Click(object sender, EventArgs e) {
            AuthForm authForm = new AuthForm(CurrentUser);
            if (authForm.ShowDialog() != DialogResult.OK) {
                return;
            }
            CurrentUser = authForm.AuthenticatedUser;
            //Проверим, нет ли этого юзера в таблице
            if (authForm.IsUserNew) {
                //Добавляем в таблицу
                var lvUser = new ListViewItem(items: new[] {
                    CurrentUser.login,
                    Convert.ToBase64String(CurrentUser.password_hash),
                    CurrentUser.salt,
                    CurrentUser.registration_date.ToShortDateString(),
                    CurrentUser.role
                });
                lvUser.Tag = CurrentUser;
                interfaceManager.AddItemToTable(lvUsers, lvUser);
                interfaceManager.AutoResizeListViewColumns(lvCompanies);
            }
            lCurrentUserShowing.Text = CurrentUser.login;
            //Определяем функционал в соответствии с правами юзера
            GiveUserHisFunctions();
            //Приветствуем
            MessageBox.Show(string.Format("Добро пожаловать, {0} !", CurrentUser.login), "Приветствие");
        }

        //Добавление пользователя
        private void bAddUser_Click(object sender, EventArgs e) {
            var regForm = new RegForm();
            if (regForm.ShowDialog() == DialogResult.OK) {
                var addingUser = regForm.RegisteredUser;
                //Добавляем в таблицу
                var lvUser = new ListViewItem(items: new[] {
                    addingUser.login,
                    Convert.ToBase64String(addingUser.password_hash),
                    addingUser.salt,
                    addingUser.registration_date.ToShortDateString(),
                    addingUser.role
                });
                lvUser.Tag = addingUser;
                interfaceManager.AddItemToTable(lvUsers, lvUser);
                interfaceManager.AutoResizeListViewColumns(lvCompanies);
            }
        }

        //Удаление пользователя
        private void bDeleteUser_Click(object sender, EventArgs e) {
            foreach (ListViewItem selectedItem in lvUsers.SelectedItems) {
                var deletingUser = (user)selectedItem.Tag;
                if (deletingUser.id == CurrentUser.id) {
                    MessageBox.Show("Вы не можете удалить свой профиль!", "Удаление пользователя");
                    continue;
                }
                using (var ctx = new DataContext()) {
                    try {
                        ctx.users.Attach(deletingUser); //тип говорим, что через объект работаем с записью бд
                        ctx.users.Remove(deletingUser);
                        ctx.SaveChanges(); //сохраняем изменения в бд
                    }
                    catch (Exception exc) {
                        MessageBox.Show(exc.Message + "\n\nДействие не было выполнено", "Удаление пользователя");
                        return;
                    }
                    interfaceManager.DeleteItemFromTable(lvUsers, selectedItem); //удаляем из таблицы
                    interfaceManager.AutoResizeListViewColumns(lvFilms); //изменение размера колонок
                }
            }
        }

        //Редактирование пользователя
        private void bEditUser_Click(object sender, EventArgs e) {
            foreach (ListViewItem selectedItem in lvUsers.SelectedItems) {
                var editingUser = (user)selectedItem.Tag;
                var editForm = new UserEditForm(editingUser, CurrentUser);
                if (editForm.ShowDialog() == DialogResult.OK) {
                    user newUserData = editForm.NewUser;
                    using (var ctx = new DataContext()) {
                        try {
                            ctx.users.Attach(editingUser); //тип говорим, что через объект работаем с записью бд
                            editingUser.login = newUserData.login;
                            editingUser.password_hash = newUserData.password_hash;
                            editingUser.salt = newUserData.salt;
                            editingUser.registration_date = newUserData.registration_date;
                            editingUser.role = newUserData.role;
                            ctx.SaveChanges(); //сохраняем изменения в бд
                        }
                        catch (Exception exc) {
                            MessageBox.Show(exc.Message + "\n\nДействие не было выполнено", "Редактирование пользователя");
                            return;
                        }
                        interfaceManager.UpdateItemInTable(selectedItem, newUserData); //меняем в таблице
                        interfaceManager.AutoResizeListViewColumns(lvFilms); //изменение размера колонок
                    }
                }

            }
        }

        //+Добавление кинокомпании
        private void bAddCompany_Click(object sender, EventArgs e) {
            var addingForm = new CompanyEditForm("Добавление компании");
            if (addingForm.ShowDialog() == DialogResult.OK) {
                //Создаём новую компанию
                var addingCompany = new company {
                    name = addingForm.ComName,
                    foundation_year = addingForm.ComFoundationYear,
                    address = addingForm.ComAdress
                };
                //Добавляем компанию в БД
                if (dataManager.AddCompanyToDB(addingCompany) == -1) {
                    MessageBox.Show("Действие не было выполнено.", "Добавление кинокомпании");
                    return;
                }
                //Добавляем в таблицу
                var lvCom = new ListViewItem(items: new[] {
                    addingForm.ComName,
                    addingForm.ComFoundationYear.ToString(),
                    addingForm.ComAdress
                });
                lvCom.Tag = addingCompany.id; //id обновился при сохранении данных
                interfaceManager.AddItemToTable(lvCompanies, lvCom);
                interfaceManager.AutoResizeListViewColumns(lvCompanies);
            }
        }

        //+Удаление кинокомпании
        private void bDeleteCompany_Click(object sender, EventArgs e) {
            foreach (ListViewItem selectedItem in lvCompanies.SelectedItems) {
                int deletingCompanyId = (int)selectedItem.Tag;
                if (dataManager.DeleteCompanyFromDB(deletingCompanyId) == false) {
                    MessageBox.Show("Действие не было выполнено. Возможно, есть зависимые фильмы.", "Удаление компании");
                    return;
                }
                interfaceManager.DeleteItemFromTable(lvCompanies, selectedItem);  //удаляем из таблицы
                interfaceManager.AutoResizeListViewColumns(lvCompanies); //изменение размера колонок
            }
        }
        
        //+Редактирование компании
        private void bEditCompany_Click(object sender, EventArgs e) {
            foreach (ListViewItem selectedItem in lvCompanies.SelectedItems) {
                int thisCompanyId = (int)selectedItem.Tag;
                var thisCompany = dataManager.GetCompanyFromDB(thisCompanyId);
                var updatingForm = new CompanyEditForm("Редактирование компании", thisCompany);
                if (updatingForm.ShowDialog() == DialogResult.OK) {
                    bool isNewName = thisCompany.name != updatingForm.ComName;
                    var newCompanyData = new company {
                        name = updatingForm.ComName,
                        foundation_year = updatingForm.ComFoundationYear,
                        address = updatingForm.ComAdress
                    };
                    if (dataManager.EditCompanyInDB(thisCompanyId, newCompanyData) == false) {
                        MessageBox.Show("Действие не было выполнено.", "Редактирование компании");
                        return;
                    }
                    interfaceManager.UpdateItemInTable(selectedItem, newCompanyData);
                    interfaceManager.AutoResizeListViewColumns(lvCompanies);
                    //Если поменяли имя, меняем имя этой компании в таблице фильмов
                    if (isNewName) {
                        foreach (ListViewItem lvFilm in lvFilms.Items) {
                            using (var ctx = new DataContext()) {
                                var curFilm = ctx.films.Find((int)lvFilm.Tag);
                                if (curFilm.company != null)
                                    if (curFilm.company.id == thisCompany.id)
                                        lvFilm.SubItems[8].Text = newCompanyData.name;
                            }
                        }
                        interfaceManager.AutoResizeListViewColumns(lvFilms);
                    }
                }
            }
        }

        //+Добавление фильма !!! контекстное добавление компании
        private void bAddFilm_Click(object sender, EventArgs e) {
            //Вытаскиваем список компаний
            var companies = new List<company>();
            using (var ctx = new DataContext()) {
                foreach (var com in ctx.companies) {
                    companies.Add(com);
                }
            }
            companies.Sort((company a, company b) => a.name.CompareTo(b.name));

            var addingForm = new FilmEditForm("Добавление фильма", countyNames, companies);
            if (addingForm.ShowDialog() == DialogResult.OK) {
                //Добавляем компанию, если была введена новая
                if (addingForm.IsCompanyNew) {
                    if (dataManager.AddCompanyToDB(addingForm.FilmCompany) == -1) {
                        MessageBox.Show("Действие не было выполнено. Не удалось добавить компанию.", "Добавление фильма");
                        return;
                    }
                    //Добавляем в таблицу
                    var lvCom = new ListViewItem(items: new[] {
                    addingForm.FilmCompany.name,
                    "",
                    ""
                    });
                    lvCom.Tag = addingForm.FilmCompany.id;
                    interfaceManager.AddItemToTable(lvCompanies, lvCom);
                    interfaceManager.AutoResizeListViewColumns(lvCompanies);
                }
                //Создаём новый фильм
                var addingFilm = new film {
                    name = addingForm.FilmName,
                    year = addingForm.FilmYear,
                    country = addingForm.FilmCountryName,
                    budget = addingForm.FilmBudget,
                    age_limit = addingForm.FilmAgeLimit,
                    duration = addingForm.FilmDuration,
                    rating = addingForm.FilmRating,
                    genre = addingForm.FilmGenre,
                    company_id = addingForm.FilmCompany.id, //id обновилось при вставке компании, если компания новая
                    director = addingForm.FilmDirector,
                    composer = addingForm.FilmComposer
                };
                if (dataManager.AddFilmToDB(addingFilm) == -1) {
                    MessageBox.Show("Действие не было выполнено. Не удалось добавить фильм.", "Добавление фильма");
                    return;
                }
                //Добавляем фильм в таблицу
                var lvFilm = new ListViewItem(items: new[] {
                    addingForm.FilmName,
                    addingForm.FilmYear.ToString(),
                    addingForm.FilmCountryName,
                    addingForm.FilmBudget.ToString(),
                    addingForm.FilmAgeLimit.ToString(),
                    addingForm.FilmDuration.ToString(),
                    addingForm.FilmRating.ToString(),
                    addingForm.FilmGenre,
                    addingForm.FilmCompany.name,
                    addingForm.FilmDirector,
                    addingForm.FilmComposer
                });
                lvFilm.Tag = addingFilm.id;
                interfaceManager.AddItemToTable(lvFilms, lvFilm);
                interfaceManager.AutoResizeListViewColumns(lvFilms);
            }
        }

        //+Удаление фильма
        private void bDeleteFilm_Click(object sender, EventArgs e) {
            foreach (ListViewItem selectedItem in lvFilms.SelectedItems) {
                int thisFilmId = (int)selectedItem.Tag;
                if (dataManager.DeleteFilmFromDB(thisFilmId) == false) {
                    MessageBox.Show("Действие не было выполнено. Возможно, есть зависимые контракты.", "Удаление фильма");
                    return;
                }
                interfaceManager.DeleteItemFromTable(lvFilms, selectedItem); //удаляем из таблицы
                interfaceManager.AutoResizeListViewColumns(lvFilms); //изменение размера колонок
            }
        }

        //+Редактирование фильма !!! контекстное добавление компании
        private void bEditFilm_Click(object sender, EventArgs e) {
            //Вытаскиваем список компаний
            List<company> companies;
            using (var ctx = new DataContext()) {
                companies = ctx.companies.ToList();
            }
            companies.Sort((company a, company b) => a.name.CompareTo(b.name));

            foreach (ListViewItem selectedItem in lvFilms.SelectedItems) {
                int thisFilmId = (int)selectedItem.Tag;
                var thisFilm = dataManager.GetFilmFromDB(thisFilmId);
                var updatingForm = new FilmEditForm("Редактирование фильма", countyNames, companies, thisFilm, selectedItem.SubItems[8].Text);
                if (updatingForm.ShowDialog() == DialogResult.OK) {
                    //Добавляем новую компанию, если была указана новая
                    if (updatingForm.IsCompanyNew) {
                        if (dataManager.AddCompanyToDB(updatingForm.FilmCompany) == -1) {
                            MessageBox.Show("Действие не было выполнено. Не удалось добавить компанию.", "Редактирование фильма");
                            return;
                        }
                        //И в таблицу
                        var lvCom = new ListViewItem(items: new[] {
                            updatingForm.FilmCompany.name,
                            "",
                            ""
                        });
                        lvCom.Tag = updatingForm.FilmCompany.id;
                        interfaceManager.AddItemToTable(lvCompanies, lvCom);
                        interfaceManager.AutoResizeListViewColumns(lvCompanies);
                    }
                    //Создаём фильм с новыми данными
                    var newFilmData = new film {
                        name = updatingForm.FilmName,
                        year = updatingForm.FilmYear,
                        country = updatingForm.FilmCountryName,
                        budget = updatingForm.FilmBudget,
                        age_limit = updatingForm.FilmAgeLimit,
                        duration = updatingForm.FilmDuration,
                        rating = updatingForm.FilmRating,
                        genre = updatingForm.FilmGenre,
                        company_id = updatingForm.FilmCompany.id, //id обновилось при вставке компании, если компания новая
                        director = updatingForm.FilmDirector,
                        composer = updatingForm.FilmComposer
                    };
                    //Обновляем фильм в БД
                    dataManager.EditFilmInDB(thisFilmId, newFilmData);
                    //Обновляем фильм в таблице
                    interfaceManager.UpdateItemInTable(selectedItem, newFilmData, updatingForm.FilmCompany.name);
                    interfaceManager.AutoResizeListViewColumns(lvFilms);
                    //Обновляем данные в таблице контрактов
                    //Если поменяли название и год - меняем запись там
                    if (newFilmData.name != thisFilm.name || newFilmData.year != thisFilm.year) {
                        foreach (ListViewItem lvContract in lvContracts.Items) {
                            var curContractPK = (ContractPrimaryKey)lvContract.Tag;
                            var curContract = dataManager.GetContractFromDB(curContractPK);
                            if (curContract.film_id == thisFilm.id)
                                lvContract.SubItems[0].Text = newFilmData.ToString();
                        }
                        interfaceManager.AutoResizeListViewColumns(lvContracts);
                    }
                }
            }
        }

        //+Добавление актёра
        private void bAddActor_Click(object sender, EventArgs e) {
            var addingForm = new ActorEditForm("Добавление актёра", countyNames);
            if (addingForm.ShowDialog() == DialogResult.OK) {
                //Создаём нового актёра
                var addingActor = new actor {
                    name = addingForm.ActorName,
                    birthday = addingForm.ActorBirthDay,
                    country = addingForm.ActorCountry,
                    description = addingForm.ActorDescription
                };
                //Добавляем актёра в БД
                if (dataManager.AddActorToDB(addingActor) == -1) {
                    MessageBox.Show("Действие не было выполнено.", "Добавление актёра");
                    return;
                }
                //Добавляем в таблицу
                var lvActor = new ListViewItem(items: new[] {
                    addingForm.ActorName,
                    addingForm.ActorBirthDay.ToShortDateString(),
                    addingForm.ActorCountry,
                    addingForm.ActorDescription
                });
                lvActor.Tag = addingActor.id;
                interfaceManager.AddItemToTable(lvActors, lvActor);
                interfaceManager.AutoResizeListViewColumns(lvActors);
            }
        }

        //+Удаление актёра
        private void bDeleteActor_Click(object sender, EventArgs e) {
            foreach (ListViewItem selectedItem in lvActors.SelectedItems) {
                int deletingActorId = (int)selectedItem.Tag;
                if (dataManager.DeleteActorFromDB(deletingActorId) == false) {
                    MessageBox.Show("Действие не было выполнено. Возможно, есть зависимые контракты.", "Удаление актёра");
                    return;
                }
                interfaceManager.DeleteItemFromTable(lvActors, selectedItem); //удаляем из таблицы
                interfaceManager.AutoResizeListViewColumns(lvActors); //изменение размера колонок
            }
        }

        //+Редактирование актёра
        private void bEditActor_Click(object sender, EventArgs e) {
            foreach (ListViewItem selectedItem in lvActors.SelectedItems) {
                int thisActorId = (int)selectedItem.Tag;
                var thisActor = dataManager.GetActorFromDB(thisActorId);
                var updatingForm = new ActorEditForm("Редактирование актёра", countyNames, thisActor);
                if (updatingForm.ShowDialog() == DialogResult.OK) {
                    var newActorData = new actor {
                        name = updatingForm.ActorName,
                        birthday = updatingForm.ActorBirthDay,
                        country = updatingForm.ActorCountry,
                        description = updatingForm.ActorDescription
                    };
                    if (dataManager.EditActorInDB(thisActorId, newActorData) == false) {
                        MessageBox.Show("Действие не было выполнено.", "Редактирование актёра");
                        return;
                    } 
                    interfaceManager.UpdateItemInTable(selectedItem, newActorData);
                    interfaceManager.AutoResizeListViewColumns(lvActors);
                    //Обновляем данные в таблице контрактов
                    //Если поменяли имя, дату рождения или страну - меняем запись там
                    if (newActorData.name != thisActor.name || newActorData.birthday != thisActor.birthday || newActorData.country != thisActor.country) {
                        foreach (ListViewItem lvContract in lvContracts.Items) {
                            var curContractPK = (ContractPrimaryKey)lvContract.Tag;
                            var curContract = dataManager.GetContractFromDB(curContractPK);
                            if (curContract.actor_id == thisActorId)
                                lvContract.SubItems[1].Text = newActorData.ToString();
                        }
                        interfaceManager.AutoResizeListViewColumns(lvContracts);
                    }
                }
            }
        }

        //+Добавление контракта !!! контекстное добавление фильмов и актёров
        private void bAddContract_Click(object sender, EventArgs e) {
            //Вытаскиваем списки фильмов и актёров
            List<film> films;
            List<actor> actors;
            using (var ctx = new DataContext()) {
                films = ctx.films.ToList();
                actors = ctx.actors.ToList();
            }
            films.Sort((film a, film b) => a.name.CompareTo(b.name));
            actors.Sort((actor a, actor b) => a.name.CompareTo(b.name));

            var addingForm = new ContractEditForm("Добавление контракта", films, actors);
            if (addingForm.ShowDialog() == DialogResult.OK) {
                //Добавляем фильм, если был указан новый
                if (addingForm.IsFilmNew) {
                    if (dataManager.AddFilmToDB(addingForm.NewContrFilm) == -1) {
                        MessageBox.Show("Действие не было выполнено. Не удалось добавить фильм.", "Добавление контракта");
                        return;
                    }
                    //И в таблицу
                    var lvFilm = new ListViewItem(items: new[] {
                        addingForm.NewContrFilm.name,
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        "",
                        ""
                    });
                    lvFilm.Tag = addingForm.NewContrFilm.id; //обновилось при добавлении
                    interfaceManager.AddItemToTable(lvFilms, lvFilm);
                    interfaceManager.AutoResizeListViewColumns(lvFilms);
                }
                //Добавляем актёра, если был указан новый
                if (addingForm.IsActorNew) {
                    if (dataManager.AddActorToDB(addingForm.NewContrActor) == -1) {
                        MessageBox.Show("Действие не было выполнено. Не удалось добавить актёра.", "Добавление контракта");
                        return;
                    }
                    //И в таблицу
                    var lvActor = new ListViewItem(items: new[] {
                    addingForm.NewContrActor.name,
                    "",
                    "",
                    ""
                    });
                    lvActor.Tag = addingForm.NewContrActor.id; //обновилось при добавлении
                    interfaceManager.AddItemToTable(lvActors, lvActor);
                    interfaceManager.AutoResizeListViewColumns(lvActors);
                }
                //Создаём новый контракт
                var addingContract = new films_and_actors {
                    film_id = addingForm.NewContrFilm.id,
                    actor_id = addingForm.NewContrActor.id,
                    actor_honorarium = addingForm.NewContrHonorarium
                };
                //Добавляем контракт в БД
                if (dataManager.AddContractToDB(addingContract) == null) {
                    MessageBox.Show("Действие не было выполнено.", "Добавление контракта");
                    return;
                }
                //Добавляем в таблицу
                var lvContract = new ListViewItem(items: new[] {
                    addingForm.NewContrFilm.ToString(),
                    addingForm.NewContrActor.ToString(),
                    addingForm.NewContrHonorarium.ToString()
                });
                lvContract.Tag = new ContractPrimaryKey { FilmId = addingContract.film_id, ActorId = addingContract.actor_id };
                interfaceManager.AddItemToTable(lvContracts, lvContract);
                interfaceManager.AutoResizeListViewColumns(lvContracts);
            }
        }

        //+Удаление контракта
        private void bDeleteContract_Click(object sender, EventArgs e) {
            foreach (ListViewItem selectedItem in lvContracts.SelectedItems) {
                var thisContractPK = (ContractPrimaryKey)selectedItem.Tag;
                if (dataManager.DeleteContractFromDB(thisContractPK) == false) {
                    MessageBox.Show("Действие не было выполнено.", "Удаление контракта");
                    return;
                }
                interfaceManager.DeleteItemFromTable(lvContracts, selectedItem); //удаляем из таблицы
                interfaceManager.AutoResizeListViewColumns(lvContracts); //изменение размера колонок
            }
        }

        //+Редактирование контрактов !!! Контекстное добавление фильмов и актёров
        private void bEditContract_Click(object sender, EventArgs e) {
            //Вытаскиваем списки фильмов и актёров
            List<film> films;
            List<actor> actors;
            using (var ctx = new DataContext()) {
                films = ctx.films.ToList();
                actors = ctx.actors.ToList();
            }
            films.Sort((film a, film b) => a.name.CompareTo(b.name));
            actors.Sort((actor a, actor b) => a.name.CompareTo(b.name));

            foreach (ListViewItem selectedItem in lvContracts.SelectedItems) {
                ContractPrimaryKey thisContractPK = (ContractPrimaryKey)selectedItem.Tag;
                var thisContract = dataManager.GetContractFromDB(thisContractPK);
                var updatingForm = new ContractEditForm("Редактирование контракта", films, actors, thisContract, selectedItem.SubItems[0].Text, 
                    selectedItem.SubItems[1].Text);
                if (updatingForm.ShowDialog() == DialogResult.OK) {
                    //Добавляем фильм, если был указан новый
                    if (updatingForm.IsFilmNew) {
                        if (dataManager.AddFilmToDB(updatingForm.NewContrFilm) == -1) {
                            MessageBox.Show("Действие не было выполнено. Не удалось добавить фильм.", "Добавление контракта");
                            return;
                        }
                        //И в таблицу
                        var lvFilm = new ListViewItem(items: new[] {
                            updatingForm.NewContrFilm.name,
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            ""
                        });
                        lvFilm.Tag = updatingForm.NewContrFilm.id; //обновилось при добавлении
                        interfaceManager.AddItemToTable(lvFilms, lvFilm);
                        interfaceManager.AutoResizeListViewColumns(lvFilms);
                    }
                    //Добавляем актёра, если был указан новый
                    if (updatingForm.IsActorNew) {
                        if (dataManager.AddActorToDB(updatingForm.NewContrActor) == -1) {
                            MessageBox.Show("Действие не было выполнено. Не удалось добавить актёра.", "Добавление контракта");
                            return;
                        }
                        //И в таблицу
                        var lvActor = new ListViewItem(items: new[] {
                            updatingForm.NewContrActor.name,
                            "",
                            "",
                            ""
                        });
                        lvActor.Tag = updatingForm.NewContrActor.id; //обновилось при добавлении
                        interfaceManager.AddItemToTable(lvActors, lvActor);
                        interfaceManager.AutoResizeListViewColumns(lvActors);
                    }
                    //Обновляем контракт в БД
                    var newContractData = new films_and_actors {
                        film_id = updatingForm.NewContrFilm.id,
                        actor_id = updatingForm.NewContrActor.id,
                        actor_honorarium = updatingForm.NewContrHonorarium
                    };
                    if (dataManager.EditContractInDB(thisContractPK, newContractData) == false) {
                        MessageBox.Show("Действие не было выполнено.", "Редактирование контракта");
                        return;
                    }
                    //Обновляем контракт в таблице
                    interfaceManager.UpdateItemInTable(selectedItem, newContractData, updatingForm.NewContrFilm, updatingForm.NewContrActor);
                    interfaceManager.AutoResizeListViewColumns(lvContracts);
                }
            }
        }

        //Найти все фильмы актёра
        private void bFindFilmsForActor_Click(object sender, EventArgs e) {
            var dataManager = new DataManager();
            //Вытаскиваем списки актёров
            List<actor> actors;
            using (var ctx = new DataContext()) {
                actors = ctx.actors.ToList();
            }
            actors.Sort((actor a, actor b) => a.name.CompareTo(b.name));

            var searchingForm = new SearchObjectSelectingForm(actors);
            if (searchingForm.ShowDialog() != DialogResult.OK)
                return;
            SearchResultsForm resultForm;
            using (var ctx = new DataContext()) {
                resultForm = new SearchResultsForm(dataManager.GetFilmsForActors(ctx, (actor)searchingForm.SelectedItem));
            }
            resultForm.Show();
        }

        //Найти всех актёров фильма
        private void bFindActorsForFilm_Click(object sender, EventArgs e) {
            var dataManager = new DataManager();
            //Вытаскиваем списки фильмов
            List<film> films;
            using (var ctx = new DataContext()) {
                films = ctx.films.ToList();
            }
            films.Sort((film a, film b) => a.name.CompareTo(b.name));

            var searchingForm = new SearchObjectSelectingForm(films);
            if (searchingForm.ShowDialog() != DialogResult.OK)
                return;
            SearchResultsForm resultForm;
            using (var ctx = new DataContext()) {
                resultForm = new SearchResultsForm(dataManager.GetActorsForFilm(ctx, (film)searchingForm.SelectedItem));
            }
            resultForm.Show();
        }
    }
}