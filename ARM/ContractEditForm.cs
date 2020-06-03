using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ARM {
    public partial class ContractEditForm : Form {
        //Метод настройки формы
        private void SetUpForm(string headerText, List<film> films, List<actor> actors) {
            //Задаём заголовок формы (редактирование/добавление)
            Text = headerText;
            //Задаём список фильмов
            cbFilm.DataSource = films;
            //Задаём список актёров
            cbActor.DataSource = actors;
        }

        //Конструктор для пустой формы
        public ContractEditForm(string headerText, List<film> films, List<actor> actors) {
            InitializeComponent();
            SetUpForm(headerText, films, actors);
        }

        //Конструктор для инициализированных полей
        public ContractEditForm(string headerText, List<film> films, List<actor> actors, films_and_actors contract, string filmStr, string actorStr) {
            InitializeComponent();
            SetUpForm(headerText, films, actors);
            cbFilm.Text = filmStr;
            cbActor.Text = actorStr;
            tbActorHonorarium.Text = contract.actor_honorarium.HasValue ? contract.actor_honorarium.Value.ToString() : "";
        }

        //Свойства формы
        public film NewContrFilm { get; private set; }
        public actor NewContrActor { get; private set; }
        public decimal NewContrHonorarium { get; private set; }
        public bool IsFilmNew { get; private set; } //для контекстного добавления фильма
        public bool IsActorNew { get; private set; } //и актёра

        //Отмена изменений
        private void bActorCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //Принять изменения
        private void bActorSave_Click(object sender, EventArgs e) {
            //Фильм
            if (cbFilm.Text == "") {
                MessageBox.Show("Не выбран фильм!\nЕсли нет нужного, вы можете ввести название нового фильма");
                return;
            }
            //Если выбран существующий - его берём. Нет - отмечаем это и создаём новый
            if (cbFilm.SelectedItem != null) {
                NewContrFilm = (film)cbFilm.SelectedItem;
                IsFilmNew = false;
            }
            else {
                NewContrFilm = new film {
                    name = cbFilm.Text
                };
                IsFilmNew = true;
            }

            //Актёр
            if (cbActor.Text == "") {
                MessageBox.Show("Не выбран актёр!\nЕсли нет нужного, вы можете ввести имя нового актёра");
                return;
            }
            //Если выбран существующий - его берём. Нет - отмечаем это и создаём новый
            if (cbActor.SelectedItem != null) {
                NewContrActor = (actor)cbActor.SelectedItem;
                IsActorNew = false;
            }
            else {
                NewContrActor = new actor {
                    name = cbActor.Text
                };
                IsActorNew = true;
            }


            decimal decimalRez;
            if (!decimal.TryParse(tbActorHonorarium.Text, out decimalRez)) {
                MessageBox.Show("Гонорар введён неверно!");
                return;
            }
            NewContrHonorarium = decimalRez;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
