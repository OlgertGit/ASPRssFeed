using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace ASPRssFeed
{
public partial class PageContent : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "Content";
            RssFeeds();
        }
    }

    private void RssFeeds()
    {
        string RssFeedUrl = "https://flipboard.com/@raimoseero/feed-nii8kd0sz?rss";
        List<Feeds> feedsList = new List<Feeds>();

        try
        {
            XDocument xDoc = new XDocument();
            xDoc = XDocument.Load(RssFeedUrl);
            XNamespace media = XNamespace.Get("http://search.yahoo.com/mrss/");

            var elements = (from x in xDoc.Descendants("item")
                            select new
            {
                title = x.Element("title").Value,
                link = x.Element("link").Value,
            });

            if (elements != null)
            {
                foreach (var i in elements)
                {
                    Feeds feeds = new Feeds
                    {
                        Title = i.title,
                        Link = i.link,
                    };

                    HttpWebRequest GETRequest = (HttpWebRequest)WebRequest.Create("https://mercury.postlight.com/parser?url=" + feeds.Link);
                    GETRequest.Method = "GET";
                    GETRequest.ContentType = "application/json";
                    GETRequest.Headers.Add("x-api-key", "4uaoznF1Cbqj6jQErtZnEhf1bCPfqGf9d4TNethi");

                    HttpWebResponse GETResponse = (HttpWebResponse)GETRequest.GetResponse();
                    Stream GETResponseStream = GETResponse.GetResponseStream();
                    StreamReader sr = new StreamReader(GETResponseStream);

                    feeds.Content = sr.ReadToEnd();
                    feedsList.Add(feeds);
                }
            }
            gv_Rss.DataSource = feedsList;
            gv_Rss.DataBind();
        }
        catch (WebException e)
        {
            if (e.Status == WebExceptionStatus.ProtocolError)
            {
                WebResponse resp = e.Response;
                using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                {
                    Feeds feeds = new Feeds()
                    {
                        Content = sr.ReadToEnd()
                    };
                    feedsList.Add(feeds);
                }
            }
        }
        catch (Exception)
        {
            throw;
        }
    }
}
}