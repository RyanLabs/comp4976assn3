using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using comp4976assn2.Models.ClientEntity;
using comp4976assn2.Models.SmartEntity;

namespace comp4976assn2.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ClientContext>());
        }

        public virtual DbSet<ClientModel> Clients { get; set; }
        public virtual DbSet<FiscalYearModel> FiscalYearModels { get; set; }
        public virtual DbSet<RiskLevelModel> RiskLevelModels { get; set; }
        public virtual DbSet<CrisisModel> CrisisModels { get; set; }
        public virtual DbSet<ServiceModel> ServiceModels { get; set; }
        public virtual DbSet<ProgramModel> ProgramModels { get; set; }
        public virtual DbSet<RiskStatusModel> RiskStatusModels { get; set; }
        public virtual DbSet<AssignedWorkerModel> AssignedWorkerModels { get; set; }
        public virtual DbSet<ReferralSourceModel> ReferralSourceModels { get; set; }
        public virtual DbSet<ReferralContactModel> ReferralContactModels { get; set; }
        public virtual DbSet<IncidentModel> IncidentModels { get; set; }
        public virtual DbSet<AbuserRelationshipModel> AbuserRelationshipModels { get; set; }
        public virtual DbSet<VictimOfIncidentModel> VictimOfIncidentModels { get; set; }
        public virtual DbSet<FamilyViolenceFileModel> FamilyViolenceFileModels { get; set; }
        public virtual DbSet<EthnicityModel> EthnicityModels { get; set; }
        public virtual DbSet<AgeModel> AgeModels { get; set; }
        public virtual DbSet<RepeatClientModel> RepeatClientModels { get; set; }
        public virtual DbSet<DuplicateFileModel> DuplicateFileModels { get; set; }
        public virtual DbSet<FileStatusModel> FileStatusModels { get; set; }

        public virtual DbSet<SmartModel> SmartModels { get; set; }
        public virtual DbSet<SexWorkExploitationModel> SexWorkExploitationModels { get; set; }
        public virtual DbSet<MultiplePerpetratorsModel> MultiplePerpetratorsModels { get; set; }
        public virtual DbSet<DrugFacilitatedAssaultModel> DrugFacilitatedAssaultModels { get; set; }
        public virtual DbSet<CityOfAssaultModel> CityOfAssaultModels { get; set; }
        public virtual DbSet<CityOfResidenceModel> CityOfResidenceModels { get; set; }
        public virtual DbSet<ReferringHospitalModel> ReferringHospitalModels { get; set; }
        public virtual DbSet<HospitalAttendedModel> HospitalAttendedModels { get; set; }
        public virtual DbSet<SocialWorkAttendanceModel> SocialWorkAttendanceModels { get; set; }
        public virtual DbSet<PoliceAttendanceModel> PoliceAttendanceModels { get; set; }
        public virtual DbSet<VictimServicesAttendanceModel> VictimServicesAttendanceModels { get; set; }
        public virtual DbSet<MedicalOnlyModel> MedicalOnlyModels { get; set; }
        public virtual DbSet<EvidenceStoredModel> EvidenceStoredModels { get; set; }
        public virtual DbSet<HIVMedsModel> HivMedsModels { get; set; }
        public virtual DbSet<ReferredToCBVSModel> ReferredToCbvsModels { get; set; }
        public virtual DbSet<PoliceReportedModel> PoliceReportedModels { get; set; }
        public virtual DbSet<ThirdPartyReportModel> ThirdPartyReportModels { get; set; }
        public virtual DbSet<BadDateReportModel> BadDateReportModels { get; set; }

    }
}