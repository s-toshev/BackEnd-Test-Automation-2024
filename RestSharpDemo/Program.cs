using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace RestSharpDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //firstDemo

            //var client = new RestClient("http://api.github.com");

            //var request = new RestRequest("/users/softuni/repos", Method.Get);

            //var response = client.Execute(request);
            //Console.WriteLine(response.StatusCode);
            //Console.WriteLine(response.Content);

            //secondDemo
            // var client = new RestClient("http://api.github.com");

            //var request = new RestRequest("/repos/{user}/{repo}/issues/{id}", Method.Get);

            //request.AddUrlSegment("user", "testnakov");
            //request.AddUrlSegment("repo", "test-nakov-repo");
            //request.AddUrlSegment("id", "1");

            //var response = client.Execute(request);


            //Console.WriteLine(response.StatusCode);
            //Console.WriteLine(response.Content);


            //deserializing JSON responses

            // var client = new RestClient("http://api.github.com");

            // var request = new RestRequest("/users/softuni/repos", Method.Get);

            // var response = client.Execute(request);

            // var repoObjects = JsonConvert.DeserializeObject<List<Repo>>(response.Content);

            //foreach (var item in repoObjects)
            // {
            //     Console.WriteLine(item.full_name + " " + item.html_url + " " + item.Id);
            // }

            //github token auth demo:
            //token = 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

            var client = new RestClient(new RestClientOptions("https://api.github.com")
            {
                Authenticator = new HttpBasicAuthenticator("s-toshev", "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")
            });

            var request = new RestRequest
 ("/repos/s-toshev/sample-repo-13-jun-2023", Method.Post);

            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(new { title = "TestingIssue", body = "Body" });

            var response = client.Execute(request);

            Console.WriteLine(response.StatusCode);
        }
    }
}
