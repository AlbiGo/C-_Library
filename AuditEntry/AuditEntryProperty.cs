using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditEntry
{
    public class AuditEntryProperty
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("AuditEntry")]
        public int? AuditEntryID { get; set; }
        public AuditEntry AuditEntry { get; set; }
        public string? PropertyName { get; set; }
        public string? PropertyOldValue { get; set; }
        public string? PropertyNewValue { get; set; }
        public string? Modified { get; set; }
    }
}
