
using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    [QueryProperty(nameof(Monkey), "Monkey")]
    public class ShowMonkeyViewModel:ViewModel
    {
        Monkey monkey;
        public Monkey Monkey { get { return monkey; } set { monkey = value; GetMonkey(); } }
        public ICommand ShowMonkeyCommand { get; set; }
        public ICommand ShowMonkeyImage { get; set; }   
        private string name;
        public string Name 
        { 
            get { return this.name; } 
            set
            {   
                this.name = value;
                OnPropertyChanged();
            } 
        }
        private string location;
        public string Location
        {
            get { return this.location; }
            set
            {
                this.location = value;
                OnPropertyChanged();
            }
        }

        private string imageUrl;
        public string ImageUrl
        {
            get { return this.imageUrl; }
            set
            {
                this.imageUrl = value;
                OnPropertyChanged();
            }
        }
        public ShowMonkeyViewModel()
        {
            ShowMonkeyCommand = new Command(GetMonkey);
            ShowMonkeyImage = new Command(ShowImage,()=>monkey!=null);//new Command(()=>{if (monkey != null)ImageUrl = monkey.ImageUrl;)}

        }

        private void GetMonkey()
        {
            //MonkeysService service = new MonkeysService();
            //Monkey = service.GetRandomMonkey();
            if (Monkey != null)
            {
                Name=Monkey.Name;
                Location=Monkey.Location;
                ImageUrl=Monkey.ImageUrl;
            }
            //check if the command can work now
                ((Command)ShowMonkeyImage).ChangeCanExecute();
        }

        private void ShowImage()
        {
            if (Monkey != null)
                ImageUrl=Monkey.ImageUrl;   


        }
    }
}
