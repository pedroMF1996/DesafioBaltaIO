using DesafioBaltaIO.Domain.IBGE.Models;

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

        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        [InlineData("f47ac10b-58cc-4372-a567-0e02b2c3d479")]
        [InlineData("6f3dbda5-6366-4fc7-b9f3-1312a23d0b4b")]
        [InlineData("a5a913cc-9b3d-4c19-8d12-7f6f9e8bca54")]
        [InlineData("d5872479-61c1-4755-a1a3-4e77d7e4b04e")]
        [InlineData("9a3db232-5a0d-4859-9b34-9c2d4a5bfe5c")]
        [InlineData("cf6ffde0-25a6-4f76-81e0-8c746a146d0f")]
        [InlineData("7c547baf-76d7-482e-8bea-9d14df2ea83c")]
        [InlineData("21cf00d7-e729-4f97-a109-14d4eb7a1632")]
        [InlineData("be8d1c3d-9f0a-4583-a9a3-3d7a82dbdf7e")]
        [InlineData("3d7a82db-d7e4-4a9a-9834-9a0f-d3c1d8e8eb21")]
        [InlineData("789bcdf2-3b4a-4fa7-8e0d-8ddae9229905")]
        [InlineData("c1c1c1c1-c1c1-4c1c-c1c1-c1c1c1c1c1c1")]
        [InlineData("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")]
        [InlineData("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")]
        public void AssociarCadastranteComSucesso(string cadastradoPor)
        {
            Guid cadastradoPorGuid;
            if (!Guid.TryParse(cadastradoPor, out cadastradoPorGuid))
                Assert.Fail($"Registro {cadastradoPor} nao e um guid");

            Assert.True(Localidade.AssociarCadastrante(cadastradoPorGuid));
        }
    }
}