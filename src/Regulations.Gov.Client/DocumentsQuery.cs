namespace Regulations.Gov.Client
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DocumentsQuery : Dictionary<string, string[]>
    {
        private string GetString(string key)
        {
            if (this.TryGetValue(key, out var values)) return string.Join(" ", values);

            return null;
        }

        private T? GetEnumValue<T>(string key)
            where T : struct
        {
            if (Enum.TryParse(GetString(key), out T value)) return value;

            return null;
        }

        private int? GetInt(string key)
        {
            if (int.TryParse(GetString(key), out var value)) return value;

            return null;
        }

        private DateTimeOffset? GetDateTimeOffset(string key)
        {
            if (DateTimeOffset.TryParse(GetString(key), out var value)) return value;

            return null;
        }

        private void Set(string key, string value)
        {
            this[key] = new[] { value };
        }

        private const string _keyword = "s";
        public string Keywords
        {
            get => GetString(_keyword);
            set => Set(_keyword, value);
        }

        private const string _type = "dct";
        public DocumentType? Type
        {
            get
            {
                switch (GetString(_type))
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
                        Set(_type, "N");
                        break;
                    case DocumentType.ProposedRule:
                        Set(_type, "PR");
                        break;
                    case DocumentType.Rule:
                        Set(_type, "R");
                        break;
                    case DocumentType.Other:
                        Set(_type, "O");
                        break;
                    case DocumentType.SupportingAndRelatedMaterial:
                        Set(_type, "SR");
                        break;
                    case DocumentType.PublicSubmission:
                        Set(_type, "PS");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        private const string _subtype = "docst";
        public string Subtype
        {
            get => GetString(_subtype);
            set => Set(_subtype, value);
        }

        private const string _docketId = "dktid";
        public string DocketId
        {
            get => GetString(_docketId);
            set => Set(_docketId, value);
        }

        private const string _commentPeriod = "cp";
        public CommentPeriodStatus? CommentPeriod
        {
            get => GetEnumValue<CommentPeriodStatus>(_commentPeriod);
            set => Set(_commentPeriod, ((char)value).ToString());
        }

        private const string _federalAgencies = "a";
        public ISet<string> FederalAgencies
        {
            get => new HashSet<string>(this[_federalAgencies]);
            set => Set(_federalAgencies, string.Join("+", value));
        }

        private const string _resultsPerPage = "rpp";
        public int? ResultsPerPage
        {
            get => GetInt(_resultsPerPage);
            set => Set(_resultsPerPage, $"{value}");
        }

        private const string _pageOffset = "po";
        public int? PageOffset
        {
            get => GetInt(_pageOffset);
            set => Set(_pageOffset, $"{value}");
        }
        public int? CommentPeriodClosingSoon { get; set; } // cs

        private const string _commentPeriodStartDate = "cmsd";
        public DateTimeOffset? CommentPeriodStartDate
        {
            get => GetDateTimeOffset(_commentPeriodStartDate);
            set => Set(_commentPeriodStartDate, $"{value:MM/dd/yy}");
        }

        private const string _commentPeriodEndDate = "cmd";
        public DateTimeOffset? CommentPeriodEndDate 
        {
            get => GetDateTimeOffset(_commentPeriodEndDate);
            set => Set(_commentPeriodEndDate, $"{value:MM/dd/yy}");
        }

        private const string _sortBy = "sb";
        public SortFields? SortBy
        {
            get
            {
                switch (GetString(_sortBy))
                {
                    case "docketId":
                        return SortFields.DocketId;
                    case "docId":
                        return SortFields.DocId;
                    case "title":
                        return SortFields.Title;
                    case "postedDate":
                        return SortFields.PostedDate;
                    case "agency":
                        return SortFields.Agency;
                    case "documentType":
                        return SortFields.DocumentType;
                    case "submitterName":
                        return SortFields.SubmitterName;
                    case "organization":
                        return SortFields.Organization;
                    default:
                        return null;
                }
            }
            set
            {
                switch (value)
                {
                    case SortFields.DocketId:
                        Set(_sortBy, "docketId");
                        break;
                    case SortFields.DocId:
                        Set(_sortBy, "docId");
                        break;
                    case SortFields.Title:
                        Set(_sortBy, "title");
                        break;
                    case SortFields.PostedDate:
                        Set(_sortBy, "postedDate");
                        break;
                    case SortFields.Agency:
                        Set(_sortBy, "agency");
                        break;
                    case SortFields.DocumentType:
                        Set(_sortBy, "documentType");
                        break;
                    case SortFields.SubmitterName:
                        Set(_sortBy, "submitterName");
                        break;
                    case SortFields.Organization:
                        Set(_sortBy, "organization");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }
        private const string _sortOrder = "so";
        public SortOrderType? SortOrder
        {
            get
            {
                switch (GetString(_sortOrder))
                {
                    case "ASC":
                        return SortOrderType.Ascending;
                    case "DESC":
                        return SortOrderType.Descending;
                    default:
                        return null;
                }
            }
            set
            {
                switch (value)
                {
                    case SortOrderType.Ascending:
                        Set(_sortOrder, "ASC");
                        break;
                    case SortOrderType.Descending:
                        Set(_sortOrder, "DESC");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(value));
                }
            }
        }

        // Other query options:
        // public string DocketType { get; set; } // dkt
        // public string DocketSubtype { get; set; } // dktst
        // public string DocketSubtype2 { get; set; } // dktst2
        // public int? NewlyPosted { get; set; } // np
        // public DateTimeOffset? CreationStartDate { get; set; } // crd
        // public DateTimeOffset? CreationEndDate { get; set; } // crd
        // public DateTimeOffset? ReceivedStartDate { get; set; } // rc
        // public DateTimeOffset? ReceivedEndDate { get; set; } // rc
        // public DateTimeOffset? PostedStartDate { get; set; } // pd
        // public DateTimeOffset? PostedEndDate { get; set; } // pd
        // public string Category { get; set; } // cat

    }
}
