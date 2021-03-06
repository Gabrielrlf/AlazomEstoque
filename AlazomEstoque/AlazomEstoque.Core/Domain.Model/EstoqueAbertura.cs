using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlazomEstoque.Core.Domain.Model
{
    public class EstoqueAbertura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IdAbertura { get; set; }
        public int QtdDia { get; set; }
        public DateTime HorarioAbertura { get; set; }
    }
}
