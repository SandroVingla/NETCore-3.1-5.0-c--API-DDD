using System;

namespace Api.Domain.Models
{
    public class CepModel : BaseModel
    {
        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }
        private string _logradouro;
        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }
        
        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set 
            { 
                _numero = string.IsNullOrEmpty(value) ? "S/N" : value ; 
            }
        }
        private Guid _MunicipioId;
        public Guid MunicipioId
        {
            get { return _MunicipioId; }
            set { _MunicipioId = value; }
        }
        
        
        
    }
}
