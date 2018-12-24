using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using XOGameCL.Code;

namespace XOGame
{    
    public interface IMainForm
    {
        event EventHandler StartResultForm;                                                      
        IResultForm GetResultForm();
        void Show();
    }

    public partial class MainForm : Form, IMainForm, IGame
    {
        public MainForm()
        {
            InitializeComponent();
            
            this.Load += MainForm_Load;

            btnNewGame.Click += MainForm_Load;
            btnGetResult.Click += btnGetResult_Click;
            
            #region Кнопки игрового поля
            button1.Click += button_Click;
            button2.Click += button_Click;
            button3.Click += button_Click;
            button4.Click += button_Click;
            button5.Click += button_Click;
            button6.Click += button_Click;
            button7.Click += button_Click;
            button8.Click += button_Click;
            button9.Click += button_Click;
            #endregion
        }


        public event EventHandler StartResultForm;
        void btnGetResult_Click(object sender, EventArgs e)
        {
            if (StartResultForm != null)
                StartResultForm(null, EventArgs.Empty);
        }
        public event EventHandler СделатьХодПК;
        public event EventStep СделатьХод;
        
        void button_Click(object sender, EventArgs e)
        {
            if (СделатьХод != null)
                СделатьХод((XOObject)((sender as Button).Tag));

            if (СделатьХодПК != null)
                СделатьХодПК(null, EventArgs.Empty);
        }

        public event EventHandler УстановитьПараметрыПоУмолчанию;
        void MainForm_Load(object sender, EventArgs e)
        {
            if (УстановитьПараметрыПоУмолчанию != null)
                УстановитьПараметрыПоУмолчанию(null, EventArgs.Empty);
        }

       public void УстановитьСостояниеИгровогоПоляПоУмолчанию(XOObject value)
        {                    
            XOObject btn1 = new XOObject() { ID = button1.Name, Ход = value.Ход, ХодСделан = value.ХодСделан};
            УстановитьСостояниеИгровогоПоля(btn1);

            XOObject btn2 = new XOObject() { ID = button2.Name, Ход = value.Ход, ХодСделан = value.ХодСделан };
            УстановитьСостояниеИгровогоПоля(btn2);

            XOObject btn3 = new XOObject() { ID = button3.Name, Ход = value.Ход, ХодСделан = value.ХодСделан };
            УстановитьСостояниеИгровогоПоля(btn3);

            XOObject btn4 = new XOObject() { ID = button4.Name, Ход = value.Ход, ХодСделан = value.ХодСделан };
            УстановитьСостояниеИгровогоПоля(btn4);

            XOObject btn5 = new XOObject() { ID = button5.Name, Ход = value.Ход, ХодСделан = value.ХодСделан };
            УстановитьСостояниеИгровогоПоля(btn5);

            XOObject btn6 = new XOObject() { ID = button6.Name, Ход = value.Ход, ХодСделан = value.ХодСделан };
            УстановитьСостояниеИгровогоПоля(btn6);

            XOObject btn7 = new XOObject() { ID = button7.Name, Ход = value.Ход, ХодСделан = value.ХодСделан };
            УстановитьСостояниеИгровогоПоля(btn7);

            XOObject btn8 = new XOObject() { ID = button8.Name, Ход = value.Ход, ХодСделан = value.ХодСделан };
            УстановитьСостояниеИгровогоПоля(btn8);

            XOObject btn9 = new XOObject() { ID = button9.Name, Ход = value.Ход, ХодСделан = value.ХодСделан };
            УстановитьСостояниеИгровогоПоля(btn9);
        
        }

        public void УстановитьСостояниеИгровогоПоля(XOObject value)
        {
            foreach (var btn in Controls.Find(value.ID, true))
            {                
                btn.Tag = value;                
                (btn as Button).SetImage(value.Ход.ToString());
            }
        }

        public void УстановитьРолиИгроков(string you, string computer)
        {
            lblComputer.Text = computer;
            lblYou.Text = you;
        }

        public XOObject[] ПолучитьСостояниеИгровогоПоля()
        {
            return new XOObject[] { 
                (XOObject)button1.Tag, 
                (XOObject)button2.Tag, 
                (XOObject)button3.Tag, 
                (XOObject)button4.Tag, 
                (XOObject)button5.Tag, 
                (XOObject)button6.Tag,
                (XOObject)button7.Tag, 
                (XOObject)button8.Tag, 
                (XOObject)button9.Tag 
            };
        }

        public bool ПолучитьРежимСложностиИгры()
        {           
            return btnMode.Checked;
        }

        #region Запуск окна
        public new void Show()
        {
            Application.Run(this);
        }
        #endregion                                 

        public IResultForm GetResultForm()
        {
            return new ResultForm();
        }        
    }
}
