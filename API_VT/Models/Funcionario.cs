using System;
using System.ComponentModel.DataAnnotations;


namespace API_VT.Models.Entities
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataAdmissao { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double CustoDiarioVT { get; set; }
        [Required]
        public int EscalaId { get; set; }
        public Escala Escala { get; set; }
        [Required]
        public int SetorId { get; set; }
        public Setor Setor { get; set; }

        public Funcionario() { }

        public Funcionario(int id, string nome, string sobrenome, DateTime dataAdmissao, double custoDiarioVT, int escalaId, int setorId)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            DataAdmissao = dataAdmissao;
            CustoDiarioVT = custoDiarioVT;
            EscalaId = escalaId;
            SetorId = setorId;
        }
    }
}
