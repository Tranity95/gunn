using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace gunn
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void AddGun(object sender, EventArgs e)
        {
            string addGun = await DisplayPromptAsync("Добавить ", "Введите название оружия");
            if (!string.IsNullOrWhiteSpace(addGun))
            {
                guns.Add(addGun);
                gunslist.ItemsSource = null;
                gunslist.ItemsSource = guns;
                SaveGunsToFile();


            }
        }

        private async void SelectedGun(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && e.Item is string selectedGun)
            {
                string action = await DisplayActionSheet("Выберите действие", "Отмена", null, "Редактировать", "Удалить", "Тип патронов");
                if (action == "Редактировать")
                {
                    string editedGun = await DisplayPromptAsync("Редактировать ", "Введите новое название оружия", initialValue: selectedGun);

                    if (!string.IsNullOrWhiteSpace(editedGun))
                    {
                        int index = guns.IndexOf(selectedGun);
                        guns[index] = editedGun;
                        gunslist.ItemsSource = null;
                        gunslist.ItemsSource = guns;
                        selectedGun = null;
                        SaveGunsToFile();
                    }
                }
                else if (action == "Удалить")
                {
                    guns.Remove(selectedGun);
                    gunslist.ItemsSource = null;
                    gunslist.ItemsSource = guns;
                    selectedGun = null;
                    SaveGunsToFile();
                }
                else if (action == "Тип патронов")
                {
                 
                }
            }
        }

        private async void NewPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Ammo());
        }
    }
}
