using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ARM {
    public partial class ActorEditForm : Form {
        //Метод настройки формы
        private void SetUpForm(string headerText, List<string> countryNames) {
            //Задаём заголовок формы (редактирование/добавление)
            this.Text = headerText;
            //Задаём список стран
            this.cbActorCountry.DataSource = countryNames;
        }

        //Свойства формы
        public string ActorName { get; private set; }
        public DateTime ActorBirthDay { get; private set; }
        public string ActorCountry { get; private set; }
        public string ActorDescription { get; private set; }

        //Конструктор для пустой формы
        public ActorEditForm(string headerText, List<string> countryNames) {
            InitializeComponent();
            SetUpForm(headerText, countryNames);
        }

        //Конструктор для инициализации полей
        public ActorEditForm(string headerText, List<string> countryNames, actor editingActor) {
            InitializeComponent();
            SetUpForm(headerText, countryNames);
            //Заполнение полей
            tbActorName.Text = editingActor.name;
            dtpActorBirthday.Value = editingActor.birthday ?? dtpActorBirthday.MinDate;
            cbActorCountry.Text = editingActor.country;
            tbActorDescription.Text = editingActor.description;
        }

        

        //Отмена изменений
        private void bActorCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //Принять изменения
        private void bActorSave_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(tbActorName.Text)) {
                MessageBox.Show("Введите имя актёра!");
                return;
            }
            ActorName = tbActorName.Text;

            ActorBirthDay = dtpActorBirthday.Value;

            if (string.IsNullOrWhiteSpace(cbActorCountry.Text)) {
                MessageBox.Show("Не выбрана страна актёра!");
                return;
            }
            ActorCountry = cbActorCountry.Text;

            if (string.IsNullOrWhiteSpace(tbActorDescription.Text)) {
                MessageBox.Show("Введите описание актёра!");
                return;
            }
            ActorDescription = tbActorDescription.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
