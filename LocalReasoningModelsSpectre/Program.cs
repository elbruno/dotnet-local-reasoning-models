// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.AI;
using Spectre.Console;

var promptMathSimple = "Please solve 2 + 3";
var promptMathComplex = "Which is bigger, 9.9 or 9.11?";

AnsiConsole.Record();

AnsiConsole.Write(
    new FigletText("Reasoning Models")
        .LeftJustified()
        .Color(Color.Purple));

AnsiConsole.Markup("[bold][green]Solving 2 problems using reasoning models[/][/]");
AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("[bold][green]Problems:[/][/]");
AnsiConsole.MarkupLine($"[green]\t1. {promptMathSimple}[/]");
AnsiConsole.MarkupLine($"[green]\t2. {promptMathComplex}[/]");
AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("[bold][green]Models to be used:[/][/]");
AnsiConsole.MarkupLine("[green]\t1. llama3.2-vision[/]");
AnsiConsole.MarkupLine("[green]\t2. qwq[/]");
AnsiConsole.WriteLine();

var table = new Table().LeftAligned();
AnsiConsole.Live(table)
    .AutoClear(false)
    .Overflow(VerticalOverflow.Visible) // Show ellipsis when overflowing
    .Start(ctx =>
    {
        table.AddColumn("llama3.2-vision");
        table.AddColumn("marco-o1");
        table.AddColumn("qwq");
        ctx.Refresh();

        // add rows with the problems
        var simpleMathRowText = $"[bold][green]====Prompt: {promptMathSimple}====[/][/]";
        table.AddRow(new Markup(simpleMathRowText), new Markup(simpleMathRowText), new Markup(simpleMathRowText));
        ctx.Refresh();
        table.AddEmptyRow();
        table.AddEmptyRow();
        var complexMathRowText = $"[bold][green]====Prompt: {promptMathComplex}====[/][/]";
        table.AddRow(new Markup(complexMathRowText), new Markup(complexMathRowText), new Markup(complexMathRowText));
        table.AddEmptyRow();
        ctx.Refresh();

        AnalyzeModelForReasoning(ctx, table, 0, "llama3.2-vision", promptMathSimple, promptMathComplex).Wait();
        AnalyzeModelForReasoning(ctx, table, 1, "marco-o1", promptMathSimple, promptMathComplex).Wait();
        AnalyzeModelForReasoning(ctx, table, 1, "qwq", promptMathSimple, promptMathComplex).Wait();
    });

var html = AnsiConsole.ExportHtml();
File.WriteAllText("output.html", html);


static async Task AnalyzeModelForReasoning(LiveDisplayContext ctx, Table table, int columnIndex, string modelId, string promptMathSimple, string promptMathComplex)
{
    var chat = new OllamaChatClient(new Uri("http://localhost:11434/"), modelId);
    await ProcessPromptAsync(ctx, table, 1, columnIndex, chat, promptMathSimple);
    await ProcessPromptAsync(ctx, table, 4, columnIndex, chat, promptMathComplex);


}

static async Task ProcessPromptAsync(LiveDisplayContext ctx, Table table, int rowIndex, int columnIndex, OllamaChatClient chat, string prompt)
{
    var result = chat.CompleteStreamingAsync(prompt);
    var live_response = "";
    await foreach (var message in result)
    {
        live_response += message.Text;
        table.UpdateCell(rowIndex, columnIndex, new Text(live_response));
        ctx.Refresh();
    }
}
