using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using XOGame.Core;

namespace XOGameMetro.Core
{
    public static class MyButton
    {                          
        public static void TextToImage(this Button button, string text)
        {
            button.Content = text;
            switch (text.ToLower())
            {
                case "x":
                    button.Background = new Uri("image\\X_1.PNG", UriKind.Relative).UriToImageBrush();
                    break;
                case "o":
                    button.Background = new Uri("image\\O_1.PNG", UriKind.Relative).UriToImageBrush();
                    break;
                default:
                    button.Background = new Uri("image\\Q.PNG", UriKind.Relative).UriToImageBrush();
                    break;
            }
        }

        public static XOObject ButtonToXOObject(this Button button)
        {
            return new XOObject
            {
                Name = button.Name,
                Text = button.Content.ToString(),
                Tag = button.Tag,
                Background = button.Background
            };
        }
       
    }
}
