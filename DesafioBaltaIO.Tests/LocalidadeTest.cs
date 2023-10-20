using DesafioBaltaIO.Domain.Models.IBGE;

namespace DesafioBaltaIO.Tests
{
    public class LocalidadeTest
    {
        public LocalidadeModel Localidade { get; } = new LocalidadeModel("1100012", "XY", "cidade origem");

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
        public void InstanciarLocalidadeComSucesso(string codigo, string estado, string cidade)
        {
            Assert.True(new LocalidadeModel(codigo, estado, cidade).IsValid());
        }


        [Theory]
        [InlineData("RO", "1100015", "Alta Floresta D''''Oeste")]
        [InlineData("Barcelos", "AM", "1300409")]
        [InlineData("1400506", "São João da Baliza", "RR")]
        [InlineData("Castanhal", "PA", "1502400")]
        [InlineData("1703057", "Bandeirantes do Tocantins", "TO")]
        [InlineData("Alcântara", "MA", "2100204")]
        [InlineData("2202000", "Buriti dos Lopes", "PI")]
        [InlineData("Beberibe", "CE", "2302206")]
        public void InstanciarLocalidadeSemSucesso(string codigo, string estado, string cidade)
        {
            Assert.False(new LocalidadeModel(codigo, estado, cidade).IsValid());
        }


        [Theory]
        [InlineData("Alta Floresta D''''Oeste")]
        [InlineData("Barcelos")]
        [InlineData("São João da Baliza")]
        [InlineData("Castanhal")]
        [InlineData("Bandeirantes do Tocantins")]
        [InlineData("Alcântara")]
        [InlineData("Buriti dos Lopes")]
        [InlineData("Beberibe")]
        [InlineData("Arês")]
        [InlineData("Cuité de Mamanguape")]
        [InlineData("Belém de Maria")]
        [InlineData("Belém do São Francisco")]
        [InlineData("Anadia")]
        [InlineData("Abaré")]
        [InlineData("Buenópolis")]
        public void AlterarCidadeComSucesso(string cidade)
        {
            Assert.True(Localidade.AlterarCidade(cidade));
        }

        [Theory]
        [InlineData("RO")]
        [InlineData("AM")]
        [InlineData("RR")]
        [InlineData("PA")]
        [InlineData("TO")]
        [InlineData("MA")]
        [InlineData("PI")]
        [InlineData("CE")]
        [InlineData("RN")]
        [InlineData("PB")]
        [InlineData("PE")]
        [InlineData("AL")]
        [InlineData("BA")]
        [InlineData("MG")]
        public void AlterarEstadoComSucesso(string estado)
        {
            Assert.True(Localidade.AlterarEstado(estado));
        }

        [Theory]
        [InlineData("1100015")]
        [InlineData("1300409")]
        [InlineData("1400506")]
        [InlineData("1502400")]
        [InlineData("1703057")]
        [InlineData("2100204")]
        [InlineData("2202000")]
        [InlineData("2302206")]
        [InlineData("2401206")]
        [InlineData("2505238")]
        [InlineData("2601508")]
        [InlineData("2601607")]
        [InlineData("2700201")]
        [InlineData("2900207")]
        [InlineData("3109204")]
        public void AlterarCodigoComSucesso(string codigo)
        {
            Assert.True(Localidade.AlterarCodigo(codigo));
        }
    }
}