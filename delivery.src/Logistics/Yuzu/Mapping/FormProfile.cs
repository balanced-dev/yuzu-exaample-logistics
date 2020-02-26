using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using Umbraco.Core;
using Umbraco.Core.Composing;
using YuzuDelivery.Core;
using YuzuDelivery.Core.ViewModelBuilder;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.Umbraco.Import;
using YuzuDelivery.UmbracoModels;
using YuzuDelivery.ViewModels;
using YuzuDelivery.Umbraco.Grid;
using YuzuDelivery.Umbraco.Forms;

namespace Logistics
{
    public class FormProfile : Profile
    {
        public FormProfile(IYuzuDeliveryImportConfiguration config)
        {
            config.IgnoreUmbracoModelsForAutomap.Add<HomeHeroFeature>();
            config.IgnoreUmbracoModelsForAutomap.Add<SiteFooterNewsletterSection>();

            this.AddForm<HomeHeroFeature, vmSub_HomeHeroFeature>(src => src.Form, dest => dest.Form);
            this.AddForm<SiteFooterNewsletterSection, vmSub_SiteFooterNewsletterSection>(src => src.Form, dest => dest.Form);
        }
    }
}