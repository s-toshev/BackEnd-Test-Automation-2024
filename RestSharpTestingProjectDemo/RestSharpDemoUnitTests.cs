using RestSharp.Authenticators;
using RestSharp;
using System.Net;
using Newtonsoft.Json;

namespace RestSharpTestingProjectDemo
{
    public class Tests
    {
        private RestClient _client;

        [SetUp]
        public void Setup()
        {

            var options = new RestClientOptions("https://api.github.com")
            {
                MaxTimeout = 3000,

                Authenticator = new HttpBasicAuthenticator("s-toshev", "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")

            };

            _client = new RestClient(options);
        }

        [Test]
        public void Test_GitGetIssuesEndpoint()
        {
            //Arrange

            var request = new RestRequest
             ("/repos/s-toshev/sample-repo-13-jun-2023", Method.Get);

            //can set different timeout per test:

            request.Timeout = 1000;

            //Act
            var response = _client.Execute(request);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);


        }

        [Test]
        public void Test_GitGetIssuesEndpoint_MoreValidation()
        {
            //Arrange

            var request = new RestRequest
             ("/repos/testnakov/test-nakov-repo/issues", Method.Get);

            //Act
            var response = _client.Execute(request);

            var issuesObj = JsonConvert.DeserializeObject<List<Issue>>(response.Content);   

            //Assert
            //toDo


        }



        [Test]
        public void Test_GitPostMethod()
        {



            //Arrange&Act
            var createdIssue = CreateIssue("IssueTetst123", "BodyTest21343");

            //Assert
            Assert.AreEqual("IssueTetst123", createdIssue.Title);
            Assert.AreEqual("BodyTest21343", createdIssue.Body);
            

        }

        [Test]
        public void Test()
        {
            //ToDo


            //Arrange

            //Act

            //Assert


        }


        private Issue CreateIssue(string title, string body)
        {

            var request = new RestRequest
             ("/repos/testnakov/test-nakov-repo/issues", Method.Post);

            request.AddBody(new { body, title });

            var response = _client.Execute(request);

            var issuesObj = JsonConvert.DeserializeObject<Issue>(response.Content);

            return issuesObj;
        }

        [TestCase()]
        [TestCase()]
        [TestCase()]
        [TestCase()]

        public void Test_ZippopotamUS()
        {
            //Arrange



            //Act


            //Assert 



        }


        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Place
        {
            [JsonProperty("place name")]
            public string placename { get; set; }
            public string longitude { get; set; }
            public string state { get; set; }

            [JsonProperty("state abbreviation")]
            public string stateabbreviation { get; set; }
            public string latitude { get; set; }
        }

        public class Root
        {
            [JsonProperty("post code")]
            public string postcode { get; set; }
            public string country { get; set; }

            [JsonProperty("country abbreviation")]
            public string countryabbreviation { get; set; }
            public List<Place> places { get; set; }
        }



    }
}