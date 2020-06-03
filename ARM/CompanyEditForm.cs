using System;
using System.Windows.Forms;

namespace ARM {
    public partial class CompanyEditForm : Form {
        //Метод для настройки формы
        private void SetUpForm(string headerText) {
            //Задаём заголовок формы (редактирование/добавление)
            this.Text = headerText;
        }

        //Конструктор для пустой формы
        public CompanyEditForm(string headerText) {
            InitializeComponent();
            SetUpForm(headerText);
        }

        //Конструтор для инициализации полей формы
        public CompanyEditForm(string headerText, company editingCompany) {
            InitializeComponent();
            SetUpForm(headerText);
            //Заполняем поля
            tbCompanyName.Text = editingCompany.name;
            tbCompanyFoundationYear.Text = editingCompany.foundation_year.ToString();
            tbCompanyAdress.Text = editingCompany.address;
        }

        //Свойства формы
        public string ComName { get; private set; }
        public int ComFoundationYear { get; private set; }
        public string ComAdress { get; private set; }

        //Отмена изменений
        private void bCompanyCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Сохранение изменений
        private void bCompanySave_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(tbCompanyName.Text)) {
                MessageBox.Show("Заполните поле имени!");
                return;
            }
            ComName = tbCompanyName.Text;

            if (!int.TryParse(tbCompanyFoundationYear.Text, out int intYear)) {
                MessageBox.Show("Дата основания введена неверно!");
                return;
            }
            ComFoundationYear = intYear;

            if (string.IsNullOrWhiteSpace(tbCompanyAdress.Text)) {
                MessageBox.Show("Заполните поле адреса!");
                return;
            }
            ComAdress = tbCompanyAdress.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
