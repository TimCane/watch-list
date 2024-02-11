namespace WatchList.Core.Swagger
{
    [AttributeUsage(
        AttributeTargets.Class |
        AttributeTargets.Struct |
        AttributeTargets.Parameter |
        AttributeTargets.Property |
        AttributeTargets.Enum)]
    public class ExampleAttribute : Attribute
    {
        public ExampleAttribute(string example)
        {
            Example = example;
        }

        public string Example { get; set; }
    }
}
