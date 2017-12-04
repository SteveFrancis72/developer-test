using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrangeBricks.Web.Models
{
    public class Viewing
    {
        [Key]
        public int Id { get; set; }
        public DateTime ViewingAt { get; set; }
 
        public string BuyerId { get; set; }
 
        public DateTime CreatedAt { get; set; }
 
        [ForeignKey("PropertyId")]
        public virtual Property Property { get; set; }
 
        [Column("Property_Id")]
        public int PropertyId { get; set; }
    }
}