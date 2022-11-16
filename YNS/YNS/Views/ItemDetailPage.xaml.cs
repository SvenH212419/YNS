using System.ComponentModel;
using Xamarin.Forms;
using YNS.ViewModels;

namespace YNS.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}