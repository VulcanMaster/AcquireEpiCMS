﻿using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using EPiServer.Web;
using EPiServer;

namespace AcquireEpiCMS.Web.Models.Pages
{
    [ContentType(DisplayName = "StandardPage", GUID = "37eed0d1-f489-49a4-bd71-dec7df92c3eb", Description = "")]
    public class StandardPage : PageData
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
            Name = "Main body",
            Description = "The main body will be shown in the main content area of the page, using the XHTML-editor you can insert for example text, images and tables.",
            GroupName = SystemTabNames.Content,
            Order = 3)]
        public virtual XhtmlString MainBody { get; set; }


        [Display(Order = 4)]
        [UIHint(UIHint.Image)]
        public virtual Url Image { get; set; }

        [Display(Order = 10)]
        public virtual ContentArea RightColumnContent { get; set; }
    }
}