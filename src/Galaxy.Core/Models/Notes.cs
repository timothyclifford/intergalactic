using System;
using System.Collections.Generic;
using System.Linq;

using Galaxy.Core.Utils;

namespace Galaxy.Core.Models
{
    public class Notes
    {
        public IList<Unit> Units { get; set; }

        public IList<Resource> Resources { get; set; }

        public IList<IQuestion> Questions { get; set; }

        public Notes()
        {
            Units = new List<Unit>();
            Resources = new List<Resource>();
            Questions = new List<IQuestion>();
        }
    }
}