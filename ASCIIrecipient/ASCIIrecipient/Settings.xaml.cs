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

namespace ASCIIrecipient
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window, INotifyPropertyChanged
    {

        private FontProperties fontData;
        public FontProperties FontData
        {
            get { return fontData ?? new FontProperties { FontFamily = new FontFamily("Consolas"), FontSize = 1 }; }
            set
            {
                fontData = value;
                OnPropertyChanged("FontData");
            }
        }

        public Settings()
        {
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FontData = new FontProperties
            {
                FontFamily = FontFamilyComboBox.FontFamily
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
