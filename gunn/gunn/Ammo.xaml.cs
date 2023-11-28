using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace gunn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Ammo : ContentPage
    {
        public List<string> ammos;
        public string filePath2;
        public Ammo()
        {
            InitializeComponent();
            ammos = new List<string>();
            filePath2 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ammos.txt");

            if (File.Exists(filePath2))
            {
                ammos = new List<string>(File.ReadAllLines(filePath2));
            }
            ammoslist.ItemsSource = ammos;
        }

        private void AddAmmo(object sender, EventArgs e)
        {
            string newAmmo = ammoadd.Text;
            if (!string.IsNullOrWhiteSpace(newAmmo))
            {
                ammos.Add(newAmmo);
                ammoslist.ItemsSource = null;
                ammoslist.ItemsSource = ammos;
                SaveAmmosToFile();
                ammoadd.Text = string.Empty;
            }
        }

        private async void SelectedAmmo(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is string selectedAmmo)
            {
                string action = await DisplayActionSheet("Выберите действие", "Отмена", null, "Редактировать", "Удалить");
                if (action == "Редактировать")
                {
                    string editedAmmo = await DisplayPromptAsync("Редактировать ", "Введите новое название типа патронов", initialValue: selectedAmmo);

                    if (!string.IsNullOrWhiteSpace(editedAmmo))
                    {
                        int index = ammos.IndexOf(selectedAmmo);
                        ammos[index] = editedAmmo;
                        ammoslist.ItemsSource = null;
                        ammoslist.ItemsSource = ammos;
                        selectedAmmo = null;

                        SaveAmmosToFile();

                    }
                }
                else if (action == "Удалить")
                {
                    ammos.Remove(selectedAmmo);
                    ammoslist.ItemsSource = null;
                    ammoslist.ItemsSource = ammos;
                    selectedAmmo = null;
                    SaveAmmosToFile();
                }
            }
        }

        private void SaveAmmosToFile()
        {
            File.WriteAllLines(filePath2, ammos);
        }

        private async void NewPage2(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}