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
    public class ApiClienteFornecedorController : Controller
    {
        private readonly Contexto _contexto;


        public ApiClienteFornecedorController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("ObterPessoas")]
        public async Task<JsonResult> ObterPessoas()
        {
            try
            {
                var pessoas = await _contexto.ClienteFornecedor.ToListAsync();

                return Json(new { Sucesso = true, Pessoas = pessoas });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("GravarPessoa")]
        public async Task<JsonResult> GravarPessoa(ClienteFornecedor pessoa)
        {
            try
            {
                if (pessoa.Id != Guid.Empty)
                {
                    _contexto.AtualizarTudo(pessoa);
                }
                else
                {
                    _contexto.Add(pessoa);
                }

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true, Id = pessoa.Id });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("ExcluirPessoa")]
        public async Task<JsonResult> ExcluirPessoa(ClienteFornecedor tipo)
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
    }
}
