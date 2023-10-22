using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.IBGE.Models.Specs
{


    #region DataCadastro
    public class LocalidadeDataCadastroNaoVazioOuFuturaSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => localidade.DataCadastro > DateTime.MinValue && localidade.DataCadastro.Value.Ticks <= DateTime.UtcNow.Ticks;
        }
    }
    #endregion

}
