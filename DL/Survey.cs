using System;
using System.Collections.Generic;

namespace DL;

public partial class Survey
{
    public int IdSurvey { get; set; }

    public int? ActivityId { get; set; }

    public string Answer { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Activity? Activity { get; set; }
}
