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
            var resultado = db.Produtos.Include("Categoria").OrderByDescending(x => x.Economia).ToList();
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
            }

            return Request.CreateResponse(HttpStatusCode.OK, encontrados);
        }

        [HttpGet]
        [Route("sugestoes/{algo}")]
        public HttpResponseMessage sugestoesProdutos(string algo)
        {
            Regex ER = new Regex(algo, RegexOptions.IgnoreCase);
            var resultado = db.Produtos.Include("Categoria").OrderByDescending(x => x.Economia).ToList();
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

        [HttpGet]
        [Route("produtos/sugestoes")]
        public HttpResponseMessage sugestoesP()
        {
            var resultado = db.Produtos.OrderByDescending(x => x.Economia).ToList();
            var encontrados = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                
                encontrados.Add(resultado[i]);
               
            }

            return Request.CreateResponse(HttpStatusCode.OK, encontrados);
        }

        [Route("produtos")]
        public HttpResponseMessage GetProdutos()
        {
            var resultado = db.Produtos.ToList();
            ArrayList arrayList = new ArrayList();
            foreach(Produto p in resultado)
            {
                arrayList.Add(p.Id);
            }
            return Request.CreateResponse(HttpStatusCode.OK, arrayList);
        }

        [Route("produtos/{produtoId}")]
        public HttpResponseMessage GetProduto(int produtoId)
        {
            var resultado = db.Produtos.Include("Categoria").Where(x => x.Id == produtoId);
            Produto p = resultado.First();

            return Request.CreateResponse(HttpStatusCode.OK, resultado);
        }

        [Route("consulta/{consultaId}")]
        public HttpResponseMessage Getconsulta(int consultaId)
        {
            var resultado = db.Consulta.Where(x => x.Id == consultaId).FirstOrDefault();
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
                
                foreach (Consulta c in consultas)
                {
                    var iguais = consultas.Where(x => x.Site == c.Site).ToList();
                    if (iguais.Count > 1)
                    {
                        try
                        {
                            for (int x = 1; x < iguais.Count; x++)
                            {
                                db.Consulta.Remove(iguais[x]);
                            }
                        }
                        catch
                        {

                        }
                        db.SaveChanges();
                    }
                }
                
                int i = 0;
                consultas = db.Consulta.Include("Produto").Where(x => x.ProdutoId == produtoId).ToList();
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
        [Route("varredura")]
        public HttpResponseMessage varredura()
        {
            try
            {


                ArrayList arrayList = new ArrayList();
                Exe exe = new Exe();
                exe.clearArrayList();
                exe.exeSpeed("https://dentalspeed.com/grupo/motor-p-endodontia");
                //exe.exeCremer("https://www.dentalcremer.com.br/departamento/854748/motor-para-clinica");
                arrayList = exe.getArrayList();
                int categoriaId = 4;
                
                foreach (Verificacao v in arrayList)
                {

                    var produtos = db.Produtos.ToArray();
                    Produto res = null;
                    for(int i = 0; i < produtos.Length; i++)
                    {
                        Produto p = produtos[i];
                        if (Distance.Similarity(p.Titulo, v.ProdutoNome))
                        {
                            res = p;
                            i = produtos.Length;
                        }
                    }

                    if (res != null)
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
                        }
                        
                    }
                    else
                    {
                        Produto produto = new Produto();
                        produto.Titulo = Distance.RemoveAdjetivoCor(v.ProdutoNome);
                        produto.CategoriaId = categoriaId;
                        produto.imagem = v.Imagem;
                        db.Produtos.Add(produto);

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
                            produto.Economia = 0;
                            produto.MelhorConsulta = consulta.Id;
                            produto.PiorConsulta = consulta.Id;
                        }
                        db.Produtos.Add(produto);

                    }

                    db.SaveChanges();
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


        [HttpPost]
        [Route("categoria")]
        public HttpResponseMessage PostCategoria(Categoria categoria)
        {
            if (categoria == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();

                var result = categoria;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao add consulta");
            }
        }


        [HttpDelete]
        [Route("categoria")]
        public HttpResponseMessage deleteCategoria(int categoriaId)
        {
            if (categoriaId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Produtos.Remove(db.Produtos.Find(categoriaId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "produto deletado");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao deletar o produto");
            }
        }
        [HttpPut]
        [Route("categoria")]
        public HttpResponseMessage putCategoria(Categoria categoria)
        {
            if (categoria == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            try
            {
                db.Entry<Categoria>(categoria).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = categoria;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "falha ao atualizar produto");
            }
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}