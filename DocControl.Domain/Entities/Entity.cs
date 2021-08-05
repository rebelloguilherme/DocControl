using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocControl.Domain.Entities
{
    //Abstract class (Base)
    //All classes which comes with Entity Heritance automatically Heritate all the atributes
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
