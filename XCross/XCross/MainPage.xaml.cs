using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XCross
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }
        private async void Test1Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Test1Page());
        }
        private async void Test2Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Test2Page());
        }
        private async void Test3Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Test3Page());
        }
        private async void Test4Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Test4Page());
        }
        private async void Test5Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Test5Page());
        }
    }
}
