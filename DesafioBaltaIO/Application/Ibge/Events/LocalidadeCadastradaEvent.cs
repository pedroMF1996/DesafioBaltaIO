using NetDevPack.Messaging;

namespace DesafioBaltaIO.Application.Ibge.Events
{
    public class LocalidadeCadastradaEvent : Event
    {
        public Guid LocalidadeId { get; private set; }
        public string CodigoLocalidade { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public LocalidadeCadastradaEvent(Guid localidadeId, DateTime dataCadastro, string codigoLocalidade)
        {
            LocalidadeId = localidadeId;
            DataCadastro = dataCadastro;
            CodigoLocalidade = codigoLocalidade;
        }
    }
}
