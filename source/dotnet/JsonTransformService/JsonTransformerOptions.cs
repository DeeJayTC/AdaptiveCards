using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace JsonTransformService
{

    public enum EmptyArrayHandling
    {
        Keep,
        Remove
    }

    public class JsonTransformerOptions
    {
        /// <summary>
        /// How empty arrays are handled, keep or remove
        /// </summary>
        public EmptyArrayHandling EmptyArrayHandling { get; set; }

        /// <summary>
        /// Shared properties to be used by all templates, use AddSharedProperties to set data
        /// </summary>
        public Dictionary<string,string> SharedProperties => SharedProps;

        private Dictionary<string,string> SharedProps { get; set; }

        /// <summary>
        /// Helper function to add any object as shared properties
        /// </summary>
        /// <param name="data"><see cref="object"/></param>
        /// <returns></returns>
        public void AddSharedProperties(object data)
        {
            SharedProps = data.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .ToDictionary(prop => prop.Name, prop => prop.GetValue(data, null).ToString());
            return;
        }


    }
}
