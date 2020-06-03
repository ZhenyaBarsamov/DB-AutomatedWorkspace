using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ARM {
    public partial class FilmEditForm : Form {
        //Метод настройки формы
        private void SetUpForm(string headerText, List<string> countryNames, List<company> companies) {
            //Задаём заголовок формы (редактирование/добавление)
            this.Text = headerText;
            //Задаём список стран
            this.cbFilmCountry.DataSource = countryNames;
            //Задаём список возрастных ограничений
            var ageLimits = new List<string>();
            for (int age = 0; age <= 18; age++)
                ageLimits.Add(age.ToString());
            this.cbFilmAgeLimit.DataSource = ageLimits;
            //Задаём список рейтингов
            var ratings = new List<string>();
            for (int rating = 0; rating <= 10; rating++)
                ratings.Add(rating.ToString());
            this.cbFilmRating.DataSource = ratings;
            //Задаём список компаний
            this.cbFilmCompany.DataSource = companies;
        }

        //Конструктор для пустой формы
        public FilmEditForm(string headerText, List<string> countryNames, List<company> companies) {
            InitializeComponent();
            SetUpForm(headerText, countryNames, companies);
        }

        //Конструктор для инициализированных полей
        public FilmEditForm(string headerText, List<string> countryNames, List<company> companies, film editingFilm, string filmCompanyName) {
            InitializeComponent();
            SetUpForm(headerText, countryNames, companies);
            //Заполнение полей
            tbFilmName.Text = editingFilm.name;
            tbFilmYear.Text = editingFilm.year.ToString();
            cbFilmCountry.Text = editingFilm.country;
            tbFilmBudget.Text = editingFilm.budget.ToString();
            cbFilmAgeLimit.Text = editingFilm.age_limit.ToString();
            tbFilmDuration.Text = editingFilm.duration.ToString();
            cbFilmRating.Text = editingFilm.rating.ToString();
            tbFilmGenre.Text = editingFilm.genre;
            cbFilmCompany.Text = filmCompanyName;
            tbFilmDirector.Text = editingFilm.director;
            tbFilmComposer.Text = editingFilm.composer;
        }

        //Свойства формы
        public string FilmName { get; private set; }
        public int FilmYear { get; private set; }
        public string FilmCountryName { get; private set; }
        public decimal FilmBudget { get; private set; }
        public int FilmAgeLimit { get; private set; }
        public int FilmDuration { get; private set; }
        public int FilmRating { get; private set; }
        public string FilmGenre { get; private set; }
        public company FilmCompany { get; private set; }
        public string FilmDirector { get; private set; }
        public string FilmComposer { get; private set; }
        public bool IsCompanyNew { get; private set; } //Для контекстного добавления компании

        //Отмена изменений
        private void bFilmCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Сохранение изменений
        private void bFilmSave_Click(object sender, EventArgs e) {
            decimal decimalRez; //Для парсинга
            int integerRez;

            if (string.IsNullOrWhiteSpace(tbFilmName.Text)) {
                MessageBox.Show("Введите название фильма!");
                return;
            }
            FilmName = tbFilmName.Text;

            if (!int.TryParse(tbFilmYear.Text, out integerRez)) {
                MessageBox.Show("Год производства введён неверно!");
                return;
            }
            FilmYear = integerRez;

            if (string.IsNullOrWhiteSpace(cbFilmCountry.Text)) {
                MessageBox.Show("Не выбрана страна производства фильма!");
                return;
            }
            FilmCountryName = cbFilmCountry.Text;

            if (!decimal.TryParse(tbFilmBudget.Text, out decimalRez)) {
                MessageBox.Show("Бюджет введён неверно!");
                return;
            }
            FilmBudget = decimalRez;

            FilmAgeLimit = int.Parse(cbFilmAgeLimit.Text);

            if (!int.TryParse(tbFilmDuration.Text, out integerRez)) {
                MessageBox.Show("Продолжительность введена неверно!");
                return;
            }
            FilmDuration = integerRez;

            FilmRating = int.Parse(cbFilmRating.Text);

            if (string.IsNullOrWhiteSpace(tbFilmGenre.Text)) {
                MessageBox.Show("Введите жанр фильма!");
                return;
            }
            FilmGenre = tbFilmGenre.Text;

            if (cbFilmCompany.Text == "") {
                MessageBox.Show("Не выбрана кинокомпания!\nЕсли нет нужной, вы можете ввести название новой кинокомпании");
                return;
            }
            //Если выбрана существующая компания - её берём. Нет - отмечаем это и создаём новую
            if (cbFilmCompany.SelectedItem != null) {
                FilmCompany = (company)cbFilmCompany.SelectedItem;
                IsCompanyNew = false;
            }
            else {
                FilmCompany = new company {
                    name = cbFilmCompany.Text
                };
                IsCompanyNew = true;
            }

            if (string.IsNullOrWhiteSpace(tbFilmDirector.Text)) {
                MessageBox.Show("Введите режиссёра фильма!");
                return;
            }
            FilmDirector = tbFilmDirector.Text;

            if (string.IsNullOrWhiteSpace(tbFilmComposer.Text)) {
                MessageBox.Show("Введите композитора фильма");
                return;
            }
            FilmComposer = tbFilmComposer.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}