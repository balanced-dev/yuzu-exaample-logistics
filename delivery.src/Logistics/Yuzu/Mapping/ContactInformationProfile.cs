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
    public class ContactInformationProfile : Profile
    {
        public ContactInformationProfile(IYuzuDeliveryImportConfiguration config)
        {
            config.IgnoreUmbracoModelsForAutomap.Add<ContactInformation>();

            RecognizePrefixes("Contact");
            CreateMap<ContactInformation, vmSub_ContactInformationContactDetails>();

            RecognizePrefixes("More");
            CreateMap<ContactInformation, vmSub_ContactInformationMoreInfo>();

            CreateMap<ContactInformation, vmBlock_ContactInformation>()
                .ForMember(x => x.Form, opt => opt.MapFrom<FormMemberValueResolver<ContactInformation, vmBlock_ContactInformation>, object>(y => y.Form))
                .ForMember(x => x.ContactDetails, opt => opt.MapFrom(x => x))
                .ForMember(x => x.MoreInfo, opt => opt.MapFrom(x => x));
        }
    }
}