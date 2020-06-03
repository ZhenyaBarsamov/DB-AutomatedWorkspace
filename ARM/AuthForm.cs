using System;
using System.Linq;
using System.Windows.Forms;
using ARM.MyWorkClasses;

namespace ARM {
    public partial class AuthForm : Form {
        //Поля
        public string Login { get; private set; }
        private string Password { get; set; }
        public bool IsUserNew { get; private set; } //Был ли аутентифицированный юзер зарегистрированным
        public user AuthenticatedUser { get; private set; } //новый юзер
        public user CurrentUser { get; private set; } //текущий юзер
        //Класс для работы с данными юзера
        UsersManager usersManager;

        //Конструктор для аутентификации
        public AuthForm() {
            InitializeComponent();
            usersManager = new UsersManager();
        }

        //Конструтор для смены юзера
        public AuthForm(user currentUser) {
            InitializeComponent();
            usersManager = new UsersManager();
            CurrentUser = currentUser;
            tbLogin.Text = CurrentUser.login;
            Text = "Смена пользователя";
        }

        private void bApply_Click(object sender, EventArgs e) {
            //Убираем пробелы с концов
            tbLogin.Text = tbLogin.Text.Trim();
            //Если мы меняем пользователя на того же самого
            if (CurrentUser != null)
                if (tbLogin.Text == CurrentUser.login) {
                    MessageBox.Show(string.Format("Вы уже вошли как {0} !", CurrentUser.login), "Аутентификация");
                    return;
                }
            //Проверка правильности ввода
            if (string.IsNullOrWhiteSpace(tbLogin.Text)) {
                MessageBox.Show("Логин не может быть пустым или состоять из пробелов!", "Аутентификация");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPassword.Text)) {
                MessageBox.Show("Пароль не может быть пустым или состоять из пробелов!", "Аутентификация");
                return;
            }
            Login = tbLogin.Text;
            Password = tbPassword.Text;
            //Работаем с БД
            using (var ctx = new DataContext()) {
                //Существует ли юзер с таким логином?
                user thisUser = usersManager.IsUserLoginExists(ctx.users, Login);
                if (thisUser == null) {
                    MessageBox.Show("Пользователя с таким логином не существует!", "Аутентификация");
                    return;
                }
                //Получаем соль
                string salt = thisUser.salt;
                //Вычисляем хэш
                byte[] passwordHash = usersManager.GetPasswordHash(Password + salt);
                //Аутентификация
                if (!thisUser.password_hash.SequenceEqual(passwordHash)) {
                    MessageBox.Show("Неправильный пароль!", "Аутентификация");
                    return;
                }
                AuthenticatedUser = thisUser;
            }
            IsUserNew = false;
            //Успешно
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bGuestAccess_Click(object sender, EventArgs e) {
            Login = "guest";
            Password = "guest";
            //Работаем с БД
            using (var ctx = new DataContext()) {
                //Существует ли юзер с таким логином?
                user thisUser = usersManager.IsUserLoginExists(ctx.users, Login);
                if (thisUser == null) {
                    MessageBox.Show("В данный момент отсутствует возможность входа под логином 'guest'.\nПожалуйста, обратитесь к администратору.", "Аутентификация");
                    return;
                }
                AuthenticatedUser = thisUser;
            }
            IsUserNew = false;
            //Успешно
            DialogResult = DialogResult.OK;
            Close();
        }

        private void bRegistration_Click(object sender, EventArgs e) {
            RegForm regForm = new RegForm();
            if (regForm.ShowDialog() != DialogResult.OK)
                return;
            //Успешно
            AuthenticatedUser = regForm.RegisteredUser;
            IsUserNew = true;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
