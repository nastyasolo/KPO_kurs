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
    public partial class MenuForm : Form
    {
        String role;

        public MenuForm(String role) // Конструктор формы меню
        {
            InitializeComponent(); // Инициализация компонентов формы
            this.role = role; // Установка роли пользователя
            if (role =="0" )
            { // Скрытие панели администратора, если роль пользователя не является администраторской
                AdminPanel.Visible = false;
            }
        }

        private void closeButton_Click(object sender, EventArgs e) // Обработчик события для кнопки закрытия приложения
        {
            Application.Exit();
        }

        private void buttonLookData_Click(object sender, EventArgs e) // Обработчик события для кнопки просмотра данных о поездах
        {
            // Скрываем текущую форму и открываем форму просмотра данных о поездах
            this.Hide();
            LookTrainForm lookTrainForm = new LookTrainForm(role);
            lookTrainForm.Show();
        }

        private void SearchTaskTrainButton_Click(object sender, EventArgs e) // Обработчик события для кнопки поиска поездов по заданию
        {
            // Скрываем текущую форму и открываем форму поиска поездов
            this.Hide();
            SearchTaskTrainForm searchTaskTrainForm = new SearchTaskTrainForm(role);
            searchTaskTrainForm.Show();
        }

        private void UsersData_Click(object sender, EventArgs e) // Обработчик события для кнопки просмотра данных о пользователях
        {
            // Обработчик события для кнопки просмотра данных о пользователях
            this.Hide();
            LookUserForm lookUserForm = new LookUserForm(role);
            lookUserForm.Show();
        }
    }
}
