using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ReportAPI.Models;
using RazorLight;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReportAPI.Services
{
    public class ReportService
    {
        private readonly IRazorViewEngine _viewEngine;
        private readonly ITempDataProvider _tempDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private readonly HttpClient _client;

        public ReportService(IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
        {
            _viewEngine = viewEngine;
            _tempDataProvider = tempDataProvider;
            _serviceProvider = serviceProvider;

            _client = new HttpClient
            {
                BaseAddress = new Uri(Resources.SettingsResources.Uri)
            };
        }

        /// <summary>
        /// Renders a physical Razor view (.cshtml) to string.
        /// </summary>
        public async Task<string> RenderViewToStringAsync<TModel>(ControllerContext context, string viewName, TModel model)
        {
            var viewResult = _viewEngine.FindView(context, viewName, false);
            if (!viewResult.Success)
                throw new FileNotFoundException($"View '{viewName}' not found.");

            var viewDictionary = new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            await using var sw = new StringWriter();
            var viewContext = new ViewContext(
                context,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(context.HttpContext, _tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return sw.ToString();
        }

        /// <summary>
        /// Fetches Razor template definition from an external API.
        /// </summary>
        public async Task<string> GetTemplateHtmlFromApiAsync(string reportName, long templateType)
        {
            var url = $"api/GetDefinitionByReportName/{reportName}/{templateType}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch template: {response.StatusCode}");
            }

            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Renders Razor template from string using RazorLight.
        /// </summary>
        public async Task<string> RenderHtmlFromTemplateAsync<TModel>(string razorTemplate, TModel model)
        {
            var engine = new RazorLightEngineBuilder()
                .UseMemoryCachingProvider()
                .Build();

            string templateKey = Guid.NewGuid().ToString(); // Unique key to cache the template
            return await engine.CompileRenderStringAsync(templateKey, razorTemplate, model);
        }
    }
}