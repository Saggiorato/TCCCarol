using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using TccCarol.Dados;
using TccCarol.Dados.Configuracao;

namespace TccCarol.Api
{
    [Route("api/[controller]")]
    public class ApiProdutoController : Controller
    {
        private readonly Contexto _contexto;

        public ApiProdutoController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet("ObterProdutos")]
        public async Task<JsonResult> ObterProdutos(bool ingrediente)
        {
            try
            {
                var produtos = await _contexto.Produto.Where(x => x.Ingrediente == ingrediente).Include(x => x.Ingredientes).OrderBy(x => x.Nome).ToListAsync();

                return Json(new { Sucesso = true, Produtos = produtos });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("GravarProduto")]
        public async Task<JsonResult> GravarProduto(Produto produto)
        {
            try
            {
                if (produto.Id != Guid.Empty)
                {
                    _contexto.AtualizarTudo(produto);
                }
                else
                {
                    _contexto.Add(produto);
                }

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true, Id = produto.Id });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("ExcluirProduto")]
        public async Task<JsonResult> ExcluirProduto(Produto produto)
        {
            try
            {
                _contexto.Remove(produto);

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("GravarIngrediente")]
        public async Task<JsonResult> GravarIngrediente(IngredienteProduto ing)
        {
            try
            {
                ing.Ingrediente = null;
                _contexto.Add(ing);

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true, Id = ing.Id });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpPost("ExcluirIngrediente")]
        public async Task<JsonResult> ExcluirIngrediente(IngredienteProduto ing)
        {
            try
            {
                _contexto.Remove(ing);

                await _contexto.SaveChangesAsync();

                return Json(new { Sucesso = true });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpGet("ObterIngredientes")]
        public async Task<JsonResult> ObterIngredientes(Guid id)
        {
            try
            {
                var ingredientes = await _contexto.IngredienteProduto.Where(x => x.ProdutoId == id).Include(x => x.Ingrediente).ToListAsync();

                return Json(new { Sucesso = true, Ingredientes = ingredientes });
            }
            catch (Exception ex)
            {
                return Json(new { Sucesso = false, Erro = ex.InnerException?.Message ?? ex.Message });
            }
        }
    }
}
