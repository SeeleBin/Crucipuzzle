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

namespace WPFCruciPuzzle
{
    /// <summary>
    /// WPF crucipuzzle
    /// Dargui Hamza 24/02/2021
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static string fileName="";
        //creo una grid di tipo Tabellone
        Tabellone Puzzle;

        private void FileOpener_Click(object sender, RoutedEventArgs e)
        {
            //abilitazione pulsanti
            InserimentoUtente.IsEnabled = true;
            LetRimanenti.IsEnabled = true;
            CercaParole.IsEnabled = true;
            try
            {
                //leggo e cotrollo nome del file
                fileName = FileName.Text;
                if (fileName == null)
                {
                    throw new Exception();
                }
                //creo tabellone con file
                Puzzle = new Tabellone(@"..\..\..\" + fileName);//Creo tabellone
            }
            catch (Exception ex)
            {
                //errore in caso di file sbagliato
                MessageBox.Show("Mettere un file valido:\n" + ex.Message, "Errore"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //resetto la grid
            Tab.Children.Clear();
            Tab.RowDefinitions.Clear();
            Tab.ColumnDefinitions.Clear();
            Puzzle.CreazioneTabellone(Tab);
        }

        private void LetRimanenti_Click(object sender, RoutedEventArgs e)
        {
            //inizializzo la parola segreta
            string parolaSegreta = "";
            for (int i = 0; i < Puzzle.NumeroRighe(); i++)
            {
                for (int s = 0; s < Puzzle.NumeroColonne(); s++)
                {
                    //itero per controllare lettere bianche 
                    if (Puzzle.Caselle[i, s].MyBrush.Color == Colors.White)
                        parolaSegreta = parolaSegreta + Puzzle.Caselle[i, s].Lettera;//controllo per colore
                }
            }
            //show result
            FinalSolution.Text = parolaSegreta;
        }

        private void CercaParole_Click(object sender, RoutedEventArgs e)
        {
            Puzzle.SatusCleaner();
            //cancello tabellone precedente
            Tab.Children.Clear();
            Tab.RowDefinitions.Clear();
            Tab.ColumnDefinitions.Clear();
            //Creo il tabellone
            Puzzle.CreazioneTabellone(Tab);
            string word = InserimentoUtente.Text;
            Puzzle.Ricerca(word);

        }
    }
}
