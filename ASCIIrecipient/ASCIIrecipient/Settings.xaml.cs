using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace ASCIIrecipient
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        private FontProperties fontData;        

        public Settings(FontProperties fontData)
        {
            this.fontData = fontData;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Fill font combobox            
            ObservableCollection<string> SourceCB = new ObservableCollection<string>();
            foreach (var font in Fonts.SystemFontFamilies)
            {
                SourceCB.Add(font.Source);
            }
            FontFamilyComboBox.ItemsSource = SourceCB;
            //
            FontFamilyComboBox.SelectedItem = "Consolas";
            FontSizeTextBox.Text = "1";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(FontFamilyComboBox.SelectedItem != null)
            fontData.FontFamily = new FontFamily(FontFamilyComboBox.SelectedItem.ToString());
            if(FontSizeTextBox.Text != "")
            fontData.FontSize = Convert.ToDouble(FontSizeTextBox.Text);
        }
        

        private void FontSizeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && e.Text != "," || FontSizeTextBox.Text.Contains(",") && e.Text == ",")
            {
                e.Handled = true;                
            }
        }

        private void FontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontFamilyComboBox.SelectedItem.ToString() != "Consolas")
            {
                AttentionTextBlock.Visibility = Visibility.Visible;
            }
            else
            {
                AttentionTextBlock.Visibility = Visibility.Hidden;
            }
        }
    }
}
