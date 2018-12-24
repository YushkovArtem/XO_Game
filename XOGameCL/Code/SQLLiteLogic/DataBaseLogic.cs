using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOGameCL.Code
{    
    public class DataBaseLogic
    {
        private static DataBaseLogic _DataBaseLogic;
        
        public string DB_Patch { get; private set; }
        public string ConnectionString { get; private set; }
        public BindingList<ResultType> Результаты { get; private set; }

        private DataBaseLogic()
        { 
        }
        
        public static DataBaseLogic GetInstance()
        {
            if (_DataBaseLogic == null)
                _DataBaseLogic = new DataBaseLogic();
            return _DataBaseLogic;
        }
        /// <summary>
        /// Метод проверяет наличие БД по указанномк пути, и создает бд по указанному пути если БД не найдена.
        /// </summary>
        /// <param name="db_patch"> путь к БД</param>
        /// <returns>Обьект класса</returns>
        public DataBaseLogic SetConnectDB(string db_patch)
        {
            this.DB_Patch = db_patch;
            this.ConnectionString = "Data Source= " + this.DB_Patch + ";Version=3;";

            if (File.Exists(db_patch))
                return this;

            SQLiteConnection.CreateFile(this.DB_Patch);
            
            using (SQLiteConnection m_dbConnection = new SQLiteConnection(this.ConnectionString))
            {
                m_dbConnection.Open();

                string sql;
                SQLiteCommand command;
                #region table result - Таблица результатов создание
                sql = "create table rezults (x_rezult int, o_rezult int, add_date date)";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                #endregion

                m_dbConnection.Close();
            }
            return this;
        }

        /// <summary>
        /// Метод добавляет результат игры в соответствующую таблицу БД
        /// </summary>
        /// <param name="X">Очков заработал игрок Х</param>
        /// <param name="O">Очков заработал игрок У</param>
        /// <returns>Обьект класса</returns>
        public DataBaseLogic AddResultInTable(int X, int O)
        {

            using (SQLiteConnection m_dbConnection = new SQLiteConnection(this.ConnectionString))
            {
                m_dbConnection.Open();

                string sql;
                SQLiteCommand command;

                #region table rezult - Таблица результатов Добавление
                sql = "insert into rezults (x_rezult, o_rezult, add_date) values (" + X + ", " + O + ",date('now'))";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                #endregion
                m_dbConnection.Close();
            }
            return this;
        }
        
        /// <summary>
        /// Метод получает список сохраненных результатов из соответствующей таблицы
        /// </summary>
        /// <returns>Обьект класса</returns>
        public DataBaseLogic GetResultsFromTable()
        {
            Результаты = new BindingList<ResultType>();

            using (SQLiteConnection connect = new SQLiteConnection(ConnectionString))
            {
                connect.Open();
                SQLiteCommand sqlComm = new SQLiteCommand("SELECT t.x_rezult, t.o_rezult, t.add_date FROM rezults t", connect);

                using (SQLiteDataReader r = sqlComm.ExecuteReader())
                {
                    while (r.Read())
                    {
                        Результаты.Add(new ResultType() {Date = r.GetDateTime(2), O = r.GetInt32(1), X = r.GetInt32(0) });
                    }
                }
                connect.Close();
            }

            return this;
        }        
    }
}
