using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class CepEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
         public string Cep { get; set; }

        [Required]
        [MaxLength(2)]
        public string Logradouro { get; set; }
          
        [MaxLength(10)]
        public string  Numero { get; set; }

        public Guid MunicipioId { get; set; }

        public MunicipioEntity Municipio { get; set; }
    }
}
