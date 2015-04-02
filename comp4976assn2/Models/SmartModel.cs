using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using comp4976assn2.Models.SmartEntity;

namespace comp4976assn2.Models
{
    public class SmartModel
    {
        [Key]
        public int ClientReferenceNumber { get; set; }
        public int AccompanimentMinutes { get; set; }
        public int NumberTransportsProvided { get; set; }
        public bool ReferredToNurse { get; set; }

        [ForeignKey("SexWorkExploitation")]
        public int SexWorkExploitationId { get; set; }
        public SexWorkExploitationModel SexWorkExploitation { get; set; }

        [ForeignKey("MultiplePerpetrators")]
        public int MultiplePerpetratorsId { get; set; }
        public MultiplePerpetratorsModel MultiplePerpetrators { get; set; }

        [ForeignKey("DrugFacilitatedAssault")]
        public int DrugFacilitatedAssaultId { get; set; }
        public DrugFacilitatedAssaultModel DrugFacilitatedAssault { get; set; }

        [ForeignKey("CityOfAssault")]
        public int CityOfAssaultId { get; set; }
        public CityOfAssaultModel CityOfAssault { get; set; }

        [ForeignKey("CityOfResidence")]
        public int CityOfResidenceId { get; set; }
        public CityOfResidenceModel CityOfResidence { get; set; }

        [ForeignKey("ReferringHospital")]
        public int ReferringHospitalid { get; set; }
        public ReferringHospitalModel ReferringHospital { get; set; }

        [ForeignKey("HospitalAttended")]
        public int HospitalAttendedId { get; set; }
        public HospitalAttendedModel HospitalAttended { get; set; }

        [ForeignKey("SocialWorkAttendance")]
        public int SocialWorkAttendanceId { get; set; }
        public SocialWorkAttendanceModel SocialWorkAttendance { get; set; }

        [ForeignKey("PoliceAttendance")]
        public int PoliceAttendanceId { get; set; }
        public PoliceAttendanceModel PoliceAttendance { get; set; }

        [ForeignKey("VictimServicesAttendance")]
        public int VictimServicesAttendanceId { get; set; }
        public VictimServicesAttendanceModel VictimServicesAttendance { get; set; }

        [ForeignKey("MedicalOnly")]
        public int MedicalOnlyId { get; set; }
        public MedicalOnlyModel MedicalOnly { get; set; }

        [ForeignKey("EvidenceStored")]
        public int EvidenceStoredId { get; set; }
        public EvidenceStoredModel EvidenceStored { get; set; }

        [ForeignKey("HivMeds")]
        public int HivMedsId { get; set; }
        public HIVMedsModel HivMeds { get; set; }

        [ForeignKey("ReferredToCbvs")]
        public int ReferredToCbvsId { get; set; }
        public ReferredToCBVSModel ReferredToCbvs { get; set; }

        [ForeignKey("PoliceReported")]
        public int PoliceReportedId { get; set; }
        public PoliceReportedModel PoliceReported { get; set; }

        [ForeignKey("ThirdPartyReport")]
        public int ThirdPartyReportId { get; set; }
        public ThirdPartyReportModel ThirdPartyReport { get; set; }

        [ForeignKey("BadDateReport")]
        public int BadDateReportId { get; set; }
        public BadDateReportModel BadDateReport { get; set; }

    }
}