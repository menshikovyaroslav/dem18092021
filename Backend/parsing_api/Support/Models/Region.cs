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
        public long Id { get; set; }

        /// <summary>
        /// Название региона
        /// </summary>
        [Column("name")]
        public string Name { get; set; }
    }
}
