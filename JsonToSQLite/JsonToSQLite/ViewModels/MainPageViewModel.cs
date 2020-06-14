using Flurl.Http;
using JsonToSQLite.Models.SQLiteSettings.DbModels;
using JsonToSQLite.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JsonToSQLite.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public PostDbModel PostDataDB { get; set; }

        public Command PassDataBTN { get; set; }
        public Command SeeDataFromDB { get; set; }

        public string LabelData { get; set; }

        public INavigation navigation { get; set; }

        public MainPageViewModel(INavigation _navigation)
        {

            navigation = _navigation;
            PassDataBTN = new Command(async () => await LoadDataAsync());

            SeeDataFromDB = new Command(async () => {

                await navigation.PushAsync(new SQLiteView());


            });
        }


        public async Task LoadDataAsync()
        {

            var Data = await "https://jsonplaceholder.typicode.com/posts"
            .GetJsonAsync<List<PostDbModel>>();

            foreach (var _data in Data)
            {
                await App.Database.SaveItemAsync(_data);
            }

            LabelData = "Data Has Passed";


        }
    }
}
