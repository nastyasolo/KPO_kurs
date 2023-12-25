using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_кпо
{
    internal class DataBase
    {
        // Объект MySqlConnection для управления подключением к базе данных
        MySqlConnection connection = new MySqlConnection ("server=localhost;port=3306;username=root;password=root;database=data");
        

        public void openConnection() // Метод для открытия подключения к базе данных
        {
            if(connection.State==System.Data.ConnectionState.Closed) {
            connection.Open ();}
        }
        public void closeConnection()  // Метод для закрытия подключения к базе данных
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public MySqlConnection getConnection() // Метод для получения объекта MySqlConnection для внешнего использования
        {
            return connection;
        }

    }
}
