using System.Linq;
using HtmlAgilityPack;
using System.Globalization;
using System.Net; 
using System;
using System.Text;

public static class cremer
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
            
            source = RemoveAccents(source);
            target = RemoveAccents(target);
            source = source.ToUpper();
            target = target.ToUpper();
            
            source = source.Replace(" ", "").Replace("-", "");
            target = target.Replace(" ", "").Replace("-", "");

            Console.WriteLine(source);
            Console.WriteLine(target);            

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
                Console.WriteLine(htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-name']/h1").InnerHtml);
                Console.WriteLine(htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-price-price']").InnerHtml);
                string str =  htmlDoc.DocumentNode.SelectSingleNode("//*[@class='product-shortDescription']").InnerHtml.ToString();
                str = str.TrimStart();
                Console.WriteLine(str);
                str = htmlDoc.DocumentNode.SelectSingleNode("//*[@rel='canonical']").GetAttributeValue("href","erro no modelo").ToString();
                str = str.TrimStart();
                Console.WriteLine(str);
            }
        }
        catch
        {
            Console.WriteLine(site);
        }

    }


}