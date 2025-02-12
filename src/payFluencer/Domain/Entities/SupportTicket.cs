using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class SupportTicket : Entity<Guid>
{
    public string Category { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Status { get; set; }

    public virtual User User{ get; set; }
}
