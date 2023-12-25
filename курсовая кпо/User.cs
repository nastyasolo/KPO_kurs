using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_кпо
{
    public class User // Класс, представляющий модель данных для пользователя
    {
        public int id { get; set; }  // Уникальный идентификатор пользователя
        public string login { get; set; } // Логин пользователя
        public string password { get; set; } // Пароль пользователя
        public string role { get; set; }// Роль пользователя 

    }
}
