﻿#pragma checksum "D:\Проекты\XOGame\XOMETRO\TetrisMetro\Help.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "96D7578972361F848878906F8EA6A4BD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace TetrisMetro {
    
    
    public partial class Help : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock lblTitle;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        internal System.Windows.Controls.TextBlock lblProductName;
        
        internal System.Windows.Controls.TextBlock lblDescription;
        
        internal System.Windows.Controls.TextBlock lblDeweloper;
        
        internal System.Windows.Controls.TextBlock lblVercion;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/XOGameMetro;component/Help.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.lblTitle = ((System.Windows.Controls.TextBlock)(this.FindName("lblTitle")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
            this.lblProductName = ((System.Windows.Controls.TextBlock)(this.FindName("lblProductName")));
            this.lblDescription = ((System.Windows.Controls.TextBlock)(this.FindName("lblDescription")));
            this.lblDeweloper = ((System.Windows.Controls.TextBlock)(this.FindName("lblDeweloper")));
            this.lblVercion = ((System.Windows.Controls.TextBlock)(this.FindName("lblVercion")));
        }
    }
}

