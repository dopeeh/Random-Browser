using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Net;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Random_Browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static int RandomNumber(int min, int max)
        {
            Random random = new Random(); return random.Next(min, max);
        }

        private void browseButton_Click(object sender, RoutedEventArgs e)
        {
            bool boolLoop = true;
            while (boolLoop) {
                int randomNumber = RandomNumber(100000, 999999);
                string randomUrl = "https://prnt.sc/" + randomNumber;
                HtmlWeb htmlweb = new HtmlWeb();
                var htmlDocument = htmlweb.Load(randomUrl);
                var imageNode = htmlDocument.DocumentNode.SelectSingleNode(".//img[contains(@class,'screenshot-image')]");
                var result = imageNode.GetAttributeValue("src");

                if (htmlweb.StatusCode == System.Net.HttpStatusCode.OK & result != "//st.prntscr.com/2018/03/20/0706/img/0_173a7b_211be8ff.png")
                {
                    randomImage.Source = new BitmapImage(new Uri(result));
                    Debug.Write(result);
                    boolLoop = false;
                }
                
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveImage = new SaveFileDialog();
            if (randomImage.Source != null)
            {
                string imageSource = randomImage.Source.ToString();
                saveImage.FileName = "yourfile.png";
                saveImage.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";

                if (saveImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string locationSave = saveImage.FileName;
                    WebClient webClient = new WebClient();
                    webClient.DownloadFile(imageSource, locationSave);
                    webClient.Dispose();
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("No picture loaded");
            }
        }
    }
}
