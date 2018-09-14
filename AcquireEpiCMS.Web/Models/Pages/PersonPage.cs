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
    [ContentType(DisplayName = "PersonPage", GUID = "193a6a53-dda7-49fd-9a4f-93e14fc451b5", Description = "")]
    public class PersonPage : PageData
    {

        [CultureSpecific]
        [Display(
            Name = "Person Name",
            Description = "The name of person",
            GroupName = SystemTabNames.Content,
            Order = 1)]
        public virtual string PersonName { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Person Surname",
            Description = "The name of person",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual string PersonSurname { get; set; }

        [Display(Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual Url PersonPhoto { get; set; }

    }
}