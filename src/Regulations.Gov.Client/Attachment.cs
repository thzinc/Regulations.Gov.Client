using System.Collections.Generic;

namespace Regulations.Gov.Client
{
    public class Attachment
    {
        public int AttachmentOrderNumber { get; set; }
        public List<string> FileFormats { get; set; }
        public string PostingRestriction { get; set; }
        public string ReasonRestricted { get; set; }
        public string AgencyNotes { get; set; }
        public string Author { get; set; }
        public string Abstract { get; set; }
        public string Title { get; set; }
    }

}
