using System;
using System.Globalization;
using System.Windows.Forms;

namespace SuperSorter
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
