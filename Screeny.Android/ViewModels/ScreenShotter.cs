using System.Diagnostics;
using System.IO;
using Android.App;
using Android.Graphics;
using Screeny.Droid.ViewModels;
using Screeny.ViewModels;
using Xamarin.Forms;

[assembly: Dependency(typeof(ScreenShotter))]

namespace Screeny.Droid.ViewModels
{
    public class ScreenShotter : IScreenShotter
    {
        public ImageSource GetScreeny()
        {
            
            if (!(Forms.Context is Activity currentContext)) return null;
            Debug.WriteLine("ANDROID SCREENSHOT");
            var view = currentContext.Window.DecorView;
            view.DrawingCacheEnabled = true;
            var bitmap = view.GetDrawingCache(true);
            Debug.WriteLine("bitmap: " + bitmap);

            byte[] bitmapData;
            using (var stream = new MemoryStream())
            {
                bitmap.Compress(Bitmap.CompressFormat.Png, 0, stream);
                bitmapData = stream.ToArray();
                
                Debug.WriteLine("bitmapData: " + bitmapData);
            }
            return ImageSource.FromStream(() => new MemoryStream(bitmapData, 0, bitmapData.Length));
        }
    }
}