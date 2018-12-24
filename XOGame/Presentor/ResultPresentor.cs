using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using XOGameCL.Code;

namespace XOGame
{
    public class ResultPresentor
    {
        private IMessageService _Service;
        private IResultForm _Form;        

        public ResultPresentor(IResultForm form, IMessageService service)
        {
            this._Service = service;
            this._Form = form;
            GetResultsFromTable();
        }

        private void GetResultsFromTable()
        {
            try
            {                               
                _Form.ОчиститьТаблицу();                               
                _Form.ДобавитьЗаписьВТаблицуФормы(DataBaseLogic.GetInstance().SetConnectDB("Requests_Database.sqlite").GetResultsFromTable().Результаты);
                
            }
            catch (Exception ex)
            {
                _Service.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Метод запускает главное окно в программы
        /// </summary>
        public void Run()
        {
            try
            {
                _Form.ShowForm();
            }
            catch (Exception ex)
            {
                _Service.ShowError(ex.Message);
            }

        }
    }
}
