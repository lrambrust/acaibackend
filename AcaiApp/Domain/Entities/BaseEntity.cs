using AcaiApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public long Id { get; private set; }
    }
}
