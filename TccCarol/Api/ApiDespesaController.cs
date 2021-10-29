using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TccCarol.Dados;
using TccCarol.Dados.Configuracao;

namespace TccCarol.Api
{
    [Route("api/[controller]")]
    public class ApiDespesaController : Controller
    {
        private readonly Contexto _contexto;

        public ApiDespesaController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("ObterDespesas")]
        public async Task<JsonResult> ObterDespesas()
        {
            try
            {
                var despesas = await _contexto.HistoricoDespesa.Include(x => x.TipoDespesa).ToListAsync();

                return Json(new { Sucesso = true, Despesas = despesas });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("GravarDespesa")]
        public async Task<JsonResult> GravarDespesas(HistoricoDespesa despesa)
        {
            try
            {
                despesa.TipoDespesa = null;

                if (despesa.Id != Guid.Empty)
                {
                    _contexto.AtualizarTudo(despesa);
                }
                else
                {
                    _contexto.Add(despesa);
                }

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true, Id = despesa.Id });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("ExcluirDespesa")]
        public async Task<JsonResult> ExcluirDespesa(HistoricoDespesa despesa)
        {
            try
            {
                _contexto.Remove(despesa);

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpGet("ObterTiposDespesas")]
        public async Task<JsonResult> ObterTiposDespesas()
        {
            try
            {
                var tipos = await _contexto.TipoDespesa.ToListAsync();

                return Json(new { Sucesso = true, TiposDespesas = tipos });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("GravarTiposDespesas")]
        public async Task<JsonResult> GravarTiposDespesas(TipoDespesa tipo)
        {
            try
            {
                if (tipo.Id != Guid.Empty)
                {
                    _contexto.AtualizarTudo(tipo);
                }
                else
                {
                    _contexto.Add(tipo);
                }

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true, Id = tipo.Id });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("ExcluirTipoDespesa")]
        public async Task<JsonResult> ExcluirTipoDespesa(TipoDespesa tipo)
        {
            try
            {
                _contexto.Remove(tipo);

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("ObterDespesasGrafico")]
        public async Task<JsonResult> ObterDespesasGrafico(Filtro filtro)
        {
            try
            {
                if (filtro.DataFinal == DateTime.MinValue) filtro.DataFinal = DateTime.Now;
                filtro.DataFinal.AddHours(23).AddMinutes(59).AddSeconds(59);

                var despesas = await _contexto.HistoricoDespesa
                    .Where(x => x.Data >= filtro.DataInicial && x.Data <= filtro.DataFinal && !x.Porcentagem)
                    .Include(x => x.TipoDespesa).ToListAsync();

                var lista = new GraficoDespesasViewModel()
                {
                    Nome = new List<string>(),
                    Porcentagem = new List<decimal>()
                };

                var somaTotal = despesas.Sum(x => x.Valor);

                var despesasUnicas = despesas.GroupBy(x => x.TipoDespesaId).Select(x => new
                {
                    Valor = x.Sum(i => i.Valor),
                    Nome = x.FirstOrDefault().TipoDespesa.Descricao
                });

                foreach (var item in despesasUnicas)
                {
                    lista.Nome.Add(item.Nome);
                    lista.Porcentagem.Add(RegraTresPorcentagem(somaTotal, item.Valor));
                }

                return Json(new { Sucesso = true, Despesas = lista });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        private decimal RegraTresPorcentagem(decimal total, decimal parte)
        {
            return Math.Round((parte * 100) / total, 2);
        }
    }

    public class GraficoDespesasViewModel
    {
        public List<string> Nome { get; set; }

        public List<decimal> Porcentagem { get; set; }
    }
}
