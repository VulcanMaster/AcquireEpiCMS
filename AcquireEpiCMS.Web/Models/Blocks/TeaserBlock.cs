using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AcquireEpiCMS.Web.Models.Blocks
{
    [ContentType(DisplayName = "TeaserBlock", GUID = "65284744-8242-4a06-a014-1b8f8285674e", Description = "")]
    public class TeaserBlock : BlockData
    {

        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "Add a heading.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual String Heading { get; set; }


        [Display(
            Name = "Image", Description = "Add an image (optional)",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual ContentReference Image { get; set; }

    }
}