using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Screeny.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewScreenshot : ContentPage
    {
        public ViewScreenshot(ImageSource imageSource)
        {
            InitializeComponent();
            
            Debug.WriteLine("ScreenShot imageSource: " + imageSource);
            ScreenShotImage.Source = imageSource;
        }
    }
}