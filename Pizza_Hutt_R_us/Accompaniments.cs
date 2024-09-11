using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pizza_Hutt_R_us
{
    public class Accompaniments
    {
        public int ID { get; set; }
        private string name { get; set; }

        private decimal cost { get; set; }

        public string Name
        {
            get => name;
            set
            {
                name = value;

            }
        }
        public decimal Cost
        {
            get => cost;
            set
            {
                cost = value;

            }
        }

        public Accompaniments(int ID, string name, decimal cost)
        {
            this.ID = ID;
            this.Name = name;
            this.Cost = cost;
        }


    }
}
