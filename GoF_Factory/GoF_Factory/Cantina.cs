using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Factory
{
    /// <summary>
    /// Factory für IEssen
    /// Essen ist abhängig von der aktuellen Uhrzeit 
    /// Bis 11 Uhr gibt es Frühstück 
    /// Bis 14 Uhr gibt es Mittagessen
    /// Bis 22 Uhr gibt es Abendessen
    /// Ansonsten gibt es kein Essen
    /// 
    /// Welches Essen erzeugt wird, wird der Fabrik überlassen. 
    /// </summary>
    class Cantina
    {
        /// <summary>
        /// Parameterlose Implementierung
        /// </summary>
        /// <returns>IEssen Essen</returns>
        public IEssen GibEssen() => GibEssen(DateTime.Now);


        /// <summary>
        /// Implementierung mit Parameter
        /// </summary>
        /// <param name="uhrzeit">Uhrzeit für die man ein Essen will</param>
        /// <returns>IEssen Essen</returns>
        public IEssen GibEssen(DateTime uhrzeit)
        {
            IEssen mahlzeit;
            switch (uhrzeit.Hour)
            {
                //Switch mit Pattern matching 
                case int h when (h >= 6 && h < 11):
                    mahlzeit = new Frühstück();
                    break;
                case int h when (h >= 11 && h < 14):
                    mahlzeit = new Mittagessen();
                    break;
                case int h when (h >= 14 && h < 22):
                    mahlzeit = new Abendessen();
                    break;
                default:
                    mahlzeit = new KeinEssen();
                    break;
            }


            return mahlzeit;
        }

        #region PatternMatching
        public void DemoFürPatternMatching(IEssen input)
        {
            // Seit c# 7.0:
            switch (input)
            {
                case Frühstück x:
                    break;
                case Mittagessen x:
                    break;
                case Abendessen x:
                    break;
            }
        }

        public void DemoFürPatternMatching<T>(T input) where T : IEssen
        {
            // Seit c# 7.1:
            switch (input)
            {
                case Frühstück x:
                    break;
                case Mittagessen x:
                    break;
                case Abendessen x:
                    break;
            }
        }
        #endregion
    }
}
