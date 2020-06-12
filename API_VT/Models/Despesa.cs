using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_VT.Models.Entities
{
    public class Despesa
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/yyyy}")]
        public DateTime DataReferencia { get; set; }
        [Required]
        public double DespesaMensal { get; set; }
    }
}
