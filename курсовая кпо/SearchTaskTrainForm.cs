using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace курсовая_кпо
{
    public partial class SearchTaskTrainForm : Form
    {
        String role;
        public SearchTaskTrainForm(String role) // Конструктор формы поиска поезда по индивидуальному заданию
        {
            InitializeComponent(); // Инициализация компонентов формы
            this.role = role;  // Присвоение роли полю role
        }

        private void comeToMenu_Click(object sender, EventArgs e) // Обработчик события нажатия возвращения в меню
        {
            this.Hide(); // Скрытие текущей формы
            // Создание и отображение формы меню
            MenuForm menuForm = new MenuForm(role);
            menuForm.Show();
            
        }

        private void closeButton_Click(object sender, EventArgs e) // Обработчик события нажатия кнопки закрытия приложения
        {
            Application.Exit();
        }

        private void buttonSearchTrain_Click(object sender, EventArgs e) // Обработчик события нажатия кнопки поиска поезда по заданию
        {
            string endStation = Convert.ToString(endStationTrainField.Text);  // Получение конечной станции из текстового поля

            if (string.IsNullOrWhiteSpace(endStation))  // Проверка наличия введенной конечной станции
            {
                MessageBox.Show("Введите конечную станцию.");
                return;
            }

            // Проверка формата минимального времени
            if (!DateTime.TryParseExact(minTimeField.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат минимального времени. Используйте формат HH:mm.");
                return;
            }

            // Проверка формата максимального времени
            if (!DateTime.TryParseExact(maxTimeField.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат максимального времени. Используйте формат HH:mm.");
                return;
            }

            // Преобразование строковых представлений времени в объекты DateTime
            DateTime minTime = Convert.ToDateTime(minTimeField.Text);
            DateTime maxTime = Convert.ToDateTime(maxTimeField.Text);
            DateTime time;

            // Очистка списков перед добавлением новых данных
            listBox1.Items.Clear();
            listBox4.Items.Clear();
            listBox7.Items.Clear();
           

            List<Train> ListTrain = new List<Train>(); // Создание списка для хранения найденных поездов
            try
            {
                // Создание объекта для работы с базой данны
                DataBase dataBase = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                // Создание SQL-команды для выбора поездов с указанной конечной станцией
                MySqlCommand command = new MySqlCommand("SELECT * FROM trains WHERE `endStation` = @endSt ", dataBase.getConnection());
                command.Parameters.Add("endSt", MySqlDbType.VarChar).Value = endStation;

                // Назначение команды адаптеру
                adapter.SelectCommand = command;
                adapter.Fill(table);

                // Цикл по строкам результата запроса
                foreach (DataRow row in table.Rows)
                {
                    Train train = new Train();

                    // Заполнение свойств объекта Train данными из строки результата
                    train.number = Convert.ToString(row.ItemArray[1]);
                    train.timeStart = Convert.ToString(row.ItemArray[4]);
                    train.availableTicket = Convert.ToInt32(row.ItemArray[7]);

                    time = Convert.ToDateTime(row.ItemArray[4]);

                    // Проверка, попадает ли время отправления поезда в заданный временной диапазон
                    if (time <= maxTime && time >= minTime)
                    {
                        //Добавляем поезд в список
                        ListTrain.Add(train);
                    }
                }
                // Заполнение списков на форме данными из списка ListTrain
                for (int i = 0; i < ListTrain.Count; i++)
                {
                    listBox1.Items.Add($"{ListTrain[i].number}");
                    listBox4.Items.Add($"{ListTrain[i].timeStart}");
                    listBox7.Items.Add($"{ListTrain[i].availableTicket}");
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
    }
}
