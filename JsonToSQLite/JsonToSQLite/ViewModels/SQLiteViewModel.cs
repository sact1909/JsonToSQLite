using JsonToSQLite.Models.SQLiteSettings.DbModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace JsonToSQLite.ViewModels
{
    public class SQLiteViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<PostDbModel> DbData { get; set; } = new ObservableCollection<PostDbModel>();

        public SQLiteViewModel()
        {
            new Action(async () => await LoadDataAsync())();
        }

        public async Task LoadDataAsync()
        {

            List<PostDbModel> Data = new List<PostDbModel>();
            
            Data = await App.Database.GetItemsAsync();
            foreach (var _Data in Data)
            {
                DbData.Add(_Data);
            }

        }
    }
}
