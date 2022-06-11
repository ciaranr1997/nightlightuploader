using System;
using System.Windows.Forms;

namespace DbdSSUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting!");
            MainForm form = new MainForm();
            form.Show();
            
            Application.Run();

        }
    }
}
