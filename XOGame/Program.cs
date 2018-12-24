using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XOGame;
using XOGameCL.Code;

namespace XOGame
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm form = new MainForm();
            IMessageService serv = new MessageService();
            var presenter = new MainPresentor(form, serv); // Dependency Injection
            presenter.Run();
        }
    }
}
