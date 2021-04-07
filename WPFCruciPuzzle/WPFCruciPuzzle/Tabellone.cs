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
namespace WPFCruciPuzzle
{
    /// <summary>
    /// Dargui Hamza 4L
    /// 24/02/2021
    /// </summary>
    class Tabellone
    {
        //Attributi
        private Casella[,] _caselle;
        private Parola[] _parole;

        //Proprietà
        /// <summary>
        /// Tabellone contenente le caselle
        /// </summary>
        public Casella[,] Caselle { get; set; }
        /// <summary>
        /// Vettore delle parole cercate
        /// </summary>
        public Parola[,] Parole { get; set; }

        //Costruttori
        /// <summary>
        /// Costruttore del tabellone
        /// </summary>
        /// <param name="Puzzle"></param>
        public Tabellone(Casella[,] Puzzle)
        {
            this.Caselle = Puzzle;
        }
        /// <summary>
        /// Costruttore del tabellone
        /// </summary>
        /// <param name="r">Numero di righe</param>
        /// <param name="c">Numero di colonne</param>
        public Tabellone(int r, int c)
        {
            Caselle = new Casella[r, c];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileTabellone"></param>
        public Tabellone(string fileTabellone)
        {
            string[] readText = File.ReadAllLines(fileTabellone);//leggo da tab
            Caselle = new Casella[readText.Length, readText[0].Length];

            for (int r = 0; r < Caselle.GetLength(0); r++)
                for (int c = 0; c < Caselle.GetLength(1); c++)
                    Caselle[r, c] = new Casella(char.ToUpper(readText[r][c]));//uppo il char
        }

        //Metodi
        public bool CercaParola(Parola parola)
        {
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int NumeroRighe()
        {
            return Caselle.GetLength(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int NumeroColonne()
        {
            return Caselle.GetLength(1);
        }
        
        /// <summary>
        /// Prendo x della prima lettera
        /// </summary>
        /// <param name="parola"></param>
        /// <returns></returns>
        public int posFistLetX(string parola)
        {
            for (int r = 0; r < Caselle.GetLength(0); r++)
            {
                for (int c = 0; c < Caselle.GetLength(1); c++)
                {
                    if (Caselle[r, c].Check == false && Caselle[r, c].Lettera.ToString() == parola[0].ToString().ToUpper())
                    {
                        return c;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// prendo y prima lettera
        /// </summary>
        /// <param name="parola"></param>
        /// <returns></returns>
        public int posFistLetY(string parola)
        {
            for (int r = 0; r < Caselle.GetLength(0); r++)
            {
                for (int c = 0; c < Caselle.GetLength(1); c++)
                {
                    if (Caselle[r, c].Check == false && Caselle[r, c].Lettera.ToString() == parola[0].ToString().ToUpper())
                    {
                        return r;
                    }
                }
            }
            return -1;
        }
        /// <summary>
        /// trovo numero della prima lettera ripetuta sulla grid
        /// </summary>
        /// <param name="parola"></param>
        /// <returns></returns>
        public int numOfLet(string parola)
        {
            int cont = 0;
            for (int r = 0; r < Caselle.GetLength(0); r++)
            {
                for (int c = 0; c < Caselle.GetLength(1); c++)
                {
                    if (Caselle[r, c].Check == false && Caselle[r, c].Lettera.ToString() == parola[0].ToString().ToUpper())
                    {
                        cont++;
                    }
                }
            }
            return cont;
        }
        /// <summary>
        /// Add on per numOfLet
        /// </summary>
        public void SatusCleaner()
        {

            for (int r = 0; r < Caselle.GetLength(0); r++)
            {
                for (int c = 0; c < Caselle.GetLength(1); c++) { if (Caselle[r, c].Check == true) { Caselle[r, c].Check = false; } }
            }

        }

        public void CreazioneTabellone(Grid Tab)
        {
            //creo matrice di label
            Label[,] gridLab = new Label[NumeroRighe(), NumeroColonne()];
            for (int i = 0; i < NumeroRighe(); i++)
            {
                for (int s = 0; s < NumeroColonne(); s++)
                {
                    //creo lable con impostazioni custom
                    gridLab[i, s] = new Label()
                    {
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalContentAlignment = VerticalAlignment.Center,
                        BorderBrush = Brushes.Black,
                        Background = Caselle[i, s].MyBrush,
                        BorderThickness = new Thickness(0.6)
                    };
                    //cambio colore di una parola vecchia
                    if (Caselle[i, s].MyBrush.Color == Colors.Green)
                    {
                        Caselle[i, s].MyBrush.Color = Colors.Red;
                    }
                    //aggiungo una lettera alla label
                    gridLab[i, s].Content = Caselle[i, s].Lettera;
                }
            }
            for (int i = 0; i < NumeroColonne(); i++)
            {
                //creo colonne della grid
                Tab.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(10, GridUnitType.Star) });
            }
            for (int i = 0; i < NumeroRighe(); i++)
            {
                //creo righe della grid
                Tab.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(10, GridUnitType.Star) });
                for (int s = 0; s < NumeroColonne(); s++)
                {
                    Grid.SetRow(gridLab[i, s], i);
                    Grid.SetColumn(gridLab[i, s], s);
                    Tab.Children.Add(gridLab[i, s]);
                }

            }
        }

        public void Ricerca(string word)
        {
           
            try
            {
                //prendo parola dalla texbox
                
                //controllo lunghezza della parola
                if (word == null || word.Length > Caselle.GetLength(1))
                {
                    throw new Exception();
                }
                //trovo il numero delle lettere iniziali
                int times = numOfLet(word);
                for (int i = 0; i < times; i++)
                {
                    //trovo le posizioni delle prime lettere
                    int x, y;
                    x = posFistLetX(word);
                    y = posFistLetY(word);
                    //sinistra destra
                    for (int s = x, cont = 0; s < word.Length + x; s++, cont++)
                    {
                        if (s > Caselle.GetLength(1) - 1 || s<0)
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        if (Caselle[y, s].Lettera.ToString() != word[cont].ToString().ToUpper())
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        else if (cont == word.Length - 1)
                        {
                            for (int k = x; k < word.Length + x; k++)
                            {
                                Caselle[y, k].MyBrush.Color = Colors.Green;
                            }
                            return;
                        }
                    }
                    //destra sinistra
                    for (int s = x, cont = 0; s > x - word.Length; s--, cont++)
                    {
                        if (s < 0)
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        if (Caselle[y, s].Lettera.ToString() != word[cont].ToString().ToUpper())
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        else if (cont == word.Length - 1)
                        {
                            for (int k = x; k > x - word.Length; k--)
                            {
                                Caselle[y, k].MyBrush.Color = Colors.Green;
                            }
                            return;
                        }
                    }
                    //alto basso
                    for (int s = y, cont = 0; s < word.Length + y; s++, cont++)
                    {
                        if (s > Caselle.GetLength(0) - 1)
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        if (Caselle[s, x].Lettera.ToString() != word[cont].ToString().ToUpper())
                        {
                            Caselle[y, s].Check = true;
                            break;
                        }
                        else if (cont == word.Length - 1)
                        {
                            for (int k = y; k < word.Length + y; k++)
                            {
                                Caselle[k, x].MyBrush.Color = Colors.Green;
                            }
                            return;
                        }
                    }
                    //basso alto
                    for (int s = y, cont = 0; s > y - word.Length; s--, cont++)
                    {
                        if (s < 0)
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        if (Caselle[s, x].Lettera.ToString() != word[cont].ToString().ToUpper())
                        {
                            Caselle[y, s].Check = true;
                            break;
                        }
                        else if (cont == word.Length - 1)
                        {
                            for (int k = y; k > y - word.Length; k--)
                            {
                                Caselle[k, x].MyBrush.Color = Colors.Green;
                            }
                            return;
                        }
                    }
                    //alto destra basso sinistra
                    for (int s = x, n = y, cont = 0; s < word.Length + x; s++, n++, cont++)
                    {
                        if (s > Caselle.GetLength(1) - 1 || n > Caselle.GetLength(0) - 1)
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        if (Caselle[n, s].Lettera.ToString() != word[cont].ToString().ToUpper())
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        else if (cont == word.Length - 1)
                        {
                            for (int k = x, m = y; k < word.Length + x; k++, m++)
                            {
                                Caselle[m, k].MyBrush.Color = Colors.Green;
                            }
                            return;
                        }
                    }
                    //basso destra alto sinistra
                    for (int s = x, n = y, cont = 0; s < word.Length + x; s++, n--, cont++)
                    {
                        if (s > Caselle.GetLength(1) - 1 || n < 0)
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        if (Caselle[n, s].Lettera.ToString() != word[cont].ToString().ToUpper())
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        else if (cont == word.Length - 1)
                        {
                            for (int k = x, m = y; k < word.Length + x; k++, m--)
                            {
                                Caselle[m, k].MyBrush.Color = Colors.Green;
                            }
                            return;
                        }
                    }
                    //alto sinistra basso destra
                    for (int s = x, n = y, cont = 0; s < word.Length + x; s--, n++, cont++)
                    {
                        if (s < 0 || n > Caselle.GetLength(0) - 1)
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        if (Caselle[n, s].Lettera.ToString() != word[cont].ToString().ToUpper())
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        else if (cont == word.Length - 1)
                        {
                            for (int k = x, b = y; k > x - word.Length; k--, b++)
                            {
                                Caselle[b, k].MyBrush.Color = Colors.Green;
                            }
                            return;
                        }
                    }
                    //basso destra alto sinistra
                    for (int s = x, n = y, cont = 0; s < word.Length + x; s--, n--, cont++)
                    {
                        if (s < 0 || n < 0)
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        if (Caselle[n, s].Lettera.ToString() != word[cont].ToString().ToUpper())
                        {
                            Caselle[y, x].Check = true;
                            break;
                        }
                        else if (cont == word.Length - 1)
                        {
                            for (int k = x, b = y; k > x - word.Length; k--, b--)
                            {
                                Caselle[b, k].MyBrush.Color = Colors.Green;
                            }
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //in caso di overflow di parola
                MessageBox.Show("Parola non trovata\n" , "Errore"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
       



    }
}
