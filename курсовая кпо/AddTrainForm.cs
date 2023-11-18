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
    public partial class AddTrainForm : Form
    {
        public AddTrainForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void goToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void buttonAddTrain_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("INSERT INTO `trains` (`number`, `endStation`, `date`, `timeStart`, `timeEnd`, `price`, `availableTicket`, `soldTicket`) VALUES (@number, @endSt, @date, @startTime, @endTime, @price, @availableTicket, @soldTicket)", db.getConnection());

            command.Parameters.Add("@number", MySqlDbType.VarChar).Value = numberTrainField.Text;
            command.Parameters.Add("@endSt", MySqlDbType.VarChar).Value = endStationField.Text;
            command.Parameters.Add("@date", MySqlDbType.VarChar).Value = dateTrainField.Text;
            command.Parameters.Add("@startTime", MySqlDbType.VarChar).Value = timeStartField.Text;
            command.Parameters.Add("@endTime", MySqlDbType.VarChar).Value = timeEndField.Text;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = priceField.Text;
            command.Parameters.Add("@availableTicket", MySqlDbType.VarChar).Value = availableTicketField.Text;
            command.Parameters.Add("@soldTicket", MySqlDbType.VarChar).Value = soldTicketField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Поезд добавлен");
            }
            else
                MessageBox.Show("Поезд не добавлен");

            db.closeConnection();
        }
    }
}
