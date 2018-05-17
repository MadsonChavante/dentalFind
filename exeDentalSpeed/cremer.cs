using System.Linq;
using HtmlAgilityPack;
using System.Globalization;
using System.Net; 
using System;

public class cremer
{
    public static void Main()
    {
        //Console.WriteLine(getTitulo("https://dentalspeed.com/area/uso-continuo"));
        exe("https://www.dentalcremer.com.br/departamento/854716/perifericos-e-pecas-de-mao");
        //exe("https://dentalspeed.com/area/uso-continuo");
    }
    public static HtmlDocument StringToHtml(string site)
    {

        HtmlDocument htmlDoc = new HtmlDocument();

        using (WebClient client = new WebClient())
        {
            string html = client.DownloadString(site);
            htmlDoc.LoadHtml(html);
        }
        return htmlDoc;
    }
    public static void exe(string site)
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
                            exe(node.FirstChild.GetAttributeValue("href", "erro para pegar com count na lateral"));
                        }
                    }
                    else
                    {
                        var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//*[@id='divCaixaListagemdepartamentCollection']/div/div/div[2]/ul/li");
                        for (int i = 0; i < htmlNodes.Count; i++)
                        {
                            exe(htmlDoc.DocumentNode.SelectSingleNode("//*[@id='divCaixaListagemdepartamentCollection']/div/div/div[2]/ul/li[" + (i + 1) + "]/div/h3/a").GetAttributeValue("href", "erro para pegar o site no artigo familia"));
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine(htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-price-price']").InnerHtml);
            }
        }
        catch
        {
            Console.WriteLine(site);
        }

    }


}