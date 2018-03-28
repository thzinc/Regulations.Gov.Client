using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using System.Collections.Generic;

namespace Regulations.Gov.Client.Tests
{
    [TestClass]
    public class WhenGettingDocuments
    {
        protected RegulationsGovClient _client;

        [TestInitialize]
        public void SetUp()
        {
            var apiKey = Environment.GetEnvironmentVariable("DATA_GOV_API_KEY") ?? "DEMO_KEY";
            _client = new RegulationsGovClient(apiKey);
        }

        [TestMethod]
        public async Task ItShouldGetPublicSubmissions()
        {
            var query = new DocumentsQuery
            {
                Type = DocumentType.PublicSubmission,
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should()
                .NotBeNullOrEmpty()
                .And.OnlyContain(document => document.DocumentType == "Public Submission");
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByDocket()
        {
            var query = new DocumentsQuery
            {
                DocketId = "DOI-2017-0002",
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should()
                .NotBeNullOrEmpty()
                .And.OnlyContain(document => document.DocketId == "DOI-2017-0002")
                .And.OnlyContain(document => document.DocumentId.StartsWith("DOI-2017-0002-"));
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByOpenCommentPeriod()
        {
            var query = new DocumentsQuery
            {
                CommentPeriod = CommentPeriodStatus.Open,
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should()
                .NotBeNullOrEmpty()
                .And.OnlyContain(document => document.CommentStartDate <= DateTimeOffset.Now && DateTimeOffset.Now <= document.CommentDueDate);
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByClosedCommentPeriod()
        {
            var query = new DocumentsQuery
            {
                CommentPeriod = CommentPeriodStatus.Closed,
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should()
                .NotBeNullOrEmpty()
                .And.NotContain(document => document.CommentStartDate <= DateTimeOffset.Now && DateTimeOffset.Now <= document.CommentDueDate);
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByFederalAgencies()
        {
            var query = new DocumentsQuery
            {
                FederalAgencies = new HashSet<string>
                {
                    "DOI",
                    "EPA"
                },
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should()
                .NotBeNullOrEmpty()
                .And.OnlyContain(document => document.AgencyAcronym == "DOI" || document.AgencyAcronym == "EPA");
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByPage()
        {
            var query = new DocumentsQuery
            {
                DocketId = "DOI-2017-0002",
                ResultsPerPage = 10,
                PageOffset = 10,
                SortBy = SortFields.DocId,
                SortOrder = SortOrderType.Ascending,
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should().NotBeNullOrEmpty();
            string lastDocumentId = null;
            foreach (var document in results.Documents)
            {
                string.CompareOrdinal(lastDocumentId, document.DocumentId).Should()
                    .Be(-1, $"Last document ID {lastDocumentId} should be before {document.DocumentId}");
            }
        }

        [TestMethod]
        public async Task ItShouldGetReallyOldDocuments()
        {
            var query = new DocumentsQuery
            {
                ResultsPerPage = 10,
                PageOffset = 0,
                SortBy = SortFields.PostedDate,
                SortOrder = SortOrderType.Ascending,
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should().NotBeNullOrEmpty();
            string lastDocumentId = null;
            foreach (var document in results.Documents)
            {
                document.PostedDate.Should().BeOnOrBefore(DateTimeOffset.Parse("1900-04-10T00:00:00-05:00"));
                string.CompareOrdinal(lastDocumentId, document.DocumentId).Should()
                    .Be(-1, $"Last document ID {lastDocumentId} should be before {document.DocumentId}");
            }
        }

        [TestMethod]
        [Ignore("CommentPeriodStartDate (cmsd) appears to not work in Regulations.gov API")]
        public async Task ItShouldGetDocumentsByCommentPeriodStartDate()
        {
            var startDate = DateTimeOffset.Parse("2017-01-01");
            var query = new DocumentsQuery
            {
                CommentPeriodStartDate = startDate,
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should()
                .NotBeNullOrEmpty()
                .And.OnlyContain(document => document.CommentStartDate >= startDate);
        }

        [TestMethod]
        public async Task ItShouldGetDocumentsByCommentPeriodEndDate()
        {
            var endDate = DateTimeOffset.Parse("2017-01-01T00:00:00-08:00");
            var query = new DocumentsQuery
            {
                CommentPeriodEndDate = endDate,
            };
            var results = await _client.GetDocuments(query);
            results.Should().NotBeNull();
            results.Documents.Should()
                .NotBeNullOrEmpty()
                .And.OnlyContain(document => document.CommentDueDate.HasValue && endDate >= document.CommentDueDate.Value.Date);
        }
    }
}
