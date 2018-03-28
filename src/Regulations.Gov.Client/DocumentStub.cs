using System;
using Newtonsoft.Json;

namespace Regulations.Gov.Client
{
    public class DocumentStub
    {
        public string AgencyAcronym { get; set; }
        public bool AllowLateComment { get; set; }
        public int AttachmentCount { get; set; }
        [JsonConverter(typeof(WeirdDateTimeOffsetConverter))]
        public DateTimeOffset? CommentDueDate { get; set; }
        [JsonConverter(typeof(WeirdDateTimeOffsetConverter))]
        public DateTimeOffset? CommentStartDate { get; set; }
        public string CommentText { get; set; }
        public string DocketId { get; set; }
        public string DocketTitle { get; set; }
        public string DocketType { get; set; }
        public string DocumentId { get; set; }
        public string DocumentStatus { get; set; }
        public string DocumentType { get; set; }
        public int NumberOfCommentsReceived { get; set; }
        public bool OpenForComment { get; set; }
        [JsonConverter(typeof(WeirdDateTimeOffsetConverter))]
        public DateTimeOffset? PostedDate { get; set; }
        public string Title { get; set; }
    }
}
