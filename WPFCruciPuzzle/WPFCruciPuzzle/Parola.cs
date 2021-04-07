using System;
using System.Collections.Generic;
using System.Text;

namespace WPFCruciPuzzle
{
    /// <summary>
    /// Dargui Hamza 4L
    /// 24/02/2021
    /// </summary>
    class Parola
    {
        //Attributi
        private string _contenuto;
        private ConsoleColor _background;
        private ConsoleColor _foreground;
        private int _x;
        private int _y;
        private Direzione _verso;

        //Proprietà
        /// <summary>
        /// Contenuto della stringa
        /// </summary>
        public string Contenuto { get; set; }
        /// <summary>
        /// Colore di background
        /// </summary>
        public ConsoleColor Background { get; set; }
        /// <summary>
        /// Colore di foreground
        /// </summary>
        public ConsoleColor Foreground { get; set; }
        /// <summary>
        /// Coordinata x della prima lettera, negativa se non trovata
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Coordinata y della prima lettera, negativa se non trovata
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Direzione della parola sul tabellone
        /// </summary>
        public Direzione Verso { get; set; }

        //Costruttori
        public Parola()
        {
            Contenuto = " ";
            Background = ConsoleColor.Black;
            Foreground = ConsoleColor.White;
            X = -1;
            Y = -1;
            Verso = Direzione.NULL;
        }

        public Parola(string contenuto)
        {
            Contenuto = contenuto;
            Background = ConsoleColor.Black;
            Foreground = ConsoleColor.White;
            X = -1;
            Y = -1;
            Verso = Direzione.NULL;
        }

    }
}
