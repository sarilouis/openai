using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using System.Threading.Tasks.Sources;

namespace OpenAI.Playground.TestHelpers
{
    internal static class CompletionTestHelper
    {
        public static async Task RunSimpleCompletionTest(IOpenAIService sdk)
        {
            ConsoleExtensions.WriteLine("Completion Testing is starting:", ConsoleColor.Cyan);

            try
            {
                ConsoleExtensions.WriteLine("Completion Test:", ConsoleColor.DarkCyan);
                var prompts = new List<string>() { "Once upon a time", "It was the best of times" };
                var completionResult = await sdk.Completions.Create(new CompletionCreateRequest()
                {
                    Prompt = prompts,
                    MaxTokens = 5,
                    Model = Models.TextDavinciV2
                });

                if (completionResult.Successful)
                {
                    for (int i = 0; i < prompts.Count; i++)
                    {
                        ConsoleExtensions.WriteLine($"Prompt {i + 1}:", ConsoleColor.DarkCyan);
                        Console.WriteLine(prompts.ElementAtOrDefault(i));
                        ConsoleExtensions.WriteLine($"Completion {i + 1}:", ConsoleColor.DarkCyan);
                        Console.WriteLine(completionResult.Choices.ElementAtOrDefault(i));
                    }
                }
                else
                {
                    if (completionResult.Error == null)
                    {
                        throw new Exception("Unknown Error");
                    }

                    Console.WriteLine($"{completionResult.Error.Code}: {completionResult.Error.Message}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}