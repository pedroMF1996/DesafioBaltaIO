using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.IBGE.Models.Specs
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

}
