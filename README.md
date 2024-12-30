# .NET and Local Reasoning Models Sample

This sample Blazor application demonstrates how to integrate and run local reasoning models using [Ollama](https://ollama.com/) in a .NET application. The application compares the outputs of a standard model, and two different reasoning models when solving mathematical problems.

## Reasoning Models

Reasoning models are designed to enhance the logical reasoning capabilities of AI models. Unlike standard Large Language Models (LLMs) like GPT-4, which are trained on extensive general text data, reasoning models focus on logical deduction, mathematical computations, and understanding complex relationships.

For more information on reasoning models, you can read articles like [this one](https://techcrunch.com/2024/12/14/reasoning-ai-models-have-become-a-trend-for-better-or-worse/).

### Differences with Standard LLMs

- **Enhanced Logical Reasoning**: Reasoning models excel at tasks requiring logical thinking and problem-solving.

- **Specialized Training**: They are trained on datasets emphasizing reasoning and deduction rather than on general language data.

- **Improved Problem-Solving**: They handle complex computations and reasoning tasks more effectively than standard LLMs.

## Prerequisites

To run this sample, you will need:

1. **.NET 9 SDK**: Ensure you have the [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) installed.

1. **Blazor**: No additional setup is required beyond installing the .NET SDK.

1. **Ollama**: Install Ollama by following the instructions on the [Ollama website](https://ollama.ai/).

1. **Reasoning Models**: Install the following reasoning models using Ollama:

   - [llama3.2-vision](https://ollama.com/library/llama3.2-vision)
   - [marco-o1](https://ollama.com/library/marco-o1)
   - [qwq](https://ollama.com/library/qwq)

   Use the following commands to download the models:

   ```bash
   ollama pull llama3.2-vision
   ollama pull marco-o1
   ollama pull qwq
   ```   

## Running the Application

1. **Clone the Repository**: Clone this repository to your local machine.

2. **Navigate to the Project Directory**:

3. **Start Ollama**: Ensure that Ollama is running.

4. **Run the Application**

5. **Access the Application**: Open your web browser and navigate to `https://localhost:5001` or the URL provided in the console output.

## Application Functionality

The application presents a web page where you can compare the responses of different reasoning models to predefined mathematical problems.

### Features

- **Model Comparison**: Start each model individually by clicking the **Start** button next to the model's name.
- **Mathematical Problems**:
  - **Simple Problem**: *"Please solve 2 + 3"*
  - **Complex Problem**: *"Which is bigger, 9.9 or 9.11?"*
- **Live Responses**: The responses from each model are displayed live in the table.
- **Elapsed Time**: A notification shows the elapsed time during processing.

## Understanding the Code

The main functionality is implemented in the `Home.razor` component.

- **Models Interaction**: Uses `OllamaChatClient` to interact with local models.
- **Asynchronous Processing**: Processes prompts asynchronously and updates the UI with live responses.
- **Notification System**: Displays notifications and elapsed time during processing.

## Conclusion

This sample demonstrates how to integrate local reasoning models into a .NET Blazor application using Ollama. Running models locally provides control over data privacy and leverages specialized models for enhanced reasoning capabilities.

## References

- [Ollama Documentation](https://ollama.ai/docs)
- [Reasoning AI Models Trend](https://techcrunch.com/2024/12/14/reasoning-ai-models-have-become-a-trend-for-better-or-worse/)
