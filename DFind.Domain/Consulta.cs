using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace DFind.Domain
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string preco { get; set; }
        public string site { get; set; }    
        public string descricao { get; set; }
        public string caminho { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        

        public void PesquisarPreco()
        {
            try
            {
                HtmlDocument doc = new HtmlDocument();

                using (WebClient client = new WebClient())
                {
                    string html = client.DownloadString(this.site);
                    doc.LoadHtml(html);
                }

                //Titulo
                HtmlNode no = doc.DocumentNode.SelectSingleNode(this.caminho);
                this.preco = FormatarPreco(no.InnerText);
            }
            catch
            {
                this.preco = null;
            }
        }
        public string FormatarPreco(string str)
        {
            string test = str.Replace("&#82;&#36;32.25", "32,25").Replace("&#82;&#36;", "").Replace(" ","").Replace("R$","").Replace("noboletoÃ vista", "");
            decimal deci = Convert.ToDecimal(test);
            CultureInfo culturaBrasileira = new CultureInfo("pt-BR");
            return deci.ToString("C", culturaBrasileira);
        }
       
        


    }
}
