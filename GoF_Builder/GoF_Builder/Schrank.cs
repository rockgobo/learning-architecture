using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Builder
{
    /// <summary>
    /// Schrank implementiert Builder Pattern
    /// </summary>
    class Schrank
    {
        private Schrank() { } //Muss private sein, da das erstellen der Builder übernommen soll

        public int AnzahlTüren { get; set; }
        public enum OberflächenArt { Unbehandelt, Lackiert, Gewachst }
        public OberflächenArt Oberfläche { get; set;}
        public string Farbe { get; set; }
        public bool Metallschienen { get; set; }
        public int AnzahlBöden { get; set; }
        public bool Kleiderstange { get; set; }

        public static Erbauer Schrankbauer() => new Erbauer(); 

        // Auto property
        // prop + TAB + TAB

        // Volles Property mit privatem Feld 
        // propfull + TAB + TAB


        /// <summary>
        /// Interner Builder für Schränke, hier kann der Client den Schrank konfigurieren 
        /// Konstraints werden in den Builder Methoden überprüft und eventuell ein Fehler
        /// geworfen
        /// </summary>
        public class Erbauer
        {
            private Schrank gebauterSchrank;

            public Erbauer(){
                gebauterSchrank = new Schrank();
            }

            public Erbauer MitTüren(int AnzahlTüren)
            {
                if (AnzahlTüren >= 2 && AnzahlTüren <= 7)
                    gebauterSchrank.AnzahlTüren = AnzahlTüren;
                else
                    throw new ArgumentException("Der Schrank darf nur zwischen 2 und 7 Türen haben !");
                return this;
            }
            public Erbauer MitBöden(int AnzahlBöden)
            {
                if (AnzahlBöden >= 0 && AnzahlBöden <= 6)
                    gebauterSchrank.AnzahlBöden = AnzahlBöden;
                else
                    throw new ArgumentException("Der Schrank darf nur zwischen 0 und 6 Böden haben !");
                return this;
            }
            public Erbauer MitOberfläche(OberflächenArt Oberfläche)
            {
                gebauterSchrank.Oberfläche = Oberfläche;
                return this;
            }
            public Erbauer MitFarbe(string Farbe)
            {
                if (gebauterSchrank.Oberfläche == OberflächenArt.Lackiert)
                    gebauterSchrank.Farbe = Farbe;
                else
                    throw new ArgumentException("Der Schrank darf nur eine Farbe bekommen, wenn er lackiert wird !");
                return this;
            }
            public Erbauer MitKleiderstange(bool Kleiderstange)
            {
                gebauterSchrank.Kleiderstange = Kleiderstange;
                return this;
            }
            public Erbauer MitMetallschienen(bool Metallschienen)
            {
                gebauterSchrank.Metallschienen = Metallschienen;
                return this;
            }

            public Schrank Konstruieren()
            {
                return gebauterSchrank;
            }
        }
    }
}
