using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XOGameCL.Code
{   
    public class Victory : IVictory
    {

        private static IVictory _Victory;
        private Victory()
        {         
        }
        public static IVictory GetInstance()
        {
            if (_Victory == null)
                _Victory = new Victory();
            return _Victory;
        }

        /// <summary>
        /// Метод определяет победителя в игре
        /// </summary>
        /// <param name="value">Массив обьектов текущего состояния игрового поля</param>
        /// <returns>СостояниеХода.X - если победил игрок Х, СостояниеХода.O - если победил игрок О, СостояниеХода.NULL - если нечья, null - если игра еще не закончена</returns>
        public  СостояниеХода? Победа(XOObject[] value)
        {

            СостояниеХода cell_0 = ((XOObject)value[0]).Ход;
            СостояниеХода cell_1 = ((XOObject)value[1]).Ход;
            СостояниеХода cell_2 = ((XOObject)value[2]).Ход;
            СостояниеХода cell_3 = ((XOObject)value[3]).Ход;
            СостояниеХода cell_4 = ((XOObject)value[4]).Ход;
            СостояниеХода cell_5 = ((XOObject)value[5]).Ход;
            СостояниеХода cell_6 = ((XOObject)value[6]).Ход;
            СостояниеХода cell_7 = ((XOObject)value[7]).Ход;
            СостояниеХода cell_8 = ((XOObject)value[8]).Ход;

            if (((cell_0 == СостояниеХода.X) && (cell_1 == СостояниеХода.X) && (cell_2 == СостояниеХода.X)) ||
                ((cell_3 == СостояниеХода.X) && (cell_4 == СостояниеХода.X) && (cell_5 == СостояниеХода.X)) ||
                ((cell_6 == СостояниеХода.X) && (cell_7 == СостояниеХода.X) && (cell_8 == СостояниеХода.X)) ||
                ((cell_0 == СостояниеХода.X) && (cell_3 == СостояниеХода.X) && (cell_6 == СостояниеХода.X)) ||
                ((cell_1 == СостояниеХода.X) && (cell_4 == СостояниеХода.X) && (cell_7 == СостояниеХода.X)) ||
                ((cell_2 == СостояниеХода.X) && (cell_5 == СостояниеХода.X) && (cell_8 == СостояниеХода.X)) ||
                ((cell_0 == СостояниеХода.X) && (cell_4 == СостояниеХода.X) && (cell_8 == СостояниеХода.X)) ||
                ((cell_2 == СостояниеХода.X) && (cell_4 == СостояниеХода.X) && (cell_6 == СостояниеХода.X)))
            {
                return СостояниеХода.X;

            }
            else if
                (((cell_0 == СостояниеХода.O) && (cell_1 == СостояниеХода.O) && (cell_2 == СостояниеХода.O)) ||
                 ((cell_3 == СостояниеХода.O) && (cell_4 == СостояниеХода.O) && (cell_5 == СостояниеХода.O)) ||
                 ((cell_6 == СостояниеХода.O) && (cell_7 == СостояниеХода.O) && (cell_8 == СостояниеХода.O)) ||
                 ((cell_0 == СостояниеХода.O) && (cell_3 == СостояниеХода.O) && (cell_6 == СостояниеХода.O)) ||
                 ((cell_1 == СостояниеХода.O) && (cell_4 == СостояниеХода.O) && (cell_7 == СостояниеХода.O)) ||
                 ((cell_2 == СостояниеХода.O) && (cell_5 == СостояниеХода.O) && (cell_8 == СостояниеХода.O)) ||
                 ((cell_0 == СостояниеХода.O) && (cell_4 == СостояниеХода.O) && (cell_8 == СостояниеХода.O)) ||
                 ((cell_2 == СостояниеХода.O) && (cell_4 == СостояниеХода.O) && (cell_6 == СостояниеХода.O)))
            {
                return СостояниеХода.O;

            }
            else if
              ((cell_0 != СостояниеХода.NULL) && (cell_1 != СостояниеХода.NULL) && (cell_2 != СостояниеХода.NULL) &&
               (cell_3 != СостояниеХода.NULL) && (cell_4 != СостояниеХода.NULL) && (cell_5 != СостояниеХода.NULL) &&
               (cell_6 != СостояниеХода.NULL) && (cell_7 != СостояниеХода.NULL) && (cell_8 != СостояниеХода.NULL))
            {
                return СостояниеХода.NULL;
            }

            return null;
        }

        /// <summary>
        /// Метод определяет следующий ход в игре для ПК
        /// </summary>
        /// <param name="value">Массив обьектов текущего состояния игрового поля</param>
        /// <param name="nextStep">Текущий игрок Х или О</param>
        /// <returns></returns>
        public XOObject ПолучитьЯчейкуДляСледующегоХода(XOObject[] value, СостояниеХода nextStep)
        {
            XOObject result = null;

            result = ПроверитьВозможностьСвоегоВыйгрыша(value, nextStep);
            if (result == null)
                result = НедопуститьВыйгрышСоперника(value, nextStep);
            
            if (result == null)
                result = ВыбратьОптимальныйХод(value);
            
            return result;

           // return ВыбратьОптимальныйХод(value);
        }

        /// <summary>
        /// Метод не дает выйграть сопернику
        /// </summary>
        /// <param name="value">Массив обьектов текущего состояния игрового поля</param>
        /// <param name="nextStep">Текущий игрок Х или О</param>
        /// <returns></returns>
        private  XOObject НедопуститьВыйгрышСоперника(XOObject[] value, СостояниеХода nextStep)
        {
            if (nextStep == СостояниеХода.O)
                nextStep = СостояниеХода.X;
            else
                nextStep = СостояниеХода.O;
            return ПроверитьВозможностьСвоегоВыйгрыша(value, nextStep);
        }

        /// <summary>
        /// Метод определяет опримальный ход
        /// </summary>
        /// <param name="value">Массив обьектов текущего состояния игрового поля</param>
        /// <returns></returns>
        private  XOObject ВыбратьОптимальныйХод(XOObject[] value)
        {
            IEnumerable<object> getMass = value.Where(p => ((p as XOObject)) != null).Where(p => (p as XOObject).Ход == СостояниеХода.NULL);
            Random rnd = new Random();
            int maxValue = (getMass.Count() - 1) < 0 ? 0 : (getMass.Count() - 1);
            return (XOObject)getMass.ToArray()[rnd.Next(maxValue)];
        }

        /// <summary>
        /// Метод оределяет возможно ли на данном этапе завершить игру
        /// </summary>
        /// <param name="value">Массив обьектов текущего состояния игрового поля</param>
        /// <param name="nextStep">Текущий игрок Х или О</param>
        /// <returns></returns>
        private  XOObject ПроверитьВозможностьСвоегоВыйгрыша(object[] value, СостояниеХода nextStep)
        {
            XOObject cell_0 = value[0] as XOObject;
            XOObject cell_1 = value[1] as XOObject;
            XOObject cell_2 = value[2] as XOObject;
            XOObject cell_3 = value[3] as XOObject;
            XOObject cell_4 = value[4] as XOObject;
            XOObject cell_5 = value[5] as XOObject;
            XOObject cell_6 = value[6] as XOObject;
            XOObject cell_7 = value[7] as XOObject;
            XOObject cell_8 = value[8] as XOObject;                       

            #region 1
            if ((cell_0.Ход == nextStep) && (cell_2.Ход == nextStep) && (cell_1.Ход == СостояниеХода.NULL))
                return cell_1;
            if ((cell_3.Ход == nextStep) && (cell_5.Ход == nextStep) && (cell_4.Ход == СостояниеХода.NULL))
                return cell_4;
            if ((cell_6.Ход == nextStep) && (cell_8.Ход == nextStep) && (cell_7.Ход == СостояниеХода.NULL))
                return cell_7;
            if ((cell_0.Ход == nextStep) && (cell_6.Ход == nextStep) && (cell_3.Ход == СостояниеХода.NULL))
                return cell_3;
            if ((cell_1.Ход == nextStep) && (cell_7.Ход == nextStep) && (cell_4.Ход == СостояниеХода.NULL))
                return cell_4;
            if ((cell_2.Ход == nextStep) && (cell_8.Ход == nextStep) && (cell_5.Ход == СостояниеХода.NULL))
                return cell_5;
            if ((cell_0.Ход == nextStep) && (cell_8.Ход == nextStep) && (cell_4.Ход == СостояниеХода.NULL))
                return cell_4;
            if ((cell_2.Ход == nextStep) && (cell_6.Ход == nextStep) && (cell_4.Ход == СостояниеХода.NULL))
                return cell_4;
            #endregion

            #region 2
            if ((cell_1.Ход == nextStep) && (cell_2.Ход == nextStep) && (cell_0.Ход == СостояниеХода.NULL))
                return cell_0;
            if ((cell_4.Ход == nextStep) && (cell_5.Ход == nextStep) && (cell_3.Ход == СостояниеХода.NULL))
                return cell_3;
            if ((cell_7.Ход == nextStep) && (cell_8.Ход == nextStep) && (cell_6.Ход == СостояниеХода.NULL))
                return cell_6;
            if ((cell_3.Ход == nextStep) && (cell_6.Ход == nextStep) && (cell_0.Ход == СостояниеХода.NULL))
                return cell_0;
            if ((cell_4.Ход == nextStep) && (cell_7.Ход == nextStep) && (cell_1.Ход == СостояниеХода.NULL))
                return cell_1;
            if ((cell_5.Ход == nextStep) && (cell_8.Ход == nextStep) && (cell_2.Ход == СостояниеХода.NULL))
                return cell_2;
            if ((cell_4.Ход == nextStep) && (cell_8.Ход == nextStep) && (cell_0.Ход == СостояниеХода.NULL))
                return cell_0;
            if ((cell_4.Ход == nextStep) && (cell_6.Ход == nextStep) && (cell_6.Ход == СостояниеХода.NULL))
                return cell_2;
            #endregion

            #region 3
            if ((cell_0.Ход == nextStep) && (cell_1.Ход == nextStep) && (cell_2.Ход == СостояниеХода.NULL))
                return cell_2;
            if ((cell_3.Ход == nextStep) && (cell_4.Ход == nextStep) && (cell_5.Ход == СостояниеХода.NULL))
                return cell_5;
            if ((cell_6.Ход == nextStep) && (cell_7.Ход == nextStep) && (cell_8.Ход == СостояниеХода.NULL))
                return cell_8;
            if ((cell_0.Ход == nextStep) && (cell_3.Ход == nextStep) && (cell_6.Ход == СостояниеХода.NULL))
                return cell_6;
            if ((cell_1.Ход == nextStep) && (cell_4.Ход == nextStep) && (cell_7.Ход == СостояниеХода.NULL))
                return cell_7;
            if ((cell_2.Ход == nextStep) && (cell_5.Ход == nextStep) && (cell_8.Ход == СостояниеХода.NULL))
                return cell_8;
            if ((cell_0.Ход == nextStep) && (cell_4.Ход == nextStep) && (cell_8.Ход == СостояниеХода.NULL))
                return cell_8;
            if ((cell_2.Ход == nextStep) && (cell_4.Ход == nextStep) && (cell_6.Ход == СостояниеХода.NULL))
                return cell_6;
            #endregion

            return null;
        }
                    
    }
}
