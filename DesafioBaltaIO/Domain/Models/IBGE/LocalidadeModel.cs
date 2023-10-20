using DesafioBaltaIO.Domain.Models.IBGE.Specs;
using NetDevPack.Domain;

namespace DesafioBaltaIO.Domain.Models.IBGE
{
    public class LocalidadeModel : Entity, IAggregateRoot
    {
        public string Codigo { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }

        protected LocalidadeModel()
        {}

        public LocalidadeModel(string codigo, string estado, string cidade)
        {
            Codigo = codigo;
            Estado = estado;
            Cidade = cidade;
        }

        public bool AlterarEstado(string estado)
        {
            Estado = estado;
            return IsValid();
        }

        public bool AlterarCidade(string cidade)
        {
            Cidade = cidade;
            return IsValid();
        }

        public bool AlterarCodigo(string codigo)
        {
            Codigo = codigo;
            return IsValid();
        }

        public bool IsValid()
        {
            return new LocalidadeEstadoNaoNuloOuVazioSpecification()
                .And(new LocalidadeCidadeNaoNuloOuVazioSpecification())
                .And(new LocalidadeCodigoNaoNuloOuVazioSpecification())
                .And(new LocalidadeCodigoEhNumeroSpecification())
                .And(new LocalidadeCodigoNoPadraoSpecification())
                .IsSatisfiedBy(this);
        }
    }
}
