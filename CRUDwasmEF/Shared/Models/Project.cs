using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDwasmEF.Shared.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamlidId { get; set; }
        public Developer Teamlid { get; set; }
        public string TeamlidFirstName { get; set; }
        public string TeamlidLastName { get; set; }
    }
}
