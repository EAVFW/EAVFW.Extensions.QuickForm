using EAVFramework;
using EAVFramework.Shared;
using EAVFW.Extensions.Documents;
using EAVFW.Extensions.QuickForm.Models.Questions;
using EAVFW.Extensions.QuickForm.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace EAVFW.Extensions.QuickForm.Abstractions
{

    [EntityInterface(EntityKey = "*")]
    [ConstraintMapping(EntityKey = "Document", ConstraintName = nameof(TDocument))]
    public interface IQuickFormTemplateEntity<TDocument>
        where TDocument : DynamicEntity, IDocumentEntity
    {
       
        public Guid Id { get; set; }
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
    public class DefaultDocumentService : IDocumentService
    {
        public async Task<byte[]> SerializeAndCompressAsync<T>(T quickFormProps)
        {

            var serializer = Newtonsoft.Json.JsonSerializer.CreateDefault(new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            using (var data = new MemoryStream())
            {
                using (var stream = new GZipStream(data, CompressionMode.Compress, true))
                {
                    using (var jsonwriter = new JsonTextWriter(new StreamWriter(stream, leaveOpen: true)))
                    {
                        serializer.Serialize(jsonwriter, quickFormProps);
                    }

                    await stream.FlushAsync();
                }
                await data.FlushAsync();

                return data.ToArray();
            }

        }

        public Task<T> DecompressAndDeserializeAsync<T>(byte[] compressedData)
        {
            using var memoryStreamIn = new MemoryStream(compressedData);
            using var decompressor = new GZipStream(memoryStreamIn, CompressionMode.Decompress);
            using var textReader = new StreamReader(decompressor);
            using var jsonReader = new JsonTextReader(textReader);

            var serializer = new Newtonsoft.Json.JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            return Task.FromResult(serializer.Deserialize<T>(jsonReader));
        }
    }
}
