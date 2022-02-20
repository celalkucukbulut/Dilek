using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domains
{
    public abstract class EntityBase
    {

    }

    public abstract class Entity<T> : EntityBase, IEntity<T>
    {
        [Key]
        public T ID { get; set; }
    }
}
