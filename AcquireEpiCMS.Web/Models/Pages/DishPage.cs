using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using EPiServer;

namespace AcquireEpiCMS.Web.Models.Pages
{
    [ContentType(DisplayName = "DishPage", GUID = "d85ff549-fea0-4bd1-bbd0-d18457a88174", Description = "")]
    public class DishPage : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "The title of the dish.",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string Title { get; set; }


        [CultureSpecific]
        [Display(
            Name = "Description",
            Description = "The description of the dish.",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual XhtmlString Description { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Picture",
            Description = "The picture of the dish",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual Url Picture { get; set; }
    }
}