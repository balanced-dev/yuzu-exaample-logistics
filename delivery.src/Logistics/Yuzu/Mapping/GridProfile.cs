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
    public class GridProfile : Profile
    {
        public GridProfile(IYuzuDeliveryImportConfiguration config)
        {
            config.IgnoreViewmodels.Add<vmBlock_RowBuilderConfig>();
            config.IgnoreUmbracoModelsForAutomap.Add<SectionGridPage>();

            this.AddGridWithRows<SectionGridPage, vmPage_SectionGridPage, vmBlock_RowBuilderConfig>(src => src.Content, dest => dest.Content);
        }
    }
}