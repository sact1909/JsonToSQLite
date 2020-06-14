using JsonToSQLite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JsonToSQLite.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLiteView : ContentPage
    {
        public SQLiteView()
        {
            InitializeComponent();
            BindingContext = new SQLiteViewModel();
        }
    }
}