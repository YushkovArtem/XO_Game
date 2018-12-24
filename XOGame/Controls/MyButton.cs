using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace XOGame
{
    // class надстройка для рассширения функционала class Button
    public static class MyButton
    {
        public static void SetImage(this Button button, string value)
        {            
            switch (value.ToLower())
            {
                case "х":
                case "x":
                    button.Image = Properties.Resources.X_1;
                    break;
                case "о":
                case "o":
                    button.Image = Properties.Resources.O_1;
                    break;
                default:
                    button.Image = Properties.Resources.Q;
                    break;
            }
        }
    }
}
