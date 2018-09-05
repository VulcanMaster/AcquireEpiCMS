using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AcquireEpiCMS.Web.Models.Pages
{
    [ContentType(DisplayName = "StartPage", GUID = "f7d70b25-6281-4107-9e15-39e40ce8a09d", Description = "")]
    public class StartPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Main intro",
            Description = "The main intro string area.",
            GroupName = SystemTabNames.Content,
            Order = 0)]
        public virtual string MainIntro { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

    }
}