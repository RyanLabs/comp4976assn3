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
    [Authorize(Roles = "Administrator")]
    public class ClientController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Client
        public async Task<ActionResult> Index()
        {
            var clients = db.Clients.Include(c => c.AbuserRelationship).Include(c => c.Age).Include(c => c.AssignedWorker).Include(c => c.Crisis).Include(c => c.DuplicateFile).Include(c => c.Ethnicity).Include(c => c.FileStatus).Include(c => c.FiscalYear).Include(c => c.Incident).Include(c => c.Program).Include(c => c.ReferralContact).Include(c => c.ReferralSource).Include(c => c.RepeatClient).Include(c => c.RiskLevel).Include(c => c.RiskStatus).Include(c => c.Service).Include(c => c.VictimOfIncident);
            return View(await clients.ToListAsync());
        }

        // GET: Client/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientModel = await db.Clients.FindAsync(id);
            if (clientModel == null)
            {
                return HttpNotFound();
            }
            return View(clientModel);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationshipModels, "AbuserRelationshipId", "AbuserRelationship");
            ViewBag.AgeId = new SelectList(db.AgeModels, "AgeId", "Age");
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkerModels, "AssignedWorkerId", "AssignedWorker");
            ViewBag.CrisisId = new SelectList(db.CrisisModels, "CrisisId", "Crisis");
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFileModels, "DuplicateFileId", "DuplicateFile");
            ViewBag.EthnicityId = new SelectList(db.EthnicityModels, "EthnicityId", "Ethnicity");
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
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidentModels, "VictimOfIncidentId", "VictimOfIncident");
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ClientReferenceNumber,FiscalId,Month,Day,Surname,Firstname,PoliceFileNumber,CourtFileNumber,SwcFileNumber,RiskLevelId,CrisisId,ServiceId,ProgramId,RiskAssessmentAssignedTo,RiskStatusId,AssignedWorkerId,ReferralSourceId,ReferralContactId,IncidentId,AbuserName,AbuserRelationshipId,VictimOfIncidentId,FamilyViolenceFileId,EthnicityId,AgeId,RepeatClientId,DuplicateFileId,NumberChildren6,NumberChildren12,NumberChildren18,FileStatusId,DateLastTransfered,DateClosed,DateReopened")] ClientModel clientModel)
        {
            if (ModelState.IsValid)
            {
                db.Clients.Add(clientModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationshipModels, "AbuserRelationshipId", "AbuserRelationship", clientModel.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.AgeModels, "AgeId", "Age", clientModel.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkerModels, "AssignedWorkerId", "AssignedWorker", clientModel.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.CrisisModels, "CrisisId", "Crisis", clientModel.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFileModels, "DuplicateFileId", "DuplicateFile", clientModel.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.EthnicityModels, "EthnicityId", "Ethnicity", clientModel.EthnicityId);
            ViewBag.FileStatusId = new SelectList(db.FileStatusModels, "FileStatusId", "FileStatus", clientModel.FileStatusId);
            ViewBag.FiscalId = new SelectList(db.FiscalYearModels, "FiscalId", "FiscalYear", clientModel.FiscalId);
            ViewBag.IncidentId = new SelectList(db.IncidentModels, "IncidentId", "Incident", clientModel.IncidentId);
            ViewBag.ProgramId = new SelectList(db.ProgramModels, "ProgramId", "Program", clientModel.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContactModels, "ReferralContactId", "ReferralContact", clientModel.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSourceModels, "ReferralSourceId", "ReferralSource", clientModel.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClientModels, "RepeatClientId", "RepeatClient", clientModel.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevelModels, "RiskLevelId", "RiskLevel", clientModel.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatusModels, "RiskStatusId", "RiskStatus", clientModel.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.ServiceModels, "ServiceId", "Service", clientModel.ServiceId);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidentModels, "VictimOfIncidentId", "VictimOfIncident", clientModel.VictimOfIncidentId);
            return View(clientModel);
        }

        // GET: Client/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientModel = await db.Clients.FindAsync(id);
            if (clientModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationshipModels, "AbuserRelationshipId", "AbuserRelationship", clientModel.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.AgeModels, "AgeId", "Age", clientModel.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkerModels, "AssignedWorkerId", "AssignedWorker", clientModel.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.CrisisModels, "CrisisId", "Crisis", clientModel.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFileModels, "DuplicateFileId", "DuplicateFile", clientModel.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.EthnicityModels, "EthnicityId", "Ethnicity", clientModel.EthnicityId);
            ViewBag.FileStatusId = new SelectList(db.FileStatusModels, "FileStatusId", "FileStatus", clientModel.FileStatusId);
            ViewBag.FiscalId = new SelectList(db.FiscalYearModels, "FiscalId", "FiscalYear", clientModel.FiscalId);
            ViewBag.IncidentId = new SelectList(db.IncidentModels, "IncidentId", "Incident", clientModel.IncidentId);
            ViewBag.ProgramId = new SelectList(db.ProgramModels, "ProgramId", "Program", clientModel.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContactModels, "ReferralContactId", "ReferralContact", clientModel.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSourceModels, "ReferralSourceId", "ReferralSource", clientModel.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClientModels, "RepeatClientId", "RepeatClient", clientModel.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevelModels, "RiskLevelId", "RiskLevel", clientModel.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatusModels, "RiskStatusId", "RiskStatus", clientModel.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.ServiceModels, "ServiceId", "Service", clientModel.ServiceId);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidentModels, "VictimOfIncidentId", "VictimOfIncident", clientModel.VictimOfIncidentId);
            return View(clientModel);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ClientReferenceNumber,FiscalId,Month,Day,Surname,Firstname,PoliceFileNumber,CourtFileNumber,SwcFileNumber,RiskLevelId,CrisisId,ServiceId,ProgramId,RiskAssessmentAssignedTo,RiskStatusId,AssignedWorkerId,ReferralSourceId,ReferralContactId,IncidentId,AbuserName,AbuserRelationshipId,VictimOfIncidentId,FamilyViolenceFileId,EthnicityId,AgeId,RepeatClientId,DuplicateFileId,NumberChildren6,NumberChildren12,NumberChildren18,FileStatusId,DateLastTransfered,DateClosed,DateReopened")] ClientModel clientModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AbuserRelationshipId = new SelectList(db.AbuserRelationshipModels, "AbuserRelationshipId", "AbuserRelationship", clientModel.AbuserRelationshipId);
            ViewBag.AgeId = new SelectList(db.AgeModels, "AgeId", "Age", clientModel.AgeId);
            ViewBag.AssignedWorkerId = new SelectList(db.AssignedWorkerModels, "AssignedWorkerId", "AssignedWorker", clientModel.AssignedWorkerId);
            ViewBag.CrisisId = new SelectList(db.CrisisModels, "CrisisId", "Crisis", clientModel.CrisisId);
            ViewBag.DuplicateFileId = new SelectList(db.DuplicateFileModels, "DuplicateFileId", "DuplicateFile", clientModel.DuplicateFileId);
            ViewBag.EthnicityId = new SelectList(db.EthnicityModels, "EthnicityId", "Ethnicity", clientModel.EthnicityId);
            ViewBag.FileStatusId = new SelectList(db.FileStatusModels, "FileStatusId", "FileStatus", clientModel.FileStatusId);
            ViewBag.FiscalId = new SelectList(db.FiscalYearModels, "FiscalId", "FiscalYear", clientModel.FiscalId);
            ViewBag.IncidentId = new SelectList(db.IncidentModels, "IncidentId", "Incident", clientModel.IncidentId);
            ViewBag.ProgramId = new SelectList(db.ProgramModels, "ProgramId", "Program", clientModel.ProgramId);
            ViewBag.ReferralContactId = new SelectList(db.ReferralContactModels, "ReferralContactId", "ReferralContact", clientModel.ReferralContactId);
            ViewBag.ReferralSourceId = new SelectList(db.ReferralSourceModels, "ReferralSourceId", "ReferralSource", clientModel.ReferralSourceId);
            ViewBag.RepeatClientId = new SelectList(db.RepeatClientModels, "RepeatClientId", "RepeatClient", clientModel.RepeatClientId);
            ViewBag.RiskLevelId = new SelectList(db.RiskLevelModels, "RiskLevelId", "RiskLevel", clientModel.RiskLevelId);
            ViewBag.RiskStatusId = new SelectList(db.RiskStatusModels, "RiskStatusId", "RiskStatus", clientModel.RiskStatusId);
            ViewBag.ServiceId = new SelectList(db.ServiceModels, "ServiceId", "Service", clientModel.ServiceId);
            ViewBag.VictimOfIncidentId = new SelectList(db.VictimOfIncidentModels, "VictimOfIncidentId", "VictimOfIncident", clientModel.VictimOfIncidentId);
            return View(clientModel);
        }

        // GET: Client/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientModel clientModel = await db.Clients.FindAsync(id);
            if (clientModel == null)
            {
                return HttpNotFound();
            }
            return View(clientModel);
        }

        // POST: Client/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ClientModel clientModel = await db.Clients.FindAsync(id);
            db.Clients.Remove(clientModel);
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
