using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ARM.MyWorkClasses {
    class InterfaceManager {
        //Автоматическое изменение размера колонок
        public void AutoResizeListViewColumns(ListView listView) {
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //Проверка существования юзера в таблице интерфейса
        public bool IsUserInTable(ListView lvUsers, user u) {
            foreach (ListViewItem lvUser in lvUsers.Items) {
                if (((user)lvUser.Tag).id == u.id)
                    return true;
            }
            return false;
        }

        //Добавление объекта в указанный ListView
        public void AddItemToTable(ListView listView, ListViewItem addingItem) {
            listView.Items.Add(addingItem);
        }

        //Удаление объекта из указанного ListView
        public void DeleteItemFromTable(ListView listView, ListViewItem deletingItem) {
            listView.Items.Remove(deletingItem);
        }



        //-------------------------------ИНИЦИАЛИЗАЦИЯ ТАБЛИЦ ИНТЕРФЕЙСА------------------------------
        //Инициализация таблицы фильмов
        public void InitializeFilmTable(ListView lvFilms, IEnumerable<film> films) {
            //Очищаем элемент управления
            lvFilms.Clear();
            //Добавляем колонки
            lvFilms.Columns.Add("Название");
            lvFilms.Columns.Add("Год производства");
            lvFilms.Columns.Add("Страна");
            lvFilms.Columns.Add("Бюджет");
            lvFilms.Columns.Add("Возрастное ограничение");
            lvFilms.Columns.Add("Продолжительность (мин)");
            lvFilms.Columns.Add("Рейтинг");
            lvFilms.Columns.Add("Жанр");
            lvFilms.Columns.Add("Кинокомпания");
            lvFilms.Columns.Add("Режиссёр");
            lvFilms.Columns.Add("Композитор");
            //Заполнение
            foreach (var film in films) {
                var lvFilm = new ListViewItem(items: new[] {
                    film.name,
                    film.year.ToString(),
                    film.country,
                    film.budget.ToString(),
                    film.age_limit.ToString(),
                    film.duration.ToString(),
                    film.rating.ToString(),
                    film.genre,
                    film.company != null ? film.company.name : "",
                    film.director,
                    film.composer
                });
                lvFilm.Tag = film.id; //сопоставимый со строкой объект - его ключ
                lvFilms.Items.Add(lvFilm);
            }
            //Авторазмер
            AutoResizeListViewColumns(lvFilms);
        }

        //Инициализация таблицы кинокомпаний
        public void InitializeCompanyTable(ListView lvCompanies, IEnumerable<company> companies) {
            //Очищаем элемент управления
            lvCompanies.Clear();
            //Добавляем колонки
            lvCompanies.Columns.Add("Название");
            lvCompanies.Columns.Add("Год основания");
            lvCompanies.Columns.Add("Адрес");
            //Заполнение
            foreach (var company in companies) {
                var lvCompany = new ListViewItem(items: new[] {
                    company.name,
                    company.foundation_year.ToString(),
                    company.address
                });
                lvCompany.Tag = company.id; //сопоставимый со строкой объект - его ключ
                lvCompanies.Items.Add(lvCompany);
            }
            //Авторазмер
            AutoResizeListViewColumns(lvCompanies);
        }

        //Инициализация таблицы актёров
        public void InitializeActorsTable(ListView lvActors, IEnumerable<actor> actors) {
            //Очищаем элемент управления
            lvActors.Clear();
            //Добавляем колонки
            lvActors.Columns.Add("Имя");
            lvActors.Columns.Add("Дата рождения");
            lvActors.Columns.Add("Страна");
            lvActors.Columns.Add("Описание");
            //Заполнение
            foreach (var actor in actors) {
                var lvActor = new ListViewItem(items: new[] {
                    actor.name,
                    actor.birthday.HasValue ? actor.birthday.Value.ToShortDateString() : "",
                    actor.country,
                    actor.description
                });
                lvActor.Tag = actor.id; //сопоставимый со строкой объект - его ключ
                lvActors.Items.Add(lvActor);
            }
            //Авторазмер
            AutoResizeListViewColumns(lvActors);
        }

        //Инициализация таблицы контрактов
        public void InitializeContractsTable(ListView lvContracts, IEnumerable<films_and_actors> contracts) {
            //Очищаем элемент управления
            lvContracts.Clear();
            //Добавляем колонки
            lvContracts.Columns.Add("Фильм");
            lvContracts.Columns.Add("Актёр");
            lvContracts.Columns.Add("Гонорар актёра");
            //Заполнение
            foreach (var contract in contracts) {
                var lvContract = new ListViewItem(items: new[] {
                    contract.film.ToString(),
                    contract.actor.ToString(),
                    contract.actor_honorarium.ToString()
                });
                lvContract.Tag = new ContractPrimaryKey { FilmId = contract.film_id, ActorId = contract.actor_id}; //составной первичный ключ
                lvContracts.Items.Add(lvContract);
            }
            //Авторазмер
            AutoResizeListViewColumns(lvContracts);
        }

        //Инициализация таблицы пользователей
        public void InitializeUsersTable(ListView lvUsers, IEnumerable<user> users) {
            //Очищаем элемент управления
            lvUsers.Clear();
            //Добавляем колонки
            lvUsers.Columns.Add("Логин");
            lvUsers.Columns.Add("Хэш пароля");
            lvUsers.Columns.Add("Соль");
            lvUsers.Columns.Add("Дата регистрации");
            lvUsers.Columns.Add("Роль");
            //Заполнение
            foreach (var user in users) {
                var lvUser = new ListViewItem(items: new[] {
                    user.login,
                    Convert.ToBase64String(user.password_hash),
                    user.salt,
                    user.registration_date.ToShortDateString(),
                    user.role
                });
                lvUser.Tag = user; //сопоставимый со строкой объект - пользователь
                lvUsers.Items.Add(lvUser);
            }
            //Авторазмер
            AutoResizeListViewColumns(lvUsers);
        }
        //--------------------------------------------------------------------------------------------



        //----------------------------------ОБНОВЛЕНИЕ СТРОК ТАБЛИЦЫ----------------------------------
        //Обновление указанного объекта ListView
        public void UpdateItemInTable(ListViewItem item, company com) {
            item.SubItems[0].Text = com.name;
            item.SubItems[1].Text = com.foundation_year.ToString();
            item.SubItems[2].Text = com.address;
        }

        //Обновление указанного объекта ListView
        public void UpdateItemInTable(ListViewItem item, film f, string flimCompanyName) {
            item.SubItems[0].Text = f.name;
            item.SubItems[1].Text = f.year.ToString();
            item.SubItems[2].Text = f.country;
            item.SubItems[3].Text = f.budget.ToString();
            item.SubItems[4].Text = f.age_limit.ToString();
            item.SubItems[5].Text = f.duration.ToString();
            item.SubItems[6].Text = f.rating.ToString();
            item.SubItems[7].Text = f.genre;
            item.SubItems[8].Text = flimCompanyName;
            item.SubItems[9].Text = f.director;
            item.SubItems[10].Text = f.composer;
        }

        //Обновление указанного объекта ListView
        public void UpdateItemInTable(ListViewItem item, films_and_actors contract, film f, actor a) {
            item.SubItems[0].Text = f.ToString();
            item.SubItems[1].Text = a.ToString();
            item.SubItems[2].Text = contract.actor_honorarium.ToString();
            item.Tag = new ContractPrimaryKey { FilmId = contract.film_id, ActorId = contract.actor_id }; //т.к. контракты мы пересоздаём
        }

        //Обновление указанного объекта ListView
        public void UpdateItemInTable(ListViewItem item, actor a) {
            item.SubItems[0].Text = a.name;
            item.SubItems[1].Text = a.birthday.HasValue ? a.birthday.Value.ToShortDateString() : null;
            item.SubItems[2].Text = a.country;
            item.SubItems[3].Text = a.description;
        }

        //Обновление указанного объекта ListView
        public void UpdateItemInTable(ListViewItem item, user u) {
            item.SubItems[0].Text = u.login;
            item.SubItems[1].Text = Convert.ToBase64String(u.password_hash);
            item.SubItems[2].Text = u.salt;
            item.SubItems[3].Text = u.registration_date.ToShortDateString();
            item.SubItems[4].Text = u.role;
        }
        //--------------------------------------------------------------------------------------------
    }
}
