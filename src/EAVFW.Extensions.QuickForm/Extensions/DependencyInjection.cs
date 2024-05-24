using EAVFramework.Plugins;
using EAVFramework;
using EAVFW.Extensions.Documents;
using EAVFW.Extensions.QuickForms.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hafnia.BusinessLogic.Plugins.LOITemplates;

namespace EAVFW.Extensions.QuickForms.Extensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddQuickForms<TContext, TQuickFormTemplateEntity, TDocument,TProvider, TDocumentService>(this IServiceCollection services)
            where TContext : DynamicContext
            where TQuickFormTemplateEntity : DynamicEntity, IQuickFormTemplateEntity<TDocument>
            where TDocument : DynamicEntity, IDocumentEntity, new ()
            where TProvider : class, IQuickFormProvider<TQuickFormTemplateEntity, TDocument>
            where TDocumentService : class, IDocumentService
        {
            services.AddPlugin<QuickFormDefinitionPlugin<TContext, TQuickFormTemplateEntity, TDocument>>();
            services.AddScoped<IQuickFormProvider<TQuickFormTemplateEntity, TDocument>, TProvider>();
            services.AddScoped<IDocumentService, TDocumentService>();
            return services;
        }
    }
}
