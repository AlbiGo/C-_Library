using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditEntry
{
    public class AuditEntry
    {
        [Key]
        public int ID { get; set; }
        public string EntityName { get; set; }
        public int EntityID { get; set; }
        public DateTime Created { get; set; }
        public string Type { get; set; }
        public int UserId { get; set; }

        public List<AuditEntryProperty> AuditEntryProperties { get; set; }
    }
}
