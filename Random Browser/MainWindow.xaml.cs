using System.Windows;
using System.Windows.Media;
using Random_Browser.Classes;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Random_Browser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Timer _timer = new Timer() {Interval = 5000};

        public MainWindow()
        {
            InitializeComponent();
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() => {
                RandomImage.Source = Screenshot.Fetch();
            });
        }

        private static void image_DownloadFailed(object sender, ExceptionEventArgs e)
        {
            MessageBox.Show(e.ErrorException.Message);
        }


        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            RandomImage.Source = Screenshot.Fetch();
        }

        private void LazyButton_Click(object sender, RoutedEventArgs e)
        {
            RandomImage.Source = Screenshot.Fetch();
            _timer.Start();
        }

        /*private void saveButton_Click(object sender, RoutedEventArgs e)
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
        }*/
    }
}
