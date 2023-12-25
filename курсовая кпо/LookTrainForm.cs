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
    public partial class LookTrainForm : Form
    {
        String role;

        public LookTrainForm(String role)  // Конструктор формы просмотра поездов
        {
            
            InitializeComponent();// Инициализация компонентов формы
            this.role = role;
            panel3.Visible = false;
            if (role != "1") // Скрытие кнопки удаления и административной панели для обычных пользователей
            {
                buttonDeleteTrain.Visible = false;
                adminPanel.Visible = false;
            }
            FillTrainList();  // Заполнение списка поездов при загрузке формы
        }
        private void ClearAllListBoxes() // Метод для очищения списков поездов в форме
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
        }
        private void FillTrainList() // Метод для заполнения списков поездов в форме
        {
            ClearAllListBoxes(); // Очистка всех списков перед заполнением новыми данными

            List<Train> ListTrain = new List<Train>();  
            try
            {
                
                ListTrain = getData(); // Получение списка поездов из базы данных
                for (int i = 0; i < ListTrain.Count; i++)   // Заполнение listBox соответствующими данными о поездах
                {
                    listBox1.Items.Add($"{ListTrain[i].number}");
                    listBox2.Items.Add($"{ListTrain[i].endStation}");
                    listBox3.Items.Add($"{ListTrain[i].date.ToShortDateString()}");
                    listBox4.Items.Add($"{ListTrain[i].timeStart}");
                    listBox5.Items.Add($"{ListTrain[i].timeEnd}");
                    listBox6.Items.Add($"{ListTrain[i].price}");
                    listBox7.Items.Add($"{ListTrain[i].availableTicket}");
                    listBox8.Items.Add($"{ListTrain[i].soldTicket}");
                }
            }
            catch { }
        }
        private List<Train> getData() // Метод для получения данных о поездах из базы данных
        {
            List<Train> ListTrain = new List<Train>(); // Создаем список поездов

            DataBase dataBase = new DataBase(); // Создаем объект для работы с базой данных

            // Получаем данные из базы и сохраняем их в DataTable
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM trains", dataBase.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);

            foreach (DataRow row in table.Rows) // Проходим по каждой строке DataTable и создаем объект Train
            {
                Train train = new Train();
                // Заполняем поля объекта данными из текущей строки DataTable
                train.number = Convert.ToString(row.ItemArray[1]);
                train.endStation = Convert.ToString(row.ItemArray[2]);
                train.date = Convert.ToDateTime(row.ItemArray[3]);
                train.timeStart = Convert.ToString(row.ItemArray[4]);
                train.timeEnd = Convert.ToString(row.ItemArray[5]);
                train.price = Convert.ToString(row.ItemArray[6]);
                train.availableTicket = Convert.ToInt32(row.ItemArray[7]);
                train.soldTicket = Convert.ToInt32(row.ItemArray[8]);


                //Добавляем поезда в список
                ListTrain.Add(train);
            }
            return ListTrain; // Возвращаем список с данными о поездах
        }

        private void closeButton_Click(object sender, EventArgs e) // Обработчик события закрытия приложения
        {
            Application.Exit();
        }

        private void comeToMenu_Click(object sender, EventArgs e) // Обработчик события возвращения в главное меню
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(role);
            menuForm.ShowDialog();
        }

        private void unVPanel_Click(object sender, EventArgs e) // Обработчик события скрытия панели информации о выбранном поезде
        {
            panel3.Visible = false;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e, ListBox listBox) // Обработчик события выбора элемента в одном из списков поездов
        {
            try
            {
                var indexSelect = listBox.SelectedIndex; // Получение индекса выбранного элемента

                // Выделение соответствующего элемента в каждом из списков
                SelectItemInListBox(listBox1, indexSelect);
                SelectItemInListBox(listBox2, indexSelect);
                SelectItemInListBox(listBox3, indexSelect);
                SelectItemInListBox(listBox4, indexSelect);
                SelectItemInListBox(listBox5, indexSelect);
                SelectItemInListBox(listBox6, indexSelect);
                SelectItemInListBox(listBox7, indexSelect);
                SelectItemInListBox(listBox8, indexSelect);

                // Заполнение текстовых полей формы данными выбранного поезда
                numberTrainField.Text = listBox1.Items[indexSelect].ToString();
                endStationField.Text = listBox2.Items[indexSelect].ToString();
                dateField.Text = listBox3.Items[indexSelect].ToString();
                startTimeField.Text = listBox4.Items[indexSelect].ToString();
                endTimeField.Text = listBox5.Items[indexSelect].ToString();
                priceField.Text = listBox6.Items[indexSelect].ToString();
                availableTicketField.Text = listBox7.Items[indexSelect].ToString();
                soldTicketField.Text = listBox8.Items[indexSelect].ToString();

                panel3.Visible = true; // Отображение панели с информацией о поезде

            }
            catch { }
        }
        private void SelectItemInListBox(ListBox listBox, int index) // Метод для выбора элемента в ListBox по индексу
        {
            if (index >= 0 && index < listBox.Items.Count) // Проверяем, что индекс находится в пределах допустимых значений
            {
                listBox.SelectedIndex = index;// Устанавливаем индекс выбранного элемента в ListBox
            }
        }

        // Обработчики событий выбора элементов в списках поездов
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox1);
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox2);
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox3);
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox4);
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox5);
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox6);
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox7);
        }

        private void listBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(sender, e, listBox8);
        }

        private void buttonBuyTicket_Click(object sender, EventArgs e) // Обработчик события нажатия на кнопку покупки билетов
        {
            try
            {
                // Проверка введенных данных
                if (string.IsNullOrWhiteSpace(numOfTicketField.Text) || !int.TryParse(numOfTicketField.Text, out int numOfTicket) || numOfTicket <= 0)
                {
                    MessageBox.Show("Введите корректное количество билетов.");
                    return;
                }

                // Получение доступного и проданного количества билетов
                int availableTicket = Convert.ToInt32(availableTicketField.Text);
                int soldTicket = Convert.ToInt32(soldTicketField.Text);

                // Проверка наличия достаточного количества билетов
                if (numOfTicket > availableTicket)
                {
                    MessageBox.Show("Недостаточно доступных билетов.");
                    return;
                }

                // Изменение количества доступных и проданных билетов
                availableTicket -= numOfTicket;
                soldTicket += numOfTicket;

                // Подготовка запроса к базе данных
                DataBase db = new DataBase();
                MySqlCommand command = new MySqlCommand("UPDATE `trains` SET `availableTicket` = @newAT, `soldTicket` = @newST WHERE `trains`.`number` = @number AND `trains`.`endStation` = @endSt", db.getConnection());

                // Передача параметров в запрос к БД
                command.Parameters.Add("@number", MySqlDbType.Int32).Value = numberTrainField.Text;
                command.Parameters.Add("@endSt", MySqlDbType.VarChar).Value = endStationField.Text;
                command.Parameters.Add("@newAT", MySqlDbType.VarChar).Value = availableTicket;
                command.Parameters.Add("@newST", MySqlDbType.VarChar).Value = soldTicket;

                db.openConnection(); // Открытие соединения с базой данных

                // Выполнение запроса к базе данных
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Билеты куплены успешно.");
                    FillTrainList();
                    panel3.Visible = false;

                }
                else
                    MessageBox.Show("Ошибка при покупке билетов.");

                db.closeConnection(); // Закрытие соединения с базой данных
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }

        }

        public List<Train> Sort(List<Train> train, string typeSort) // Метод для сортировки списка поездов по определенному критерию
        {
            List<Train> sortTrain = new List<Train>(); // Создаем новый список для отсортированных поездов

            switch (typeSort)
            {
                case "number": // Сортировка по номеру поезда
                    sortTrain = train.OrderBy(t => t.number).ToList();
                    break;
                case "endStation":  // Сортировка по конечной станции
                    sortTrain = train.OrderBy(t => t.endStation).ToList();
                    break;
                case "price":  // Сортировка по цене (преобразование строки в число)
                    sortTrain = train.OrderBy(t => double.Parse(t.price)).ToList();
                    break;
                default: // По умолчанию возвращаем неизмененный список
                    sortTrain = train;
                    break;
            }

            UpdateListBoxes(sortTrain); // Перезаписываем ListBox'ы с отсортированными данными

            return sortTrain; // Возвращаем отсортированный список поездов
        }

        private void UpdateListBoxes(List<Train> sortedTrains) // Метод для обновления данных в ListBox'ах на основе отсортированного списка поездов
        {
            ClearAllListBoxes(); // Очищаем все ListBox'ы перед обновлением

            // Проходим по отсортированному списку поездов и добавляем данные в соответствующие ListBox'ы
            foreach (var train in sortedTrains)
            {
                listBox1.Items.Add(train.number);
                listBox2.Items.Add(train.endStation);
                listBox3.Items.Add(train.date.ToShortDateString());
                listBox4.Items.Add(train.timeStart);
                listBox5.Items.Add(train.timeEnd);
                listBox6.Items.Add(train.price);
                listBox7.Items.Add(train.availableTicket);
                listBox8.Items.Add(train.soldTicket);
            }
        }

        // Обработчики событий сортировки поездов по различным критериям :
        private void buttonSortNumber_Click(object sender, EventArgs e) //По номеру
        {
            List<Train> ListTrain = getData();
            Sort(ListTrain, "number");
        }

        private void buttonSortEndStation_Click(object sender, EventArgs e) //По конечной станции
        {
            List<Train> ListTrain = getData();
            Sort(ListTrain, "endStation");
        }

        private void buttonSortPrice_Click(object sender, EventArgs e) //По цене
        {
            List<Train> ListTrain = getData();
            Sort(ListTrain, "price");
        }

        private void buttonSearchTrain_Click(object sender, EventArgs e) // Обработчик события поиска поезда
        {
            ClearAllListBoxes();

            List<Train> ListTrain = new List<Train>();
            try
            {
                // Подготовка запроса к базе данных для поиска по номеру поезда
                DataBase dataBase = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `trains` WHERE `number` LIKE @number", dataBase.getConnection());
                command.Parameters.Add("@number", MySqlDbType.VarChar).Value = numberTrainSearch.Text;
                adapter.SelectCommand = command;
                adapter.Fill(table);

                // Заполнение списка поездов результатами поиска
                foreach (DataRow row in table.Rows)
                {
                    Train train = new Train();
                    train.number = Convert.ToString(row.ItemArray[1]);
                    train.endStation = Convert.ToString(row.ItemArray[2]);
                    train.date = Convert.ToDateTime(row.ItemArray[3]);
                    train.timeStart = Convert.ToString(row.ItemArray[4]);
                    train.timeEnd = Convert.ToString(row.ItemArray[5]);
                    train.price = Convert.ToString(row.ItemArray[6]);
                    train.availableTicket = Convert.ToInt32(row.ItemArray[7]);
                    train.soldTicket = Convert.ToInt32(row.ItemArray[8]);

                    //Добавляем поезда в список
                    ListTrain.Add(train);
                }
                // Заполнение списков на форме данными о найденных поездах
                for (int i = 0; i < ListTrain.Count; i++)
                {
                    listBox1.Items.Add($"{ListTrain[i].number}");
                    listBox2.Items.Add($"{ListTrain[i].endStation}");
                    listBox3.Items.Add($"{ListTrain[i].date}");
                    listBox4.Items.Add($"{ListTrain[i].timeStart}");
                    listBox5.Items.Add($"{ListTrain[i].timeEnd}");
                    listBox6.Items.Add($"{ListTrain[i].price}");
                    listBox7.Items.Add($"{ListTrain[i].availableTicket}");
                    listBox8.Items.Add($"{ListTrain[i].soldTicket}");
                }
            }
            catch { }
        }

        private void buttonDeleteTrain_Click(object sender, EventArgs e) // Обработчик события удаления поезда
        {
            try
            {
                    string trainNumberToDelete = numberTrainField.Text; // Получение номера поезда для удаления

                    // Запрос на подтверждение удаления
                    DialogResult result = MessageBox.Show($"Вы уверены, что хотите удалить поезд с номером {trainNumberToDelete}?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // Подготовка запроса к базе данных для удаления поезда
                        DataBase db = new DataBase();
                        MySqlCommand command = new MySqlCommand("DELETE FROM `trains` WHERE `trains`.`number` = @number AND `trains`.`date` = @date", db.getConnection());

                        command.Parameters.Add("@number", MySqlDbType.VarChar).Value = trainNumberToDelete;
                        command.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateField.Text;
                        db.openConnection();

                        // Выполнение запроса на удаление
                        if (command.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Поезд удален успешно.");
                            FillTrainList();
                            panel3.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при удалении поезда.");
                        }

                        db.closeConnection();
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении поезда: {ex.Message}");
            }
        }
        private void ClearTrainInputFields() // Метод для очистки полей для ввода данных о поезде
        {

            numberTrainField.Text = "";
            endStationField.Text = "";
            newNumberTrainField.Text = "";
            newEndStationField.Text = "";
            newDateField.Text = "";
            newStartTimeField.Text = "";
            newEndTimeField.Text = "";
            newPriceField.Text = "";
            newAvailableTicketField.Text = "";
            newSoldTicketField.Text = "";
        }

        private void editTrain_Click(object sender, EventArgs e) // Обработчик события для кнопки редактирования поезда
        {
            try { 
                if (!ValidateTrainInput()) // Проверяем введенные данные перед редактированием
                    return;
                DataBase db = new DataBase(); // Создаем объект для работы с базой данных
                // Создаем SQL-команду для обновления данных поезда в базе
                MySqlCommand command = new MySqlCommand("UPDATE `trains` SET `number` = @newNumber, `endStation` = @newEndSt, `date` = @newDate, `timeStart` = @newTS, `timeEnd` = @newTE, `price` = @newPrice, `availableTicket` = @newAT, `soldTicket` = @newST WHERE `trains`.`number` = @number AND `trains`.`date` = @date", db.getConnection());

                // Задаем параметры для SQL-команды на основе введенных данных
                command.Parameters.Add("@number", MySqlDbType.VarChar).Value = numberTrainField.Text;
                command.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateField.Text;
                command.Parameters.Add("@newnumber", MySqlDbType.VarChar).Value = newNumberTrainField.Text;
                command.Parameters.Add("@newEndSt", MySqlDbType.VarChar).Value = newEndStationField.Text;
                command.Parameters.Add("@newDate", MySqlDbType.VarChar).Value = newDateField.Text;
                command.Parameters.Add("@newTS", MySqlDbType.VarChar).Value = newStartTimeField.Text;
                command.Parameters.Add("@newTE", MySqlDbType.VarChar).Value = newEndTimeField.Text;
                command.Parameters.Add("@newPrice", MySqlDbType.VarChar).Value = newPriceField.Text;
                command.Parameters.Add("@newAT", MySqlDbType.VarChar).Value = newAvailableTicketField.Text;
                command.Parameters.Add("@newST", MySqlDbType.VarChar).Value = newSoldTicketField.Text;

                db.openConnection(); // Открываем соединение с базой данных

                // Выполняем SQL-команду и проверяем результат
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Изменено");
                    FillTrainList(); // Обновляем список поездов после успешного редактирования
                    panel3.Visible = false; // Скрываем панель редактирования 
                    ClearTrainInputFields();// Очищаем поля ввода
                }
                else
                    MessageBox.Show("Ошибка!");

                db.closeConnection(); // Закрываем соединение с базой данных
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании поезда: {ex.Message}");
            }
        }

        private void addTrain_Click(object sender, EventArgs e) // Обработчик события для кнопки добавления нового поезда
        {
            try
            {
                if (!ValidateTrainInput()) // Проверяем введенные данные перед добавлением
                    return;
                DataBase db = new DataBase(); // Создаем объект для работы с базой данных
                // Создаем SQL-команду для добавления нового поезда в базу
                MySqlCommand command = new MySqlCommand("INSERT INTO `trains` (`number`, `endStation`, `date`, `timeStart`, `timeEnd`, `price`, `availableTicket`, `soldTicket`) VALUES (@newNumber, @newEndSt, @newDate, @newTS, @newTE, @newPrice, @newAT, @newST)", db.getConnection());

                // Задаем параметры для SQL-команды на основе введенных данных
                command.Parameters.Add("@newnumber", MySqlDbType.VarChar).Value = newNumberTrainField.Text;
                command.Parameters.Add("@newEndSt", MySqlDbType.VarChar).Value = newEndStationField.Text;
                command.Parameters.Add("@newDate", MySqlDbType.VarChar).Value = newDateField.Text;
                command.Parameters.Add("@newTS", MySqlDbType.VarChar).Value = newStartTimeField.Text;
                command.Parameters.Add("@newTE", MySqlDbType.VarChar).Value = newEndTimeField.Text;
                command.Parameters.Add("@newPrice", MySqlDbType.VarChar).Value = newPriceField.Text;
                command.Parameters.Add("@newAT", MySqlDbType.VarChar).Value = newAvailableTicketField.Text;
                command.Parameters.Add("@newST", MySqlDbType.VarChar).Value = newSoldTicketField.Text;

                db.openConnection(); // Открываем соединение с базой данных

                if (command.ExecuteNonQuery() == 1) // Выполняем SQL-команду и проверяем результат
                {
                    MessageBox.Show("Поезд добавлен");
                    FillTrainList(); // Обновляем список поездов после успешного добавления
                    panel3.Visible = false; // Скрываем панель редактирования 
                    ClearTrainInputFields();// Очищаем поля ввода
                }
                else
                    MessageBox.Show("Поезд не добавлен");

                db.closeConnection();  // Закрываем соединение с базой данных
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении поезда: {ex.Message}");
            }
        }

        private bool ValidateTrainInput() // Метод для проверки введенных данных о поезде
        {
            // Проверяем, что все поля заполнены
            if (string.IsNullOrWhiteSpace(newNumberTrainField.Text) ||
                string.IsNullOrWhiteSpace(newEndStationField.Text) ||
                string.IsNullOrWhiteSpace(newDateField.Text) ||
                string.IsNullOrWhiteSpace(newStartTimeField.Text) ||
                string.IsNullOrWhiteSpace(newEndTimeField.Text) ||
                string.IsNullOrWhiteSpace(newPriceField.Text) ||
                string.IsNullOrWhiteSpace(newAvailableTicketField.Text) ||
                string.IsNullOrWhiteSpace(newSoldTicketField.Text))
            {
                MessageBox.Show("Заполните все поля.");
                return false;
            }

            // Проверяем формат введенной даты
            if (!DateTime.TryParseExact(newDateField.Text, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат даты. Используйте формат dd.MM.yyyy.");
                return false;
            }

            // Проверяем формат введенного начального времени
            if (!DateTime.TryParseExact(newStartTimeField.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат начального времени.");
                return false;
            }

            // Проверяем формат введенного конечного времени
            if (!DateTime.TryParseExact(newEndTimeField.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _))
            {
                MessageBox.Show("Неверный формат конечного времени.");
                return false;
            }

            // Проверяем, что введенная стоимость является числом
            if (!int.TryParse(newPriceField.Text, out _))
            {
                MessageBox.Show("Введите корректную стоимость (только цифры).");
                return false;
            }

            // Проверяем, что введенное количество доступных билетов является числом
            if (!int.TryParse(newAvailableTicketField.Text, out _))
            {
                MessageBox.Show("Введите корректное количество билетов (только цифры).");
                return false;
            }

            // Проверяем, что введенное количество проданных билетов является числом
            if (!int.TryParse(newSoldTicketField.Text, out _))
            {
                MessageBox.Show("Введите корректное количество проданных билетов (только цифры).");
                return false;
            }


            return true;
        }

        
    }
}
