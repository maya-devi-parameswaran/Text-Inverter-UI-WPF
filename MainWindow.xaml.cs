using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty InvertedTextProperty =
        DependencyProperty.Register("InvertedText", typeof(string), typeof(MainWindow), new UIPropertyMetadata(string.Empty));

        public string InvertedText
        {
            get { return (string)this.GetValue(InvertedTextProperty); }
            set { this.SetValue(InvertedTextProperty, value); }
        }

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ServiceReference1.WebService1SoapClient proxy = new ServiceReference1.WebService1SoapClient();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.WebService1SoapClient proxy = new ServiceReference1.WebService1SoapClient();
            InvertedText  = String.IsNullOrEmpty(proxy.InvertText(Text.Text)) ? "" : string.Format("Inverted text is \" {0} \" ", proxy.InvertText(Text.Text));
        }
    }
}
