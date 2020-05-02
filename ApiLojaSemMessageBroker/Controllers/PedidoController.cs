using System;
using System.Data.SqlClient;
using ApiLojaSemMessageBroker.INFRA;
using ApiLojaSemMessageBroker.Models;
using ApiLojaSemMessageBroker.Repositorio;
using KissLog;
using Microsoft.AspNetCore.Mvc;

namespace ApiLojaSemMessageBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger _logger;
        PedidoRepositorio PedidoRepositorio = new PedidoRepositorio(new MSSQLDB());

        public PedidoController(ILogger logger)
        {
            _logger = logger;
        }

        public IActionResult Adicionar(Pedido pedido)
        {
            try
            {
               PedidoRepositorio.EfetuarPedido(pedido);
                _logger.Info($"Pedido efetuado com sucesso. ID{pedido.Id} Data={DateTime.Now}");

                return Accepted(200);
            }catch(Exception Erro)
            {
                if(Erro is SqlException)               
                    _logger.Error($"Erro ao gravar pedido no Banco de Dados. ID = {pedido.Id} Data{DateTime.Now}");
                else
                    _logger.Error($"Erro ao gravar pedido. ID = {pedido.Id} Data{DateTime.Now}");

                return new StatusCodeResult(500);
            }
        }
    }
}