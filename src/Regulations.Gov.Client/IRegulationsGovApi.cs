using System;

namespace Regulations.Gov.Client
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Regulations.Gov.Client;
    using RestEase;

    public interface IRegulationsGovApi
    {
        [Get("regulations/v3/documents.json")]
        Task<DocumentsResult> GetDocuments(string api_key, [QueryMap]DocumentsQuery query);

        [Get("regulations/v3/document.json")]
        Task<Document> GetDocument(string api_key, string documentId);

        [Get("regulations/v3/docket.json")]
        Task<Docket> GetDocket(string api_key, string docketId);

        [Get("regulations/v3/download")]
        Task<HttpResponseMessage> GetDownload(string api_key, string documentId, string contentType = null, int? attachmentNumber = null);
    }
}
