using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonkeysMVVM.ViewModels
{
    public class FindMonkeyByLocationPageViewModel:ViewModel
    {
        private MonkeysService monkeysService;
        Monkey monkey;
        private int count;
        private string country;
        public string Name { get => monkey.Name;  }
        public int Count { get => count; set {  count = value; OnPropertyChanged(); } }
         public string ImageUrl { get => monkey.ImageUrl;  }
         public string Country { get => country; set { country = value; OnPropertyChanged(); ((Command)SearchCommand).ChangeCanExecute();  } }    
        public ICommand SearchCommand { get; protected set; }

        public FindMonkeyByLocationPageViewModel()
        {
            this.monkeysService = monkeysService;
            count = 0;
            SearchCommand = new Command(FindMonkey, () => Country != null);
            monkey = new Monkey() {Name = "לא נמצאו קופים", ImageUrl = "monkey"};
        }

        private void FindMonkey()
        {
            List<Monkey> list = monkeysService.FindMonkeysByLocation(country);
            Count= list.Count;
            monkey=list.FirstOrDefault();
            Country = null;
            if (monkey == null)
                monkey = new Monkey() { Name = "לא נמצאו קופים", ImageUrl = "monkey" };
            RefreshFields();
            
        }

        private void RefreshFields()
        {
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(ImageUrl));
            
        }
    }
}
