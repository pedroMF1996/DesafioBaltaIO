
using DesafioBaltaIO.Domain.IBGE.Interfaces;
using Moq;

namespace DesafioBaltaIO.Tests.ApplicationTests
{
    public class IbgeCommandHandlerTests
    {
        private readonly ILocalidadeReository _localidadeReository;

        public IbgeCommandHandlerTests()
        {
            _localidadeReository = new Mock<ILocalidadeReository>().Object;
        }

        [Theory]
        [InlineData("1100015", "RO", "Alta Floresta D''''Oeste")]
        [InlineData("1300409", "AM", "Barcelos")]
        [InlineData("1400506", "RR", "São João da Baliza")]
        [InlineData("1502400", "PA", "Castanhal")]
        [InlineData("1703057", "TO", "Bandeirantes do Tocantins")]
        [InlineData("2100204", "MA", "Alcântara")]
        [InlineData("2202000", "PI", "Buriti dos Lopes")]
        [InlineData("2302206", "CE", "Beberibe")]
        [InlineData("2401206", "RN", "Arês")]
        [InlineData("2505238", "PB", "Cuité de Mamanguape")]
        [InlineData("2601508", "PE", "Belém de Maria")]
        [InlineData("2601607", "PE", "Belém do São Francisco")]
        [InlineData("2700201", "AL", "Anadia")]
        [InlineData("2900207", "BA", "Abaré")]
        [InlineData("3109204", "MG", "Buenópolis")]
        public void CadastrarLocalidadeComSucesso(string codigo, string estado, string cidade)
        {

        }
        
        [Theory]
        [InlineData("1100015", "RO", "Barcelos", "Alta Floresta D''''Oeste")]
        [InlineData("1300409", "AM", "São João da Baliza", "Barcelos")]
        [InlineData("1400506", "RR", "Castanhal", "São João da Baliza")]
        [InlineData("1502400", "PA", "Bandeirantes do Tocantins", "Castanhal")]
        [InlineData("1703057", "TO", "Alcântara", "Bandeirantes do Tocantins")]
        [InlineData("2100204", "MA", "Buriti dos Lopes", "Alcântara")]
        [InlineData("2202000", "PI", "Beberibe", "Buriti dos Lopes")]
        [InlineData("2302206", "CE", "Arês", "Beberibe")]
        [InlineData("2401206", "RN", "Cuité de Mamanguape", "Arês")]
        [InlineData("2505238", "PB", "Belém de Maria", "Cuité de Mamanguape")]
        [InlineData("2601508", "PE", "Belém do São Francisco", "Belém de Maria")]
        [InlineData("2601607", "PE", "Anadia", "Belém do São Francisco")]
        [InlineData("2700201", "AL", "Abaré", "Anadia")]
        [InlineData("2900207", "BA", "Buenópolis", "Abaré")]
        [InlineData("3109204", "MG", "Cidade nao correspondente", "Buenópolis")]
        public void AlterarCidadeLocalidadeComSucesso(string codigo, string estado, string cidade, string cidadeNova)
        {

        }


        [Theory]
        [InlineData("1100015", "AM", "Alta Floresta D''''Oeste", "RO")]
        [InlineData("1300409", "RR", "Barcelos", "AM")]
        [InlineData("1400506", "PA", "São João da Baliza", "RR")]
        [InlineData("1502400", "TO", "Castanhal", "PA")]
        [InlineData("1703057", "MA", "Bandeirantes do Tocantins", "TO")]
        [InlineData("2100204", "PI", "Alcântara", "MA")]
        [InlineData("2202000", "CE", "Buriti dos Lopes", "PI")]
        [InlineData("2302206", "RN", "Beberibe", "CE")]
        [InlineData("2401206", "PB", "Arês", "RN")]
        [InlineData("2505238", "PE", "Cuité de Mamanguape", "PB")]
        [InlineData("2601508", "AL", "Belém de Maria", "PE")]
        [InlineData("2700201", "PE", "Anadia", "AL")]
        [InlineData("2601607", "BA", "Belém do São Francisco", "PE")]
        [InlineData("2900207", "MG", "Abaré", "BA")]
        [InlineData("3109204", "XY", "Buenópolis", "MG")]
        public void AlterarEstadoLocalidadeComSucesso(string codigo, string estado, string cidade, string estadoNovo)
        {

        }


        [Theory]
        [InlineData("1100015", "RO", "Alta Floresta D''''Oeste")]
        [InlineData("1300409", "AM", "Barcelos")]
        [InlineData("1400506", "RR", "São João da Baliza")]
        [InlineData("1502400", "PA", "Castanhal")]
        [InlineData("1703057", "TO", "Bandeirantes do Tocantins")]
        [InlineData("2100204", "MA", "Alcântara")]
        [InlineData("2202000", "PI", "Buriti dos Lopes")]
        [InlineData("2302206", "CE", "Beberibe")]
        [InlineData("2401206", "RN", "Arês")]
        [InlineData("2505238", "PB", "Cuité de Mamanguape")]
        [InlineData("2601508", "PE", "Belém de Maria")]
        [InlineData("2601607", "PE", "Belém do São Francisco")]
        [InlineData("2700201", "AL", "Anadia")]
        [InlineData("2900207", "BA", "Abaré")]
        [InlineData("3109204", "MG", "Buenópolis")]
        public void RemoverLocalidadeComSucesso(string codigo, string estado, string cidade)
        {

        }
    }
}
