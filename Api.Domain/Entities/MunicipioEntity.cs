using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class MunicipioEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public int Nome { get; set; }

        public int CodIBGE { get; set; }
         [Required]
        public Guid Ufid { get; set; }
        public UfEntity Uf { get; set; }

        public IEnumerable<CepEntity> Ceps { get; set; }
    }
}
