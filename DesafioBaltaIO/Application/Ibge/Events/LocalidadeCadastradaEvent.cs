using NetDevPack.Messaging;

namespace DesafioBaltaIO.Application.Ibge.Events
{
    public class LocalidadeCadastradaEvent : Event
    {
        public string CodigoLocalidade { get; private set; }

        public LocalidadeCadastradaEvent(string codigoLocalidade)
        {
            CodigoLocalidade = codigoLocalidade;
        }
    }
}
