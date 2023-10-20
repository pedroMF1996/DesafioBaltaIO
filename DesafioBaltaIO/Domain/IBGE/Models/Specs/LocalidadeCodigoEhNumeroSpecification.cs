using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.IBGE.Models.Specs
{
    #endregion
    #region CodigoSpecifications

    public class LocalidadeCodigoEhNumeroSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            int result;
            return localidade => int.TryParse(localidade.Codigo, out result);
        }
    }
    #endregion

}
