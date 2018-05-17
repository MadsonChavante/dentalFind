using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DFind.Domain
{
    public class Verificacao
    {
        public string Titulo;
        public string site;
        public string descricao;
        public string caminho;
        public string ProdutoNome;
        public string Imagem;
    }
    public class ExeSpeed
    {
        ArrayList dentalSpeed = new ArrayList();
        
        public ArrayList getDentalSpeed()
        {
            return this.dentalSpeed;
        }
        public HtmlDocument StringToHtml(string site)
        {
            HtmlDocument htmlDoc = new HtmlDocument();

            using (WebClient client = new WebClient())
            {
                string html = client.DownloadString(site);
                htmlDoc.LoadHtml(html);
            }
            return htmlDoc;
        }
        public void exe(string site)
        {
            try
            {
                var htmlDoc = StringToHtml(site);
                if (htmlDoc.DocumentNode.SelectSingleNode("//article").Id == "article_default")
                {
                    var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//article");
                    if (htmlDoc.DocumentNode.SelectSingleNode("//article/div").GetAttributeValue("class", "erro") == "lista-result-busca")
                    {
                        htmlNodes = htmlDoc.DocumentNode.SelectNodes("//article/div[@class='lista-result-busca']/div");
                    }
                    else
                    {
                        htmlNodes = htmlDoc.DocumentNode.SelectNodes("//article/div[@class='lista-result-busca col-xs-24']/div");
                    }
                    foreach (var node in htmlNodes)
                    {
                        exe(node.Descendants().ElementAt(1).Descendants().ElementAt(1).GetAttributeValue("href", "erro para pegar o site no artigo padrao"));
                    }
                }
                else if (htmlDoc.DocumentNode.SelectSingleNode("//article").Id == "familia")
                {
                    var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='lista-familia']/div");
                    for (int i = 0; i < htmlNodes.Count; i++)
                    {
                        exe(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='lista-familia']/div[" + (i + 1) + "]/div/div[1]/p/a").GetAttributeValue("href", "erro para pegar o site no artigo familia"));
                    }
                }
                else if (htmlDoc.DocumentNode.SelectSingleNode("//article").Id == "modelo")
                {
                    Verificacao verificacao = new Verificacao();
                    verificacao.caminho = "//*[@id='mostra-valores']/span[2]/span[2]";
                    verificacao.descricao = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/h2/p").InnerHtml;
                    verificacao.Titulo = htmlDoc.DocumentNode.SelectSingleNode("/html/head/meta[6]").GetAttributeValue("content", "erro no modelo");
                    verificacao.site = site;
                    verificacao.Imagem = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/div/div/span[1]/img").GetAttributeValue("src", "erro na imagem do produto");
                    
                    string marca = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/span").InnerHtml;

                    byte[] bytes = Encoding.Default.GetBytes(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/h1").InnerText.ToString());
                    string nome  = Encoding.UTF8.GetString(bytes);

                    verificacao.ProdutoNome = nome +" - "+marca;

                    this.dentalSpeed.Add(verificacao);
                }
            }
            catch
            {
                Console.WriteLine(site);
            }

        }
        private string UnicodeToUTF8(string strFrom)
        {
            byte[] bytSrc;
            byte[] bytDestination;
            string strTo = String.Empty;

            bytSrc = Encoding.Unicode.GetBytes(strFrom);
            bytDestination = Encoding.Convert(Encoding.Unicode, Encoding.ASCII, bytSrc);
            strTo = Encoding.ASCII.GetString(bytDestination);

            return strTo;
        }
    }
}
