using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///Компановщик, для формирования стратегии игры
namespace XOGameCL.Code
{
    /// <summary>
    /// Component - компонент
    /// </summary>
    /// <li>
    /// <lu>объявляет интерфейс для компонуемых объектов;</lu>
    /// <lu>предоставляет подходящую реализацию операций по умолчанию,
    /// общую для всех классов;</lu>
    /// <lu>объявляет интерфейс для доступа к потомкам и управлению ими;</lu>
    /// <lu>определяет интерфейс доступа к родителю компонента в рекурсивной структуре
    /// и при необходимости реализует его. Описанная возможность необязательна;</lu>
    /// </li>
    public abstract class Component
    {
        protected int[] _disposition;

        // Constructor
        public Component(int[] disposition)
        {
            this._disposition = disposition;
        }

        public abstract Component FindChild(int[] disposition);

        public abstract int[] ToIntArray();

        public abstract ArrayList GetChilds();
    }

    /// <summary>
    /// Composite - составной объект
    /// </summary>
    /// <li>
    /// <lu>определяет поведеление компонентов, у которых есть потомки;</lu>
    /// <lu>хранит компоненты-потомоки;</lu>
    /// <lu>реализует относящиеся к управлению потомками операции и интерфейсе
    /// класса <see cref="Component"/></lu>
    /// </li>
    public class VictoryComposite : Component
    {
        private ArrayList children = new ArrayList();

        // Constructor
        public VictoryComposite(int[] disposition)
            : base(disposition)
        {
        }

        public void Add(Component component)
        {
            children.Add(component);
        }

        public void Remove(Component component)
        {
            children.Remove(component);
        }

        public override Component FindChild(int[] disposition)
        {
            if (this._disposition.SequenceEqual(disposition))
            {
                return this;
            }

            foreach (Component component in this.children)
            {
                Component found = component.FindChild(disposition);

                if (found != null)
                {
                    return found;
                }
            }

            return null;
        }

        public override int[] ToIntArray()
        {
            return this._disposition;
        }

        public override ArrayList GetChilds()
        {
            return this.children;
        }
    }

    /// <summary>
    /// Leaf - лист
    /// </summary>
    /// <remarks>
    /// <li>
    /// <lu>представляет листовой узел композиции и не имеет потомков;</lu>
    /// <lu>определяет поведение примитивных объектов в композиции;</lu>
    /// </li>
    /// </remarks>
    public class VictoryLeaf : Component
    {
        // Constructor
        public VictoryLeaf(int[] disposition)
            : base(disposition)
        {
        }
        public override Component FindChild(int[] disposition)
        {
            return (this._disposition.SequenceEqual(disposition)) ? this : null;
        }

        public override int[] ToIntArray()
        {
            return this._disposition;
        }

        public override ArrayList GetChilds()
        {
            return null;
        }
    }
}
