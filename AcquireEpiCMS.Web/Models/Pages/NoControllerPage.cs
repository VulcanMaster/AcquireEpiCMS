using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AcquireEpiCMS.Web.Models.Pages
{
    [ContentType(DisplayName = "NoControllerPage", GUID = "817f8f90-29b5-47b8-8324-267814e5c9cc", Description = "")]
    public class NoControllerPage : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual XhtmlString MainBody { get; set; }

    }
}