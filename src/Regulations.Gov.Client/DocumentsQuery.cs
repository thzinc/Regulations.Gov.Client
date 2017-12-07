namespace Regulations.Gov.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DocumentsQuery : Dictionary<string, string[]>
    {
        public string Keywords
        {
            get
            {
                return string.Join(" ", this["s"] ?? new string[0]);
            }
            set
            {
                this["s"] = new[] { value };
            }
        }

        public DocumentType? Type
        {
            get
            {
                var dct = (this["dct"] ?? new string[0]).FirstOrDefault();
                if (dct == null) return null;

                switch (dct)
                {
                    case "N":
                        return DocumentType.Notice;
                    case "PR":
                        return DocumentType.ProposedRule;
                    case "R":
                        return DocumentType.Rule;
                    case "O":
                        return DocumentType.Other;
                    case "SR":
                        return DocumentType.SupportingAndRelatedMaterial;
                    case "PS":
                        return DocumentType.PublicSubmission;
                    default:
                        return null;
                }
            }
            set
            {
                switch (value)
                {
                    case DocumentType.Notice:
                        this["dct"] = new[] { "N" };
                        break;
                    case DocumentType.ProposedRule:
                        this["dct"] = new[] { "PR" };
                        break;
                    case DocumentType.Rule:
                        this["dct"] = new[] { "R" };
                        break;
                    case DocumentType.Other:
                        this["dct"] = new[] { "O" };
                        break;
                    case DocumentType.SupportingAndRelatedMaterial:
                        this["dct"] = new[] { "SR" };
                        break;
                    case DocumentType.PublicSubmission:
                        this["dct"] = new[] { "PS" };
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        public string Subtype { get; set; } // docst
        public string DocketId { get; set; } // dktid
        public string DocketType { get; set; } // dkt
        public string DocketSubtype { get; set; } // dktst
        public string DocketSubtype2 { get; set; } // dktst2
        public string CommentPeriod { get; set; } // cp
        public ISet<string> FederalAgencies { get; set; } // a
        public int? ResultsPerPage { get; set; } // rpp
        public int? PageOffset { get; set; } // po
        public int? CommentPeriodClosingSoon { get; set; } // cs
        public DateTimeOffset CommentPeriodStartDate { get; set; } // cmsd
        public DateTimeOffset CommentPeriodEndDate { get; set; } // cmd
        public int? NewlyPosted { get; set; } // np
        public DateTimeOffset CreationStartDate { get; set; } // crd
        public DateTimeOffset CreationEndDate { get; set; } // crd
        public DateTimeOffset ReceivedStartDate { get; set; } // rc
        public DateTimeOffset ReceivedEndDate { get; set; } // rc
        public DateTimeOffset PostedStartDate { get; set; } // pd
        public DateTimeOffset PostedEndDate { get; set; } // pd
        public string Category { get; set; } // cat
        public string SortBy { get; set; } // sb
        public string SortOrder { get; set; } // so
    }
}
