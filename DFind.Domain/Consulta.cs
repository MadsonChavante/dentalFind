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
        
        public decimal Resposta { get; set; }

        public string RespostaString { get; set; }
        public string Site { get; set; }    
        public string Descricao { get; set; }
        public string Caminho { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        

        public void PesquisarPreco()
        {
            try
            {
                HtmlDocument doc = new HtmlDocument();

                using (WebClient client = new WebClient())
                {
                    string html = client.DownloadString(this.Site);
                    doc.LoadHtml(html);
                }

                //Titulo
                HtmlNode no = doc.DocumentNode.SelectSingleNode(this.Caminho);
                FormatarPreco(no.InnerText);
            }
            catch
            {
                this.RespostaString = null;
            }
        }
        public void FormatarPreco(string str)
        {
            string test = str.Replace("&#82;&#36;32.25", "32,25").Replace("&#82;&#36;", "").Replace(" ","").Replace("R$","").Replace("noboletoÃ vista", "");
            decimal deci = Convert.ToDecimal(test);
            this.Resposta = deci;
            CultureInfo culturaBrasileira = new CultureInfo("pt-BR");
            this.RespostaString = deci.ToString("C", culturaBrasileira);
        }

    }
}
