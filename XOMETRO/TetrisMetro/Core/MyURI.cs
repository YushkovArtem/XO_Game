using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace XOGameMetro.Core
{
    public static class MyURI
    {
        public static ImageBrush UriToImageBrush(this Uri uri)
        {
            BitmapImage bi = new BitmapImage();
           // bi.BeginInit();
            bi.UriSource = uri;
            //bi.EndInit();
            ImageBrush ib = new ImageBrush();
            //ib.TileMode = TileMode.Tile;
            ib.ImageSource = bi;
            ib.Stretch = Stretch.None;
            return ib;
            //RootGrid.Background = ib;
        }
    }
}
