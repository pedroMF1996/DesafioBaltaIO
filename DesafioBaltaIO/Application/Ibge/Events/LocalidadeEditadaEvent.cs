using NetDevPack.Messaging;

namespace DesafioBaltaIO.Application.Ibge.Events
{
    public class LocalidadeEditadaEvent : Event
    {
        public Guid LocalidadeId { get; private set; }
        public string CodigoLocalidade { get; private set; }
        public DateTime DataEdicao { get; private set; }

        public LocalidadeEditadaEvent(Guid localidadeId, DateTime dataEdicao, string codigoLocalidade)
        {
            LocalidadeId = localidadeId;
            DataEdicao = dataEdicao;
            CodigoLocalidade = codigoLocalidade;
        }
    }
}
