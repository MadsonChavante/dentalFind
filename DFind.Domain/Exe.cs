using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DFind.Domain
{
    public static class Distance
    {
        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
        public static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
        public static int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            return distance[sourceWordCount, targetWordCount];
        }
        
    }
    public class Verificacao
    {
        public string Titulo;
        public string Site;
        public string Descricao;
        public string Caminho;
        public string ProdutoNome;
        public string Imagem;
    }
    public class Exe
    {
        ArrayList arrayList = new ArrayList();

        public ArrayList getArrayList()
        {
            return this.arrayList;
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
        public void exeCremer(string site)
        {
            try
            {
                var htmlDoc = StringToHtml(site);
                try
                {
                    if (htmlDoc.DocumentNode.SelectSingleNode("//*[@id='col-left']").GetAttributeValue("id", "erro") == "col-left")
                    {
                        if (htmlDoc.DocumentNode.SelectSingleNode("//*[@id='col-left']/nav[1]/ul/li/ul") != null)
                        {
                            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='col-left']/nav[1]/ul/li/ul/li");

                            foreach (var node in htmlNodes)
                            {
                                exeCremer(node.FirstChild.GetAttributeValue("href", "erro para pegar com count na lateral"));
                            }
                        }
                        else
                        {
                            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='divCaixaListagemdepartamentCollection']/div/div/div[2]/ul/li");
                            for (int i = 0; i < htmlNodes.Count; i++)
                            {
                                exeCremer(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='divCaixaListagemdepartamentCollection']/div/div/div[2]/ul/li[" + (i + 1) + "]/div/h3/a").GetAttributeValue("href", "erro para pegar o site no artigo familia"));
                            }
                        }
                    }
                }
                catch
                {

                    Console.WriteLine(htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-name']/h1").InnerHtml);
                    Console.WriteLine(htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-price-price']").InnerHtml);
                    string str = htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-shortDescription']").InnerHtml.ToString();
                    str = str.TrimStart();
                    Console.WriteLine(str);

                    Verificacao verificacao = new Verificacao();
                    verificacao.Caminho = "//*[@class='product-price-price']";
                    verificacao.Descricao = htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-shortDescription']").InnerHtml;
                    verificacao.Titulo = htmlDoc.DocumentNode.SelectSingleNode("/html/head/meta[13]").GetAttributeValue("content", "erro no modelo");
                    verificacao.Site = site;
                    verificacao.Imagem = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='imgPrincipalProduto']").GetAttributeValue("src", "erro na imagem do produto");


                    byte[] bytes = Encoding.Default.GetBytes(htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-name']/h1").InnerText.ToString());
                    string nome = Encoding.UTF8.GetString(bytes);

                    verificacao.ProdutoNome = nome;

                    this.arrayList.Add(verificacao);
                }
            }
            catch
            {
                Console.WriteLine(site);
            }

        }
        public void exeSpeed(string site)
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
                        exeSpeed(node.Descendants().ElementAt(1).Descendants().ElementAt(1).GetAttributeValue("href", "erro para pegar o site no artigo padrao"));
                    }
                }
                else if (htmlDoc.DocumentNode.SelectSingleNode("//article").Id == "familia")
                {
                    var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='lista-familia']/div");
                    for (int i = 0; i < htmlNodes.Count; i++)
                    {
                        exeSpeed(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='lista-familia']/div[" + (i + 1) + "]/div/div[1]/p/a").GetAttributeValue("href", "erro para pegar o site no artigo familia"));
                    }
                }
                else if (htmlDoc.DocumentNode.SelectSingleNode("//article").Id == "modelo")
                {
                    Verificacao verificacao = new Verificacao();
                    verificacao.Caminho = "//*[@id='mostra-valores']/span[2]/span[2]";
                    verificacao.Descricao = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/h2/p").InnerHtml;
                    verificacao.Titulo = htmlDoc.DocumentNode.SelectSingleNode("/html/head/meta[6]").GetAttributeValue("content", "erro no modelo");
                    verificacao.Site = site;
                    verificacao.Imagem = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/div/div/span[1]/img").GetAttributeValue("src", "erro na imagem do produto");
                    
                    string marca = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/span").InnerHtml;

                    byte[] bytes = Encoding.Default.GetBytes(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/h1").InnerText.ToString());
                    string nome  = Encoding.UTF8.GetString(bytes);

                    verificacao.ProdutoNome = nome +" - "+marca;

                    this.arrayList.Add(verificacao);
                }
            }
            catch
            {
                Console.WriteLine(site);
            }

        }
    }
}
