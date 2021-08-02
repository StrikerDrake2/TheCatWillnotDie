using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bad_Habits
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Habits_List : ContentPage
    {
        public Habits_List()
        {
            InitializeComponent();
        }

        private void selectHabitsBtn_Clicked(object sender, EventArgs e)
        {
            pir1.Focus();
        }

        private void pir1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ent1.Text = pir1.SelectedItem.ToString();
        }

        private async void nextHabitsBtn_Clicked(object sender, EventArgs e)
        {
            Label label = new Label()
            { Text = ent1.Text };

            NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
            IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
            MainPage homePage = navStack[0] as MainPage;

            homePage.AddHabits(label);

            await Navigation.PopAsync();
        }
    }
}