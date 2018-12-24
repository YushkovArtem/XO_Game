using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGameCL.Code
{
    public interface IVictory
    {
        XOObject ПолучитьЯчейкуДляСледующегоХода(XOObject[] value, СостояниеХода nextStep);
        СостояниеХода? Победа(XOObject[] value);
    }
}
