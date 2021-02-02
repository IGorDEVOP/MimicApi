using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MimicAPI.Models
{
    public class Words
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Points { get; set; }

        public bool Active { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Updated { get; set; }
    }
}
