using System;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDto
    {
        public Guid Id { get; set; }

        public string nome { get; set; }
        public string CodIBGE { get; set; }
        public Guid UfId { get; set; }
    }
}
