using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Xml.Linq;

namespace ASPRssFeed
{
public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Title = "Koduleht";
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
                pubDate = x.Element("pubDate").Value,
                description = x.Element("description").Value,
                guid = x.Element("guid").Value,
                author = (string)x.Element("author"),
                category = x.Element("category").Value
            });

            if (elements != null)
            {
                foreach (var i in elements)
                {
                    Feeds feeds = new Feeds
                    {
                        Title = i.title,
                        Link = i.link,
                        PublishDate = DateTime.Parse(i.pubDate).ToString(),
                        Description = i.description,
                        Guid = i.guid,
                        Author = i.author ?? "Puudub",
                        Category = i.category == string.Empty ? "Puudub" : i.category
                    };
                    feedsList.Add(feeds);
                }
            }
            gv_Rss.DataSource = feedsList;
            gv_Rss.DataBind();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
}