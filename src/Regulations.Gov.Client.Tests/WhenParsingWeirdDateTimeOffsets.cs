using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System;
using Newtonsoft.Json;

namespace Regulations.Gov.Client.Tests
{
    [TestClass]
    public class WhenParsingWeirdDateTimeOffsets
    {
        [TestMethod]
        public void ParseWellFormedDate()
        {
            var json = @"
            {
                ""postedDate"": ""2016-10-28T00:00:00-04:00""
            }
            ";
            var document = JsonConvert.DeserializeObject<DocumentStub>(json);
            document.PostedDate.Should().Be(DateTimeOffset.Parse("2016-10-28T00:00:00-04:00"));
        }

        [TestMethod]
        public void ParsePoorlyFormedDate()
        {
            var json = @"
            {
                ""postedDate"": ""1821-05-24T00:00:00-04:56:02""
            }
            ";
            var document = JsonConvert.DeserializeObject<DocumentStub>(json);
            document.PostedDate.Should().Be(DateTimeOffset.Parse("1821-05-24T00:00:00-04:56"));
        }
    }
}
