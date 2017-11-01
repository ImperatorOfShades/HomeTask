using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Praktica
{
    struct Data
    {
       public int Day, Mounth, Year;
    };

    public class Project
    {
        private string name, client;//Название проекта и Заказчик;
        private string startDate, endDate;//Даты начала и окончания проекта;
        private decimal price;
        private double realization, rollback;//Цена в грн.; 
                                                    //коефициент реализации в срок в % ;
                                                    //и величина отката в % ;
        public bool adding;//
        public int possition;//позиция в таблице
                                //акксессоры для обработки входных и исходящих данных
        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                if (value != "")
                    name = value;
                else
                    name = "NoName";    
            }
        }

        public string Client
        {
            get
            {
                return client;
            }
            set
            {
                if (value != "")
                    client = value;
                else
                    client = "NoClient";
            }
        }

        public string StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                if (value != "" && value != "    ,  ,")
                    startDate = value;
                else
                    startDate = "2010.10.10";

            }
        }

        public string EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (value != "" && value != "    ,  ,")
                    endDate = value;
                else
                    endDate = "2010.12.12";
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value != null)
                    price = value;
                else
                    price = 0;
            }
        }

        public double Realization
        {
            get
            {
                return realization;
            }
            set
            {
                if ((value > 0) && (value <= 100))
                    realization = value;
                else
                    realization = 0;
            }
        }

        public double Rollback
        {
            get
            {
                return rollback;
            }
            set
            {
                if ((value > 0) && (value <= 100))
                    rollback = value;
                else
                    rollback = 0;
            }
        }      
    }
}
