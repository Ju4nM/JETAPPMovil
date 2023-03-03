using System;
using System.Collections.Generic;
using System.Text;
using JET.ViewModel;

namespace JET.Models
{
    class UserModel: BaseViewModel
    {
        // Necesitan actualizacion
        public string _firstName;
        public string _firstLastName;
        public string _userName;
        public string id;

        // No necesitan actualizarse en la vista
        public string secondName;
        public string secondLastName;
        public string email;
        public bool userType;
        public bool gender;

        public string firstName
        {
            get => _firstName; 
            set => SetProperty(ref _firstName, value); 
        }

        public string firstLastName
        {
            get => _firstLastName; 
            set => SetProperty(ref _firstLastName, value); 
        }
        public string userName
        {
            get => _userName; 
            set => SetProperty(ref _userName, value); 
        }
        public string _id
        {
            get => id; 
            set => SetProperty(ref id, value); 
        }

    }
}
