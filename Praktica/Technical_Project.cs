using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Praktica
{
    class Technical_Project : Project
    {
        private string standart;//стандарт тех. документации
        private string techn_Task;//техническое задание
        private int parts;//кол-во частей в проекте
        private decimal econom_Rating;//экономическая оценка изделия
        private string quality_Rating;//оценка качества
        //акксессоры для обработки входных и исходящих данных
        public string Standart 
        {
            get { return standart; }
            set
            {
                if (value != "")
                    standart = value;
                else
                    standart= "NoName";
            }
        }
        public string Techn_Task
        {
            get { return techn_Task; }
            set
            {
                if (value != "")
                    techn_Task = value;
                else
                    techn_Task = "NoTask";
            }
        }
        public int Parts
        {
            get { return parts; }
            set
            {
                if (Convert.ToBoolean(value))
                    parts = value;
                else
                    parts = 1;
            }
        }
        public decimal Econom_Rating
        {
            get { return econom_Rating; }
            set
            {
                if (value != null)
                    econom_Rating = value;
                else
                    econom_Rating = 0;
            }
        }
        public string Quality_rating
        {
            get { return quality_Rating; }
            set
            {
                if (value != "")
                    quality_Rating = value;
                else
                    quality_Rating = "No";
            }
        }
    }
}
