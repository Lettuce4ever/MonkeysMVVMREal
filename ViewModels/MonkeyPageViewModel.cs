using MonkeysMVVM.Models;
using MonkeysMVVM.Services;
using MonkeysMVVM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace MonkeysMVVM.ViewModels
{
    public class MonkeyPageViewModel : ViewModel
    {
        Monkey SelectedMonkey { get; set; }
        public ObservableCollection<Monkey> Monkeys { get; set; }
        public Monkey Monkey { get; set; }
        public ICommand LoadMonkeysCommand { get; private set; }
        public ICommand GoToShowMonkeyViewCommand { get; private set; }

        private bool isRefreshing;
        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }

        public MonkeyPageViewModel()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Monkey", SelectedMonkey);
            Monkeys = new ObservableCollection<Monkey>();

            LoadMonkeysCommand = new Command(async () => await LoadMonkeys());
            GoToShowMonkeyViewCommand = new Command(async () => await GoToShowMonkeyView());
        }

        private async Task GoToShowMonkeyView()
        {
            
            AppShell.Current.GoToAsync("ShowMonkey");
        }
        private async Task LoadMonkeys()
        {
            IsRefreshing = true;
            MonkeysService monkeys = new MonkeysService();
            var list = monkeys.GetMonkey();
            for(int i =0; i < list.Count; i++)
            {
                Monkeys.Add(list[i]);
            }
            IsRefreshing=false;
         }
    }
}
