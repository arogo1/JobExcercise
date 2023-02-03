using Excersice;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static async Task Main(string[] args)
    {
        //Setup DI
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ICalculation, Calculation>()
            .BuildServiceProvider();


        //Actual work
        try
        {
            var service = serviceProvider.GetService<ICalculation>();

            string JSONresponse = "{\n  \"Device\": \"Arista\",\n  \"Model\": \"X-Video\",\n  \"NIC\": [\n    {\n      \"Description\": \"Linksys ABR\",\n      \"MAC\": \"14:91:82:3C:D6:7D\",\n      \"Timestamp\": \"2020-03-23T18:25:43.511Z\",\n      \"Rx\": \"3698574500\",\n      \"Tx\": \"122558800\"\n    }\n  ]\n}";

            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseModel>(JSONresponse);

            var results = new Dictionary<string, Result>();

            foreach(var x in response.NIC)
            {
                var result = await service.DoCalculation(x);

                results.Add(x.MAC, result);
            }


            //Send result to somewhere, in our case we will just consolse it
            foreach(var x in results)
            {
                Console.WriteLine(x.Key);
                Console.WriteLine(x.Value.BitrateRx);
                Console.WriteLine(x.Value.BitrateTx);
                Console.WriteLine();
            }
        }
        catch(Exception ex)
        {
            //log exception to some logging service in my case will just console it
            Console.WriteLine(ex);
        }
        
    }
}



