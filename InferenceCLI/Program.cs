namespace InferenceCLI
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            // Program variables
            var statusCode = 0;
            string requestedModel;
            string requestedPrecision;

            // Parse the CLI
            var cliParser = new CLI.Parser();
            (requestedModel, requestedPrecision) = await cliParser.Parse(args);

            Console.WriteLine($"The requested model: {requestedModel}");
            Console.WriteLine($"The requested precision: {requestedPrecision}");

            // Exit
            return statusCode;
        }
    }
}