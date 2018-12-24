using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGameCL.Code
{
    public delegate void EventStep(XOObject sender);

    public interface IGame
    {
        event EventHandler УстановитьПараметрыПоУмолчанию;
        event EventStep СделатьХод;
        event EventHandler СделатьХодПК;

        XOObject[] ПолучитьСостояниеИгровогоПоля();
        void УстановитьСостояниеИгровогоПоля(XOObject value);
        void УстановитьСостояниеИгровогоПоляПоУмолчанию(XOObject value);
        
        void УстановитьРолиИгроков(string you, string computer);
        
        bool ПолучитьРежимСложностиИгры();
    }
}
