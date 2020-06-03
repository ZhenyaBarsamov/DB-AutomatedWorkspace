using System;
using System.Collections.Generic;
using System.Linq;

namespace ARM.MyWorkClasses {
    class DataManager {
        //-------------------------------СТАНДАРТНЫЕ ЗАПРОСЫ ДЛЯ ПОИСКА-------------------------------
        //Поиск всех актёров данного фильма
        public List<actor> GetActorsForFilm(DataContext ctx, film f) {
            List<actor> rez;
            rez = (from contract in ctx.films_and_actors
                    where contract.film_id == f.id
                    select contract.actor).ToList();
            return rez;
        }

        //Поиск всех фильмов данного актёра
        public List<film> GetFilmsForActors(DataContext ctx, actor a) {
            List<film> rez;
            rez = (from contract in ctx.films_and_actors
                    where contract.actor_id == a.id
                    select contract.film).ToList();
            return rez;
        }
        //--------------------------------------------------------------------------------------------



        //----------------------------------ПОЛУЧЕНИЕ ОБЪЕКТОВ ИЗ БД----------------------------------
        //Получение нужного объекта из БД. Если его нет в БД, или ошибка - null
        private object GetObjectFromDB(string objectType, params int[] primaryKeyValue) {
            var objTypeLower = objectType.ToLower();
            object rez;
            using (var ctx = new DataContext()) {
                try {
                    if (objTypeLower == "actor")
                        rez = ctx.actors.Find(primaryKeyValue[0]);
                    else if (objTypeLower == "film")
                        rez = ctx.films.Find(primaryKeyValue[0]);
                    else if (objTypeLower == "company")
                        rez = ctx.companies.Find(primaryKeyValue[0]);
                    else if (objTypeLower == "contract")
                        rez = ctx.films_and_actors.Find(primaryKeyValue[0], primaryKeyValue[1]);
                    else if (objTypeLower == "user")
                        rez = ctx.users.Find(primaryKeyValue[0]);
                    else if (objTypeLower == "country")
                        rez = ctx.countries.Find(primaryKeyValue[0]);
                    else
                        throw new ArgumentException();
                }
                catch {
                    return null;
                }
            }
            return rez;
        }

        //Получение актёра из БД по ключу
        public actor GetActorFromDB(int id) {
            return (actor) GetObjectFromDB("actor", id);
        }

        //Получение фильма из БД по ключу
        public film GetFilmFromDB(int id) {
            return (film) GetObjectFromDB("film", id);
        }

        //Получение компании из БД по ключу
        public company GetCompanyFromDB(int id) {
            return (company) GetObjectFromDB("company", id);
        }

        //Получение контракта из БД по ключу
        public films_and_actors GetContractFromDB(ContractPrimaryKey contractPK) {
            return (films_and_actors) GetObjectFromDB("contract", contractPK.FilmId, contractPK.ActorId);
        }

        //Получение пользователя из БД по ключу
        public user GetUserFromDB(int id) {
            return (user) GetObjectFromDB("user", id);
        }
        //--------------------------------------------------------------------------------------------



        //----------------------------------ДОБАВЛЕНИЕ ОБЪЕКТОВ В БД----------------------------------
        //Добавление объекта в БД. Возвращает булево значение - значение успеха
        //Обновляет в addingObject поля первичного ключа
        private bool AddObjectToDB(string objectType, object addingObject) {
            var objTypeLower = objectType.ToLower();
            using (var ctx = new DataContext()) {
                try {
                    if (objTypeLower == "actor")
                        ctx.actors.Add((actor)addingObject);
                    else if (objTypeLower == "film")
                        ctx.films.Add((film)addingObject);
                    else if (objTypeLower == "company")
                        ctx.companies.Add((company)addingObject);
                    else if (objTypeLower == "contract")
                        ctx.films_and_actors.Add((films_and_actors)addingObject);
                    else if (objTypeLower == "user")
                        ctx.users.Add((user)addingObject);
                    else if (objTypeLower == "country")
                        ctx.countries.Add((country)addingObject);
                    else
                        throw new ArgumentException();
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        //Добавление актёра в БД. Возвращает id добавленного актёра, или -1 при ошибке
        public int AddActorToDB(actor newActor) {
            if (AddObjectToDB("actor", newActor) == false)
                return -1;
            else
                return newActor.id; //id обновилось при сохранении изменений в БД
        }

        //Добавление фильма в БД. Возвращает id добавленного фильма, или -1 при ошибке
        public int AddFilmToDB(film newFilm) {
            if (AddObjectToDB("film", newFilm) == false)
                return -1;
            else
                return newFilm.id; //Обновился при сохранении
        }

        //Добавление компании в БД. Возвращает id добавленной компании, или -1 при ошибке
        public int AddCompanyToDB(company newCompany) {
            if (AddObjectToDB("company", newCompany) == false)
                return -1;
            else
                return newCompany.id; //Обновился при сохранении
        }

        //Добавление контракта в БД. Возвращает первичный ключ записи, или null при ошибке
        public ContractPrimaryKey AddContractToDB(films_and_actors newContract) {
            if (AddObjectToDB("contract", newContract) == false)
                return null;
            else
                return new ContractPrimaryKey { FilmId = newContract.film_id, ActorId = newContract.actor_id }; //Обновился при сохранении
        }

        //Добавление пользователя в БД. Возвращает его id, или -1 при ошибке
        public int AddUserToDB(user newUser) {
            if (AddObjectToDB("user", newUser) == false)
                return -1;
            else
                return newUser.id; //Обновился при сохранении
        }
        //--------------------------------------------------------------------------------------------



        //----------------------------------УДАЛЕНИЕ ОБЪЕКТОВ ИЗ БД-----------------------------------
        //Удаление актёра из БД. Возвращает логическое значение = удалён ли он
        public bool DeleteActorFromDB(int deletingActorId) {
            var deletingActor = GetActorFromDB(deletingActorId);
            using (var ctx = new DataContext()) {
                try {
                    ctx.actors.Attach(deletingActor);
                    if (deletingActor.films_and_actors.Count != 0)
                        return false;
                    ctx.actors.Remove(deletingActor);
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        //Удаление фильма из БД. Возвращает логическое значение = удалён ли он
        public bool DeleteFilmFromDB(int deletingFilmId) {
            var deletingFilm = GetFilmFromDB(deletingFilmId);
            using (var ctx = new DataContext()) {
                try {
                    ctx.films.Attach(deletingFilm);
                    ctx.films.Remove(deletingFilm);
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }        

        //Удаление компании из БД. Возвращает логическое значение = удалена ли она
        public bool DeleteCompanyFromDB(int deletingCompanyId) {
            var deletingCompany = GetCompanyFromDB(deletingCompanyId);
            using (var ctx = new DataContext()) {
                try {
                    ctx.companies.Attach(deletingCompany);
                    if (deletingCompany.films.Count != 0)
                        return false;
                    ctx.companies.Remove(deletingCompany);
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        //Удаление контракта из БД. Возвращает логическое значение = удалён ли он
        public bool DeleteContractFromDB(ContractPrimaryKey deletingContractPK) {
            var deletingContract = GetContractFromDB(deletingContractPK);
            using (var ctx = new DataContext()) {
                try {
                    ctx.films_and_actors.Attach(deletingContract);
                    ctx.films_and_actors.Remove(deletingContract);
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        //Удаление пользователя из БД. Возвращает логическое значение = удалён ли он
        public bool DeleteUserFromDB(int deletingUserId) {
            var deletingUser = GetUserFromDB(deletingUserId);
            using (var ctx = new DataContext()) {
                try {
                    ctx.users.Attach(deletingUser);
                    ctx.users.Remove(deletingUser);
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }
        //--------------------------------------------------------------------------------------------



        //-------------------------------РЕДАКТИРОВАНИЕ ОБЪЕКТОВ В БД---------------------------------
        //Редактирование актёра. Возвращает логическое значение = отредактирован ли он
        public bool EditActorInDB(int actorId, actor newActorData) {
            var thisActor = GetActorFromDB(actorId);
            using (var ctx = new DataContext()) {
                try {
                    ctx.actors.Attach(thisActor);
                    thisActor.name = newActorData.name;
                    thisActor.birthday = newActorData.birthday;
                    thisActor.country = newActorData.country;
                    thisActor.description = newActorData.description;
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        //Редактирование фильма. Возвращает логическое значение = отредактирован ли он
        public bool EditFilmInDB(int filmId, film newFilmData) {
            var thisFilm = GetFilmFromDB(filmId);
            using (var ctx = new DataContext()) {
                try {
                    ctx.films.Attach(thisFilm);
                    thisFilm.name = newFilmData.name;
                    thisFilm.year = newFilmData.year;
                    thisFilm.country = newFilmData.country;
                    thisFilm.budget = newFilmData.budget;
                    thisFilm.age_limit = newFilmData.age_limit;
                    thisFilm.duration = newFilmData.duration;
                    thisFilm.rating = newFilmData.rating;
                    thisFilm.genre = newFilmData.genre;
                    thisFilm.company_id = newFilmData.company_id;
                    thisFilm.director = newFilmData.director;
                    thisFilm.composer = newFilmData.composer;
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        //Редактирование компании. Возвращает логическое значение = отредактирована ли она
        public bool EditCompanyInDB(int companyId, company newCompanyData) {
            var thisCompany = GetCompanyFromDB(companyId);
            using (var ctx = new DataContext()) {
                try {
                    ctx.companies.Attach(thisCompany);
                    thisCompany.name = newCompanyData.name;
                    thisCompany.foundation_year = newCompanyData.foundation_year;
                    thisCompany.address = newCompanyData.address;
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        //Редактирование контракта. Возвращает логическое значение = отредактирован ли он
        //Обновляет значение первичного ключа
        public bool EditContractInDB(ContractPrimaryKey contractPK, films_and_actors newContractData) {
            //Т.к. Entity Framework не позволяет менять значения первичных ключей, будем
            //заново пересоздавать кортеж для этой записи
            if (DeleteContractFromDB(contractPK) == false)
                return false;
            var rezPK = AddContractToDB(newContractData);
            if (rezPK == null)
                return false;
            contractPK = rezPK;
            return true;
        }

        //Редактирование пользователя
        public bool EditUserInDB(int userId, user newUserData) {
            var thisUser = GetUserFromDB(userId);
            using (var ctx = new DataContext()) {
                try {
                    ctx.users.Attach(thisUser);
                    thisUser.login = newUserData.login;
                    thisUser.password_hash = newUserData.password_hash;
                    thisUser.salt = newUserData.salt;
                    thisUser.registration_date = newUserData.registration_date;
                    thisUser.role = newUserData.role;
                    ctx.SaveChanges();
                }
                catch {
                    return false;
                }
            }
            return true;
        }
        //--------------------------------------------------------------------------------------------
    }
}
