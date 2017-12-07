using System;
using System.Collections.Generic;

namespace Regulations.Gov.Client
{
    public class Document
    {
        /// <summary>
        /// Some agencies will accept comments after the due date.
        /// </summary>
        public bool AllowLateComment { get; set; }

        /// <summary>
        /// Additional files associated with this document
        /// </summary>
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Date and time when the period for the public to comment ends.
        /// </summary>
        public DateTimeOffset CommentDueDate { get; set; }

        public DocumentReference CommentOnDoc { get; set; }

        /// <summary>
        /// Date and time when the period for the public to comment begins.
        /// </summary>
        public DateTimeOffset CommentStartDate { get; set; }

        /// <summary>
        /// Identifies whether the document is Posted on or Withdrawn from Regulations.gov.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The date, specified in the Federal Register, when a rule takes effect and is enforced.
        /// </summary>
        public DateTimeOffset EffectiveDate { get; set; }

        /// <summary>
        /// Formats of the document, included as URLs to download from the API
        /// </summary>
        public List<string> FileFormats { get; set; }

        /// <summary>
        /// The document is open for Comment. This value is recalculated daily based on the comment end date. If allowLateComment is true, then the comment remains open indefinitely.
        /// </summary>
        public bool OpenForComment { get; set; }

        /// <summary>
        /// The date a document was posted to Regulations.gov and made available for public view and comment.
        /// </summary>
        public DateTimeOffset PostedDate { get; set; }

        /// <summary>
        /// For a comment submitted through Regulations.gov, this marks the date a comment is submitted by the commenter.
        /// </summary>
        public DateTimeOffset ReceivedDate { get; set; }

        /// <summary>
        /// The number of pages in the document.
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// The first and last page numbers of the document.
        /// </summary>
        public string StartEndPage { get; set; }

        /// <summary>
        /// The detailed description of a document.
        /// </summary>
        public Field<string> Abstract { get; set; }

        /// <summary>
        /// An abbreviation of the agency name. Ex. EPA
        /// </summary>
        public Field<string> AgencyAcronym { get; set; }

        /// <summary>
        /// Full name of the Federal Agency.
        /// </summary>
        public Field<string> AgencyName { get; set; }

        /// <summary>
        /// Number of attachments associated with a document.
        /// </summary>
        public Field<int> AttachmentCount { get; set; }

        /// <summary>
        /// A Code of Federal Regulations (CFR) Citation Number exists for each regulation referring to the rules published in the Federal Register by executive departments and agencies of the Federal Government.
        /// </summary>
        public Field<string> Cfr { get; set; }

        /// <summary>
        /// The text of the submitter's comment.
        /// </summary>
        public Field<string> Comment { get; set; }

        /// <summary>
        /// A unique identifier established for a docket.
        /// </summary>
        public Field<string> DocketId { get; set; }

        /// <summary>
        /// A Docket Type is either Rulemaking or Nonrulemaking. A Rulemaking docket includes the type of regulation that establishes a rule. While a Nonrulemaking docket does not include a rule.
        /// </summary>
        public Field<string> DocketType { get; set; }

        /// <summary>
        /// A unique identifier established for a document.
        /// </summary>
        public Field<string> DocumentId { get; set; }

        /// <summary>
        /// A primary classification of a document.
        /// </summary>
        public Field<string> DocumentType { get; set; }

        /// <summary>
        /// A secondary classification of a document.
        /// </summary>
        public Field<string> DocumentSubtype { get; set; }

        /// <summary>
        /// The unique identifier of a document from the Federal Register (example FR Doc. E6-540).
        /// </summary>
        public Field<string> FederalRegisterNumber { get; set; }

        /// <summary>
        /// The Regulation Identifier Number (RIN) assigned to each regulation which allows it to be cross-referenced with the Regulatory Agenda.
        /// </summary>
        public Field<string> Rin { get; set; }

        /// <summary>
        /// The formal title of the document.
        /// </summary>
        public Field<string> Title { get; set; }

        public Field<string> TrackingNumber { get; set; }

        public Field<int> NumItemsRecieved { get; set; }
    }

}
