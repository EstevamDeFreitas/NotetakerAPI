using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public enum AccessLevel
    {
        Owner,
        Remove,
        Edit,
        Add,
        View
    }
}
