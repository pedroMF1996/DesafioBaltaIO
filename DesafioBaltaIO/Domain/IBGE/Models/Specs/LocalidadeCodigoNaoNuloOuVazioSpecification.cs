using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.IBGE.Models.Specs
{
    #endregion

    #region CodigoSpecifications
    public class LocalidadeCodigoNaoNuloOuVazioSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => !string.IsNullOrEmpty(localidade.Codigo);
        }
    }
    #endregion

}
