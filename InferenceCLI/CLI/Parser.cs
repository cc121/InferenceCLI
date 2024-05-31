using System.CommandLine;

namespace InferenceCLI.CLI
{
    internal class Parser
    {
        private readonly RootCommand rootCommand;
        private Option<string> modelOption;
        private Option<string> precisionOption;

        public Parser() {
            // Define the options
            modelOption = new Option<string>(
                "--model",
                getDefaultValue: () => "Phi3-Mini-4K",
                description: "The model to run inference with. Options are Phi3-Mini-4K and Phi3-Mini-128K.")
                    .FromAmong(
                        "Phi3-Mini-4K",
                        "Phi3-Mini-128K"
                );

            precisionOption = new Option<string>(
                "--precision",
                getDefaultValue: () => "INT4",
                description: "The precision of the model. The only option is INT4.")
                    .FromAmong(
                        "INT4"
                );

            // Create the root command
            rootCommand = new RootCommand("A CLI app to run model inference.");
            rootCommand.AddOption(modelOption);
            rootCommand.AddOption(precisionOption);
        }

        public async Task<(string, string)> Parse(string[] args)
        {
            var requestedModel = string.Empty;
            var requestedPrecision = string.Empty;

            // Set the handler
            rootCommand.SetHandler((model, precision) =>
            {
                requestedModel = model;
                requestedPrecision = precision;
            },
            modelOption, precisionOption);

            // Invoke the command
            await rootCommand.InvokeAsync(args);

            // Return the model and precision requested by the user
            return (requestedModel, requestedPrecision);
        }
    }
}
