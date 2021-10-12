using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlazomEstoque.Core.Domain.Model
{
    public class CadastroFornecedor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Placa { get; set; }
        public DateTime HorarioEntrada { get; set; }
    }
}
