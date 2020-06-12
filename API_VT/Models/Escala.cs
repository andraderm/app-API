using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_VT.Models.Entities
{
    public class Escala
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EscalaTrabalho { get; set; }

        public Escala() { }
        public Escala(int id, string escala)
        {
            Id = id;
            EscalaTrabalho = escala;
        }
    }
}
