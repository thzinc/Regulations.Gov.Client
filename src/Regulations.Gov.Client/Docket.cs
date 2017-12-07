using System.Collections.Generic;

namespace Regulations.Gov.Client
{
    public class Docket
    {
        /// <summary>
        /// A government entity that publishes rules or notices in the Federal Register.
        /// </summary>
        public string Agency { get; set; }

        /// <summary>
        /// An abbreviation of the agency name.
        /// </summary>
        public string AgencyAcronym { get; set; }

        /// <summary>
        /// Each entry in the Agenda is associated with one of the following stages: Prerule, Proposed Rule, Final Rule, Long-Term Actions, and Completed Actions.
        /// </summary>
        public string AgendaStageOfRulemaking { get; set; }

        /// <summary>
        /// The section(s) of the Code of Federal Regulations (CFR) that will be affected by the action.
        /// </summary>
        public string CfrCitation { get; set; }

        // /// <summary>
        // /// The agency representative who will answer questions about the rulemaking.
        // /// </summary>
        // public List<object> Contact { get; set; }

        /// <summary>
        /// A unique identifier established for a docket.
        /// </summary>
        public string DocketId { get; set; }

        /// <summary>
        /// An indication of whether or not the agency has prepared or plans to prepare a Statement of Energy Effects for the action, as required by Executive Order 13211 "Actions Concerning Regulations That Significantly Affect Energy Supply, Distribution, or Use," signed May 18, 2001 (66 FR 28355).
        /// </summary>
        public string EnergyEffects { get; set; }

        /// <summary>
        /// An indication of whether or not the action has "federalism implications" as defined in Executive Order 13132. This term refers to actions "that have substantial direct effects on the States, on the relationship between the national government and the States, or on the distribution of power and responsibilities among the various levels of government."
        /// </summary>
        public string FederalismImplications { get; set; }

        /// <summary>
        /// An indication of whether or not the action is expected to affect levels of government and, if so, whether the governments are State, local, tribal, or Federal.
        /// </summary>
        public string GovernmentLevelsAffected { get; set; }

        /// <summary>
        /// A summary of expected impacts and effects of the rulemaking action, including Energy, International, and Small Entities.
        /// </summary>
        public string ImpactsAndEffects { get; set; }

        /// <summary>
        /// An indication of whether or not the rulemaking was included in the agency's current regulatory plan published in the fall of any given year.
        /// </summary>
        public string IncludedInRegulatoryPlan { get; set; }

        /// <summary>
        /// An indication of whether or not the regulation is expected to have international trade and investment effects, or otherwise may be of interest to the Nation's international trading partners.
        /// </summary>
        public string InternationalImpacts { get; set; }

        /// <summary>
        /// The section(s) of the United States Code (U.S.C.) or Public Law (Pub. L.) or the Executive Order (E.O.) that authorize(s) the regulatory action.
        /// </summary>
        public string LegalAuthorities { get; set; }

        /// <summary>
        /// An indication of whether or not the action is subject to a statutory or judicial deadline, the date of that deadline, and whether the deadline pertains to an NPRM, a Final Action, or some other action.
        /// </summary>
        public string LegalDeadlines { get; set; }

        /// <summary>
        /// An indication of whether or not the rule is "major" under 5 U.S.C. 801 (Pub. L. 104-121) because it has resulted or is likely to result in an annual effect on the economy of $100 million or more or meets other criteria specified in that Act.
        /// </summary>
        public string MajorRule { get; set; }

        /// <summary>
        /// This count refers to the total comments received on this docket, as of 11:59 PM yesterday, from Regulations.gov and alternate means.
        /// </summary>
        public string NumberOfComments { get; set; }

        /// <summary>
        /// Some agencies are aligned to a department within the Executive branch.
        /// </summary>
        public string ParentAgency { get; set; }

        /// <summary>
        /// An abbreviation of the department name.
        /// </summary>
        public string ParentAgencyAcronym { get; set; }

        /// <summary>
        /// An indication of the significance of the regulation. Agencies assign each entry to one of the following: Economically Significant; Other Significant; Substantive, Nonsignificant; Routine and Frequent; and Informational/Administrative/Other.
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Specific month and year that the rulemaking action is published in the Unified Agenda.
        /// </summary>
        public string PublicationPeriod { get; set; }

        /// <summary>
        /// One or more past or current Dockets associated with activity related to this action.
        /// </summary>
        public string RelatedDockets { get; set; }

        /// <summary>
        /// One or more past or current RIN(s) associated with activity related to this action, such as merged RINs, split RINs, new activity for previously completed RINs, or duplicate RINs.
        /// </summary>
        public string RelatedRins { get; set; }

        /// <summary>
        /// An indication of whether or not an analysis is required by the Regulatory Flexibility Act (5 U.S.C. 601 et seq.) because the rulemaking action is likely to have a significant economic impact on a substantial number of small entities as defined by the Act.
        /// </summary>
        public string RequiresRegulatoryFlexibilityAnalysis { get; set; }

        /// <summary>
        /// The number assigned to each regulation that allows it to be cross-referenced with the Regulatory Agenda. Only applies to 'Rulemaking' dockets.
        /// </summary>
        public string Rin { get; set; }

        /// <summary>
        /// The types of small entities (businesses, governmental jurisdictions, or organizations) on which the rulemaking action is likely to have an impact as defined by the Regulatory Flexibility Act.
        /// </summary>
        public string SmallEntitiesAffected { get; set; }

        // /// <summary>
        // /// Listed by dates and citations (if available), all past steps and a projected date for at least the next step for the regulatory action.
        // /// </summary>
        // public List<object> TimeTables { get; set; }

        /// <summary>
        /// Formal title of the docket.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Docket Type (Rulemaking or Nonrulemaking)
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// An indication of whether or not the rule is covered by section 202 of the Unfunded Mandates Reform Act of 1995 (Pub. L. 104-4).
        /// </summary>
        public string UnfundedMandates { get; set; }
    }

}
