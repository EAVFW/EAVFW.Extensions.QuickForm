using EAVFramework;
using EAVFramework.Plugins;

using System.Threading.Tasks;

using System;
using System.Collections.Generic;

using System.Linq;
using EAVFW.Extensions.QuickForm.Models;
using EAVFW.Extensions.QuickForm.Abstractions;
using EAVFW.Extensions.Documents;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace Hafnia.BusinessLogic.Plugins.LOITemplates
{


    /// <summary>
    /// Will take Template.MetadataPayload as input to generate the QuickFormDefinition required as props in LOIPortal application (end-user portal).
    /// </summary>
    [PluginRegistration(EntityPluginExecution.PostOperation, EntityPluginOperation.Create, order:10)]
    [PluginRegistration(EntityPluginExecution.PostOperation, EntityPluginOperation.Update, order: 10)]
    public class QuickFormDefinitionPlugin<TContext, TQuickFormTemplateEntity, TDocument> : IPlugin<TContext, TQuickFormTemplateEntity> , IPluginRegistration
        where TContext : DynamicContext
        where TQuickFormTemplateEntity : DynamicEntity, IQuickFormTemplateEntity<TDocument>
        where TDocument : DynamicEntity, IDocumentEntity, new()
    {
        private readonly IQuickFormProvider<TQuickFormTemplateEntity, TDocument> _quickFormProvider;
        private readonly IDocumentService _documentService;

        public QuickFormDefinitionPlugin(IQuickFormProvider<TQuickFormTemplateEntity, TDocument> quickFormProvider, IDocumentService documentService)
        {
            _quickFormProvider = quickFormProvider ?? throw new ArgumentNullException(nameof(quickFormProvider));
            _documentService = documentService ?? throw new ArgumentNullException(nameof(documentService));
        }
        public async Task Execute(PluginContext<TContext, TQuickFormTemplateEntity> context)
        { 
            /* First run. Populate QuickFormProps with empty values */
            if (context.Input.QuickFormDefinitionId == null)
            {

                var quickFormProps = new QuickFormDefinition()
                {
                    Intro =await _quickFormProvider.CreateIntroAsync(context.Input),
                    Submit = await _quickFormProvider.CreateSubmitAsync(context.Input),
                    Ending = await _quickFormProvider.CreateEndingAsync(context.Input),
                    Questions = await _quickFormProvider.CreateQuestionsAsync(context.Input)
                };


                context.Input.QuickFormDefinition = new TDocument()
                {
                    Data =  await _documentService.SerializeAndCompressAsync(quickFormProps),// await HafniaDocumentHelpers.CompressObject(quickFormProps),
                    ContentType = "application/json",
                    Compressed = true
                };
            }
            else
            {
                // use JToken.merge to avoid overriding already written user input.
                var modifiedQuickFormProps = new QuickFormDefinition()
                {
                    Intro = await _quickFormProvider.CreateIntroAsync(context.Input),
                    Submit = await _quickFormProvider.CreateSubmitAsync(context.Input),
                    Ending = await _quickFormProvider.CreateEndingAsync(context.Input),
                    Questions = await _quickFormProvider.CreateQuestionsAsync(context.Input)
                };
              

                var oldDefinition = await _documentService.DecompressAndDeserializeAsync<QuickFormDefinition>(context.Input.QuickFormDefinition.Data);

                foreach (var deleted in 
                    oldDefinition.Questions.Keys
                        .Where(key => !modifiedQuickFormProps.Questions.Keys.Contains(key))
                        .ToArray())
                {
                    oldDefinition.Questions.Remove(deleted);
                }

                var newJToken = JObject.FromObject(modifiedQuickFormProps);
                var oldDefinitionJtoken = JObject.FromObject(oldDefinition);

                newJToken.Merge(oldDefinitionJtoken, new JsonMergeSettings
                {
                    MergeNullValueHandling = MergeNullValueHandling.Ignore,
                    MergeArrayHandling = MergeArrayHandling.Replace
                });
                //oldDefinitionJtoken.Merge(newJToken, new JsonMergeSettings
                //{
                //    MergeNullValueHandling = MergeNullValueHandling.Ignore,
                //    MergeArrayHandling = MergeArrayHandling.Replace
                //});

                

                
                context.Input.QuickFormDefinition.Data = await _documentService.SerializeAndCompressAsync(newJToken);
                context.Input.QuickFormDefinition.Compressed = true;
            }

        }

    }
}
