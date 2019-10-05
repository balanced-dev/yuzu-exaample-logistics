using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using YuzuDelivery.Core;
using YuzuDelivery.Umbraco.Blocks;
using YuzuDelivery.Umbraco.Grid;
using YuzuDelivery.Umbraco.Forms;
using YuzuDelivery.Umbraco.Import;
using Logistics.Core.ViewModels;
using Logistics.Core.UmbracoModels;

namespace Logistics.Core
{

    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    [ComposeBefore(typeof(YuzuStartup))]
    public class YuzuImportsComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            var Server = HttpContext.Current.Server;
            var localAssembly = Assembly.GetAssembly(typeof(YuzuImportsComposer));

            var config = new YuzuDeliveryImportConfiguration()
            {
                IsActive = ConfigurationManager.AppSettings["YuzuImportActive"] == "true",
                DocumentTypeAssemblies = new Assembly[] { localAssembly },
                ViewModelQualifiedTypeName = "Logistics.Core.ViewModels.{0}, Logistics.Core",
                UmbracoModelsQualifiedTypeName = "Logistics.Core.UmbracoModels.{0}, Logistics.Core",
                DataTypeFolder = new DataTypeFolder()
                {
                    Name = "Logistics",
                    Level = 1
                },
                DataLocations = new List<IDataLocation>()
                {
                    new DataLocation()
                    {
                        Name = "Main",
                        Path = Server.MapPath(ConfigurationManager.AppSettings["HandlebarsData"])
                    }
                },
                ImageLocations = new List<IDataLocation>()
                {
                    new DataLocation()
                    {
                        Name = "Main",
                        Path = Server.MapPath(ConfigurationManager.AppSettings["HandlebarsImages"])
                    }
                },
                CustomConfigFileLocation = Server.MapPath(ConfigurationManager.AppSettings["YuzuImportCustomConfig"])
            };

            config.IgnoreViewmodels.Add<vmBlock_Form>();
            config.IgnoreViewmodels.Add<vmBlock_FormButton>();
            config.IgnoreViewmodels.Add<vmBlock_FormTextArea>();
            config.IgnoreViewmodels.Add<vmBlock_FormTextInput>();
            config.IgnoreViewmodels.Add<vmBlock_SectionGridConfig>();

            config.IgnorePropertiesInViewModels.Add<vmBlock_BlogSummaryGrid, List<vmSub_BlogSummaryGridPaginationLink>>(x => x.PaginationLinks);

            config.IgnoreProperties.Add("Form");
            config.IgnoreProperties.Add("Endpoint");

            config.IgnoreUmbracoModelsForAutomap.Add<SectionGridPage>();
            config.IgnoreUmbracoModelsForAutomap.Add<ContactInformation>();
            config.IgnoreUmbracoModelsForAutomap.Add<HomeHeroFeature>();
            config.IgnoreUmbracoModelsForAutomap.Add<SiteFooterNewsletterSection>();

            YuzuDeliveryImport.Initialize(config);
        }

    }

}
