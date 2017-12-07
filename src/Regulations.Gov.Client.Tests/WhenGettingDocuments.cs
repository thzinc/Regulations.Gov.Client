using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Regulations.Gov.Client.Tests
{
    [TestClass]
    public class WhenGettingDocuments
    {
        protected RegulationsGovClient _client;

        [TestInitialize]
        public void SetUp()
        {
            _client = new RegulationsGovClient("DEMO_KEY");
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByType()
        {
            var query = new DocumentsQuery
            {
                Type = DocumentType.ProposedRule,
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should()
                .NotBeNullOrEmpty()
                .And.OnlyContain(document => document.DocumentType == "Proposed Rule");
        }
    }
}
