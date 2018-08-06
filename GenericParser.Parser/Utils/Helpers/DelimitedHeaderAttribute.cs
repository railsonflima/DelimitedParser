namespace GenericParser.Attribute
{
    public class DelimitedHeaderAttribute : System.Attribute
    {
        public string HeaderName { get; private set; }
        public object DefaultValue { get; set; }
        public bool Obriga { get; set; }

        public DelimitedHeaderAttribute(string headerName)
        {
            HeaderName = headerName;
        }
    }
}
