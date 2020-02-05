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
using System.IO;

namespace RicercaOrdinamento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(File.Exists(file))
            {
                using(StreamReader leggifile=new StreamReader(file))
                {
                    string line;
                    while((line=leggifile.ReadLine())!=null)
                    {
                        nomi.Add(line);
                        txtListaOrdinataNomi.Text += $"{line}\n";
                    }
                }
            }

        }
        List<string> nomi = new List<string>();
        const string file = "nomi.txt";
        
        private void btnInserisci_Click(object sender, RoutedEventArgs e)
        {
            nomi.Add(txtNome.Text);
            nomi.Sort();
            txtListaOrdinataNomi.Text = null;
            for(int c=0; c<nomi.Count;c++)
            {
                txtListaOrdinataNomi.Text += $"{nomi[c]}\n";
            }
        }

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            using(StreamWriter creafile=new StreamWriter(file))
            {
                creafile.Write(txtListaOrdinataNomi.Text);
            }
        }

        private void btnCerca_Click(object sender, RoutedEventArgs e)
        {
            string nome_da_cercare = txtRicercaNome.Text;
            if(nomi.Contains(nome_da_cercare))
                txtRisultatoRicerca.Text = ("Il nome è presente");
            else
                txtRisultatoRicerca.Text=("Il nome non è presente");
        }
    }
}
