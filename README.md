# Delimited Parser
DelimitedParser convert your delimited file text into a model class. Is a simple way to parse files with delimited format.

# Installation

The library is available via [NuGet](https://www.nuget.org/packages/DelimitedParser/) packages:

### Package Manager

```command
Install-Package DelimitedParser -Version 1.0.0
```

### .NET CLI

```command
dotnet add package DelimitedParser --version 1.0.0
```

# Getting Starter

Let's suppose that you have the following file delimited below:

```csv
TESTING_01;TESTING_02;TESTING_03
testing1;10;true
testing2;20;false
testing3;30;true
testing4;40;false
testing5;50;true
```

And you need to convert this format into a model class. With this library you can to do that easily. The first step is create a model with a custom attribute called "DelimitedHeader", the custom attribute "DelimitedHeader" is the header  name into a delimited file, the code below explain how to create this model.

```c#
using GenericParser.Attribute;

namespace GenericParser.Emulator
{
    public class TestingModel
    {
        [DelimitedHeader("TESTING_01")]
        public string TestingPropString { get; set; }

        [DelimitedHeader("TESTING_02")]
        public int TestingPropStringInt { get; set; }

        [DelimitedHeader("TESTING_03")]
        public bool TestingPropStringBool { get; set; }
    }
}
```

After you created a custom model, the only step after is create an instance of the class, passing you model type and informing you type of delimiter char

```c#
using GenericParser.DelimitedParser.Parser;

namespace GenericParser.Emulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\FileWithHeaderTesting.csv";

            var delimitedParser = new DelimitedParser<TestingModel>(filePath)
            {
                Delimitator = ';'
            };

            var model = delimitedParser.Parse();
        }
    }
}

```

The method "Parse" of the class "DelimitedParser" will return an object with all the properties of the delimited file, the printscreen below show us this object:

![alt tag](http://www.nathalianutricionista.com.br/railson/screenshotC%23.jpg "Description goes here")


If your delimited file there's no line "Header", not problem! It's also possible to use this library, instead of use the class "DelimitedParser", use the class "DelimitedWithoutHeaderParser", and than informing a string supposing a header into a delimited file:

```c#
using GenericParser.DelimitedParser.Parser;

namespace GenericParser.Emulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\FileWithoutHeaderTesting.csv";

            var delimitedParser = new DelimitedWithoutHeaderParser<TestingModel>(filePath)
            {
                Delimitator = ';',
                HeaderFile = "TESTING_01;TESTING_02;TESTING_03"
            };

            var model = delimitedParser.Parse();
        }
    }
}
```
