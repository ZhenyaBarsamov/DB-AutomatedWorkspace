using System;
using System.Windows.Forms;
using ARM.MyWorkClasses;

namespace ARM {
    public partial class RegForm : Form {
        //Поля
        public string Login { get; private set; }
        private string Password { get; set; }
        public user RegisteredUser { get; private set; }

        //Класс для работы с данными юзера
        UsersManager usersManager = new UsersManager();
        
        //Конструктор для регистрации
        public RegForm() {
            InitializeComponent();
        }

        //Отмена регистрации
        private void bCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        //Регистрация
        private void bApply_Click(object sender, EventArgs e) {
            //Убираем пробелы с концов
            tbLogin.Text = tbLogin.Text.Trim();
            //Проверка правильности ввода
            if (string.IsNullOrWhiteSpace(tbLogin.Text)) {
                MessageBox.Show("Логин не может быть пустым или состоять из пробелов!", "Регистрация");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPassword.Text)) {
                MessageBox.Show("Пароль не может быть пустым или состоять из пробелов!", "Регистрация");
                return;
            }
            if (usersManager.GetPasswordEvaluation(tbPassword.Text) < 1) {
                MessageBox.Show("Пароль слишком простой! Пожалуйста, придумайте новый!", "Регистрация");
                return;
            }
            Login = tbLogin.Text;
            Password = tbPassword.Text;
            //Работаем с БД
            using (var ctx = new DataContext()) {
                //Существует ли юзер с таким логином?
                user thisUser = usersManager.IsUserLoginExists(ctx.users, Login);
                if (thisUser != null) {
                    MessageBox.Show("Пользователь с таким логином уже существует!", "Регистрация");
                    return;
                }
                //Получаем соль
                string salt = usersManager.GetNewSalt();
                //Вычисляем хэш
                byte[] passwordHash = usersManager.GetPasswordHash(Password + salt);
                //Добавляем юзера
                thisUser = new user {
                    login = Login,
                    password_hash = passwordHash,
                    salt = salt,
                    role = "operator",
                    registration_date = DateTime.Now.Date
                };
                try {
                    ctx.users.Add(thisUser);
                    ctx.SaveChanges();
                }
                catch (Exception exc) {
                    MessageBox.Show(exc.Message + "\n\nДействие не было выполнено", "Регистрация");
                    return;
                }
                RegisteredUser = thisUser;
            }
            //Успешно
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
