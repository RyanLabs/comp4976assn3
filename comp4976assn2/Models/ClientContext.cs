using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace comp4976assn2.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext()
            : base("DefaultConnection")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ClientContext>());
        }

        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientModel> Clients { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.FiscalYearModel> FiscalYearModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.RiskLevelModel> RiskLevelModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.CrisisModel> CrisisModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.ServiceModel> ServiceModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.ProgramModel> ProgramModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.RiskStatusModel> RiskStatusModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.AssignedWorkerModel> AssignedWorkerModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.ReferralSourceModel> ReferralSourceModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.ReferralContactModel> ReferralContactModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.IncidentModel> IncidentModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.AbuserRelationshipModel> AbuserRelationshipModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.VictimOfIncidentModel> VictimOfIncidentModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.FamilyViolenceFileModel> FamilyViolenceFileModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.EthnicityModel> EthnicityModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.AgeModel> AgeModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.RepeatClientModel> RepeatClientModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.DuplicateFileModel> DuplicateFileModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.ClientEntity.FileStatusModel> FileStatusModels { get; set; }

        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.SexWorkExploitationModel> SexWorkExploitationModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.MultiplePerpetratorsModel> MultiplePerpetratorsModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.DrugFacilitatedAssaultModel> DrugFacilitatedAssaultModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.CityOfAssaultModel> CityOfAssaultModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.CityOfResidenceModel> CityOfResidenceModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.ReferringHospitalModel> ReferringHospitalModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.HospitalAttendedModel> HospitalAttendedModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.SocialWorkAttendanceModel> SocialWorkAttendanceModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.PoliceAttendanceModel> PoliceAttendanceModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.VictimServicesAttendanceModel> VictimServicesAttendanceModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.MedicalOnlyModel> MedicalOnlyModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.EvidenceStoredModel> EvidenceStoredModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.HIVMedsModel> HivMedsModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.ReferredToCBVSModel> ReferredToCbvsModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.PoliceReportedModel> PoliceReportedModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.ThirdPartyReportModel> ThirdPartyReportModels { get; set; }
        public System.Data.Entity.DbSet<comp4976assn2.Models.SmartEntity.BadDateReportModel> BadDateReportModels { get; set; }

    }
}