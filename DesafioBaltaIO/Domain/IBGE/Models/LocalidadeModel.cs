using DesafioBaltaIO.Domain.IBGE.Models.Specs;
using NetDevPack.Domain;

namespace DesafioBaltaIO.Domain.IBGE.Models
{
    public class LocalidadeModel : Entity, IAggregateRoot
    {
        public string Codigo { get; private set; }
        public string Estado { get; private set; }
        public string Cidade { get; private set; }
        public Guid CadastradoPor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public Guid EditadoPor { get; private set; }
        public DateTime DataEdicao { get; private set; }

        protected LocalidadeModel()
        { }

        public LocalidadeModel(string codigo, string estado, string cidade)
        {
            Codigo = codigo;
            Estado = estado;
            Cidade = cidade;
        }

        public bool AlterarEstado(string estado)
        {
            Estado = estado;

            return new LocalidadeEstadoNaoNuloOuVazioSpecification().IsSatisfiedBy(this);
        }

        public bool AlterarCidade(string cidade)
        {
            Cidade = cidade;

            return new LocalidadeCidadeNaoNuloOuVazioSpecification().IsSatisfiedBy(this);
        }

        public bool AlterarCodigo(string codigo)
        {
            Codigo = codigo;

            return new LocalidadeCodigoNaoNuloOuVazioSpecification()
                .And(new LocalidadeCodigoEhNumeroSpecification())
                .And(new LocalidadeCodigoNoPadraoSpecification())
                .IsSatisfiedBy(this);
        }

        public bool AssociarCadastrante(Guid cadastradoPor, DateTime dataCadastro)
        {
            CadastradoPor = cadastradoPor;
            DataCadastro = dataCadastro;

            return new LocalidadeCadastradoPorNaoVazioSpecification()
                        .And(new LocalidadeDataCadastroNaoVazioOuFuturaSpecification())
                        .IsSatisfiedBy(this);
        }
        
        public bool AssociarEditor(Guid editadoPor, DateTime dataEdicao)
        {
            EditadoPor = editadoPor;
            DataEdicao = dataEdicao;

            return new LocalidadeEditadoPorNaoVazioSpecification()
                        .And(new LocalidadeDataEdicaoNaoVazioOuFuturaSpecification())
                        .IsSatisfiedBy(this);
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
