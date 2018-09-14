using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;

namespace AcquireEpiCMS.Web.Models.Pages
{
    [ContentType(DisplayName = "NodeEmptyPage", GUID = "d017bda3-9eb6-4860-8143-c2c6fe48babe", Description = "")]
    public class NodeEmptyPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "The description of the node.",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString MainBody { get; set; }

    }
}