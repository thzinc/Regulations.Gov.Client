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

        [TestMethod]
        public async Task ItShouldGetPublicSubmissions()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsBySubtype()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByDocket()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByCommentPeriod()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByFederalAgencies()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByPage()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByCommentPeriodDate()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByCreationDate()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByReceivedDate()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByPostedDate()
        {
            Assert.Inconclusive();
        }

        [TestMethod]
        public async Task ItShouldSortDocuments()
        {
            Assert.Inconclusive();
        }

    }
}
