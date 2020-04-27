using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Fis.Entities
{
    public abstract class BaseEntity
    {
        public long  Id { get;  set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
