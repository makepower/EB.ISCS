using System.Web.Http;
using WebActivatorEx;
using EB.ISCS.WebApi;
using Swashbuckle.Application;
using System;
using Swashbuckle.Swagger;
using System.Web.Http.Description;
using System.Linq;
using System.Globalization;
using System.Text.RegularExpressions;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace EB.ISCS.WebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(c =>
              {
                  c.OperationFilter<Filters.AddAuthTokenHeaderParameter>();
                  c.SingleApiVersion("v1", "EB.ISCS.WebAPI Parameter:basic website|93BBB59D-F39A-4744-BD75-61B5223F5BED;61-11441011A37025A7445BAA59B3E8282DD68D863969489331");
                  c.OperationFilter<RemoveNamespaceParams>();
                  c.IncludeXmlComments(GetXmlCommentsPath(thisAssembly.GetName().Name));
              })
                .EnableSwaggerUi(c =>
                { });
        }

        /// <summary>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected static string GetXmlCommentsPath(string name)
        {
            return string.Format(@"{0}\bin\{1}.XML", AppDomain.CurrentDomain.BaseDirectory, name);
        }
    }

    public class RemoveNamespaceParams : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {

            operation.parameters = operation.parameters.Where(param => param.name != "namespace").ToArray();
        }


    }
    public static class VersionHelper
    {
        private const string VersionRegex = @"v([\d]+)";

        public static bool ResolveVersionSupportByControllerDescriptor(ApiDescription apiDesc, string targetApiVersion)
        {
            // remove any Version text from the tags
            apiDesc.ActionDescriptor.ControllerDescriptor.ControllerName = Regex.Replace(apiDesc.ActionDescriptor.ControllerDescriptor.ControllerName, VersionRegex, string.Empty, RegexOptions.IgnoreCase);

            // now filter out any controllers that aren't the target version
            var controllerNamespace = apiDesc.ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(controllerNamespace, string.Format(".{0}.", targetApiVersion), CompareOptions.IgnoreCase) >= 0;
        }



    }


}
