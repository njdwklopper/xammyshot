using System.Diagnostics;
using Screeny.iOS.ViewModels;
using Screeny.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(ScreenShotter))]
namespace Screeny.iOS.ViewModels
{
    public class ScreenShotter : IScreenShotter
    {
        public ImageSource GetScreeny()
        {
            Debug.WriteLine("IOS SCREENSHOT");
            return null;
        }
    }
}