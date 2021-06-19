using RestaurantApp.Models;
using RestaurantApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RestaurantApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        string username, firstname, lastname, password;
        public RegisterViewModel()
        {
            Title = "Register Page";
            OnSaveCommand = new Command(OnSave, Validate);
            BackCommand = new Command(GetBack);
            this.PropertyChanged +=
                (_, __) => OnSaveCommand.ChangeCanExecute();
        }

        private async void GetBack(object obj)
        {
            Console.WriteLine(obj);
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private bool Validate(object arg)
        {
            return !String.IsNullOrWhiteSpace(firstname)
                && !String.IsNullOrWhiteSpace(lastname) 
                && !String.IsNullOrWhiteSpace(username) 
                && !String.IsNullOrWhiteSpace(password);
        }

        private async void OnSave(object obj)
        {
            User newItem = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = Username,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName
            };

            await DataStore.AddItemAsync(newItem);

            Username = null;
            Password = null;
            FirstName = null;
            LastName = null;

            // This will pop the current page off the navigation stack

        }

        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }
        public string FirstName
        {
            get => firstname;
            set => SetProperty(ref firstname, value);
        }
        public string LastName
        {
            get => lastname;
            set => SetProperty(ref lastname, value);
        }
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public Command OnSaveCommand { get; }
        public Command BackCommand { get; }
    }
}
