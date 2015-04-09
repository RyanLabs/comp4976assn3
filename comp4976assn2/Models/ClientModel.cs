using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using comp4976assn2.Models.ClientEntity;

namespace comp4976assn2.Models
{
    public class ClientModel
    {
        [DisplayName("Client Reference Number")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("SmartModel")]
        public int ClientReferenceNumber { get; set; }
        public SmartModel SmartModel { get; set; }

        [DisplayName("Fiscal Year")]
        [ForeignKey("FiscalYear")]
        public int FiscalId { get; set; }
        public virtual FiscalYearModel FiscalYear { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Month must be between 1 and 12")]
        public int Month { get; set; }

        [Required]
        [Range(1, 31, ErrorMessage = "Day must be between 1 and 31")]
        public int Day { get; set; }

        [Required]
        [StringLength(35)]
        [MaxLength(35, ErrorMessage = "Error maxlength")]
        //[RegularExpression("/^[a-zA-Z]+$/", ErrorMessage = "Invalid Surname (Letters only)")]
        public String Surname { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(35)]
        [MaxLength(35, ErrorMessage = "Error maxlength")]
        //[RegularExpression("/^[a-zA-Z]+$/", ErrorMessage = "Invalid Firstname (Letters only)")]
        public String Firstname { get; set; }

        [DisplayName("Police File Number")]
        [StringLength(8)]
        [MaxLength(8, ErrorMessage = "Error maxlength")]
        [RegularExpression(@"^\d{2}-\d{5}$", ErrorMessage = "Format: 99-99999 (example: 14-77852).")]
        public String PoliceFileNumber { get; set; } //Nullable

        [DisplayName("Court File Number")]
        public int? CourtFileNumber { get; set; } //Nullable

        [Required]
        [DisplayName("SWC File Number")]
        public int SwcFileNumber { get; set; }

        [DisplayName("Risk Level")]
        [ForeignKey("RiskLevel")]
        public int RiskLevelId { get; set; }
        public virtual RiskLevelModel RiskLevel { get; set; }

        [DisplayName("Crisis")]
        [ForeignKey("Crisis")]
        public int CrisisId { get; set; }
        public virtual CrisisModel Crisis { get; set; }


        [DisplayName("Service")]
        [ForeignKey("Service")]
        public int ServiceId { get; set; }
        public virtual ServiceModel Service { get; set; }

        [DisplayName("Program")]
        [ForeignKey("Program")]
        public int ProgramId { get; set; }
        public virtual ProgramModel Program { get; set; }

        [Required]
        [DisplayName("Risk Assessment Assigned To")]
        [StringLength(70)]
        [MaxLength(70, ErrorMessage = "Error maxlength")]
        public String RiskAssessmentAssignedTo { get; set; }

        [DisplayName("Risk Status")]
        [ForeignKey("RiskStatus")]
        public int RiskStatusId { get; set; }
        public virtual RiskStatusModel RiskStatus { get; set; }

        [DisplayName("Assigned Worker")]
        [ForeignKey("AssignedWorker")]
        public int AssignedWorkerId { get; set; }
        public virtual AssignedWorkerModel AssignedWorker { get; set; }

        [DisplayName("Referral Source")]
        [ForeignKey("ReferralSource")]
        public int ReferralSourceId { get; set; }
        public virtual ReferralSourceModel ReferralSource { get; set; }

        [DisplayName("Referral Contact")]
        [ForeignKey("ReferralContact")]
        public int ReferralContactId { get; set; }
        public virtual ReferralContactModel ReferralContact { get; set; }

        [DisplayName("Incident")]
        [ForeignKey("Incident")]
        public int IncidentId { get; set; }
        public virtual IncidentModel Incident { get; set; }

        [Required]
        [DisplayName("Abuser Surname, First Name")]
        //[RegularExpression(@"^([A-Za-z]+),\\s+([A-Za-z]+)$", ErrorMessage = "Format: Surname, First Name")]
        public String AbuserName { get; set; }

        [DisplayName("Abuser Relationship")]
        [ForeignKey("AbuserRelationship")]
        public int AbuserRelationshipId { get; set; }
        public virtual AbuserRelationshipModel AbuserRelationship { get; set; }

        [DisplayName("Victim Of Incident")]
        [ForeignKey("VictimOfIncident")]
        public int VictimOfIncidentId { get; set; }
        public virtual VictimOfIncidentModel VictimOfIncident { get; set; }

        [DisplayName("Family Violence File")]
        [ForeignKey("FamilyViolenceFile")]
        public int FamilyViolenceFileId { get; set; }
        public virtual FamilyViolenceFileModel FamilyViolenceFile { get; set; }

        [Required]
        [MaxLength(1, ErrorMessage = "Error maxlength")]
        [StringLength(1)]
        [RegularExpression(@"^M|m|F|f|T|t$", ErrorMessage = "M or F or T (Trans)")]
        public string Gender { get; set; }

        [DisplayName("Ethnicity")]
        [ForeignKey("Ethnicity")]
        public int EthnicityId { get; set; }
        public EthnicityModel Ethnicity { get; set; }

        [DisplayName("Age")]
        [ForeignKey("Age")]
        public int AgeId { get; set; }
        public AgeModel Age { get; set; }

        [DisplayName("Repeat Client")]
        [ForeignKey("RepeatClient")]
        public int RepeatClientId { get; set; }
        public RepeatClientModel RepeatClient { get; set; }

        [DisplayName("Duplicate File")]
        [ForeignKey("DuplicateFile")]
        public int DuplicateFileId { get; set; }
        public DuplicateFileModel DuplicateFile { get; set; }

        [DisplayName("Number of Children (Age 0-6)")]
        public int NumberChildren6 { get; set; }

        [DisplayName("Number of Children (Age 7-12)")]
        public int NumberChildren12 { get; set; }

        [DisplayName("Number of Children (Age 13-18)")]
        public int NumberChildren18 { get; set; }

        [DisplayName("File Status")]
        [ForeignKey("FileStatus")]
        public int FileStatusId { get; set; }
        public virtual FileStatusModel FileStatus { get; set; }

        [DisplayName("Date Last Transferred")]
        [DataType(DataType.Date, ErrorMessage = "Data type")]
        public DateTime DateLastTransfered { get; set; }

        [DisplayName("Date Closed")]
        [DataType(DataType.Date, ErrorMessage = "Data type")]
        public DateTime DateClosed { get; set; }

        [DisplayName("Date Re-opened")]
        [DataType(DataType.Date, ErrorMessage = "Data type")]
        public DateTime DateReopened { get; set; }

    }
}