using DFind.Domain;
using DFind.Infra.DataContexts;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DFind.Api.Controllers
{
    //[EnableCors("AllowSpecificOrigin")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProdutosController : ApiController
    {
        private DFindDataContext db = new DFindDataContext();

        [HttpGet]
        [Route("pesquisar/{algo}")]
        public HttpResponseMessage pesquisarProdutos(string algo)
        {
            Regex ER = new Regex(algo, RegexOptions.None);
            var resultado = db.Produtos.Include("Categoria").ToList();
            var encontrados = new ArrayList();
            String[] tituloProdutos = new String[resultado.Count];
            
            for (int i = 0; i < resultado.Count; i++)
            {
                tituloProdutos[i] = resultado[i].Titulo;
            }
            
            Console.WriteLine(resultado.Count);

            for (int i = 0; i < tituloProdutos.Length; i++)
            {
                if (ER.IsMatch(tituloProdutos[i]))
                {
                    encontrados.Add(resultado[i]);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, encontrados);
        }

        [Route("produtos")]
        public HttpResponseMessage GetProdutos()
        {
            var resultado = db.Produtos.Include("Categoria").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [Route("produtos/{produtoId}")]
        public HttpResponseMessage GetProduto(int produtoId)
        {
            var resultado = db.Produtos.Include("Categoria").Where(x => x.Id == produtoId);
            Produto p = resultado.First();
            
            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [Route("categorias")]
        public HttpResponseMessage GetCategorias()
        {
            var resultado = db.Categorias.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [Route("categorias/{categoriaId}/produtos")]
        public HttpResponseMessage GetProdutosDaCategoria(int categoriaId)
        {
            var resultado = db.Produtos.Include("Categoria").Where(x => x.CategoriaId == categoriaId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [Route("produtos/{produtoId}/consultas")]
        public HttpResponseMessage GetConsultasDoProduto(int produtoId)
        {
            var resultado = db.Consulta.Include("Produto").Where(x => x.ProdutoId == produtoId).ToList();
            if (resultado == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                foreach (Consulta c in resultado)
                {
                    c.PesquisarPreco();
                    db.Entry<Consulta>(c).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                resultado = db.Consulta.Include("Produto").Where(x => x.ProdutoId == produtoId).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, resultado);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao tentar atualizar");
            }
        }

        [HttpPost]
        [Route("produto")]
        public HttpResponseMessage PostProduto(Produto produto)
        {
            if (produto == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Produtos.Add(produto);
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao add produto");
            }
        }

        [HttpDelete]
        [Route("produto")]
        public HttpResponseMessage deleteProduto(int produtoId)
        {
            if (produtoId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Produtos.Remove(db.Produtos.Find(produtoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "produto deletado");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao deletar o produto");
            }
        }

        [HttpPut]
        [Route("produto")]
        public HttpResponseMessage putProduto(Produto produto)
        {
            if (produto == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Entry<Produto>(produto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao atualizar produto");
            }
        }

        [HttpPost]
        [Route("consulta")]
        public HttpResponseMessage PostConsulta(Consulta consulta)
        {
            if (consulta == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                consulta.PesquisarPreco();

                if (consulta.preco != null)
                {
                    db.Consulta.Add(consulta);
                    db.SaveChanges();

                    var result = consulta;
                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao consultar o preço");
                }


            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao add consulta");
            }
        }

        [HttpDelete]
        [Route("consulta")]
        public HttpResponseMessage deleteConsulta(int consultaId)
        {
            if (consultaId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Consulta.Remove(db.Consulta.Find(consultaId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "consulta deletada");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao deletar a consulta");
            }
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}