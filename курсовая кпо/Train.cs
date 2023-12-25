using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_кпо
{
    public class Train // Класс, представляющий модель данных для поезда
    {
        public string number { get; set; } // Номер поезда

        public string endStation { get; set; } // Конечная станция

        public DateTime date { get; set; } // Дата отправления поезда

        public string timeStart { get; set; }  // Время отправления поезда

        public string timeEnd { get; set; } // Время прибытия поезда

        public string price { get; set; }  // Стоимость билета

        public int availableTicket { get; set; } // Количество доступных билетов

        public int soldTicket { get; set; } // Количество проданных билетов

    }
}
