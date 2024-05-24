using EAVFramework;
using EAVFramework.Shared;
using EAVFW.Extensions.Documents;
using EAVFW.Extensions.QuickForms.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EAVFW.Extensions.QuickForms.Abstractions
{

    [EntityInterface(EntityKey = "*")]
    [ConstraintMapping(EntityKey = "Document", ConstraintName = nameof(TDocument))]
    public interface IQuickFormTemplateEntity<TDocument>
        where TDocument : DynamicEntity, IDocumentEntity
    {
       
        public TDocument QuickFormDefinition { get; set; }

        public Guid? QuickFormDefinitionId { get; set; }

    }

    public interface IQuickFormProvider<TQuickFormTemplateEntity, TDocument>
        where TQuickFormTemplateEntity : DynamicEntity, IQuickFormTemplateEntity<TDocument>
        where TDocument : DynamicEntity, IDocumentEntity
    {
        Task<IntroProps> CreateIntroAsync(TQuickFormTemplateEntity input);
        
        Task<Dictionary<string, QuestionProps>> CreateQuestionsAsync(TQuickFormTemplateEntity input);
        Task<SubmitProps> CreateSubmitAsync(TQuickFormTemplateEntity input);
        Task<EndingProps> CreateEndingAsync(TQuickFormTemplateEntity input);
    }

    /// <summary>
    /// TODO - move to eavfw.extensions.document
    /// </summary>
    public interface IDocumentService
    {
        Task<byte[]> SerializeAndCompressAsync<T>(T quickFormProps);
        Task<T> DecompressAndDeserializeAsync<T>(byte[] data) ;
    }
}
