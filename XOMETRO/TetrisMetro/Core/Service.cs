using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;

namespace TetrisMetro
{  
    public class Service
    {
        Assembly assem
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }

        public void ShowError(string massage)
        {
            MessageBox.Show(massage, assem.FullName.Split(',')[0],MessageBoxButton.OK);
        }

        public void ShowWarning(string massage)
        {
            MessageBox.Show(massage, assem.FullName.Split(',')[0], MessageBoxButton.OK);
        }

        public void ShowMassege(string massage)
        {
            MessageBox.Show(massage, assem.FullName.Split(',')[0], MessageBoxButton.OK);
        }
    }
}
