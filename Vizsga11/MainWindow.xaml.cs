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
            sr.Close();

            foreach (var item in lista)
            {
                listbox.Items.Add(item.Nev);
            }
            vizsgaszam.Content = $"{lista.Count} vizsgázó adatait beolvastuk";
        }

        private void sikeres_Click(object sender, RoutedEventArgs e)
        {
            
            int sikeresVizsga = 0;
            foreach (var item in lista) 
            {
                if (item.ItHalozatIrasbeli>0.50 && item.ProgramozasIrasbeli>0.50 && item.HalozatokAModul>0.50&&item.HalozatokBModul>0.50&& item.HalozatokCModul>0.50&& item.HalozatokDModul>0.50&&item.SzobeliAngol>0.50&&item.SzobeliIT>0.50)
                {
                    sikeresVizsga ++;
                }
            }
            sikeresszam.Content = $"{sikeresVizsga} fő";

        }

        private void alomanyir_Click(object sender, RoutedEventArgs e)
        {
            using StreamWriter sw = new StreamWriter(path: @"..\..\..\src\vizsgaredmenyek.txt", append: false);

            foreach (var tanulo in lista)
            {
                double vegeredmeny = tanulo.vegeredmeny(tanulo.HalozatokCModul);
                string erdemjegy = tanulo.erdemjegy(tanulo.HalozatokCModul);

                sw.WriteLine($"{tanulo.Nev}\t{vegeredmeny:F2}\t{erdemjegy}");


            }
        }
        private void keresBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                string keresettNev = keresBox.Text.Trim();
                if (string.IsNullOrEmpty(keresettNev))
                {
                    eredmenyBlock.Text = "Kérlek, adj meg egy nevet a kereséshez!";
                    return;
                }

                var talalat = lista.FirstOrDefault(tanulo => tanulo.Nev.Contains(keresettNev, StringComparison.OrdinalIgnoreCase));

                if (talalat == null)
                {
                   
                    eredmenyBlock.Text = "A keresett tanuló nem található a listában.";
                }
                else
                {
                    double legjobb = talalat.LegjobbEredmeny();
                    double leggyengebb = talalat.LeggyengebbEredmeny();
                    bool sikeres = talalat.VizsgaSikeres();

                    eredmenyBlock.Text = $"Név: {talalat.Nev}\n" +
                                         $"Legjobb eredmény: {legjobb}%\n" +
                                         $"Leggyengébb eredmény: {leggyengebb}%\n" +
                                         $"Vizsga sikeres: {(sikeres ? "Igen" : "Nem")}";
                }
            }
        }

    }
}
    
