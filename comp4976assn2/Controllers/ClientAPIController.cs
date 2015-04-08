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
using comp4976assn2.Models;

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