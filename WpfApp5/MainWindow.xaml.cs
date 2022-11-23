using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp5
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

        private void Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Inkcanvas Format (*.sandy)|*.sandy|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                var fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate);
                StrokeCollection strokes = new StrokeCollection(fs);
                inkcanvas.Strokes = strokes;
            }
        }


        private void Save (object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "InkCanvas Format (*.sandy)|*.sandy|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fs = File.Open(dlg.FileName, FileMode.OpenOrCreate);
                inkcanvas.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_ClickGreen(object sender, RoutedEventArgs e)          //изменение на зеленый цвет
        {
            if (inkcanvas != null)
            {
                brush.Color = Colors.Green;
            }
        }

        private void Button_ClickBlack(object sender, RoutedEventArgs e)
        {
            if (inkcanvas != null)
            {
                brush.Color = Colors.Black;
            }
        }

        private void Button_ClickRed(object sender, RoutedEventArgs e)
        {
            if (inkcanvas != null)
            {
                brush.Color = Colors.Red;
            }
        }
    }
}
