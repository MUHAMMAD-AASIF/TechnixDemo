using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnixDemo.Model
{
    public class EntitySelectModel
    {
        public bool Select {  get; set; } = false;
        public string Entity { get; set; }
        public bool GetAll { get; set; } = false;
        public bool GetById { get; set; } = false;
        public bool Save { get; set; } = false;
        public bool Update { get; set; } = false;
        public bool Delete { get; set; } = false;
    }
}
