using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XCross
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Test6Page : ContentPage
	{
		public Test6Page ()
		{
			InitializeComponent ();
		}

        private void Calculate_Clicked(object sender, EventArgs e)
        {

        }
        private void IsNumberOnly_Toggled(object sender, ToggledEventArgs e)
        {

        }
    }
}