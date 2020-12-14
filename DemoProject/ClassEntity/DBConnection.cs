using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DemoProject.ClassEntity
{
    static public class DBConnection
    {
        static MySqlConnection mySqlConnection = 
            new MySqlConnection("database=user13fordemoproject;server=localhost;user id=root;Password=qwerty");
        static MySqlCommand mySqlCommand = new MySqlCommand();
        static MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(mySqlCommand);

        static public bool Connect()
        {
            try
            {
                mySqlConnection.Open();
                mySqlCommand.Connection = mySqlConnection;
                return true;
            }
            catch (Exception)
            {
                System.Windows.Forms.MessageBox.Show("Не удалось подключиться к БД!", "Ошибка",
                    System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
                return true;
            }
        }
        static public void Disconnect()
        {
            try
            {
                mySqlConnection.Close();

            }
            catch (Exception)
            {
            }
        }
        static public DataTable GetDataTableFromQuery(string query)
        {
            try
            {
                DataTable table = new DataTable();
                mySqlCommand.CommandText = query;
                mySqlDataAdapter.Fill(table);
                return table;    
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }
        static public string GetValue(string query)
        {
            try
            {
                mySqlCommand.CommandText = query;
                object result = mySqlCommand.ExecuteScalar();
                if (result is null)
                    return "";
                return result.ToString();
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
