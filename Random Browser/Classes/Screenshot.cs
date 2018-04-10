using System;
using System.Windows.Media.Imaging;
using HtmlAgilityPack;

namespace Random_Browser.Classes
{
    class Screenshot
    {

        public static BitmapImage Fetch()
        {
            var htmlDocument = new HtmlWeb().Load(Helper.GenerateUrl());
            var imageNode =
                htmlDocument.DocumentNode.SelectSingleNode(".//img[contains(@class,'screenshot-image')]");
            var result = imageNode.Attributes["src"].Value;
                
            var image = new BitmapImage();

            if (result == null) return null;
            if (result.Contains("st.prntscr.com/2018/04/08/0850/img/0_173a7b_211be8ff.png")) return null;
                
            image.BeginInit();
            image.CacheOption = BitmapCacheOption.OnDemand;
            image.UriSource = new Uri(result);
            image.DownloadCompleted += (s, args) =>
            {
                image.Freeze();
            };

            image.EndInit();

            return image;
        }
    }
}
