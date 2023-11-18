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
        public LookTrainForm()
        {
            InitializeComponent();
            FillTrainList();
        }
        private void FillTrainList()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();

            List<Train> ListTrain = new List<Train>();
            try
            {
                DataBase dataBase = new DataBase();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM trains", dataBase.getConnection());
                adapter.SelectCommand = command;
                adapter.Fill(table);

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


                    //Добавляем пользователей в список
                    ListTrain.Add(train);
                }
                //ListUser.Sort();
                // String columns = "{0, -20}{1, -30}{2, -30}{3, -20}";
                for (int i = 0; i < ListTrain.Count; i++)
                {
                    //listBox.Items.Add(String.Format(columns, $"{ListUser[i].id}-", $"{ListUser[i].login}-", $"{ListUser[i].password}-", $"{ListUser[i].role}-"));
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comeToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm();
            menuForm.ShowDialog();
        }

        
    }
}
