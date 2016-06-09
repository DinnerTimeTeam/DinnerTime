using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.OData;
using DinnerTimeData;
using DinnerTimeLib;

namespace DinnerTimeAPI.Controllers
{
    public class MeasurementsController : ApiController
    {
        private DinnerTimeContext db = new DinnerTimeContext();

        // GET: api/Measurements
        [EnableQuery]
        public IQueryable<Measurement> GetMeasurements()
        {
            return db.Measurements;
        }

        // GET: api/Measurements/5
        [ResponseType(typeof(Measurement))]
        public IHttpActionResult GetMeasurement(int id)
        {
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return NotFound();
            }

            return Ok(measurement);
        }

        // PUT: api/Measurements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMeasurement(int id, Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != measurement.Id)
            {
                return BadRequest();
            }

            db.Entry(measurement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeasurementExists(id))
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

        // POST: api/Measurements
        [ResponseType(typeof(Measurement))]
        public IHttpActionResult PostMeasurement(Measurement measurement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Measurements.Add(measurement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = measurement.Id }, measurement);
        }

        // DELETE: api/Measurements/5
        [ResponseType(typeof(Measurement))]
        public IHttpActionResult DeleteMeasurement(int id)
        {
            Measurement measurement = db.Measurements.Find(id);
            if (measurement == null)
            {
                return NotFound();
            }

            db.Measurements.Remove(measurement);
            db.SaveChanges();

            return Ok(measurement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MeasurementExists(int id)
        {
            return db.Measurements.Count(e => e.Id == id) > 0;
        }
    }
}