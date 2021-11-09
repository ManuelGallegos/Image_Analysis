using System;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;


namespace ImageAnalysis
{

    /// <summary>
    /// A short demo to test the Computer Vision API
    /// <see cref="https://github.com/Azure-Samples/cognitive-services-quickstart-code/blob/master/dotnet/ComputerVision/ComputerVisionQuickstart.cs"/>
    /// </summary>

    class Program
    {

        static string subscriptionKey = "XXXXXXX";
        static string endpoint = "https://mycompvision1.cognitiveservices.azure.com/";

        //image url
        private const string imgURL = "https://docs.microsoft.com/en-us/learn/wwl-data-ai/analyze-images-computer-vision/media/woman-roof.png";


        static void Main(string[] args)
        {
            Console.WriteLine("Azure Image Analysis Demo");
            Console.WriteLine();

            ComputerVisionClient client = AuthenticatedClient(endpoint, subscriptionKey);

            ImageInterpretation.AnalyzeImageFromUrl(client, imgURL).Wait();

            Console.WriteLine("..............................");
            Console.WriteLine();
            Console.WriteLine("Image Analysis is Complete");
            Console.WriteLine();
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static ComputerVisionClient AuthenticatedClient(string endpoint, string subscriptionKey)
        {
            ApiKeyServiceClientCredentials clientCredentials = new ApiKeyServiceClientCredentials(subscriptionKey);
            return new ComputerVisionClient(clientCredentials){ Endpoint = endpoint};
        }
    }
}
