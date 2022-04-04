using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome do municipio é obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome do municipio deve ser no máximo {1} caractere.")]
        public string nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código IBGE inválido.")]
        public string CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é obrigatorio")]
        public Guid UfId { get; set; }
    }
}
