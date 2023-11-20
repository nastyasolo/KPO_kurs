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
        public LookTrainForm(String role)
        {
            InitializeComponent();
            this.role = role;
            panel3.Visible = false;
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
                ////DataBase dataBase = new DataBase();
                ////DataTable table = new DataTable();
                ////MySqlDataAdapter adapter = new MySqlDataAdapter();
                ////MySqlCommand command = new MySqlCommand("SELECT * FROM trains", dataBase.getConnection());
                ////adapter.SelectCommand = command;
                ////adapter.Fill(table);

                ////foreach (DataRow row in table.Rows)
                ////{
                ////    Train train = new Train();
                ////    train.number = Convert.ToString(row.ItemArray[1]);
                ////    train.endStation = Convert.ToString(row.ItemArray[2]);
                ////    train.date = Convert.ToDateTime(row.ItemArray[3]);
                ////    train.timeStart = Convert.ToString(row.ItemArray[4]);
                ////    train.timeEnd = Convert.ToString(row.ItemArray[5]);
                ////    train.price = Convert.ToString(row.ItemArray[6]);
                ////    train.availableTicket = Convert.ToInt32(row.ItemArray[7]);
                ////    train.soldTicket = Convert.ToInt32(row.ItemArray[8]);


                ////    //Добавляем пользователей в список
                ////    ListTrain.Add(train);
                ////}
                //ListUser.Sort();
                // String columns = "{0, -20}{1, -30}{2, -30}{3, -20}";
                ListTrain = getData();
                for (int i = 0; i < ListTrain.Count; i++)
                {
                    //listBox.Items.Add(String.Format(columns, $"{ListUser[i].id}-", $"{ListUser[i].login}-", $"{ListUser[i].password}-", $"{ListUser[i].role}-"));
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

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comeToMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuForm menuForm = new MenuForm(role);
            menuForm.ShowDialog();
        }

        private void unVPanel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                var indexSelect = listBox1.SelectedIndex;
                numberTrainField.Text = listBox1.Items[indexSelect].ToString();
                endStationField.Text = listBox2.Items[indexSelect].ToString();
                dateField.Text = listBox3.Items[indexSelect].ToString();
                startTimeField.Text = listBox4.Items[indexSelect].ToString();
                endTimeField.Text = listBox5.Items[indexSelect].ToString();
                priceField.Text = listBox6.Items[indexSelect].ToString();
                availableTicketField.Text = listBox7.Items[indexSelect].ToString();
                soldTicketField.Text = listBox8.Items[indexSelect].ToString();

                panel3.Visible = true;
            }
            catch { }
        }

        private void buttonBuyTicket_Click(object sender, EventArgs e)
        {
            int numOfTicket = Convert.ToInt32(numOfTicketField.Text);
            int availableTicket= Convert.ToInt32(availableTicketField.Text);
            int soldTicket= Convert.ToInt32(soldTicketField.Text);

            availableTicket -= numOfTicket;
            soldTicket += numOfTicket;

            DataBase db = new DataBase();
            MySqlCommand command = new MySqlCommand("UPDATE `trains` SET `availableTicket` = @newAT, `soldTicket` = @newST WHERE `trains`.`number` = @number AND `trains`.`endStation` = @endSt", db.getConnection());

            command.Parameters.Add("@number", MySqlDbType.Int32).Value = numberTrainField.Text;
            command.Parameters.Add("@endSt", MySqlDbType.VarChar).Value = endStationField.Text;
            command.Parameters.Add("@newAT", MySqlDbType.VarChar).Value = availableTicket;
            command.Parameters.Add("@newST", MySqlDbType.VarChar).Value = soldTicket;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Куплено");
                FillTrainList();
                panel3.Visible = false;

            }
            else
                MessageBox.Show("Ошибка!");

            db.closeConnection();

        }

        public List<Train> Sort(List<Train> train, string typeSort)
        {


            List<Train> sortTrain = new List<Train>();

            switch (typeSort)
            {
                case "number":
                    List<string> vec = new List<string>();
                    for (int i = 0; i < train.Count; i++)
                    {
                        vec.Add(train[i].number);
                    }

                    for (int i = 0; i < train.Count - 1; i++)
                    {
                        for (int j = 0; j < train.Count - 1 - j; j++)
                        {
                            if ((vec[i].CompareTo(vec[i + 1])) > 0)
                            {
                                var temp = vec[i];
                                vec[i] = vec[i + 1];
                                vec[i + 1] = temp;

                                var tmp = train[i];
                                train[i] = train[i + 1];
                                train[i + 1] = tmp;
                            }
                        }
                    }

                    sortTrain = train;
                    break;
                case "endStation":
                    List<string> vect = new List<string>();
                    for (int i = 0; i < train.Count; i++)
                    {
                        vect.Add(train[i].endStation);
                    }

                    for (int i = 0; i < train.Count - 1; i++)
                    {
                        for (int j = 0; j < train.Count - 1 - j; j++)
                        {
                            if ((vect[i].CompareTo(vect[i + 1])) > 0)
                            {
                                var temp = vect[i];
                                vect[i] = vect[i + 1];
                                vect[i + 1] = temp;

                                var tmp = train[i];
                                train[i] = train[i + 1];
                                train[i + 1] = tmp;
                            }
                        }
                    }

                    sortTrain = train;
                    break;
                   
                case "price":
                    ////for (int i = 0; i < train.Count; i++)
                    ////{
                    ////    double price = double.Parse(train[i].price); // ошибка
                    ////    if (price > priceSort)
                    ////    {
                    ////        sortTrain.Add(train[i]);
                    ////    }
                    ////}
                    break;
                default:
                    sortTrain = train;
                    break;
            }

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            listBox7.Items.Clear();
            listBox8.Items.Clear();
            for (int i = 0; i < sortTrain.Count; i++)
            {
                //  listBox2.Items.Add(String.Format(columns, $"{ListProduct[i].name}-", $"{ListProduct[i].count}-", $"{ListProduct[i].price}-", $"{ListProduct[i].dateTime}-", $"{ListProduct[i].FIOreg}-"));
                listBox1.Items.Add($"{sortTrain[i].number}");
                listBox2.Items.Add($"{sortTrain[i].endStation}");
                listBox3.Items.Add($"{sortTrain[i].date.ToShortDateString()}");
                listBox4.Items.Add($"{sortTrain[i].timeStart}");
                listBox5.Items.Add($"{sortTrain[i].timeEnd}");
                listBox6.Items.Add($"{sortTrain[i].price}");
                listBox7.Items.Add($"{sortTrain[i].availableTicket}");
                listBox8.Items.Add($"{sortTrain[i].soldTicket}");
            }

            return sortTrain;
        }
        private List<Train> getData()
        {
            List<Train> ListTrain = new List<Train>();

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
            return ListTrain;
        }
        private void buttonSortNumber_Click(object sender, EventArgs e)
        {
            List<Train> ListTrain = getData();
            Sort(ListTrain, "number");
        }

        private void buttonSortEndStation_Click(object sender, EventArgs e)
        {
            List<Train> ListTrain = getData();
            Sort(ListTrain, "endStation");
        }

        private void buttonSortPrice_Click(object sender, EventArgs e)
        {
            List<Train> ListTrain = getData();
            Sort(ListTrain, "price");
        }
    }
}
