using Calculadora.Domain.Service;
using Calculadora.Domain.Repositories;
using Calculadora.Application;



namespace Calculadora.Domain.Factories
{
    public class OperacionFactory
    {
        private readonly IOperacionRepository _repository;

        public OperacionFactory(IOperacionRepository repository)
        {
            _repository = repository;
        }

        public IOperacionService CreateService()
        {
            return new OperacionInversaService(this._repository);
        }

        public IOperacionService CreateOperacionCorrectaService()
        {
            return new OperacionNormalService(_repository);
        }

        public IOperacionService ListarServicio()
        {
            return new OperacionInversaService(_repository);
        }

    }
}
