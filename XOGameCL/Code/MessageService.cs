﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGameCL.Code
{
    public interface IMessageService
    {        
        void ShowMessage(string message);
        void ShowExclamation(string exclamation);
        void ShowError(string error);
    }  
}
