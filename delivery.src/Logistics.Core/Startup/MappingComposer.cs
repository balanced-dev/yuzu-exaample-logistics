using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Umbraco.Core;
using Umbraco.Core.Composing;
using YuzuDelivery.Umbraco.Blocks;
using YuzuDelivery.Umbraco.Grid;
using YuzuDelivery.Umbraco.Forms;
using AutoMapper.Configuration;
using Logistics.Core.ViewModels;
using Logistics.Core.UmbracoModels;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Logistics.Core
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class MappingComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            var cfg = new MapperConfigurationExpression();
            cfg.AddMaps(typeof(MappingComposer));
            cfg.AddMaps(typeof(YuzuStartup));
            cfg.AddMaps(typeof(YuzuFormsStartup));

            cfg.AddGridWithRows<SectionGridPage, vmPage_SectionGridPage, vmBlock_SectionGridConfig>(src => src.Content, dest => dest.Content);

            cfg.AddForm<HomeHeroFeature, vmSub_HomeHeroFeature>(src => src.Form, dest => dest.Form);
            cfg.AddForm<SiteFooterNewsletterSection, vmSub_SiteFooterNewsletterSection>(src => src.Form, dest => dest.Form);

            var mapperConfig = new MapperConfiguration(cfg);

            composition.Register<IMapper>(new Mapper(mapperConfig));
        }
    }
}
