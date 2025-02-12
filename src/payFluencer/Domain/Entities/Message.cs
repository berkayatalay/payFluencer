using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Message : Entity<Guid>
{
    public string Content { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid RecieverUserId { get; set; }

    public virtual User User { get; set; }
}
