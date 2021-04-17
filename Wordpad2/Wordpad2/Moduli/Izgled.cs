using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;
using System.Windows.Controls;

namespace Wordpad2.Moduli
{
    public class Izgled
    {

        public void promeniPozadinuTeksta(bool pritisnutoDugme, TextSelection selekcija, Brush boja)
        {
            if (pritisnutoDugme)
            {
                selekcija.ApplyPropertyValue(Inline.BackgroundProperty, boja);
            }
            else
            {
                selekcija.ApplyPropertyValue(Inline.BackgroundProperty, null);
            }
        }


        public void promeniBojuTeksta(bool pritisnutoDugme, TextSelection selekcija, Brush boja)
        {
            if (pritisnutoDugme)
            {
                selekcija.ApplyPropertyValue(Inline.ForegroundProperty, boja);
            }
            else
            {
                selekcija.ApplyPropertyValue(Inline.ForegroundProperty, Brushes.Black);
            }

        }


        public void promeniVelicinuFonta(TextSelection selekcija, int velicina)
        {
            if (!selekcija.IsEmpty)
            {
                selekcija.ApplyPropertyValue(TextElement.FontSizeProperty, velicina.ToString());
            }
        }

        public void promeniFont(TextSelection selekcija, FontFamily f)
        {
            if (selekcija != null && f != null)
               selekcija.ApplyPropertyValue(Inline.FontFamilyProperty, f);
        }

    }
}
