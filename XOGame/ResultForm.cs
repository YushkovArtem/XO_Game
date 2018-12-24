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
    public interface IResultForm
    {
        void ShowForm();

        void ОчиститьТаблицу();

        void ДобавитьЗаписьВТаблицуФормы(BindingList<ResultType> item);
    }

    public partial class ResultForm : Form, IResultForm
    {
        public ResultForm()
        {
            InitializeComponent();            
        }

        public void ShowForm()
        {
            this.ShowDialog();
        }


        public void ОчиститьТаблицу()
        {
            dGVMain.Rows.Clear();

        }

        public void ДобавитьЗаписьВТаблицуФормы(BindingList<XOGameCL.Code.ResultType> collection)
        {           
            dGVMain.DataSource = collection;
        }
    }
}
