using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlazomEstoque.Core.Domain.Model
{
    public class EstoqueVagas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int QtdAtual { get; set; }
        public DateTime UltimaData { get; set; }
    }
}

