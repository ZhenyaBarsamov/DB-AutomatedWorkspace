using System;
using System.Windows.Forms;
using ARM.MyWorkClasses;

namespace ARM {
    public partial class UserEditForm : Form {
        //Поля
        private user EditingUser { get; set; }
        public user NewUser { get; private set; }
        //Класс для работы с пользователями
        UsersManager usersManager;

        //Конструктор
        public UserEditForm(user user, user currentUser) {
            InitializeComponent();
            usersManager = new UsersManager();
            //изменяемый юзер - оригинал
            EditingUser = user;
            //Заполнение комбобокса с ролями
            cbRole.Items.Clear();
            cbRole.Items.Add("admin");
            cbRole.Items.Add("operator");
            cbRole.Items.Add("guest");
            //Инициализация полей для изменения пользователя
            tbLogin.Text = user.login;
            tbSalt.Text = user.salt;
            dtpRegistrationDate.Value = user.registration_date;
            cbRole.Text = user.role;
            //Роль самого себя изменить нельзя
            if (currentUser.id == user.id)
                cbRole.Enabled = false;
        }

        //Принять
        private void bApply_Click(object sender, EventArgs e) {
            //Обрезаем пробелы с концов в логине
            tbLogin.Text = tbLogin.Text.Trim();
            //Понимаем, что было изменено
            bool isLoginChanged = tbLogin.Text != EditingUser.login,
                isPasswordChanged = !String.IsNullOrWhiteSpace(tbNewPassword.Text),
                isSaltChanged = tbSalt.Text != EditingUser.salt,
                isDateChanged = dtpRegistrationDate.Value != EditingUser.registration_date,
                isRoleChanged = cbRole.Text != EditingUser.role;

            //Если изменений не было
            if (!isLoginChanged && !isPasswordChanged && !isSaltChanged && !isDateChanged && !isRoleChanged) {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            //Проверим логин 
            if (isLoginChanged) {
                //Если логин пустой
                if (String.IsNullOrWhiteSpace(tbLogin.Text)) {
                    MessageBox.Show("Логин не может быть пустым или содержать только пробельные символы!", "Изменение");
                    return;
                }
                using (var ctx = new DataContext()) {
                    //Проверка существования пользователя
                    if (usersManager.IsUserLoginExists(ctx.users, tbLogin.Text) != null) {
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Изменение");
                        return;
                    }
                }
            }
            //Если изменена соль, то нужно изменить и пароль
            if (isSaltChanged)
                if (!isPasswordChanged) {
                    MessageBox.Show("С изменением соли необходимо изменить и пароль!", "Изменение");
                    return;
                }
            //Формируем объект нового пользователя
            NewUser = new user {
                login = tbLogin.Text,
                password_hash = !isPasswordChanged ? EditingUser.password_hash : usersManager.GetPasswordHash(tbNewPassword.Text + tbSalt.Text),
                salt = tbSalt.Text,
                registration_date = dtpRegistrationDate.Value,
                role = cbRole.Text
            };
            //Изменение успешно
            DialogResult = DialogResult.OK;
            Close();
        }

        //Отмена
        private void bCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
