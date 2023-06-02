using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Activity
    {
        public int IdActivity { get; set; }
        public string Schedule_Inicial { get; set; }
        public string Schedule_Final { get; set; }
        public string Tittle { get; set; }
        public string Created_at { get; set; }
        public string Update_at { get; set; }
        public string Status { get; set; }

        public string Condicion { get; set; }

        public string DuracionActivity { get; set; }

        public string Cronograma { get; set; }
        public ML.Property Property { get; set; }

        public List<Object> Activitys { get; set; }

        
    }
}
