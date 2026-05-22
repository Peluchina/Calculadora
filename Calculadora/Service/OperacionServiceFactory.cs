using Calculadora.DTO;
using Calculadora.Repository;

namespace Calculadora.Service
{
    public class OperacionServiceFactory
    {
        private readonly IOperacionRepository _repository;

        public OperacionServiceFactory(IOperacionRepository repository)
        {
            _repository = repository;
        }

        public IOperacionService CreateService() { 
            return new OperacionService(this._repository);
        }

        public IOperacionService CreateOperacionCorrectaService() {       
            return new OperacionCorrectaService(_repository);        
        }

        public IOperacionService ListarServicio()
        {
            return new OperacionService(_repository);
        }


    }
}
