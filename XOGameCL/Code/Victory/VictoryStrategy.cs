using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGameCL.Code
{
    public class VictoryStrategy : IVictory
    {
        private IVictory _VictoryStrategy;
        public VictoryStrategy(Mode mode)
        {
            if (mode == Mode.easy)
                _VictoryStrategy = Victory.GetInstance();
            else
                _VictoryStrategy = VictoryHard.GetInstance();

        }
        public XOObject ПолучитьЯчейкуДляСледующегоХода(XOObject[] value, СостояниеХода nextStep)
        {
            return _VictoryStrategy.ПолучитьЯчейкуДляСледующегоХода(value, nextStep);
        }

        public СостояниеХода? Победа(XOObject[] value)
        {
            return _VictoryStrategy.Победа(value);
        }
    }
}
