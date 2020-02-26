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
    public class BlogProfile : Profile
    {
        public BlogProfile(IYuzuDeliveryImportConfiguration config)
        {
            RecognizePrefixes("Meta");
            CreateMap<Blog, vmSub_BlogSummaryMeta>();

            CreateMap<Blog, vmBlock_BlogSummary>()
                .ForMember(x => x.Meta, opt => opt.MapFrom(x => x));

            config.IgnorePropertiesInViewModels.Add<vmBlock_BlogSummaryGrid, List<vmSub_BlogSummaryGridPaginationLink>>(x => x.PaginationLinks);

        }
    }
}