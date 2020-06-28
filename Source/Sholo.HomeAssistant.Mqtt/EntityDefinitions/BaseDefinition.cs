using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Sholo.HomeAssistant.Serialization;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Sholo.HomeAssistant.Mqtt.EntityDefinitions
{
    public abstract class BaseDefinition : IDefinition
    {
        protected static ISerializer YamlSerializer { get; }
        protected static JsonSerializer JsonSerializer { get; }
        protected static JsonSerializer IndentedJsonSerializer { get; }

        private readonly IDictionary<string, object> _serializationObject;

        static BaseDefinition()
        {
            YamlSerializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .ConfigureDefaultValuesHandling(DefaultValuesHandling.OmitNull)
                .Build();

            JsonSerializer = JsonSerializer.Create(HomeAssistantSerializerSettings.JsonSerializerSettings);
            IndentedJsonSerializer = JsonSerializer.Create(HomeAssistantSerializerSettings.IndentedJsonSerializerSettings);
        }

        protected BaseDefinition()
        {
            var typeName = GetType().Name.Replace("EntityDefinition", string.Empty);
            var underscoreTypeName = UnderscoredNamingConvention.Instance.Apply(typeName);

            _serializationObject = new Dictionary<string, object>
            {
                [underscoreTypeName] = this
            };
        }

        public override string ToString() => ToYamlString();

        public string ToJsonString(Formatting formatting = Formatting.None)
        {
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                if (formatting == Formatting.Indented)
                {
                    IndentedJsonSerializer.Serialize(sw, this);
                }
                else
                {
                    JsonSerializer.Serialize(sw, this);
                }
            }

            return sb.ToString();
        }

        public string ToYamlString() => YamlSerializer.Serialize(_serializationObject);
    }
}
