using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkL15;

internal struct ReceptionTime
{
    public string? Time { get; set; }
    public User? Reserver { get; set; } = null;

    public ReceptionTime(string? time) => Time = time;

    public override string ToString()
        => $@"Time: {Time}
Reserved: {(Reserver is null ? "No" : "Yes")}";

}
