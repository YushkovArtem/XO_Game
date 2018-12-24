using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOGameCL.Code;

namespace XOGame
{
    
    public class MainPresentor
    {
        private IMainForm _Form;
        private IGame _Game;
        private IMessageService _Service;

        private СостояниеХода _NextStep = СостояниеХода.X;
        private СостояниеХода _PreviousStep = СостояниеХода.O;
        
        private bool _NewGame = false;

        public MainPresentor(MainForm form, IMessageService service)
        {
            this._Form = (IMainForm)form;
            this._Game = (IGame)form;
            this._Service = service;

            this._Game.УстановитьПараметрыПоУмолчанию += УстановитьПараметрыПоУмолчанию;
            this._Game.СделатьХод += СделатьХод;
            this._Game.СделатьХодПК += СделатьХодПК;
            this._Form.StartResultForm += GetResults;            
        }
       

         /// <summary>
        /// Метод срабатывает при первоначальном запуске ПО
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void УстановитьПараметрыПоУмолчанию(object sender, EventArgs e)
        {
            try
            {                
                this._Game.УстановитьСостояниеИгровогоПоляПоУмолчанию(new XOObject() { ХодСделан = false, Ход = СостояниеХода.NULL });
                _NextStep = СостояниеХода.X;
                _PreviousStep = СостояниеХода.O;
                УстановитьРолиИгроковНаФорму(_NextStep);
            }
            catch (Exception ex)
            {
                _Service.ShowError(ex.Message);
            }
        }

        /// <summary>
        /// Метод определяет 'результативность' хода пользователя
        /// </summary>
        /// <param name="sender"></param>       
        private void СделатьХод(XOObject sender)
        {
            try
            {
                Mode mode = Mode.easy;
                if (!this._Game.ПолучитьРежимСложностиИгры()) ;
                mode = Mode.hard;

                _NewGame = true;
                
                _PreviousStep = _NextStep;

                if (sender.ХодСделан)
                {
                    return;
                }

                if (_NextStep == СостояниеХода.X)
                {
                    sender.Ход = СостояниеХода.X;
                    _NextStep = СостояниеХода.O;
                }
                else
                {
                    sender.Ход = СостояниеХода.O;
                    _NextStep = СостояниеХода.X;
                }

                sender.ХодСделан = true;
                _Game.УстановитьСостояниеИгровогоПоля(sender);

                IVictory victory = new VictoryStrategy(mode);

                СостояниеХода? rez = victory.Победа(this._Game.ПолучитьСостояниеИгровогоПоля());

                if (rez == null)
                    return;

                if (rez == СостояниеХода.NULL)
                {
                    DataBaseLogic.GetInstance().SetConnectDB("Requests_Database.sqlite").AddResultInTable(1, 1);
                    _Service.ShowMessage("Draw, Try again!");

                }

                if (rez == СостояниеХода.X)
                {
                    DataBaseLogic.GetInstance().SetConnectDB("Requests_Database.sqlite").AddResultInTable(1, 0);
                    _Service.ShowMessage("The crosses won!");

                }

                if (rez == СостояниеХода.O)
                {
                    DataBaseLogic.GetInstance().SetConnectDB("Requests_Database.sqlite").AddResultInTable(0, 1);
                    _Service.ShowMessage("Zeroes won!");

                }

                УстановитьПараметрыПоУмолчанию(null, EventArgs.Empty);

                _NewGame = false;
            }
            catch (Exception ex)
            {
                _Service.ShowError(ex.Message);
            }
        }
      
        /// <summary>
        /// Метод инициирует ход ПК и определяет  'результативность' хода ПК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void СделатьХодПК(object sender, EventArgs e)
        {
            try
            {
                if (_NewGame)
                {
                    if (_PreviousStep == _NextStep)
                        return;                    

                    Mode mode = Mode.easy;
                    if (!this._Game.ПолучитьРежимСложностиИгры())
                        mode = Mode.hard;
                    IVictory victory = new VictoryStrategy(mode);

                    СделатьХод(victory.ПолучитьЯчейкуДляСледующегоХода(this._Game.ПолучитьСостояниеИгровогоПоля(), _NextStep));
                }
            }
            catch (Exception ex)
            {
                _Service.ShowError(ex.Message);
            }
        }

              
        /// <summary>
        /// Метод устанавливает значения ролей для игроков Для Пользователя и для ПК
        /// </summary>
        private void УстановитьРолиИгроковНаФорму(СостояниеХода ход)
        {
            if (ход == СостояниеХода.X)
                this._Game.УстановитьРолиИгроков("X", "0");
            else
                this._Game.УстановитьРолиИгроков("0", "X");
        }              
            

        /// <summary>
        /// Метод получает сохраненный результат игр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void GetResults(object sender, EventArgs e)
        {
            try
            {
                ResultPresentor Result = new ResultPresentor(this._Form.GetResultForm(), this._Service);
                Result.Run();
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
                _Form.Show();
            }
            catch (Exception ex)
            {
                _Service.ShowError(ex.Message);
            }

        }
    }
}
