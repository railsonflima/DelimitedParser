using System;
using System.Collections.Generic;

namespace GenericParser.DelimitedParser.Parser
{
    public class DelimitedWithoutHeaderParser<TModel> : DelimitedParser<TModel>
        where TModel : class, new()
    {
        public string HeaderFile { get; set; } = string.Empty;

        public DelimitedWithoutHeaderParser(string path) : base(path)
        {
        }

        protected override IEnumerable<string> Parse(IEnumerable<string> content)
        {

            if (string.IsNullOrEmpty(HeaderFile))
                throw new ArgumentException($"The property '{nameof(HeaderFile)}' cannot be null or empty");

            var newContent = new List<string>
            {
                HeaderFile
            };
            newContent.AddRange(content);

            return base.Parse(newContent);
        }
    }
}
