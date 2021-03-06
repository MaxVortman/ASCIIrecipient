﻿using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace ASCIIrecipient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FontProperties FontData;
        public MainWindow()
        {
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            FontData = new FontProperties { FontFamily = new FontFamily("Consolas"), FontSize = 1 };
            DataContext = FontData;
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

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = new Settings(FontData);
            settings.Show();            
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DestinationText.Text == "")
            {
                MessageBox.Show("Nothing to save!\nAdd some pictures!");
                return;
            }
            var saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                using (var destionationFile = File.Open(System.IO.Path.ChangeExtension(saveFileDialog.FileName, ".txt"), FileMode.Create, FileAccess.Write, FileShare.Write))
                {
                    using (var writer = new StreamWriter(destionationFile))
                    {
                        writer.Write(DestinationText.Text);
                    } 
                }
            }

        }
    }
}
