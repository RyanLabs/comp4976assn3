using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comp4976assn2.Models;

namespace comp4976assn2.Controllers
{
    [Authorize(Roles = "Administrator, Worker")]
    public class ClientController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: /Client/
        public async Task<ActionResult> Index()
        {
            var clients = db.Clients.Include(c => c.AbuserRelationship).Include(c => c.Age).Include(c => c.AssignedWorker).Include(c => c.Crisis).Include(c => c.DuplicateFile).Include(c => c.Ethnicity).Include(c => c.FamilyViolenceFile).Include(c => c.FileStatus).Include(c => c.FiscalYear).Include(c => c.Incident).Include(c => c.Program).Include(c => c.ReferralContact).Include(c => c.ReferralSource).Include(c => c.RepeatClient).Include(c => c.RiskLevel).Include(c => c.RiskStatus).Include(c => c.Service).Include(c => c.SmartModel).Include(c => c.VictimOfIncident);
            return View(await clients.ToListAsync());
        }

        // GET: /Client/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientmodel = await db.Clients.FindAsync(id);
            if (clientmodel == null)
            {
                return HttpNotFound();
            }
            return View(clientmodel);
        }

        // GET: /Client/Create
        public ActionResult Create()
        {
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationshipModels, "AbuserRelationshipId", "AbuserRelationship");
            ViewBag.AgeId = new SelectList(db.AgeModels, "AgeId", "Age");
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkerModels, "AssignedWorkerId", "AssignedWorker");
            ViewBag.CrisisId = new SelectList(db.CrisisModels, "CrisisId", "Crisis");
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFileModels, "DuplicateFileId", "DuplicateFile");
            ViewBag.EthnicityId = new SelectList(db.EthnicityModels, "EthnicityId", "Ethnicity");
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFileModels, "FamilyViolenceId", "FamilyViolenceFile");
            ViewBag.FileStatusId = new SelectList(db.FileStatusModels, "FileStatusId", "FileStatus");
            ViewBag.FiscalId = new SelectList(db.FiscalYearModels, "FiscalId", "FiscalYear");
            ViewBag.IncidentId = new SelectList(db.IncidentModels, "IncidentId", "Incident");
            ViewBag.ProgramId = new SelectList(db.ProgramModels, "ProgramId", "Program");
            ViewBag.ReferralContactId = new SelectList(db.ReferralContactModels, "ReferralContactId", "ReferralContact");
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSourceModels, "ReferralSourceId", "ReferralSource");
            ViewBag.RepeatClientId = new SelectList(db.RepeatClientModels, "RepeatClientId", "RepeatClient");
            ViewBag.RiskLevelId = new SelectList(db.RiskLevelModels, "RiskLevelId", "RiskLevel");
            ViewBag.RiskStatusId = new SelectList(db.RiskStatusModels, "RiskStatusId", "RiskStatus");
            ViewBag.ServiceId = new SelectList(db.ServiceModels, "ServiceId", "Service");
            ViewBag.ClientReferenceNumber = new SelectList(db.SmartModels, "ClientReferenceNumber", "ClientReferenceNumber");
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidentModels, "VictimOfIncidentId", "VictimOfIncident");

            ViewBag.BadDateReportId = new SelectList(db.BadDateReportModels, "BadDateReportId", "BadDateReport");
            ViewBag.CityOfAssaultId = new SelectList(db.CityOfAssaultModels, "CityOfAssaultId", "CityOfAssault");
            ViewBag.CityOfResidenceId = new SelectList(db.CityOfResidenceModels, "CityOfResidenceId", "CityOfResidence");
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssaultModels, "DrugFacilitatedAssaultId", "DrugFacilitatedAssault");
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStoredModels, "EvidenceStoredId", "EvidenceStored");
            ViewBag.HivMedsId = new SelectList(db.HivMedsModels, "HIVMedsId", "HIVMeds");
            ViewBag.HospitalAttendedId = new SelectList(db.HospitalAttendedModels, "HospitalAttendedId", "HospitalAttended");
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnlyModels, "MedicalOnlyId", "MedicalOnly");
            ViewBag.MultiplePerpetratorsId = new SelectList(db.MultiplePerpetratorsModels, "MultiplePerpetratorsId", "MultiplePerpetrators");
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendanceModels, "PoliceAttendanceId", "PoliceAttendance");
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReportedModels, "PoliceReportedId", "PoliceReported");
            ViewBag.ReferredToCbvsId = new SelectList(db.ReferredToCbvsModels, "ReferredToCBVSId", "ReferredToCBVS");
            ViewBag.ReferringHospitalid = new SelectList(db.ReferringHospitalModels, "ReferringHospitalId", "ReferringHospital");
            ViewBag.SexWorkExploitationId = new SelectList(db.SexWorkExploitationModels, "SexWorkExploitationId", "SexWorkExploitation");
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendanceModels, "SocialWorkAttendanceId", "SocialWorkAttendance");
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReportModels, "ThirdPartyReportId", "ThirdPartyReport");
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendanceModels, "VictimServicesAttendanceId", "VictimServicesAttendance");

            return View();
        }

        // POST: /Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ClientReferenceNumber,FiscalId,Month,Day,Surname,Firstname,PoliceFileNumber,CourtFileNumber,SwcFileNumber,RiskLevelId,CrisisId,ServiceId,ProgramId,RiskAssessmentAssignedTo,RiskStatusId,AssignedWorkerId,ReferralSourceId,ReferralContactId,IncidentId,AbuserName,AbuserRelationshipId,VictimOfIncidentId,FamilyViolenceFileId,Gender,EthnicityId,AgeId,RepeatClientId,DuplicateFileId,NumberChildren6,NumberChildren12,NumberChildren18,FileStatusId,DateLastTransfered,DateClosed,DateReopened")] ClientModel clientmodel)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(clientmodel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationshipModels, "AbuserRelationshipId", "AbuserRelationship", clientmodel.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.AgeModels, "AgeId", "Age", clientmodel.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkerModels, "AssignedWorkerId", "AssignedWorker", clientmodel.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.CrisisModels, "CrisisId", "Crisis", clientmodel.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFileModels, "DuplicateFileId", "DuplicateFile", clientmodel.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.EthnicityModels, "EthnicityId", "Ethnicity", clientmodel.EthnicityId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFileModels, "FamilyViolenceId", "FamilyViolenceFile", clientmodel.FamilyViolenceFileId);
            ViewBag.FileStatusId = new SelectList(db.FileStatusModels, "FileStatusId", "FileStatus", clientmodel.FileStatusId);
            ViewBag.FiscalId = new SelectList(db.FiscalYearModels, "FiscalId", "FiscalYear", clientmodel.FiscalId);
            ViewBag.IncidentId = new SelectList(db.IncidentModels, "IncidentId", "Incident", clientmodel.IncidentId);
            ViewBag.ProgramId = new SelectList(db.ProgramModels, "ProgramId", "Program", clientmodel.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContactModels, "ReferralContactId", "ReferralContact", clientmodel.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSourceModels, "ReferralSourceId", "ReferralSource", clientmodel.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClientModels, "RepeatClientId", "RepeatClient", clientmodel.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevelModels, "RiskLevelId", "RiskLevel", clientmodel.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatusModels, "RiskStatusId", "RiskStatus", clientmodel.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.ServiceModels, "ServiceId", "Service", clientmodel.ServiceId);
            ViewBag.ClientReferenceNumber = new SelectList(db.SmartModels, "ClientReferenceNumber", "ClientReferenceNumber", clientmodel.ClientReferenceNumber);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidentModels, "VictimOfIncidentId", "VictimOfIncident", clientmodel.VictimOfIncidentId);
            return View(clientmodel);
        }

        // GET: /Client/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientmodel = await db.Clients.FindAsync(id);
            if (clientmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationshipModels, "AbuserRelationshipId", "AbuserRelationship", clientmodel.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.AgeModels, "AgeId", "Age", clientmodel.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkerModels, "AssignedWorkerId", "AssignedWorker", clientmodel.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.CrisisModels, "CrisisId", "Crisis", clientmodel.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFileModels, "DuplicateFileId", "DuplicateFile", clientmodel.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.EthnicityModels, "EthnicityId", "Ethnicity", clientmodel.EthnicityId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFileModels, "FamilyViolenceId", "FamilyViolenceFile", clientmodel.FamilyViolenceFileId);
            ViewBag.FileStatusId = new SelectList(db.FileStatusModels, "FileStatusId", "FileStatus", clientmodel.FileStatusId);
            ViewBag.FiscalId = new SelectList(db.FiscalYearModels, "FiscalId", "FiscalYear", clientmodel.FiscalId);
            ViewBag.IncidentId = new SelectList(db.IncidentModels, "IncidentId", "Incident", clientmodel.IncidentId);
            ViewBag.ProgramId = new SelectList(db.ProgramModels, "ProgramId", "Program", clientmodel.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContactModels, "ReferralContactId", "ReferralContact", clientmodel.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSourceModels, "ReferralSourceId", "ReferralSource", clientmodel.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClientModels, "RepeatClientId", "RepeatClient", clientmodel.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevelModels, "RiskLevelId", "RiskLevel", clientmodel.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatusModels, "RiskStatusId", "RiskStatus", clientmodel.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.ServiceModels, "ServiceId", "Service", clientmodel.ServiceId);
            ViewBag.ClientReferenceNumber = new SelectList(db.SmartModels, "ClientReferenceNumber", "ClientReferenceNumber", clientmodel.ClientReferenceNumber);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidentModels, "VictimOfIncidentId", "VictimOfIncident", clientmodel.VictimOfIncidentId);
            return View(clientmodel);
        }

        // POST: /Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ClientReferenceNumber,FiscalId,Month,Day,Surname,Firstname,PoliceFileNumber,CourtFileNumber,SwcFileNumber,RiskLevelId,CrisisId,ServiceId,ProgramId,RiskAssessmentAssignedTo,RiskStatusId,AssignedWorkerId,ReferralSourceId,ReferralContactId,IncidentId,AbuserName,AbuserRelationshipId,VictimOfIncidentId,FamilyViolenceFileId,Gender,EthnicityId,AgeId,RepeatClientId,DuplicateFileId,NumberChildren6,NumberChildren12,NumberChildren18,FileStatusId,DateLastTransfered,DateClosed,DateReopened")] ClientModel clientmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientmodel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationshipModels, "AbuserRelationshipId", "AbuserRelationship", clientmodel.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.AgeModels, "AgeId", "Age", clientmodel.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkerModels, "AssignedWorkerId", "AssignedWorker", clientmodel.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.CrisisModels, "CrisisId", "Crisis", clientmodel.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFileModels, "DuplicateFileId", "DuplicateFile", clientmodel.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.EthnicityModels, "EthnicityId", "Ethnicity", clientmodel.EthnicityId);
            ViewBag.FamilyViolenceFileId = new SelectList(db.FamilyViolenceFileModels, "FamilyViolenceId", "FamilyViolenceFile", clientmodel.FamilyViolenceFileId);
            ViewBag.FileStatusId = new SelectList(db.FileStatusModels, "FileStatusId", "FileStatus", clientmodel.FileStatusId);
            ViewBag.FiscalId = new SelectList(db.FiscalYearModels, "FiscalId", "FiscalYear", clientmodel.FiscalId);
            ViewBag.IncidentId = new SelectList(db.IncidentModels, "IncidentId", "Incident", clientmodel.IncidentId);
            ViewBag.ProgramId = new SelectList(db.ProgramModels, "ProgramId", "Program", clientmodel.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContactModels, "ReferralContactId", "ReferralContact", clientmodel.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSourceModels, "ReferralSourceId", "ReferralSource", clientmodel.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClientModels, "RepeatClientId", "RepeatClient", clientmodel.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevelModels, "RiskLevelId", "RiskLevel", clientmodel.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatusModels, "RiskStatusId", "RiskStatus", clientmodel.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.ServiceModels, "ServiceId", "Service", clientmodel.ServiceId);
            ViewBag.ClientReferenceNumber = new SelectList(db.SmartModels, "ClientReferenceNumber", "ClientReferenceNumber", clientmodel.ClientReferenceNumber);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidentModels, "VictimOfIncidentId", "VictimOfIncident", clientmodel.VictimOfIncidentId);
            return View(clientmodel);
        }

        // GET: /Client/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientmodel = await db.Clients.FindAsync(id);
            if (clientmodel == null)
            {
                return HttpNotFound();
            }
            return View(clientmodel);
        }

        // POST: /Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientModel clientmodel = await db.Clients.FindAsync(id);
            db.Clients.Remove(clientmodel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
