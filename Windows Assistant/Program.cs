using System.Windows.Forms;
using System;

namespace Windows_Assistant
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new WindowsAssistant());
        }
    }
}