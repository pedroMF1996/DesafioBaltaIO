using NetDevPack.Specification;
using System.Linq.Expressions;

namespace DesafioBaltaIO.Domain.IBGE.Models.Specs
{
    

    #region CidadeSpecification
    public class LocalidadeCidadeNaoNuloOuVazioSpecification : Specification<LocalidadeModel>
    {
        public override Expression<Func<LocalidadeModel, bool>> ToExpression()
        {
            return localidade => !string.IsNullOrEmpty(localidade.Cidade);
        }
    }
    #endregion

}
