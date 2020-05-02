using ApiLojaSemMessageBroker.INFRA;
using ApiLojaSemMessageBroker.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLojaSemMessageBroker.Repositorio
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private readonly IDB _DB;

        public PedidoRepositorio(IDB DB)
        {
            _DB = DB;
        }

        public void EfetuarPedido(Pedido pedido)
        {
           using(var db = _DB.GetDb())
            {
                db.Execute("INSERT INTO Pedido (Id,Nome,Quantidade,Valor) values " +
                    "(@Id, @Nome, @Quantidade, @Valor)",
                    new {@Id = pedido.Id,
                        @Nome = pedido.Nome,
                        @Quantidade = pedido.Quantidade,
                        @Valor = pedido.Valor});
            }
        }
    }
}
