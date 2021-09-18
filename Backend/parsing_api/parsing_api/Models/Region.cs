using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace parsing_api.Models
{
    [Table("parsingobject")]
    public class ParsingObject
    {
        [Column("id")]
        public long Id { get; set; }
        [Column("number")]
        public string Number { get; set; }
        [Column("time")]
        public DateTime Time { get; set; }
    }
}
