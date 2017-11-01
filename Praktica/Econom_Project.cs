using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Praktica
{
    class Econom_Project : Project
    {
        private bool demand;//есть ли спрос на аналог. проект
        private string orientation;//куда ориентирован проект (импорт/экспорт)
        private int project_Complexity;//сложность проекта
        private decimal income;//доход от проекта
        //акксессоры для обработки входных и исходящих данных
        public bool Demand
        {
            get { return demand; }
            set { demand = value; }
        }
        public string Orientation
        {
            get { return orientation; }
            set 
            {
                if (value != "")
                {
                    orientation = value;
                }
                else 
                {
                    orientation = "export";
                }
            }
        }
        public int Project_Complexity
        {
            get { return project_Complexity; }
            set 
            {
                if ((value > 0) && (value <= 100))
                    project_Complexity = value;
                else
                    project_Complexity = 0;

            }
        }
        public decimal Income
        {
            get { return income; }
            set 
            {
                if (value != null)
                {
                    income = value;
                }
                else
                {
                    income = 0;
                }
            }
        }
    }
}
