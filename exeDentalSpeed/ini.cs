using System.Linq;
using HtmlAgilityPack;
using System.Globalization;
using System.Net;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public static class ini
{
    public static void Main()
	{
		//exe("https://dentalspeed.com/segmento/pecas-de-mao");
		exe();
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
  public static int[] collection = new int[] { 
2771,
  2772,
  2773,
  2774,
  2775,
  2776,
  2854,
  2855,
  2856,
  2857,
  2858,
  2859,
  2860,
  2861,
  2862,
  2863,
  2864,
  2865,
  2866,
  2867,
  2868,
  2869,
  2870,
  2871,
  2872,
  2873,
  2874,
  2875,
  2876,
  2877,
  2878,
  2879,
  2880,
  2881,
  2882,
  2883,
  2884,
  2885,
  2886,
  2887,
  2888,
  2889,
  2890,
  2891,
  2892,
  2952,
  2953,
  2954,
  2955,
  2956,
  2957,
  2958,
  2959};
    public static void exe()
    {
        try
        {
            
            
            try
            {
                foreach (var item in collection)
                {
                    var htmlDoc = StringToHtml("http://localhost:18612/produtos/" + item + "/consultas");
                    
                    Console.WriteLine(item);
                }
            }
            catch
            {

            }
        }
        catch
        {
            Console.WriteLine("erro");
        }

    }


}