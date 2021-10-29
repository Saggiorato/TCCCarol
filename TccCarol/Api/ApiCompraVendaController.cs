using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TccCarol.Dados;
using TccCarol.Dados.Configuracao;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TccCarol.Api
{
    [Route("api/[controller]")]
    public class ApiCompraVendaController : Controller
    {
        private readonly Contexto _contexto;

        public ApiCompraVendaController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("ObterHistorico")]
        public async Task<JsonResult> ObterHistorico()
        {
            try
            {
                var compraVenda = await _contexto.HistoricoCompraVenda.Include(x => x.Produto).Include(x => x.ClienteFornecedor).OrderBy(x => x.Data).ToListAsync();

                foreach (var item in compraVenda)
                {
                    if (item.ClienteFornecedor != null)
                    {
                        item.ClienteFornecedor.HistoricosCompraVenda = null;
                    }

                    if (item.Produto != null)
                    {
                        item.Produto.HistoricosCompraVenda = null;
                    }
                   

                }

                return Json(new { Sucesso = true, CompraVenda = compraVenda });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("GravarCompraVenda")]
        public async Task<JsonResult> GravarCompraVenda(HistoricoCompraVenda historico)
        {
            try
            {
                if (historico.Id != Guid.Empty)
                {
                    _contexto.AtualizarTudo(historico);
                }
                else
                {
                    _contexto.Add(historico);
                }

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true, Id = historico.Id });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("ExcluirHistorico")]
        public async Task<JsonResult> ExcluirHistorico(HistoricoCompraVenda historico)
        {
            try
            {
                _contexto.Remove(historico);

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }
    }
}
