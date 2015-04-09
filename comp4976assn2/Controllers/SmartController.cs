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
    public class SmartController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: /Smart/
        public async Task<ActionResult> Index()
        {
            var smartmodels = db.SmartModels.Include(s => s.BadDateReport).Include(s => s.CityOfAssault).Include(s => s.CityOfResidence).Include(s => s.DrugFacilitatedAssault).Include(s => s.EvidenceStored).Include(s => s.HivMeds).Include(s => s.HospitalAttended).Include(s => s.MedicalOnly).Include(s => s.MultiplePerpetrators).Include(s => s.PoliceAttendance).Include(s => s.PoliceReported).Include(s => s.ReferredToCbvs).Include(s => s.ReferringHospital).Include(s => s.SexWorkExploitation).Include(s => s.SocialWorkAttendance).Include(s => s.ThirdPartyReport).Include(s => s.VictimServicesAttendance);
            return View(await smartmodels.ToListAsync());
        }

        // GET: /Smart/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmartModel smartmodel = await db.SmartModels.FindAsync(id);
            if (smartmodel == null)
            {
                return HttpNotFound();
            }
            return View(smartmodel);
        }

        // GET: /Smart/Create
        public ActionResult Create()
        {
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

        // POST: /Smart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ClientReferenceNumber,AccompanimentMinutes,NumberTransportsProvided,ReferredToNurse,SexWorkExploitationId,MultiplePerpetratorsId,DrugFacilitatedAssaultId,CityOfAssaultId,CityOfResidenceId,ReferringHospitalid,HospitalAttendedId,SocialWorkAttendanceId,PoliceAttendanceId,VictimServicesAttendanceId,MedicalOnlyId,EvidenceStoredId,HivMedsId,ReferredToCbvsId,PoliceReportedId,ThirdPartyReportId,BadDateReportId")] SmartModel smartmodel)
        {
            if (ModelState.IsValid)
            {
                db.SmartModels.Add(smartmodel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BadDateReportId = new SelectList(db.BadDateReportModels, "BadDateReportId", "BadDateReport", smartmodel.BadDateReportId);
            ViewBag.CityOfAssaultId = new SelectList(db.CityOfAssaultModels, "CityOfAssaultId", "CityOfAssault", smartmodel.CityOfAssaultId);
            ViewBag.CityOfResidenceId = new SelectList(db.CityOfResidenceModels, "CityOfResidenceId", "CityOfResidence", smartmodel.CityOfResidenceId);
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssaultModels, "DrugFacilitatedAssaultId", "DrugFacilitatedAssault", smartmodel.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStoredModels, "EvidenceStoredId", "EvidenceStored", smartmodel.EvidenceStoredId);
            ViewBag.HivMedsId = new SelectList(db.HivMedsModels, "HIVMedsId", "HIVMeds", smartmodel.HivMedsId);
            ViewBag.HospitalAttendedId = new SelectList(db.HospitalAttendedModels, "HospitalAttendedId", "HospitalAttended", smartmodel.HospitalAttendedId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnlyModels, "MedicalOnlyId", "MedicalOnly", smartmodel.MedicalOnlyId);
            ViewBag.MultiplePerpetratorsId = new SelectList(db.MultiplePerpetratorsModels, "MultiplePerpetratorsId", "MultiplePerpetrators", smartmodel.MultiplePerpetratorsId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendanceModels, "PoliceAttendanceId", "PoliceAttendance", smartmodel.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReportedModels, "PoliceReportedId", "PoliceReported", smartmodel.PoliceReportedId);
            ViewBag.ReferredToCbvsId = new SelectList(db.ReferredToCbvsModels, "ReferredToCBVSId", "ReferredToCBVS", smartmodel.ReferredToCbvsId);
            ViewBag.ReferringHospitalid = new SelectList(db.ReferringHospitalModels, "ReferringHospitalId", "ReferringHospital", smartmodel.ReferringHospitalid);
            ViewBag.SexWorkExploitationId = new SelectList(db.SexWorkExploitationModels, "SexWorkExploitationId", "SexWorkExploitation", smartmodel.SexWorkExploitationId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendanceModels, "SocialWorkAttendanceId", "SocialWorkAttendance", smartmodel.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReportModels, "ThirdPartyReportId", "ThirdPartyReport", smartmodel.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendanceModels, "VictimServicesAttendanceId", "VictimServicesAttendance", smartmodel.VictimServicesAttendanceId);
            return View(smartmodel);
        }

        // GET: /Smart/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmartModel smartmodel = await db.SmartModels.FindAsync(id);
            if (smartmodel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BadDateReportId = new SelectList(db.BadDateReportModels, "BadDateReportId", "BadDateReport", smartmodel.BadDateReportId);
            ViewBag.CityOfAssaultId = new SelectList(db.CityOfAssaultModels, "CityOfAssaultId", "CityOfAssault", smartmodel.CityOfAssaultId);
            ViewBag.CityOfResidenceId = new SelectList(db.CityOfResidenceModels, "CityOfResidenceId", "CityOfResidence", smartmodel.CityOfResidenceId);
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssaultModels, "DrugFacilitatedAssaultId", "DrugFacilitatedAssault", smartmodel.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStoredModels, "EvidenceStoredId", "EvidenceStored", smartmodel.EvidenceStoredId);
            ViewBag.HivMedsId = new SelectList(db.HivMedsModels, "HIVMedsId", "HIVMeds", smartmodel.HivMedsId);
            ViewBag.HospitalAttendedId = new SelectList(db.HospitalAttendedModels, "HospitalAttendedId", "HospitalAttended", smartmodel.HospitalAttendedId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnlyModels, "MedicalOnlyId", "MedicalOnly", smartmodel.MedicalOnlyId);
            ViewBag.MultiplePerpetratorsId = new SelectList(db.MultiplePerpetratorsModels, "MultiplePerpetratorsId", "MultiplePerpetrators", smartmodel.MultiplePerpetratorsId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendanceModels, "PoliceAttendanceId", "PoliceAttendance", smartmodel.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReportedModels, "PoliceReportedId", "PoliceReported", smartmodel.PoliceReportedId);
            ViewBag.ReferredToCbvsId = new SelectList(db.ReferredToCbvsModels, "ReferredToCBVSId", "ReferredToCBVS", smartmodel.ReferredToCbvsId);
            ViewBag.ReferringHospitalid = new SelectList(db.ReferringHospitalModels, "ReferringHospitalId", "ReferringHospital", smartmodel.ReferringHospitalid);
            ViewBag.SexWorkExploitationId = new SelectList(db.SexWorkExploitationModels, "SexWorkExploitationId", "SexWorkExploitation", smartmodel.SexWorkExploitationId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendanceModels, "SocialWorkAttendanceId", "SocialWorkAttendance", smartmodel.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReportModels, "ThirdPartyReportId", "ThirdPartyReport", smartmodel.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendanceModels, "VictimServicesAttendanceId", "VictimServicesAttendance", smartmodel.VictimServicesAttendanceId);
            return View(smartmodel);
        }

        // POST: /Smart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ClientReferenceNumber,AccompanimentMinutes,NumberTransportsProvided,ReferredToNurse,SexWorkExploitationId,MultiplePerpetratorsId,DrugFacilitatedAssaultId,CityOfAssaultId,CityOfResidenceId,ReferringHospitalid,HospitalAttendedId,SocialWorkAttendanceId,PoliceAttendanceId,VictimServicesAttendanceId,MedicalOnlyId,EvidenceStoredId,HivMedsId,ReferredToCbvsId,PoliceReportedId,ThirdPartyReportId,BadDateReportId")] SmartModel smartmodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(smartmodel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BadDateReportId = new SelectList(db.BadDateReportModels, "BadDateReportId", "BadDateReport", smartmodel.BadDateReportId);
            ViewBag.CityOfAssaultId = new SelectList(db.CityOfAssaultModels, "CityOfAssaultId", "CityOfAssault", smartmodel.CityOfAssaultId);
            ViewBag.CityOfResidenceId = new SelectList(db.CityOfResidenceModels, "CityOfResidenceId", "CityOfResidence", smartmodel.CityOfResidenceId);
            ViewBag.DrugFacilitatedAssaultId = new SelectList(db.DrugFacilitatedAssaultModels, "DrugFacilitatedAssaultId", "DrugFacilitatedAssault", smartmodel.DrugFacilitatedAssaultId);
            ViewBag.EvidenceStoredId = new SelectList(db.EvidenceStoredModels, "EvidenceStoredId", "EvidenceStored", smartmodel.EvidenceStoredId);
            ViewBag.HivMedsId = new SelectList(db.HivMedsModels, "HIVMedsId", "HIVMeds", smartmodel.HivMedsId);
            ViewBag.HospitalAttendedId = new SelectList(db.HospitalAttendedModels, "HospitalAttendedId", "HospitalAttended", smartmodel.HospitalAttendedId);
            ViewBag.MedicalOnlyId = new SelectList(db.MedicalOnlyModels, "MedicalOnlyId", "MedicalOnly", smartmodel.MedicalOnlyId);
            ViewBag.MultiplePerpetratorsId = new SelectList(db.MultiplePerpetratorsModels, "MultiplePerpetratorsId", "MultiplePerpetrators", smartmodel.MultiplePerpetratorsId);
            ViewBag.PoliceAttendanceId = new SelectList(db.PoliceAttendanceModels, "PoliceAttendanceId", "PoliceAttendance", smartmodel.PoliceAttendanceId);
            ViewBag.PoliceReportedId = new SelectList(db.PoliceReportedModels, "PoliceReportedId", "PoliceReported", smartmodel.PoliceReportedId);
            ViewBag.ReferredToCbvsId = new SelectList(db.ReferredToCbvsModels, "ReferredToCBVSId", "ReferredToCBVS", smartmodel.ReferredToCbvsId);
            ViewBag.ReferringHospitalid = new SelectList(db.ReferringHospitalModels, "ReferringHospitalId", "ReferringHospital", smartmodel.ReferringHospitalid);
            ViewBag.SexWorkExploitationId = new SelectList(db.SexWorkExploitationModels, "SexWorkExploitationId", "SexWorkExploitation", smartmodel.SexWorkExploitationId);
            ViewBag.SocialWorkAttendanceId = new SelectList(db.SocialWorkAttendanceModels, "SocialWorkAttendanceId", "SocialWorkAttendance", smartmodel.SocialWorkAttendanceId);
            ViewBag.ThirdPartyReportId = new SelectList(db.ThirdPartyReportModels, "ThirdPartyReportId", "ThirdPartyReport", smartmodel.ThirdPartyReportId);
            ViewBag.VictimServicesAttendanceId = new SelectList(db.VictimServicesAttendanceModels, "VictimServicesAttendanceId", "VictimServicesAttendance", smartmodel.VictimServicesAttendanceId);
            return View(smartmodel);
        }

        // GET: /Smart/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SmartModel smartmodel = await db.SmartModels.FindAsync(id);
            if (smartmodel == null)
            {
                return HttpNotFound();
            }
            return View(smartmodel);
        }

        // POST: /Smart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SmartModel smartmodel = await db.SmartModels.FindAsync(id);
            db.SmartModels.Remove(smartmodel);
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
