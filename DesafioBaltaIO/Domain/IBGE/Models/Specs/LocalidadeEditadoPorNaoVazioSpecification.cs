using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.IBGE.Models.Specs
{

    #region CadastradoPor
    public class LocalidadeEditadoPorNaoVazioSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => Guid.Empty != localidade.EditadoPor;
        }
    }
    #endregion

}
