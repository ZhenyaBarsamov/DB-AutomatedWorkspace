using System;
using System.Collections.Generic;
using System.Text;
using Org.BouncyCastle.Security;

namespace ARM.MyWorkClasses {
    class UsersManager {
        //Надёжность пароля от 0 до 4 по zxcvbn
        public int GetPasswordEvaluation(string password) {
            Zxcvbn.Zxcvbn zxcvbn = new Zxcvbn.Zxcvbn();
            var evaluation = zxcvbn.EvaluatePassword(password);
            return evaluation.Score; //в свойстве искомая оценка надёжности
        }

        //Вычисление хэша пароля хэш-функцией 'Стрибог'
        public byte[] GetPasswordHash(string password) {
            byte[] bytePassword = Encoding.ASCII.GetBytes(password);
            return DigestUtilities.CalculateDigest("GOST3411-2012-256", bytePassword);
        }

        //Генерация соли для нового пользователя
        public string GetNewSalt() {
            Random random = new Random();
            string salt = "";
            int saltLength = random.Next(4, 17); //длина = 4-16
            for (int i = 0; i < saltLength; i++) {
                char nextChar = (char)random.Next('A', 'z' + 1); //соль состоит из символов от A до z(между ними есть скобочки ещё)
                salt += nextChar;
            }
            return salt;
        }

        //Получение юзера с таким логином в БД
        public user IsUserLoginExists(IEnumerable<user> users, string login) {
            user rezUser = null;
            foreach (var curUser in users) {
                if (curUser.login == login) {
                    rezUser = curUser;
                    break;
                }
            }
            return rezUser;
        }
    }
}
