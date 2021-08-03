using System;
using System.Collections.Generic;
using System.Linq;
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
			NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
			IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
			MainPage homePage = navStack[0] as MainPage;
			List<object> values = App.Current.Properties.Values.ToList();
			object hab = values.FirstOrDefault(item => item.ToString() == ent1.Text);
			if (hab == null)
			{
				homePage.AddHabits(Habit.AddHabit(ent1.Text));

			}
			await Navigation.PopAsync();
		}
	}
}