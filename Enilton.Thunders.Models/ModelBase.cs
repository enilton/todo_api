using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enilton.Thunders.Models
{
    public abstract class ModelBase
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime DeletedAt { get; set; }

        protected ModelBase() {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }        
    }
}
