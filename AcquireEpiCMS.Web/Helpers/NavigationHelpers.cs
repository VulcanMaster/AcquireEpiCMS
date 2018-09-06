using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using System.Web.Mvc;
using System.Linq;

namespace AcquireEpiCMS.Web.Helpers
{
    public static class NavigationHelpers
    {
        public static void RenderMainNavigation(this HtmlHelper html,
            PageReference rootLink = null,
            ContentReference contentLink = null,
            bool includeRoot = true,
            IContentLoader contentLoader = null)
        {

            //var contentLink = html.ViewContext.RequestContext.GetContentLink();
            contentLink = contentLink ?? html.ViewContext.RequestContext.GetContentLink();

            rootLink = rootLink ?? ContentReference.StartPage;

            // Beginning here
            var writer = html.ViewContext.Writer;

            writer.WriteLine("<nav class='navbar navbar-expand-md navbar-light bg-light'>");
            writer.WriteLine("<a class='navbar-brand' href='#'>Acquire EPiServer</a>");
            writer.WriteLine("<button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#navbarSupportedContent' aria-controls='navbarSupportedContent' aria-expanded='false' aria-label='Toggle navigation'>");
            writer.WriteLine("<span class='navbar-toggler-icon'></span>");
            writer.WriteLine("</button>");

            writer.WriteLine("<div class='collapse navbar-collapse' id='navbarSupportedContent'>");
            writer.WriteLine("<ul class='navbar-nav mr-auto'>");

            // Processing with the Start page, i.e. main Home page.
            if (includeRoot)
            {

                //if (ContentReference.StartPage.CompareToIgnoreWorkID(contentLink))
                if (rootLink.CompareToIgnoreWorkID(contentLink))
                {
                    writer.WriteLine("<li class=\"active nav-item\">");
                }
                else
                {
                    writer.WriteLine("<li class=\"nav-item\">");
                }
                //                writer.WriteLine(html.PageLink(ContentReference.StartPage).ToHtmlString());
                writer.WriteLine(html.PageLink(rootLink, null, new { @class= "nav-link" }).ToHtmlString());
                writer.WriteLine("</li>");
            }

            contentLoader = contentLoader ?? ServiceLocator.Current.GetInstance<IContentLoader>();



            //var topLevelPages = contentLoader.GetChildren<PageData>(ContentReference.StartPage);
            var topLevelPages = contentLoader.GetChildren<PageData>(rootLink);

            var currentBranch = contentLoader.GetAncestors(contentLink).Select(x => x.ContentLink).ToList();
            currentBranch.Add(contentLink);


            // Processing further with top level pages
            foreach (var topLevelPage in topLevelPages)
            {
                // Checking if current location is equal to content link.
                // Second try begin
                if (currentBranch.Any(x => x.CompareToIgnoreWorkID(topLevelPage.ContentLink)))
                {
                    writer.WriteLine("<li class=\"active nav-item\">");
                }

                // First try begin
                //if (topLevelPage.ContentLink.CompareToIgnoreWorkID(contentLink))
                //{
                //    writer.WriteLine("<li class=\"active\">");

                //}
                // Fist try end
                else
                {
                    writer.WriteLine("<li class=\"nav-item\">");
                }

                writer.WriteLine(html.PageLink(topLevelPage, null, new { @class = "nav-link" }).ToHtmlString());
                writer.WriteLine("</li>");
            }


            //writer.WriteLine("<li class='nav-item active'>");
            //        writer.WriteLine("<a class='nav-link' href='#'>Home<span class='sr-only'>(current)</span></a>");
            //        writer.WriteLine("</li>");

            //writer.WriteLine("<li class='nav-item'>");
            //writer.WriteLine("<a class='nav-link' href='#'>Link</a>");
            //writer.WriteLine("</li>");
            //writer.WriteLine("<li class='nav-item dropdown'>");
            //writer.WriteLine("<a class='nav-link dropdown-toggle' href='#' id='navbarDropdown' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>");
            //writer.WriteLine("Dropdown");
            //writer.WriteLine("</a>");
            //writer.WriteLine("<div class='dropdown-menu' aria-labelledby='navbarDropdown'>");
            //writer.WriteLine("<a class='dropdown-item' href='#'>Action</a>");
            //writer.WriteLine("<a class='dropdown-item' href='#'>Another action</a>");
            //writer.WriteLine("<div class='dropdown-divider'></div>");
            //writer.WriteLine("<a class='dropdown-item' href='#'>Something else here</a>");
            //writer.WriteLine("</div>");
            //writer.WriteLine("</li>");
            //writer.WriteLine("<li class='nav-item'>");
            //writer.WriteLine("<a class='nav-link disabled' href='#'>Disabled</a>");
            //writer.WriteLine("</li>");

            writer.WriteLine("</ul>");
            writer.WriteLine("<form class='form-inline my-2 my-lg-0'>");
            writer.WriteLine("<input class='form-control mr-sm-2' type='search' placeholder='Search' aria-label='Search'>");
            writer.WriteLine("<button class='btn btn-outline-success my-2 my-sm-0' type='submit'>Search</button>");
            writer.WriteLine("</form>");
            writer.WriteLine("</div>");
            writer.WriteLine("</nav>");

            // stop here

            //var writer = html.ViewContext.Writer;
            ////Top level elements 
            //writer.WriteLine("<nav class=\"navbar navbar-inverse\">");
            //writer.WriteLine("<ul class=\"nav navbar-nav\">");

            ////Link to the start page 
            //writer.WriteLine("<li>");
            //writer.WriteLine(html.PageLink(ContentReference.StartPage).ToHtmlString());
            //writer.WriteLine("</li>");

            ////Link to the start pages children 
            //var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            //var topLevelPages = contentLoader.GetChildren<PageData>(ContentReference.StartPage);
            //foreach (var topLevelPage in topLevelPages)
            //{
            //    writer.WriteLine("<li>");
            //    writer.WriteLine(html.PageLink(topLevelPage).ToHtmlString());
            //    writer.WriteLine("</li>");
            //}

            ////Close top level elements
            //writer.WriteLine("</ul>");
            //writer.WriteLine("</nav>");
        }

        public static void YouMan()
        {
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var topLevelPages = contentLoader.GetChildren<PageData>(ContentReference.StartPage);
        }
    }
}