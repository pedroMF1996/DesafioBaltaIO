using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.IBGE.Models.Specs
{

    #region CodigoSpecifications

    public class LocalidadeCodigoNoPadraoSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => int.Parse(localidade.Codigo) >= 1000000;
        }
    }
    #endregion

}
