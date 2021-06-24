using RestaurantApp.Models;
using RestaurantApp.Views;
using System;
using System.Linq;
using Xamarin.Forms;

namespace RestaurantApp.ViewModels
{
    //<summary>
    // Login Screen
    //</summary>
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        private string username;
        private string password;
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            RegistrationCommand = new Command(GoToRegistration);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        //<summary>
        // Preusmjeravanje korisnika na screen za registraciju racuna
        //</summary>
        private async void GoToRegistration(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegistrationPage)}");
        }

        //<summary>
        // Setovanje vrijednosti koje su unesene kroz inpute
        //</summary>
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        //<summary>
        // Izvrsavanje komande prilikom klika na login button.
        // Provjerava se da li korisnik postoji u 'MockDataStore' nizu i u slucaju da postoji sa usernameom
        // i pripadajucom sifrom, korisnik se prosljediva na ekran sa jelovnikom
        //</summary>
        private async void OnLoginClicked(object obj)
        {
            
            var users = DataStore.GetItemsAsync().Result;
            User ifexisits = users.ToList().Find(x => x.Username == Username && x.Password == Password);
            if(ifexisits != null)
            {
                Console.WriteLine("succesfully passed further");
                
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                Username = null;
                Password = null;
            }
            
        }


        //<summary>
        // Provjera da li su inputi prazni prilikom klika na login button
        //</summary>
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(username)
                && !String.IsNullOrWhiteSpace(password);
        }

        
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command RegistrationCommand { get; }

        //<summary>
        // Nije implementirano, sluzi za povratak na prethodni screen
        //</summary>
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        //<Registracija korisnika, NE KORISNIT SE NA OVOME SCREENU
        //</summary>
        private async void OnSave()
        {
            User newItem = new User()
            {
                Id = Guid.NewGuid().ToString(),
                Username = Username,
                Password = Password
            };

            await DataStore.AddItemAsync(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
