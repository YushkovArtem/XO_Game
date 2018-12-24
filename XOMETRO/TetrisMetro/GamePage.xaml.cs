using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using XOGameMetro.Core;

namespace TetrisMetro
{
    public interface IGamePage
    {        
        
        void SetAllTag(string value);
        void SetAllText(string value);

        string[] GetAllText();
        object[] GetAllCell();

        void SetChange(XOObject value);
        void SetGemers(string you, string computer);
    }

    public partial class GamePage : PhoneApplicationPage, IGamePage
    {

        private int _NextStep = 1;
        private int _PreviousStep = 0;
        private bool _NewGame = false;
        private IService _Service;

        public GamePage()
        {
            InitializeComponent();

            _Service = new Service();

            this.Loaded+= MainForm_Load;
            btnNewGame.Click += MainForm_Load;
            
            #region Кнопки
            btn_0_0.Click += btn_Click;
            btn_0_1.Click += btn_Click;
            btn_0_2.Click += btn_Click;
            btn_1_0.Click += btn_Click;
            btn_1_1.Click += btn_Click;
            btn_1_2.Click += btn_Click;
            btn_2_0.Click += btn_Click;
            btn_2_1.Click += btn_Click;
            btn_2_2.Click += btn_Click;
            btn_0_0.Click += btn_NextMove;
            btn_0_1.Click += btn_NextMove;
            btn_0_2.Click += btn_NextMove;
            btn_1_0.Click += btn_NextMove;
            btn_1_1.Click += btn_NextMove;
            btn_1_2.Click += btn_NextMove;
            btn_2_0.Click += btn_NextMove;
            btn_2_1.Click += btn_NextMove;
            btn_2_2.Click += btn_NextMove;
            #endregion
        }

        public event EventHandler LoadPage;
        private void MainForm_Load(object sender, RoutedEventArgs e)
        {
            try
            {
                this.SetAllTag("0");
                this.SetAllText("");

                if (_NextStep == 1)
                    SetGemers("X", "0");
                else
                    SetGemers("0", "X");

            }
            catch (Exception ex)
            {
                _Service.ShowError(ex.Message);
            }
        }
        
        void btn_Click(object sender, EventArgs e)
        {
            try
            {
                _NewGame = true;
                XOObject btn = (sender as XOObject);
                _PreviousStep = _NextStep;
                if (!btn.Tag.ToString().Equals("0"))
                {
                    // _Service.ShowMessage("Недопустимый ход!");
                    return;
                }

                if (_NextStep == 1)
                {
                    btn.TextToImage("x");
                    _NextStep = 0;
                }
                else
                {
                    btn.TextToImage("o");
                    _NextStep = 1;
                }
                btn.Tag = 1;
                SetChange(btn);

                string rez = Victory.Winner(GetAllText());
                if (!string.IsNullOrEmpty(rez))
                {
                    _Service.ShowMassege(rez);

                    this.SetAllTag("0");
                    this.SetAllText("");

                    if (_NextStep == 1)
                        SetGemers("X", "0");
                    else
                        SetGemers("0", "X");

                    _NewGame = false;
                    //  SWSound.Start();                
                }

            }
            catch (Exception ex)
            {
                _Service.ShowError(ex.Message);
            }
        }

        private void btn_NextMove(object sender, EventArgs e)
        {
            if (_NewGame)
            {
                if (_PreviousStep == _NextStep)
                    return;
                //Thread.Sleep(100);
                btn_Click(Victory.GetNextCell(this.GetAllCell(), _NextStep), EventArgs.Empty);
            }
        }
       
        public void SetAllTag(string value)
        {
            #region кнопки
            btn_0_0.Tag = value;
            btn_0_1.Tag = value;
            btn_0_2.Tag = value;
            btn_1_0.Tag = value;
            btn_1_1.Tag = value;
            btn_1_2.Tag = value;
            btn_2_0.Tag = value;
            btn_2_1.Tag = value;
            btn_2_2.Tag = value;
            #endregion
        }

        public void SetAllText(string value)
        {
            #region кнопки
            btn_0_0.TextToImage(value);
            btn_0_1.TextToImage(value);
            btn_0_2.TextToImage(value);
            btn_1_0.TextToImage(value);
            btn_1_1.TextToImage(value);
            btn_1_2.TextToImage(value);
            btn_2_0.TextToImage(value);
            btn_2_1.TextToImage(value);
            btn_2_2.TextToImage(value);
            #endregion
        }

        public string[] GetAllText()
        {
            return new string[] { 
                btn_0_0.Content.ToString(), 
                btn_0_1.Content.ToString(), 
                btn_0_2.Content.ToString(), 
                btn_1_0.Content.ToString(), 
                btn_1_1.Content.ToString(), 
                btn_1_2.Content.ToString(), 
                btn_2_0.Content.ToString(), 
                btn_2_1.Content.ToString(), 
                btn_2_2.Content.ToString() 
            };
        }

        public object[] GetAllCell()
        {
            return new object[] { 
                btn_0_0.ButtonToXOObject(), 
                btn_0_1.ButtonToXOObject(), 
                btn_0_2.ButtonToXOObject(), 
                btn_1_0.ButtonToXOObject(), 
                btn_1_1.ButtonToXOObject(), 
                btn_1_2.ButtonToXOObject(), 
                btn_2_0.ButtonToXOObject(), 
                btn_2_1.ButtonToXOObject(), 
                btn_2_2.ButtonToXOObject() 
            };
        }

        public void SetChange(XOObject value)
        {
            var btn = ButtonGrid.FindName(value.Name);
            if (btn is Button)
            {

                if ((btn as Button).Content.Equals(value.Name))
                {
                    (btn as Button).Content = value.Text;
                    (btn as Button).Tag = value.Tag;
                    (btn as Button).Background = value.Background;
                }
            }
        }

        public void SetGemers(string you, string computer)
        {
            lblComputer.Text = computer;
            lblYou.Text = you;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationContext.QueryString.ContainsKey("title"))
            {
                lblTitle.Text = NavigationContext.QueryString["title"].ToString();
            }

        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);

            // Если можно отменить переход, уточним у пользователя, хочет ли он остаться на текущей странице 
            if (e.IsCancelable)
            {
                MessageBoxResult result = MessageBox.Show("Может быть останетесь?", "Подтверждение перехода", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    // Пользователь решил остаться 
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();             
        }     
    }
}