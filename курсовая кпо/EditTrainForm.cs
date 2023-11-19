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
    public partial class EditTrainForm : Form
    {
        String role;
        public EditTrainForm(string role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void goToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(role);
            menuForm.Show();
        }

        private void buttonEditTrain_Click(object sender, EventArgs e)
        {
            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("UPDATE `trains` SET `number` = @newNumber, `endStation` = @newEndSt, `date` = @newDate, `timeStart` = @newTS, `timeEnd` = @newTE, `price` = @newPrice, `availableTicket` = @newAT, `soldTicket` = @newST WHERE `trains`.`number` = @number", db.getConnection());

            command.Parameters.Add("@number", MySqlDbType.Int32).Value = numberTrainField.Text;
            command.Parameters.Add("@newnumber", MySqlDbType.VarChar).Value = newNumberTrainField.Text;
            command.Parameters.Add("@newEndSt", MySqlDbType.VarChar).Value = newEndStationField.Text;
            command.Parameters.Add("@newDate", MySqlDbType.VarChar).Value = newDateField.Text;
            command.Parameters.Add("@newTS", MySqlDbType.VarChar).Value = newStartTimeField.Text;
            command.Parameters.Add("@newTE", MySqlDbType.VarChar).Value = newEndTimeField.Text;
            command.Parameters.Add("@newPrice", MySqlDbType.VarChar).Value = newPriceField.Text;
            command.Parameters.Add("@newAT", MySqlDbType.VarChar).Value = newAvailableTicketField.Text;
            command.Parameters.Add("@newST", MySqlDbType.VarChar).Value = newSoldTicketField.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Изменено");
            }
            else
                MessageBox.Show("Ошибка!");

            db.closeConnection();
        }
    }
}
