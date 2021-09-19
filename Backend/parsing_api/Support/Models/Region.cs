using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Support.Models
{
    /// <summary>
    /// Модель объекта региона страны
    /// </summary>
    [Table("regions")]
    public class Region
    {
        /// <summary>
        /// Id региона
        /// </summary>
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Название региона
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// Алиасы региона
        /// </summary>
        [Column("aliases")]
        public List<string> Aliases { get; set; }
    }
}
