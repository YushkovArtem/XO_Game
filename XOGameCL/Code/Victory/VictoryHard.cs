using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGameCL.Code
{
    public class VictoryHard: IVictory
    {
        private static IVictory _Victory;
        
        public VictoryComposite _VictoryComposite { get; private set; }
        
        private VictoryHard()
        {         
           _VictoryComposite =  GetDispozition();
        }

        public static IVictory GetInstance()
        {
            if (_Victory == null)
                _Victory = new VictoryHard();
            return _Victory;
        }

        public XOObject ПолучитьЯчейкуДляСледующегоХода(XOObject[] value, СостояниеХода nextStep)
        {

            int[] previous_step_arr = new int[9];
            int[] next_step_arr = null;

            for (int i = 0; i < value.Length; i++)
            {
                previous_step_arr[i] = ПолучитьЧисловоеПредставлениеХода(value[i].Ход);
            }

            Component parent_com = _VictoryComposite.FindChild(previous_step_arr);                     
            if (parent_com == null)
                #region Временное решение из за неполноты Дерева стратегий
                return Victory.GetInstance().ПолучитьЯчейкуДляСледующегоХода(value, nextStep);
                #endregion

            System.Collections.ArrayList clilds = parent_com.GetChilds();

            if (clilds == null)
                #region Временное решение из за неполноты Дерева стратегий
                return Victory.GetInstance().ПолучитьЯчейкуДляСледующегоХода(value, nextStep);
                #endregion

            Random rnd = new Random();
            int maxValue = (clilds.Count - 1) < 0 ? 0 : (clilds.Count - 1);
            next_step_arr = ((Component)clilds[rnd.Next(0, maxValue)]).ToIntArray();

            if (next_step_arr == null)
                #region Временное решение из за неполноты Дерева стратегий
                return Victory.GetInstance().ПолучитьЯчейкуДляСледующегоХода(value, nextStep);
                #endregion
            
            for (int i = 0; i < value.Length; i++)
            {
                if(ПолучитьЧисловоеПредставлениеХода(value[i].Ход) != next_step_arr[i])
                    return new XOObject() {ID = value[i].ID, Ход  = СостояниеХода.NULL, ХодСделан = false};
            }

            #region Временное решение из за неполноты Дерева стратегий
            return Victory.GetInstance().ПолучитьЯчейкуДляСледующегоХода(value, nextStep);
            #endregion

            //return null;
        }    

        private int ПолучитьЧисловоеПредставлениеХода(СостояниеХода СостояниеХода)
        {
            if(СостояниеХода == Code.СостояниеХода.X)
                return 1;

            if(СостояниеХода == Code.СостояниеХода.O)
                return 2;

            return 0;
        }        

        public СостояниеХода? Победа(XOObject[] value)
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
        /// Стратегия с использованием компановщика, обычный граф с вариантами ходов для обеспечения наиболее вероятной выйгрышной стратегии 
        /// (одной из возможных  стратегий с гарантированный выигрышем) 1- игрок, 2 - противник
        /// </summary>
        /// <returns></returns>
        public VictoryComposite GetDispozition()
        {
            #region Заполним узлы графа стратегии для выйгрыша
            VictoryComposite root = new VictoryComposite(new int[] { 0,0,0,0,0,0,0,0,0});

            VictoryComposite Leaf_1_1 = new VictoryComposite(new int[] { 1,0,0,0,0,0,0,0,0});
            VictoryComposite Leaf_1_2 = new VictoryComposite(new int[] { 0,0,0,0,1,0,0,0,0});

            VictoryComposite Leaf_2_1 = new VictoryComposite(new int[] { 1,0,0,0,2,0,0,0,0});
            VictoryComposite Leaf_2_2 = new VictoryComposite(new int[] { 1,0,2,0,0,0,0,0,0});
            VictoryComposite Leaf_2_3 = new VictoryComposite(new int[] { 1,2,0,0,0,0,0,0,0});
            VictoryComposite Leaf_2_4 = new VictoryComposite(new int[] { 2,0,0,1,0,0,0,0,0});
            VictoryComposite Leaf_2_5 = new VictoryComposite(new int[] { 0,2,0,0,1,0,0,0,0});

            VictoryComposite Leaf_3_1 = new VictoryComposite(new int[] { 1,0,0,0,2,0,0,0,1});
            VictoryComposite Leaf_3_2 = new VictoryComposite(new int[] { 1,0,2,0,0,0,1,0,0});
            VictoryComposite Leaf_3_3 = new VictoryComposite(new int[] { 2,0,1,0,1,0,0,0,0});
            VictoryComposite Leaf_3_4 = new VictoryComposite(new int[] { 0,2,0,0,1,0,1,0,0});

            VictoryComposite Leaf_4_1 = new VictoryComposite(new int[] { 1,0,0,0,2,0,2,0,1});
            VictoryComposite Leaf_4_2 = new VictoryComposite(new int[] { 1,0,0,2,2,0,0,0,1});
            VictoryComposite Leaf_4_3 = new VictoryComposite(new int[] { 1,2,2,0,0,0,2,0,0});
            VictoryComposite Leaf_4_4 = new VictoryComposite(new int[] { 1,0,2,2,0,0,1,0,0});
            VictoryComposite Leaf_4_5 = new VictoryComposite(new int[] { 2,0,1,0,1,0,2,0,0});
            VictoryComposite Leaf_4_6 = new VictoryComposite(new int[] { 2,0,1,2,1,0,0,0,0});
            VictoryComposite Leaf_4_7 = new VictoryComposite(new int[] { 0,2,2,0,1,0,1,0,0});
            VictoryComposite Leaf_4_8 = new VictoryComposite(new int[] { 2,2,0,0,1,0,1,0,0});

            VictoryComposite Leaf_5_1 = new VictoryComposite(new int[] { 1,0,1,0,2,0,2,0,1});
            VictoryComposite Leaf_5_2 = new VictoryComposite(new int[] { 1,0,0,2,2,1,0,0,1});
            VictoryLeaf Leaf_5_3 = new VictoryLeaf(new int[] { 1,2,2,1,0,0,1,0,0});
            VictoryComposite Leaf_5_4 = new VictoryComposite(new int[] { 1,0,2,2,0,0,1,0,1});
            VictoryComposite Leaf_5_5 = new VictoryComposite(new int[] { 2,0,1,1,1,0,2,0,0});
            VictoryLeaf Leaf_5_6 = new VictoryLeaf(new int[] { 2,0,1,2,1,0,1,0,0});
            VictoryComposite Leaf_5_7 = new VictoryComposite(new int[] { 1,2,2,0,1,0,1,0,0});
            VictoryLeaf Leaf_5_8 = new VictoryLeaf(new int[] { 2,2,1,0,1,0,1,0,0});


            VictoryComposite Leaf_6_1 = new VictoryComposite(new int[] { 1,2,1,0,2,0,2,0,1});
            VictoryComposite Leaf_6_2 = new VictoryComposite(new int[] { 1,0,0,2,2,1,2,0,1});
            VictoryComposite Leaf_6_2_1 = new VictoryComposite(new int[] { 1,0,2,2,2,1,0,0,1});
            VictoryComposite Leaf_6_4 = new VictoryComposite(new int[] { 1,0,2,2,0,0,1,2,1});
            VictoryComposite Leaf_6_4_1 = new VictoryComposite(new int[] { 2,0,1,2,0,0,1,0,1});
            VictoryComposite Leaf_6_5 = new VictoryComposite(new int[] { 2,0,1,1,1,0,2,0,0});
            VictoryComposite Leaf_6_7 = new VictoryComposite(new int[] { 1,2,2,0,1,0,1,0,2});

            VictoryLeaf Leaf_7_1 = new VictoryLeaf(new int[] { 1,2,1,0,2,1,2,0,1});
            VictoryLeaf Leaf_7_2 = new VictoryLeaf(new int[] { 1,0,1,2,2,1,2,0,1});
            VictoryComposite Leaf_7_3 = new VictoryComposite(new int[] { 1,0,2,2,2,1,1,0,1});
            VictoryLeaf Leaf_7_4 = new VictoryLeaf(new int[] { 1,0,2,2,1,0,1,2,1});
            VictoryLeaf Leaf_7_5 = new VictoryLeaf(new int[] { 2,0,1,1,1,1,2,2,0});
            VictoryComposite Leaf_7_6 = new VictoryComposite(new int[] { 2,1,1,1,1,2,2,0,0});
            VictoryLeaf Leaf_7_7 = new VictoryLeaf(new int[] { 1,2,2,1,1,0,1,0,2});

            VictoryComposite Leaf_8_3 = new VictoryComposite(new int[] { 1,0,2,2,2,1,1,2,1});
            VictoryComposite Leaf_8_3_1 = new VictoryComposite(new int[] { 1,2,2,2,2,1,1,0,1});
            VictoryComposite Leaf_8_6 = new VictoryComposite(new int[] { 2,1,1,1,1,2,2,2,0});
            VictoryComposite Leaf_8_6_1 = new VictoryComposite(new int[] { 2,1,1,1,1,2,2,0,2});

            VictoryLeaf Leaf_9_3 = new VictoryLeaf(new int[] { 1,0,2,2,2,1,1,2,1});
            VictoryLeaf Leaf_9_3_1 = new VictoryLeaf(new int[] { 1,2,2,2,2,1,1,0,1});
            VictoryLeaf Leaf_9_6 = new VictoryLeaf(new int[] { 2,1,1,1,1,2,2,2,0});
            VictoryLeaf Leaf_9_6_1 = new VictoryLeaf(new int[] { 2,1,1,1,1,2,2,0,2});
            #endregion

            #region Скомпануем дерево
            Leaf_8_3.Add(Leaf_9_3);
            Leaf_8_3_1.Add(Leaf_9_3_1);
            Leaf_8_6.Add(Leaf_9_6);
            Leaf_8_6_1.Add(Leaf_9_6_1);

            Leaf_7_3.Add(Leaf_8_3);
            Leaf_7_3.Add(Leaf_8_3_1);
            Leaf_7_6.Add(Leaf_8_6);
            Leaf_7_6.Add(Leaf_8_6_1);

            Leaf_6_1.Add(Leaf_7_1);
            Leaf_6_2.Add(Leaf_7_2);
            Leaf_6_2_1.Add(Leaf_7_3);
            Leaf_6_4.Add(Leaf_7_4);
            Leaf_6_4_1.Add(Leaf_7_5);
            Leaf_6_5.Add(Leaf_7_6);
            Leaf_6_7.Add(Leaf_7_7);

            Leaf_5_1.Add(Leaf_6_1);
            Leaf_5_2.Add(Leaf_6_2);
            Leaf_5_2.Add(Leaf_6_2_1);
            Leaf_5_4.Add(Leaf_6_4);
            Leaf_5_4.Add(Leaf_6_4_1);
            Leaf_5_5.Add(Leaf_6_5);
            Leaf_5_7.Add(Leaf_6_7);

            Leaf_4_1.Add(Leaf_5_1);
            Leaf_4_2.Add(Leaf_5_2);
            Leaf_4_3.Add(Leaf_5_3);
            Leaf_4_4.Add(Leaf_5_4);
            Leaf_4_5.Add(Leaf_5_5);
            Leaf_4_6.Add(Leaf_5_6);
            Leaf_4_7.Add(Leaf_5_7);
            Leaf_4_8.Add(Leaf_5_8);

            Leaf_3_1.Add(Leaf_4_1);
            Leaf_3_1.Add(Leaf_4_2);
            Leaf_3_2.Add(Leaf_4_3);
            Leaf_3_2.Add(Leaf_4_4);
            Leaf_3_3.Add(Leaf_4_5);
            Leaf_3_3.Add(Leaf_4_6);
            Leaf_3_4.Add(Leaf_4_7);
            Leaf_3_4.Add(Leaf_4_8);

            Leaf_2_1.Add(Leaf_3_1);
            Leaf_2_2.Add(Leaf_3_2);
            Leaf_2_2.Add(Leaf_3_3);
            Leaf_2_3.Add(Leaf_3_4);
            Leaf_2_4.Add(Leaf_3_3);
            Leaf_2_5.Add(Leaf_3_4);

            Leaf_1_1.Add(Leaf_2_1);
            Leaf_1_1.Add(Leaf_2_2);
            Leaf_1_1.Add(Leaf_2_3);
            Leaf_1_2.Add(Leaf_2_4);
            Leaf_1_2.Add(Leaf_2_5);

            root.Add(Leaf_1_1);
            root.Add(Leaf_1_2);
            #endregion

            return root;
        }
    }
}
