using System;
using System.Xml;
using System.Linq;
using HtmlAgilityPack;
using System.Globalization;
using System.Net;

public class Program
{
	//public static void Main()
	//{
		//exe("https://dentalspeed.com/segmento/pecas-de-mao");
		//exe("https://dentalspeed.com/area/uso-continuo");
	//}
	public static HtmlDocument StringToHtml(string site){
	
		HtmlDocument htmlDoc = new HtmlDocument();
			
		using (WebClient client = new WebClient())
		{
			string html = client.DownloadString(site);
			htmlDoc.LoadHtml(html);
		}
		return htmlDoc;
	}
	public static void exe( string site){
		try
		{	
			var htmlDoc = StringToHtml(site);
			if(htmlDoc.DocumentNode.SelectSingleNode("//article").Id == "article_default"){
				var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//article");
				if(htmlDoc.DocumentNode.SelectSingleNode("//article/div").GetAttributeValue("class","erro") == "lista-result-busca"){
					htmlNodes = htmlDoc.DocumentNode.SelectNodes("//article/div[@class='lista-result-busca']/div");
				}else{
					htmlNodes = htmlDoc.DocumentNode.SelectNodes("//article/div[@class='lista-result-busca col-xs-24']/div");	
				}
				foreach (var node in htmlNodes)
				{
					exe(node.Descendants().ElementAt(1).Descendants().ElementAt(1).GetAttributeValue("href","erro para pegar o site no artigo padrao"));
				//for(var i = 0;i<htmlNodes.Count();i++){
					//c++;
					//htmlNodes.ElementAt(i);
				//}
				//if(node.Descendants().ElementAt(1).Descendants().ElementAt(1).GetAttributeValue("href",false)){
					
				
				//Console.WriteLine(htmlNodes.Count());
				}
			}else if(htmlDoc.DocumentNode.SelectSingleNode("//article").Id == "familia"){
				var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='lista-familia']/div");
                for (int i = 0; i < htmlNodes.Count; i++)
                {
                    exe(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='lista-familia']/div["+(i+1)+"]/div/div[1]/p/a").GetAttributeValue("href","erro para pegar o site no artigo familia"));
                }
			}else if(htmlDoc.DocumentNode.SelectSingleNode("//article").Id == "modelo"){
				var htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/h1").InnerHtml;
				Console.WriteLine(htmlNodes);
                htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/span").InnerHtml;
				Console.WriteLine(htmlNodes);
                htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='mostra-valores']/span[2]/span[2]").GetAttributeValue("content","erro no modelo");
				Console.WriteLine(htmlNodes);
				htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("/html/head/meta[6]").GetAttributeValue("content","erro no modelo");
				Console.WriteLine(htmlNodes);
				htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/h2/p").InnerHtml;
				htmlNodes = htmlDoc.DocumentNode.SelectSingleNode("//*[@id='modelo-vitrine']/div[1]/div/div/span[1]/img").GetAttributeValue("src", "erro na imagem do produto");
				Console.WriteLine(htmlNodes);
			}
			
			//if()
			
		}
		catch
		{
			Console.WriteLine(site);
		}
		
	}
		
		
}