using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.ViewModels;
using YuzuDelivery.UmbracoModels;
using Umbraco.Web;

namespace Logistics
{
    public class PageHeroTypeAfterMap : IYuzuTypeAfterConvertor<PageHero, vmBlock_PageHero>
    {
        private readonly IMapper mapper;

        public PageHeroTypeAfterMap(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Apply(PageHero source, vmBlock_PageHero dest, UmbracoMappingContext context)
        {
            if (context.Model != null)
            {
                dest.Title = context.Model.Name;
                dest.Breadcrumbs = context.Model.AncestorsOrSelf()
                    .Select(x => mapper.Map<vmBlock_DataLink>(x))
                    .Reverse()
                    .ToList();
            }
        }
    }
}