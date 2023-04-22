using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDePedidos.Application.Commands
{
    public class PedidoCreateCommand
    {
        public decimal? Valor { get; set; }
        public ClienteCreateCommand? Cliente { get; set; }
        public CobrancaCreateCommand? Cobranca { get; set; }
        public List<ProdutoCreateCommand>? Produtos { get; set; }
    }

    public class ClienteCreateCommand
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Endereco { get; set; }
        public string? Complemento { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
        public string? Cep { get; set; }
    }

    public class CobrancaCreateCommand
    {
        public string? NumeroCartao { get; set; }
        public string? NomeImpressoNoCartao { get; set; }
        public int? MesValidade { get; set; }
        public int? AnoValidade { get; set; }
        public int? CodigoSeguranca { get; set; }
        public decimal? Valor { get; set; }
    }

    public class ProdutoCreateCommand
    {
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
    }
}
