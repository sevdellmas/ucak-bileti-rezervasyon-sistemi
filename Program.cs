using System;
using System.Windows.Forms;
using UcakBiletiRezervasyonSistemi.Siniflar;

namespace UcakBiletiRezervasyonSistemi
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Başlatılacak form
            Application.Run(new FormAcilis()); 
        }
    }
}
