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
        public SearchTaskTrainForm(String role)
        {
            InitializeComponent();
            this.role = role;
        }

        private void comeToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(role);
            menuForm.Show();
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonSearchTrain_Click(object sender, EventArgs e)
        {
            string endStation = Convert.ToString(endStationTrainField.Text);
            DateTime minTime = Convert.ToDateTime(minTimeField.Text);
            DateTime maxTime = Convert.ToDateTime(maxTimeField.Text);
            DateTime time;

            listBox1.Items.Clear();
            listBox4.Items.Clear();
            listBox7.Items.Clear();
           

            List<Train> ListTrain = new List<Train>();
            try
            {
                DataBase dataBase = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM trains WHERE `endStation` = @endSt ", dataBase.getConnection());

                command.Parameters.Add("endSt", MySqlDbType.VarChar).Value = endStation;
                
                

                adapter.SelectCommand = command;
                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    Train train = new Train();

                    train.number = Convert.ToString(row.ItemArray[1]);
                    train.timeStart = Convert.ToString(row.ItemArray[4]);
                    train.availableTicket = Convert.ToInt32(row.ItemArray[7]);

                    time = Convert.ToDateTime(row.ItemArray[4]);
                    if (time <= maxTime && time >= minTime)
                    {
                        //Добавляем по в список
                        ListTrain.Add(train);
                    }
                }
                //ListUser.Sort();
                // String columns = "{0, -20}{1, -30}{2, -30}{3, -20}";
                for (int i = 0; i < ListTrain.Count; i++)
                {
                    //listBox.Items.Add(String.Format(columns, $"{ListUser[i].id}-", $"{ListUser[i].login}-", $"{ListUser[i].password}-", $"{ListUser[i].role}-"));
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
