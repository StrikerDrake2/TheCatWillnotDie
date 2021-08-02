using System;
using Xamarin.Forms;

namespace Bad_Habits
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void addBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Habits_List());
        }

        public void AddHabits(Label label)
        {
            MainStackList.Children.Add(label);
        }
    }
}
