using Microsoft.CodeAnalysis.CSharp.Syntax;
using RazorLight;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TemplateEngine.Service
{
    public static class RazorEngine
    {
        private static readonly IRazorLightEngine razorLightEngine;
        static RazorEngine()
        {
            razorLightEngine = new RazorLightEngineBuilder()
                                    .UseEmbeddedResourcesProject(typeof(RazorEngine).Assembly, "TemplateEngine.Templates")
                                    .EnableEncoding()
                                    .EnableDebugMode()
                                    .Build();
        }

        public static async Task<string> CompileRenderStringAsync<TModel>(string key, string content, TModel model)
        {
            return await razorLightEngine.CompileRenderStringAsync(key, content, model);
        }

        public static async Task<string> CompileRenderAsync<TModel>(string key, TModel model, ExpandoObject? viewBag = null)
        {
            return await razorLightEngine.CompileRenderAsync(key, model, viewBag);
        }
    }
}
