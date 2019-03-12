using JsonTransformLanguage;
using Newtonsoft.Json.Linq;

namespace JsonTransformService
{
    /// <summary>
    /// Service class wrapping JsonTransformer
    /// </summary>
    public class JsonTransformerService
    {
        private readonly JsonTransformerOptions _options;

        /// <summary>
        /// Init a new instance of transformer service
        /// </summary>
        /// <param name="options">See <see cref="JsonTransformerOptions"/></param>
        public JsonTransformerService(JsonTransformerOptions options)
        {
            _options = options;
        }


        public JToken Transform(string template, object data)
        {
            return JsonTransformer.Transform(template, data, _options.SharedProperties);
        }


    }
}
