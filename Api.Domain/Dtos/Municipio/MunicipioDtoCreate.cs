using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "Nome do municipio é campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome do município deve ser no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código IBGE inválido.")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código de UF é obrigatório")]
        public Guid UfId { get; set; }
    }
}
