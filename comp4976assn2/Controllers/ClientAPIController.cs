using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Script.Serialization;
using comp4976assn2.Models;
using Newtonsoft.Json.Linq;

namespace comp4976assn2.Controllers
{
    public class ClientAPIController : ApiController
    {
        private ClientContext db = new ClientContext();

        // GET api/ClientAPI
        public List<ClientModel> GetClients()
        {
            return db.Clients.ToList();
        }

        // GET api/ClientAPI/5
        [ResponseType(typeof(ClientModel))]
        public async Task<IHttpActionResult> GetClientModel(int id)
        {
            ClientModel clientmodel = await db.Clients.FindAsync(id);
            if (clientmodel == null)
            {
                return NotFound();
            }

            return Ok(clientmodel);
        }

        // GET api/ClientAPI/1/1
        public string GetClientsReport(string year, int month)
        {
            Console.WriteLine("Accessed");
            using (ClientContext ctx = new ClientContext())
            {
                
                var clients = from c in ctx.Clients
                              where c.Month.Equals(month)
                              //where c.FiscalYear.Equals(year)
                                   select c;

                var reportObject = new ReportModel();
                reportObject.Open = 10;
                reportObject.Closed = 10;
                reportObject.Reopened = 10;
                reportObject.Crisis = 10;
                reportObject.Court = 10;
                reportObject.SMART = 10;
                reportObject.DVU = 10;
                reportObject.MCFD = 10;
                reportObject.Male = 10;
                reportObject.Female = 10;
                reportObject.Trans = 10;
                reportObject.Adult = 10;
                reportObject.Youth12 = 10;
                reportObject.Youth18 = 10;
                reportObject.Child = 10;
                reportObject.Senior = 10;

                var json = new JavaScriptSerializer().Serialize(reportObject);

                return json;
            }

        }

        // PUT api/ClientAPI/5
        public async Task<IHttpActionResult> PutClientModel(int id, ClientModel clientmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientmodel.ClientReferenceNumber)
            {
                return BadRequest();
            }

            db.Entry(clientmodel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/ClientAPI
        [ResponseType(typeof(ClientModel))]
        public async Task<IHttpActionResult> PostClientModel(ClientModel clientmodel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients.Add(clientmodel);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = clientmodel.ClientReferenceNumber }, clientmodel);
        }

        // DELETE api/ClientAPI/5
        [ResponseType(typeof(ClientModel))]
        public async Task<IHttpActionResult> DeleteClientModel(int id)
        {
            ClientModel clientmodel = await db.Clients.FindAsync(id);
            if (clientmodel == null)
            {
                return NotFound();
            }

            db.Clients.Remove(clientmodel);
            await db.SaveChangesAsync();

            return Ok(clientmodel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientModelExists(int id)
        {
            return db.Clients.Count(e => e.ClientReferenceNumber == id) > 0;
        }
    }
}