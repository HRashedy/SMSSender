using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SMSSendAPI.Data.Model
{
    public class SMS
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Number { get; set; }
        [Required]
        [StringLength(1000)]
        public string Text { get; set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedUtc { get; set; }
    }
}
