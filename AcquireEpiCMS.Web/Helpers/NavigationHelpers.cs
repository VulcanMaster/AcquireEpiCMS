using EPiServer;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using System.Web.Mvc;
using System.Linq;
using EPiServer.Filters;
using System.Collections.Generic;

namespace AcquireEpiCMS.Web.Helpers
{
    public static class NavigationHelpers
    {

        public static void RenderLeftNavigatio(this HtmlHelper html,
            PageReference rootLink = null,
            ContentReference contentLink = null,
            bool includeRoot = true,
            IContentLoader contentLoader = null)
        {
            rootLink = rootLink ?? ContentReference.StartPage;

            contentLink = contentLink ?? html.ViewContext.RequestContext.GetContentLink();

            contentLoader = contentLoader ?? ServiceLocator.Current.GetInstance<IContentLoader>();

            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();

            var topLevelPages = contentLoader.GetChildren<PageData>(rootLink);

            var writer = html.ViewContext.Writer;

            foreach (var topLevelPage in topLevelPages)
            {
                var pageUrl = urlResolver.GetVirtualPath(topLevelPage.ContentLink).VirtualPath;

                writer.WriteLine("<p><a href=/"+ pageUrl+ ">" + topLevelPage.Name + "</a></p>");
            }
        }

        private static IEnumerable<PageReference> NavigationPath(ContentReference contentLink, IContentLoader contentLoader)
        {
            //Find all pages between the current and the 
            //"from" page, in top-down order. 
            var path = contentLoader.GetAncestors(contentLink).Reverse()
                .SkipWhile(x => ContentReference.IsNullOrEmpty(x.ParentLink)
                ||
                !x.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage))
                .OfType<PageData>().Select(x => x.PageLink).ToList();
            //In theory the current content may not be a page. 
            //We check that and, if it is, add it to the end of 
            //the content tree path. 
            var currentPage = contentLoader.Get<IContent>(contentLink) as PageData;

            if (currentPage != null)
            {
                path.Add(currentPage.PageLink);
            }
            return path;
        }


        public static void RenderTwoLevelNavigation(this HtmlHelper html,
            PageReference rootLink = null,
            ContentReference contentLink = null,
            bool includeRoot = true,
            IContentLoader contentLoader = null)
        {
            var writer = html.ViewContext.Writer;

            writer.WriteLine("<nav class='navbar navbar-expand-md navbar-light bg-light'>");
            writer.WriteLine("<a class='navbar-brand' href='#'>Acquire EPiServer</a>");
            writer.WriteLine("<button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#navbarSupportedContent' aria-controls='navbarSupportedContent' aria-expanded='false' aria-label='Toggle navigation'>");
            writer.WriteLine("<span class='navbar-toggler-icon'></span>");
            writer.WriteLine("</button>");

            writer.WriteLine("<div class='collapse navbar-collapse' id='navbarSupportedContent'>");
            writer.WriteLine("<ul class='navbar-nav mr-auto'>");


            contentLink = contentLink ?? html.ViewContext.RequestContext.GetContentLink();
            rootLink = rootLink ?? ContentReference.StartPage;
            contentLoader = contentLoader ?? ServiceLocator.Current.GetInstance<IContentLoader>();

            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();

            var topLevelPages = contentLoader.GetChildren<PageData>(rootLink);

            foreach (var topLevelPage in topLevelPages)
            {

                var pageUrl = urlResolver.GetVirtualPath(topLevelPage.ContentLink).VirtualPath;

                var containChilds = contentLoader.GetChildren<PageData>(topLevelPage.ContentLink).Any();
                if (containChilds)
                {
                    writer.WriteLine("<li class=\"nav-item dropdown\">");
                    writer.WriteLine("<a class=\"nav-link dropdown-toggle\" href =\"" + pageUrl + "\" id =\"navbarDropdown\" role =\"button\" data-toggle=\"dropdown\" aria-haspopup=\"true\" aria-expanded=\"false\">");
                    writer.WriteLine(topLevelPage.Name);
                    writer.WriteLine("</a>");
                    writer.WriteLine("<div class=\"dropdown-menu\" aria-labelledby=\"navbarDropdown\">");

                    var Childs = contentLoader.GetChildren<PageData>(topLevelPage.ContentLink);
                    if (Childs != null)
                    {
                        foreach (var Child in Childs)
                        {
                            var childPageUrl = urlResolver.GetVirtualPath(Child.ContentLink).VirtualPath;
                            writer.WriteLine("<a class=\"dropdown-item\" href=\"" + childPageUrl + "\">" + Child.Name + "</a>");
                        }
                    }

                    writer.WriteLine("<div class=\"dropdown-divider\"></div>");
                    writer.WriteLine("<a class=\"dropdown-item\" href=\"#\" >Something else here</a>");

                    writer.WriteLine("</div>");
                }
                else
                {
                    writer.WriteLine("<li class=\"nav-item\">");
                    writer.WriteLine(html.PageLink(topLevelPage, null, new { @class = "nav-link" }).ToHtmlString());
                }
                writer.WriteLine("</li>");
            }

            writer.WriteLine("</ul>");
            writer.WriteLine("<form class='form-inline my-2 my-lg-0'>");
            writer.WriteLine("<input class='form-control mr-sm-2' type='search' placeholder='Search' aria-label='Search'>");
            writer.WriteLine("<button class='btn btn-outline-success my-2 my-sm-0' type='submit'>Search</button>");
            writer.WriteLine("</form>");
            writer.WriteLine("</div>");
            writer.WriteLine("</nav>");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="rootLink"></param>
        /// <param name="contentLink"></param>
        /// <param name="includeRoot"></param>
        /// <param name="contentLoader"></param>

        public static void RenderMainNavigation(this HtmlHelper html,
            PageReference rootLink = null,
            ContentReference contentLink = null,
            bool includeRoot = true,
            IContentLoader contentLoader = null)
        {
            contentLink = contentLink ?? html.ViewContext.RequestContext.GetContentLink();

            rootLink = rootLink ?? ContentReference.StartPage;

            var writer = html.ViewContext.Writer;

            writer.WriteLine("<nav class='navbar navbar-expand-md navbar-light bg-light'>");
            writer.WriteLine("<a class='navbar-brand' href='#'>Acquire EPiServer</a>");
            writer.WriteLine("<button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#navbarSupportedContent' aria-controls='navbarSupportedContent' aria-expanded='false' aria-label='Toggle navigation'>");
            writer.WriteLine("<span class='navbar-toggler-icon'></span>");
            writer.WriteLine("</button>");

            writer.WriteLine("<div class='collapse navbar-collapse' id='navbarSupportedContent'>");
            writer.WriteLine("<ul class='navbar-nav mr-auto'>");

            if (includeRoot)
            {

                if (rootLink.CompareToIgnoreWorkID(contentLink))
                {
                    writer.WriteLine("<li class=\"active nav-item\">");
                }
                else
                {
                    writer.WriteLine("<li class=\"nav-item\">");
                }

                writer.WriteLine(html.PageLink(rootLink, null, new { @class = "nav-link" }).ToHtmlString());
                writer.WriteLine("</li>");
            }

            contentLoader = contentLoader ?? ServiceLocator.Current.GetInstance<IContentLoader>();

            var topLevelPages = contentLoader.GetChildren<PageData>(rootLink);

            // Filtering out the pages which should not be appeared in the menu
            topLevelPages = FilterForVisitor.Filter(topLevelPages).OfType<PageData>().Where(x => x.VisibleInMenu);

            var currentBranch = contentLoader.GetAncestors(contentLink).Select(x => x.ContentLink).ToList();
            currentBranch.Add(contentLink);


            // Processing further with top level pages
            foreach (var topLevelPage in topLevelPages)
            {

                // Checking if current location is equal to content link.
                if (currentBranch.Any(x => x.CompareToIgnoreWorkID(topLevelPage.ContentLink)))
                {
                    writer.WriteLine("<li class=\"active nav-item\">");
                }
                else
                {
                    writer.WriteLine("<li class=\"nav-item\">");
                }

                writer.WriteLine(html.PageLink(topLevelPage, null, new { @class = "nav-link" }).ToHtmlString());

                writer.WriteLine("</li>");

            }

            writer.WriteLine("</ul>");
            writer.WriteLine("<form class='form-inline my-2 my-lg-0'>");
            writer.WriteLine("<input class='form-control mr-sm-2' type='search' placeholder='Search' aria-label='Search'>");
            writer.WriteLine("<button class='btn btn-outline-success my-2 my-sm-0' type='submit'>Search</button>");
            writer.WriteLine("</form>");
            writer.WriteLine("</div>");
            writer.WriteLine("</nav>");
        }

        public static void RenderSubNavigation(this HtmlHelper html,
            ContentReference contentLink = null, IContentLoader contentLoader = null)
        {
            contentLink = contentLink ?? html.ViewContext.RequestContext.GetContentLink();
            contentLoader = contentLoader ?? ServiceLocator.Current.GetInstance<IContentLoader>();

            //Find all pages between the current and the 
            //start page, in top-down order. 
            var path = contentLoader.GetAncestors(contentLink)
                .Reverse().SkipWhile(x => ContentReference.IsNullOrEmpty(x.ParentLink) ||
                !x.ParentLink.CompareToIgnoreWorkID(ContentReference.StartPage)).OfType<PageData>().Select(x => x.PageLink)
                .ToList();
            //In theory the current content may not be a page. 
            //We check that and, if it is, add it to the end of 
            //the content tree path. 
            var currentPage = contentLoader.Get<IContent>(contentLink) as PageData;
            if (currentPage != null)
            {
                path.Add(currentPage.PageLink);
            }
            var root = path.FirstOrDefault();
            if (root == null)
            {
                //We're not on a page below the start page, 
                //meaning that there's nothing to render. 
                return;
            }
            RenderSubNavigationLevel(html, root, path, contentLoader);
        }

        private static void RenderSubNavigationLevel(HtmlHelper helper,
                            ContentReference levelRootLink, IEnumerable<ContentReference> path,
                            IContentLoader contentLoader)
        { //Retrieve and filter the pages on the current level 
            var children = contentLoader.GetChildren<PageData>(levelRootLink);
            children = FilterForVisitor.Filter(children).OfType<PageData>().Where(x => x.VisibleInMenu);
            if (!children.Any())
            {
                //There's nothing to render on this level so we abort 
                //in order not to write an empty ul element. 
                return;
            }
            var writer = helper.ViewContext.Writer;


            //Open list element for the current level 
            //writer.WriteLine("<ul class=\"nav\">");
            writer.WriteLine("<nav class='navbar navbar-expand-md navbar-light bg-light'>");
            writer.WriteLine("<a class='navbar-brand' href='#'>Acquire EPiServer</a>");
            writer.WriteLine("<button class='navbar-toggler' type='button' data-toggle='collapse' data-target='#navbarSupportedContent' aria-controls='navbarSupportedContent' aria-expanded='false' aria-label='Toggle navigation'>");
            writer.WriteLine("<span class='navbar-toggler-icon'></span>");
            writer.WriteLine("</button>");

            writer.WriteLine("<div class='collapse navbar-collapse' id='navbarSupportedContent'>");
            writer.WriteLine("<ul class='navbar-nav mr-auto'>");



            //Project to an anonymous class in order to know 
            //the index of each page in the collection when 
            //iterating over it. 
            var indexedChildren = children.Select((page, index) => new { index, page }).ToList();
            foreach (var levelItem in indexedChildren)
            {
                var page = levelItem.page;
                var partOfCurrentBranch = path.Any(x => x.CompareToIgnoreWorkID(levelItem.page.ContentLink));
                if (partOfCurrentBranch)
                {
                    //We highlight pages that are part of the current branch, 
                    //including the currently viewed page.
                    writer.WriteLine("<li class=\"active nav-item\">");
                }
                else
                {
                    writer.WriteLine("<li class=\"nav-item\">");
                }
                // writer.WriteLine(helper.PageLink(page).ToHtmlString());
                writer.WriteLine(helper.PageLink(page, null, new { @class = "nav-link" }).ToHtmlString());

                if (partOfCurrentBranch)
                {
                    //The page is part of the current pages branch, 
                    //so we render a level below it 
                    RenderSubNavigationLevel(helper, page.ContentLink, path, contentLoader);
                }
                writer.WriteLine("</li>");
            }
            //Close list element 
            //writer.WriteLine("</ul>");

            writer.WriteLine("</ul>");
            writer.WriteLine("<form class='form-inline my-2 my-lg-0'>");
            writer.WriteLine("<input class='form-control mr-sm-2' type='search' placeholder='Search' aria-label='Search'>");
            writer.WriteLine("<button class='btn btn-outline-success my-2 my-sm-0' type='submit'>Search</button>");
            writer.WriteLine("</form>");
            writer.WriteLine("</div>");
            writer.WriteLine("</nav>");
        }
    }
}