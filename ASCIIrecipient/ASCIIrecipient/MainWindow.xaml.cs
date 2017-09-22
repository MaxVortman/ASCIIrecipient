using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace ASCIIrecipient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new OpenFileDialog();
            if (dialogWindow.ShowDialog() == true)
            {
                var fileName = dialogWindow.FileName;
                var bi3 = new BitmapImage();
                try
                {
                    bi3.BeginInit();
                    bi3.UriSource = new Uri(fileName, UriKind.Absolute);
                    bi3.EndInit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
                SourceImage.Stretch = Stretch.Fill;
                SourceImage.Source = bi3;
                CreateAsciiText(bi3);
            }
            else
            {
                MessageBox.Show("Nothing choose!");
            }
        }

        private void CreateAsciiText(BitmapImage bi3)
        {
            var converter = new Converter { SourceBmp = bi3 };
            converter.CreateASCII();
            DestinationText.Text = converter.ASCIItext;
        }
        
    }
}
