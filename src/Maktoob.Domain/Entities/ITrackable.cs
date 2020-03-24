using System;
using System.Collections.Generic;
using System.Text;

namespace maktoob.Domain.Entities
{
    interface ITrackable
    {
        byte[] RowVersion { get; set; }
    }
}
