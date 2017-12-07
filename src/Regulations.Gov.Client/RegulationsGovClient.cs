using System.Threading.Tasks;
using RestEase;

namespace Regulations.Gov.Client
{
    public class RegulationsGovClient
    {
        private readonly IRegulationsGovApi _client;
        private readonly string _apiKey;
        public RegulationsGovClient(string apiKey)
        {
            _client = RestClient.For<IRegulationsGovApi>("https://api.data.gov");
            _apiKey = apiKey;
        }

        public Task<DocumentsResult> GetDocuments(DocumentsQuery query)
        {
            return _client.GetDocuments(_apiKey, query);
        }
        
        public Task<Document> GetDocument(string documentId)
        {
            return _client.GetDocument(_apiKey, documentId);
        }
        
        public Task<Docket> GetDocket(string docketId)
        {
            return _client.GetDocket(_apiKey, docketId);
        }
    }
}
