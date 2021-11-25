namespace DemoApp
{
    public static class DemoAppDbProperties
    {
        public static string DbTablePrefix { get; set; } = "DemoApp";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "DemoApp";
    }
}
