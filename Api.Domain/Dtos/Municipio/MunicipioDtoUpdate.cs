using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatorio")]
        public Guid  Id { get; set; }
        
        [Required(ErrorMessage = "Nome do municipio é obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome do municipio deve ser no máximo {1} caractere.")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código IBGE inválido.")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é obrigatorio")]
        public Guid UfId { get; set; }
    }
}
