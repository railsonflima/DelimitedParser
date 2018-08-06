using GenericParser.Attribute;
using GenericParser.Utils.Helpers;
using System.Collections.Generic;
using System.Linq;
using System;
using static GenericParser.FileManager.FileManagerService;
using GenericParser.Utils.Extensions;

namespace GenericParser.Parser
{
    public class DelimitedParser<TModel>
        where TModel : class, new()
    {
        public char Delimitator { get; set; } = ';';

        protected readonly string _path;

        private readonly IReadOnlyList<PropertyInfoWithAttribute<DelimitedHeaderAttribute>> _propertiesInfo;

        private static readonly int HeaderOrder = 1;

        public DelimitedParser(string path)
        {
            _path = path;

            _propertiesInfo = typeof(TModel).GetProperties()
            .Select(p => PropertyInfoWithAttribute<DelimitedHeaderAttribute>.Factory(p, System.Attribute.GetCustomAttributes(p)
            .Cast<DelimitedHeaderAttribute>().FirstOrDefault()))
            .ToList();
        }

        public IReadOnlyList<TModel> Parse()
        {
            try
            {
                var content = ReadAllLinesWithBuffer(_path);
                var normalizedContent = Parse(content);
                var header = normalizedContent.First().Split(Delimitator);
                return normalizedContent
                    .Skip(HeaderOrder)
                    .Select(x => header.Select(GroupData(x))
                    .ToDictionary(k => k.Key, v => v.Value))
                    .ContinueWith(contentText => contentText.Select(SetValueProperties).ToList());
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected virtual IEnumerable<string> Parse(IEnumerable<string> content)
        {
            return content;
        }

        private Func<string, int, KeyValuePair<string, string>> GroupData(string x)
        {

            return (a, i) => new KeyValuePair<string, string>(a, x.Split(Delimitator)[i]);
        }

        private TModel SetValueProperties(Dictionary<string, string> item)
        {
            var model = new TModel();

            item.ToList().ForEach(data =>
            {
                var propertyInfo = _propertiesInfo.FirstOrDefault(x => x.Attribute.HeaderName == data.Key);
                if (propertyInfo == null)
                    throw new Exception($"The HeaderName { data.Key } is not valid!");
                model.GetType().GetProperty(propertyInfo.Property.Name).SetValue(model, data.Value.ChangeTypeSafe(propertyInfo.Property.PropertyType, propertyInfo.Attribute.DefaultValue));
            });

            return model;
        }
    }
}
