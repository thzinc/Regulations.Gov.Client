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
    }
}
