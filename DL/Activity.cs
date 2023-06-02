using System;
using System.Collections.Generic;

namespace DL;

public partial class Activity
{
    public int IdActivity { get; set; }

    public string Tittle { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public string Status { get; set; } = null!;

    public int? IdProperty { get; set; }

    public DateTime? ScheduleInicial { get; set; }

    public DateTime? ScheduleFinal { get; set; }

    public virtual Property? IdPropertyNavigation { get; set; }

    public virtual ICollection<Survey> Surveys { get; set; } = new List<Survey>();

    public string PropetyTittle { get; set; }
    public string ActivityStatus { get; set; }
}
