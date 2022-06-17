using CallMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CallMobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private ObservableCollection<MasaClass> MasaClasses;
        public HomePage()
        {
            InitializeComponent();
            MasaClasses = new ObservableCollection<MasaClass>();
        }

        private async void List()
        {
            MasaClasses.Clear();
            var masas = await ApiService.GetMasa();
            foreach (var masa in masas)
            {
                MasaClasses.Add(masa);
            }
            list.ItemsSource = MasaClasses;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            List();
        }

        private void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = e.SelectedItem as MasaClass;
            if (selected != null)
                idTXT.Text = Convert.ToString(selected.Id);

            ((ListView)sender).SelectedItem = null;
        }

        private async void updateBTN_Clicked(object sender, EventArgs e)
        {
            var response = await ApiService.PutStation(Convert.ToInt32(idTXT.Text), 1);
            await DisplayAlert("Kaydedildi", "Durum değiştirildi.", "Tamam");
            List();
        }

        private void refleshBTN_Clicked(object sender, EventArgs e)
        {
            List();
        }
    }
}