using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Bad_Habits
{
	class Habit
	{
		static int CountKeys { get; set; }
		static object countKeys;
		static object frameValue;

		public static Frame AddHabit(string value)
		{
			Button button = new Button()
			{ Text = "Удалить" };
			button.Clicked += Button_Clicked;
			Frame frame = new Frame()
			{
				Margin = new Thickness(10),
				CornerRadius = 10,
				Content = new StackLayout
				{
					Children =
					{
						new Label
						{
							Text = value,
							HorizontalTextAlignment = TextAlignment.Center,
							FontSize = 16,
							FontAttributes = FontAttributes.Bold
						},
						button
					}
				}
			};

			if (App.Current.Properties.TryGetValue("countKeys", out countKeys))
			{
				CountKeys = (int)countKeys;
				CountKeys++;
				App.Current.Properties.Remove("countKeys");
				App.Current.Properties.Add("countKeys", CountKeys);
				App.Current.Properties.Add($"hab{CountKeys}", value);
			}
			else
			{
				CountKeys++;
				App.Current.Properties.Add("countKeys", CountKeys);
				App.Current.Properties.Add($"hab{CountKeys}", value);
			}
			return frame;
		}

		private static void Button_Clicked(object sender, EventArgs e)
		{
			Button btn = sender as Button;
			List<object> values = App.Current.Properties.Values.ToList();
			StackLayout temp = btn.Parent as StackLayout;
			var label = temp.Children.First() as Label;
			for (int i = 1; i < values.Count; i++)
			{
				if (values[i].ToString() == label.Text)
				{
					if (i < CountKeys && CountKeys != 2)
					{
						CountKeys--;
						App.Current.Properties.Remove("countKeys");
						App.Current.Properties.Add("countKeys", CountKeys);
						if (CountKeys != 2 || i == 1)
						{
							App.Current.Properties.Remove("countKeys");
							App.Current.Properties.Add("countKeys", CountKeys);
							for (int j = 1; j <= CountKeys; j++)
							{
								object temp2;
								App.Current.Properties.Remove($"hab{i}");
								App.Current.Properties.TryGetValue($"hab{i + 1}", out temp2);
								App.Current.Properties.Add($"hab{i}", temp2.ToString());
								App.Current.Properties.Remove($"hab{i + 1}");
								i++;
							}
							break;
						}
						else
						{
							for (int j = 1; j < CountKeys; j++)
							{
								object temp2;
								App.Current.Properties.Remove($"hab{i}");
								App.Current.Properties.TryGetValue($"hab{i + 1}", out temp2);
								App.Current.Properties.Add($"hab{i}", temp2.ToString());
								App.Current.Properties.Remove($"hab{i + 1}");
								i++;
							}
							break;
						}
					}
					else if (i < CountKeys && CountKeys == 2)
					{
						CountKeys--;
						App.Current.Properties.Remove("countKeys");
						App.Current.Properties.Add("countKeys", CountKeys);
						for (int j = 1; j <= CountKeys; j++)
						{
							object temp2;
							App.Current.Properties.Remove($"hab{i}");
							App.Current.Properties.TryGetValue($"hab{i + 1}", out temp2);
							App.Current.Properties.Add($"hab{i}", temp2.ToString());
							App.Current.Properties.Remove($"hab{i + 1}");
							i++;
						}
						break;
					}
					else if (i == CountKeys)
					{
						CountKeys--;
						App.Current.Properties.Remove("countKeys");
						App.Current.Properties.Add("countKeys", CountKeys);
						App.Current.Properties.Remove($"hab{i}");
					}
				}
			}
			StackLayout remove = btn.Parent.Parent.Parent as StackLayout;
			remove.Children.Remove(btn.Parent.Parent as Frame);
		}

		public static List<Frame> ReturnHabit()
		{
			List<Frame> frames = new List<Frame>();
			if (App.Current.Properties.TryGetValue("countKeys", out countKeys))
			{
				CountKeys = (int)countKeys;
				for (int i = 0; i <= CountKeys; i++)
				{
					if (App.Current.Properties.TryGetValue($"hab{i}", out frameValue))
					{
						Button button = new Button()
						{ Text = "Удалить" };
						button.Clicked += Button_Clicked;
						Frame frame = new Frame()
						{
							Margin = new Thickness(10),
							CornerRadius = 10,
							Content = new StackLayout
							{
								Children =
								{
									new Label
									{
										Text = frameValue.ToString(),
										HorizontalTextAlignment = TextAlignment.Center,
										FontSize = 16,
										FontAttributes = FontAttributes.Bold
									},
									button
								}
							}
						};
						frames.Add(frame);
					}
				}
				return frames;
			}
			else
			{
				return null;
			}
		}
	}
}
