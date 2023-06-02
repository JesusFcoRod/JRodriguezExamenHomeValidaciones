using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Survey
    {
        public int IdSurvey { get; set; }
        public string Answer { get; set; }
        public string created_at { get; set; }

        public ML.Activity Activity { get; set; }
        public List<object> Surveys { get; set; }
    }
}
