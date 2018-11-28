using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GPS.Data
{
    public class BaseEntity
    {
        [NotMapped]
        public long Id { get; set; }
        [NotMapped]
        public DateTime CreatedDate { get; set; }
        [NotMapped]
        public string CreatedBy { get; set; }
        [NotMapped]
        public DateTime ModifiedDate { get; set; }
        [NotMapped]
        public string ModifiedBy { get; set; }
    }
}
