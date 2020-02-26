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
    public class MiscProfile : Profile
    {
        public MiscProfile(IYuzuDeliveryImportConfiguration config)
        {
            CreateMap<Testimonial, vmSub_TestimonialCarouselTestimonial>();

            CreateMap<Service, vmBlock_ServiceSummary>();
            CreateMap<Service, vmBlock_ImageFeature>();
        }
    }
}