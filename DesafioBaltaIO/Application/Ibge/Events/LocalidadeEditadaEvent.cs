using NetDevPack.Messaging;

namespace DesafioBaltaIO.Application.Ibge.Events
{
    public class LocalidadeEditadaEvent : Event
    {
        public string CodigoLocalidade { get; private set; }
        public DateTime DataEdicao { get; private set; }

        public LocalidadeEditadaEvent(string codigoLocalidade, DateTime dataEdicao)
        {
            CodigoLocalidade = codigoLocalidade;
            DataEdicao = dataEdicao;
        }
    }
}
