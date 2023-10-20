using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.Models.IBGE.Specs
{

    #region EstadoSpecification
    public class LocalidadeEstadoNaoNuloOuVazioSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => localidade.Estado.Length == 2;
        }
    }

    #endregion

    #region CidadeSpecification
    public class LocalidadeCidadeNaoNuloOuVazioSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => !string.IsNullOrEmpty(localidade.Cidade);
        }
    } 
    #endregion

    #region CodigoSpecifications
    public class LocalidadeCodigoNaoNuloOuVazioSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => !string.IsNullOrEmpty(localidade.Codigo);
        }
    }

    public class LocalidadeCodigoEhNumeroSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            int result;
            return localidade => int.TryParse(localidade.Codigo, out result);
        }
    }

    public class LocalidadeCodigoNoPadraoSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => int.Parse(localidade.Codigo) >= 1000000;
        }
    }
    #endregion

    #region CadastradoPor
    public class LocalidadeCadastradoPorNaoVazioSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => Guid.Empty != localidade.CadastradoPor;
        }
    }
    #endregion

}
