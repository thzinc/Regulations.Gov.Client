using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Regulations.Gov.Client.Tests
{
    [TestClass]
    public class WhenDownloadingDocuments
    {
        protected RegulationsGovClient _client;

        [TestInitialize]
        public void SetUp()
        {
            var apiKey = Environment.GetEnvironmentVariable("DATA_GOV_API_KEY") ?? "DEMO_KEY";
            _client = new RegulationsGovClient(apiKey);
        }

        [DataTestMethod]
        [DataRow("FAA-2017-0288-0013")]
        [DataRow("EPA-HQ-OAR-2017-0355-19547")]
        public async Task ShouldDownloadDocument(string documentId)
        {
            using (var download = await _client.GetDownload(documentId))
            {
                download.StatusCode.Should().Be(HttpStatusCode.OK);
                download.Content.Headers.TryGetValues("Content-Disposition", out var contentDispositions).Should().BeTrue();
                contentDispositions.Should().HaveCount(1)
                    .And.Subject.First().Should().StartWith("attachment; filename=");
            }
        }

        [DataTestMethod]
        [DataRow("EPA-HQ-OAR-2016-0510-0078", 1)]
        [DataRow("HHS-OCR-2018-0002-11079", 7)]
        public async Task ShouldDownloadAttachment(string documentId, int attachmentCount)
        {
            for (var i = 1; i <= attachmentCount; i++)
            {
                using (var download = await _client.GetDownload(documentId, attachmentNumber: 1))
                {
                    download.StatusCode.Should().Be(HttpStatusCode.OK);
                    download.Content.Headers.TryGetValues("Content-Disposition", out var contentDispositions).Should().BeTrue();
                    contentDispositions.Should().HaveCount(1)
                        .And.Subject.First().Should().StartWith("attachment; filename=");
                }
            }
        }
    }
}
