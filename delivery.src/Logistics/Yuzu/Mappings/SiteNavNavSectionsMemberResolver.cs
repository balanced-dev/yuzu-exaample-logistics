using System;
using System.Linq;
using System.Collections.Generic;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Core;
using YuzuDelivery.UmbracoModels;
using YuzuDelivery.ViewModels;
using Umbraco.Web;

namespace Logistics
{
    public class SiteNavNavSectionsMemberResolver : IYuzuPropertyReplaceResolver<Home, List<vmSub_SiteNavNavSection>>
    {
        private readonly IMapper mapper;
        private IPublishedContentQuery contentQuery;

        public SiteNavNavSectionsMemberResolver(IMapper mapper, IPublishedContentQuery contentQuery)
        {
            this.mapper = mapper;
            this.contentQuery = contentQuery;
        }

        public List<vmSub_SiteNavNavSection> Resolve(Home source, UmbracoMappingContext context)
        {
            var root = contentQuery.ContentAtRoot().FirstOrDefault();
            return root.Children.Where(x => x.TemplateId > 0).Select(x => new vmSub_SiteNavNavSection()
            {
                IsActive = x.Id == context.Model.Id,
                Link = mapper.Map<vmBlock_DataLink>(x),
                SubLinks = mapper.Map<List<vmBlock_DataLink>>(x.Children)
            }).ToList();
        }
    }
}