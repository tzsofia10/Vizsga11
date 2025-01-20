using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Vizsga11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<eredmenyek> lista = new List<eredmenyek>();
        public MainWindow()
        {
            InitializeComponent();
            using StreamReader sr = new StreamReader(
                path: @"..\..\..\src\adatok.txt",
                encoding: Encoding.UTF8);


            while (!sr.EndOfStream)
            {
                lista.Add(new eredmenyek(sr.ReadLine()));
            }
        }
    }
    }
