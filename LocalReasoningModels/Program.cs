// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.AI;

Console.WriteLine("Running samples");

var promptMathSimple = "Please solve 2 + 3";
var promptMathComplex = "Which is bigger, 9.9 or 9.11?";

AnalyzeModelForReasoning("llama3.2-vision", promptMathSimple, promptMathComplex).Wait();
AnalyzeModelForReasoning("qwq", promptMathSimple, promptMathComplex).Wait();

static async Task AnalyzeModelForReasoning(string modelId, string promptMathSimple, string promptMathComplex)
{
    Console.WriteLine($"START\t{modelId}");
    await ProcessPromptAsync(modelId, promptMathSimple);
    await ProcessPromptAsync(modelId, promptMathComplex);
    Console.WriteLine($"END");
    Console.WriteLine();
}

static async Task ProcessPromptAsync(string modelId, string prompt)
{
    var chatGpu = new OllamaChatClient(new Uri("http://localhost:11434/"), modelId);
    Console.WriteLine($"START\t{prompt}");
    var result = chatGpu.CompleteStreamingAsync(prompt);
    await foreach (var message in result)
    {
        Console.Write(message.Text);
    }
    Console.WriteLine();
    Console.WriteLine($"END");
    Console.WriteLine();
}
