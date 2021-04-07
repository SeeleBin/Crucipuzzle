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
/// Dargui Hamza 4L
/// 24/02/2021
/// </summary>
    class Casella
    {
        //Attributi
        private char _lettera; //Lettera contenuta nella casella
        private ConsoleColor _background; //Colore di background della casella
        private ConsoleColor _foreground; //Colore di foreground della casella
        private SolidColorBrush myBrush;
        private bool check = false;
        

        //Proprietà
        /// <summary>
        /// Lettera contenuta nella casella
        /// </summary>
        public char Lettera
        {
            get
            {
                return _lettera;
            }
            set
            {
                string accettati = "ABCDEFGHIJKLMNOPQRSTUVWXYZèéàòìù".ToUpper();//controllo alfabeto
                if (accettati.Contains(char.ToUpper(value).ToString()))
                    _lettera = value;
                else
                    throw new ArgumentException("Carattere inserito non valido.");//esco errore
            }
        }
        /// <summary>
        /// Colore di background della casella
        /// </summary>
        public ConsoleColor Background { get; set; }
        /// <summary>
        /// Colore di foreground della casella
        /// </summary>
        public ConsoleColor Foreground { get; set; }
        public SolidColorBrush MyBrush { get => myBrush; set => myBrush = value; }
        public bool Check { get => check; set => check = value; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lettera"></param>
        //Costruttori
        public Casella(char lettera)
        {
            Lettera = lettera;
            Background = ConsoleColor.Black;
            Foreground = ConsoleColor.White;
            MyBrush= new SolidColorBrush(Colors.White);
        }
        /// <summary>
        /// 
        /// </summary>
        public Casella()
        {
            Lettera = ' ';
            Background = ConsoleColor.Black;
            Foreground = ConsoleColor.White;
            MyBrush = new SolidColorBrush(Colors.White);
        }
        public Casella(SolidColorBrush col)
        {
            Lettera = ' ';
            Background = ConsoleColor.Black;
            Foreground = ConsoleColor.White;
            MyBrush = new SolidColorBrush(col.Color);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lettera"></param>
        /// <param name="background"></param>
        /// <param name="foreground"></param>
        public Casella(char lettera, ConsoleColor background, ConsoleColor foreground)
        {
            Lettera = lettera;
            Background = background;
            Foreground = foreground;
            MyBrush = new SolidColorBrush(Colors.White);
        }
        public Casella(char lettera,SolidColorBrush col)
        {
            Lettera = lettera;
            Background = ConsoleColor.Black;
            Foreground = ConsoleColor.White;
            MyBrush = new SolidColorBrush(col.Color);
        }
    }
}
