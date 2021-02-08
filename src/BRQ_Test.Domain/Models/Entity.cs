using System;
using System.Collections.Generic;
using System.Text;

namespace BRQ_Test.Domain.Model
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateAt { get; set; }

        public Entity()
        {
            CreateAt = DateTime.Now;
        }
    }
}
