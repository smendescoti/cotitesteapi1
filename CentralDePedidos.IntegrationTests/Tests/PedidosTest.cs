using Bogus;
using Bogus.Extensions.Brazil;
using CentralDePedidos.Application.Commands;
using CentralDePedidos.IntegrationTests.Helpers;
using CentralDePedidos.IntegrationTests.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CentralDePedidos.IntegrationTests.Tests
{
    public class PedidosTest
    {
        [Fact]
        public async Task Test_Post_Pedidos_Returns_Created()
        {
            var faker = new Faker("pt_BR");

            var command = new PedidoCreateCommand
            {
                Valor = decimal.Parse(faker.Commerce.Price()),
                Cliente = new ClienteCreateCommand
                {
                    Nome = faker.Person.FullName,
                    Email = faker.Person.Email,
                    Cpf = faker.Person.Cpf(),
                    Telefone = faker.Person.Phone,
                    Endereco = faker.Address.FullAddress(),
                    Bairro = faker.Address.City(),
                    Cidade = faker.Address.City(),
                    Uf = faker.Address.CitySuffix(),
                    Complemento = faker.Address.StateAbbr(),
                    Numero = faker.Random.Number().ToString(),
                    Cep = faker.Address.ZipCode()
                },
                Produtos = new List<ProdutoCreateCommand>()
                {
                    new ProdutoCreateCommand
                    {
                        Nome = faker.Commerce.ProductName(),
                        Preco = decimal.Parse(faker.Commerce.Price()),
                        Quantidade = faker.Random.Number()
                    },
                    new ProdutoCreateCommand
                    {
                        Nome = faker.Commerce.ProductName(),
                        Preco = decimal.Parse(faker.Commerce.Price()),
                        Quantidade = faker.Random.Number()
                    }
                },
                Cobranca = new CobrancaCreateCommand
                {
                    NumeroCartao = faker.Finance.CreditCardNumber(),
                    CodigoSeguranca = int.Parse(faker.Finance.CreditCardCvv()),
                    Valor = decimal.Parse(faker.Commerce.Price()),
                    NomeImpressoNoCartao = faker.Person.FullName,
                    MesValidade = faker.Date.Future().Month,
                    AnoValidade = faker.Date.Future().Year
                }
            };

            var content = TestHelper.CreateContent(command);
            var result = await TestHelper.CreateClient.PostAsync("api/pedidos", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            var response = TestHelper.ReadContent<PedidoResultModel>(result);

            response.Message.Should().Be("Pedido realizado com sucesso.");
            response.Pedido.Should().NotBeNull();
        }
    }
}
