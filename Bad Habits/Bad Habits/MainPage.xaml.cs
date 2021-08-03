using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Bad_Habits
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			ReturnHabits(Habit.ReturnHabit());
		}

		private async void addBtn_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Habits_List());
		}

		public void AddHabits(Frame frame)
		{
			MainStackList.Children.Add(frame);
		}

		public void ReturnHabits(List<Frame> frames)
		{
			if (frames != null)
			{
				foreach (Frame item in frames)
				{
					MainStackList.Children.Add(item);
				}
			}
		}
	}
}
