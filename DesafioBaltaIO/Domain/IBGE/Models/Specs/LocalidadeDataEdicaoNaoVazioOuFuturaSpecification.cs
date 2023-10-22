using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.IBGE.Models.Specs
{


    #region DataEdicao
    public class LocalidadeDataEdicaoNaoVazioOuFuturaSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => localidade.DataEdicao > localidade.DataCadastro && localidade.DataEdicao.Ticks <= DateTime.UtcNow.Ticks;
        }
    }
    #endregion

}
