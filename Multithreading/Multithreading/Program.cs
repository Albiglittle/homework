using System;
using System.Windows.Forms;
using Multithreading.Controllers;
using Multithreading.Views;

namespace Multithreading
{
    internal static class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var view = new ExamView();
            var contriller = new ExamController(view);
            Application.Run(view);
        }
    }
}