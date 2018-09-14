using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AcquireEpiCMS.Web.Models.Pages
{
    [ContentType(DisplayName = "MiddlePage", GUID = "d6066e05-f4e8-45fc-af02-5942e91efd06", Description = "")]
    public class MiddlePage : PageData
    {
        [CultureSpecific]
        [Display(
             Name = "Heading",
             Description = "The page heading.",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        public virtual String Heading { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main intro",
            Description = "The main intro string area.",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string MainIntro { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Main content area",
            Description = "The container to place here the pages for display.",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual ContentArea MainContentArea { get; set; }

    }
}