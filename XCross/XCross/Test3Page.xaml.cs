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
    public partial class Test3Page : ContentPage
    {
        public Test3Page()
        {
            InitializeComponent();
            IPlatformInfo platformInfo = DependencyService.Get<IPlatformInfo>();

            modelLabel.Text = platformInfo.GetModel();
            versionLabel.Text = platformInfo.GetVersion();
        }
    }
}