using JET.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace JET.Data
{
    class UserMockData
    {
        public static ObservableCollection<UserModel> GetUserMockData ()
        {
            return new ObservableCollection<UserModel>()
            {
                new UserModel()
                {
                    id = "001",
                    firstName = "Tomás",
                    secondName = "Andrés",
                    firstLastName = "Espinoza",
                    secondLastName = "Trujillo",
                    email = "tomas@gmail.com",
                    userName = "TomasEA",
                    gender = false,
                    userType = true
                },
                new UserModel()
                {
                    id = "002",
                    firstName = "Pamela",
                    secondName = "Jazmin",
                    firstLastName = "Toledo",
                    secondLastName = "Valenzuela",
                    email = "jazmin@gmail.com",
                    userName = "JazToledo",
                    gender = true,
                    userType = false
                },
                new UserModel()
                {
                    id = "003",
                    firstName = "Gilda",
                    secondName = "Lorena",
                    firstLastName = "Duarte",
                    secondLastName = "Guerrero",
                    email = "gduarte@gmail.com",
                    userName = "gDuarte",
                    gender = true,
                    userType = false
                },
                new UserModel()
                {
                    id = "004",
                    firstName = "Miguel",
                    secondName = "Alejandro",
                    firstLastName = "Lopez",
                    secondLastName = "Humo",
                    email = "malopez@gmail.com",
                    userName = "MaLopez",
                    gender = false,
                    userType = false
                },
                new UserModel()
                {
                    id = "005",
                    firstName = "Juan",
                    secondName = "Enrique",
                    firstLastName = "Martinez",
                    secondLastName = "Flores",
                    email = "juan@gmail.com",
                    userName = "Ju4nM",
                    gender = false,
                    userType = false 
                },
            };
        }
    }
}
