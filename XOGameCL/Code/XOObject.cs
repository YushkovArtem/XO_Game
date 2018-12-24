using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGameCL.Code
{
    public enum СостояниеХода
    {
        X = 1,
        O = 0,
        NULL = 2
    }

    public class XOObject
    {
        public string ID { get; set; }
        public СостояниеХода Ход { get; set; }
        public bool ХодСделан { get; set; }       
    }
}
