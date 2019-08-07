using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace Goldenart_Mng
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool instanceCountOne = false;

            using (Mutex mtex = new Mutex(true, "MyRunningApp", out instanceCountOne))
            {
                if (instanceCountOne)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new login());
                    mtex.ReleaseMutex();
                }
                else
                {
                    MessageBox.Show("نرم افزار در حال اجراست لطفا از نوار ابزار نسبت به اجرا اقدام کنید","خطای اجرا");
                }
            }
        }
    }
}
