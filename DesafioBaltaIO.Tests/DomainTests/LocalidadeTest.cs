using DesafioBaltaIO.Domain.IBGE.Models;

namespace DesafioBaltaIO.Tests.DomainTests
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
        [InlineData("83B50A59-2F03-4CC2-B33C-2C6E5A9A56A7", "2023-01-01")]
        [InlineData("C1F4A182-781A-4BCE-AE2A-18AC647F672E", "2023-02-15")]
        [InlineData("D7C4D8F2-983F-4F8A-8CC3-A84A17212F22", "2023-03-20")]
        [InlineData("2B1AA9FF-DE89-4612-B1FD-8E7D4ED1C929", "2023-04-10")]
        [InlineData("78812BB2-CD02-4B44-9601-3B3EDC2D6B96", "2023-05-05")]
        [InlineData("FEC2C98C-6CC0-4A15-BB86-70B6D44C4F70", "2023-06-30")]
        [InlineData("E7E96052-CC0D-4D6E-814D-C2687A3FED00", "2023-07-25")]
        [InlineData("9ED9FA28-A18A-4B37-9A28-2E6A97966E8D", "2023-08-02")]
        [InlineData("536D825D-09F4-4E4F-82CB-9F58E27E8B72", "2023-09-19")]
        [InlineData("E9FD7D06-6A14-46B6-A21D-9A302B828963", "2023-10-11")]
        [InlineData("06750A24-ABAB-45F2-96E9-4BF5D14C62BE", "2023-11-03")]
        [InlineData("CD620854-41BB-42BB-8A45-DB8400F190F2", "2023-12-29")]
        [InlineData("5F2A3AE3-A3D3-4324-AF5F-75E7D6E5B3E6", "2023-06-15")]
        [InlineData("3D02A0B6-FCCB-4321-B248-2CCFA125B990", "2023-04-27")]
        [InlineData("28D70E26-54D1-4A38-A5E0-95A0143F3F8A", "2023-01-14")]
        public void AssociarCadastrante(string cadastradoPor, DateTime dataCadastro)
        {
            Guid cadastradoPorGuid;
            if (!Guid.TryParse(cadastradoPor, out cadastradoPorGuid))
                Assert.Fail($"Registro {cadastradoPor} nao e um guid");

            var cadastranteAssociado = Localidade.AssociarCadastrante(cadastradoPorGuid, dataCadastro);
            if (!cadastranteAssociado)
                if (DateTime.UtcNow.Ticks < dataCadastro.Ticks)
                    Assert.True(true);
                else
                    Assert.True(cadastranteAssociado);
        }
    }
}