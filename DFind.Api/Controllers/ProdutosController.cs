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
            Regex ER = new Regex(algo, RegexOptions.IgnoreCase);
            var resultado = db.Produtos.Include("Categoria").ToList();
            var encontrados = new ArrayList();
            String[] tituloProdutos = new String[resultado.Count];

            for (int i = 0; i < resultado.Count; i++)
            {
                tituloProdutos[i] = resultado[i].Titulo;
            }


            for (int i = 0; i < tituloProdutos.Length; i++)
            {
                if (ER.IsMatch(tituloProdutos[i]))
                {
                    encontrados.Add(resultado[i]);
                }
                if (encontrados.Count == 5)
                {
                    i = tituloProdutos.Length;
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
            var consultas = db.Consulta.Include("Produto").Where(x => x.ProdutoId == produtoId).ToList();
            var produto = db.Produtos.Where(x => x.Id == produtoId).FirstOrDefault();
            
            Consulta MelhorConsulta = new Consulta();
            Consulta PiorConsulta = new Consulta();

            if (consultas == null || produto == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                int i = 0;
                foreach (Consulta c in consultas)
                {
                    c.PesquisarPreco();

                    if (i == 0)
                    {
                        MelhorConsulta = c;
                        PiorConsulta = c;
                    }
                    else
                    {
                        if (c.Resposta < MelhorConsulta.Resposta)
                        {
                            MelhorConsulta = c;
                        }
                        else if (c.Resposta > PiorConsulta.Resposta)
                        {
                            PiorConsulta = c;
                        }
                    }

                    db.Entry<Consulta>(c).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    i++;
                }

                produto.Economia = PiorConsulta.Resposta - MelhorConsulta.Resposta;
                produto.MelhorConsulta = MelhorConsulta.Id;
                produto.PiorConsulta = PiorConsulta.Id;
                db.Entry<Produto>(produto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                consultas = db.Consulta.Include("Produto").Where(x => x.ProdutoId == produtoId).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, consultas);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao tentar atualizar");
            }
        }

        [HttpGet]
        [Route("varredura/{dental}")]
        public HttpResponseMessage varreduraSpeed(string dental)
        {
            try
            {
                ArrayList arrayList = new ArrayList();
                if ( dental == "speed")
                {
                    Exe exe = new Exe();
                    exe.exeSpeed("https://dentalspeed.com/grupo/instrumento-de-alta-rotacao");
                    arrayList = exe.getArrayList();
                }
                else if (dental == "cremer")
                {
                    Exe exe = new Exe();
                    exe.exeCremer("https://www.dentalcremer.com.br/departamento/855347/acessorio-para-autoclave");
                    arrayList = exe.getArrayList();
                }
                foreach (Verificacao v in arrayList)
                {
                    
                    var res = db.Produtos.Where(x => x.Titulo == v.ProdutoNome).FirstOrDefault();
                    if (res != null)
                    {

                        var resultado = db.Consulta.Where(x => x.Site == v.Site).ToList();
                        if(resultado == null)
                        {
                            Consulta consulta = new Consulta();
                            consulta.ProdutoId = res.Id;
                            consulta.Site = v.Site;
                            consulta.Caminho = v.Caminho;
                            consulta.Descricao = v.Descricao;
                            consulta.Titulo = v.Titulo;

                            consulta.PesquisarPreco();

                            if (consulta.RespostaString != null)
                            {
                                db.Consulta.Add(consulta);
                                db.SaveChanges();
                            }
                        }
                    }
                    else
                    {
                        Produto produto = new Produto();
                        produto.Titulo = v.ProdutoNome;
                        produto.CategoriaId = 1;
                        produto.imagem = v.Imagem;
                        db.Produtos.Add(produto);
                        db.SaveChanges();
                        Consulta consulta = new Consulta();
                        consulta.ProdutoId = produto.Id;
                        consulta.Site = v.Site;
                        consulta.Caminho = v.Caminho;
                        consulta.Descricao = v.Descricao;
                        consulta.Titulo = v.Titulo;

                        consulta.PesquisarPreco();

                        if (consulta.RespostaString != null)
                        {
                            db.Consulta.Add(consulta);
                            db.SaveChanges();
                        }
                    }    
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"ok");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao add produto");
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

                if (consulta.RespostaString != null)
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