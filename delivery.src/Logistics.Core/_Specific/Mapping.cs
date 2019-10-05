using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logistics.Core.ViewModels;
using Logistics.Core.UmbracoModels;
using AutoMapper;
using YuzuDelivery.Umbraco.Forms;

namespace Logistics.Core
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
            RecognizePrefixes("Meta");
            CreateMap<Blog, vmSub_BlogSummaryMeta>();

            CreateMap<Blog, vmBlock_BlogSummary>()
                .ForMember(x => x.Meta, opt => opt.MapFrom(x => x));

            CreateMap<Testimonial, vmSub_TestimonialCarouselTestimonial>();
            CreateMap<Service, vmBlock_ServiceSummary>();
            CreateMap<Service, vmBlock_ImageFeature>();

            RecognizePrefixes("Contact");
            CreateMap<ContactInformation, vmSub_ContactInformationContactDetails>();

            RecognizePrefixes("More");
            CreateMap<ContactInformation, vmSub_ContactInformationMoreInfo>();

            CreateMap<ContactInformation, vmBlock_ContactInformation>()
                .ForMember(x => x.Form, opt => opt.MapFrom<FormResolver<ContactInformation, vmBlock_ContactInformation>, object>(y => y.Form))
                .ForMember(x => x.ContactDetails, opt => opt.MapFrom(x => x))
                .ForMember(x => x.MoreInfo, opt => opt.MapFrom(x => x));

        }

    }
}