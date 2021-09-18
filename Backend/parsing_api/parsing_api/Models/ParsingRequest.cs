using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace parsing_api.Models
{
    public class ParsingRequest
    {
        public int PortalId { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }
        public Guid JobId { get; set; }
    }
}
