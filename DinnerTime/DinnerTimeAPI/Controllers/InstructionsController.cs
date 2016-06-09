using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DinnerTimeData;
using DinnerTimeLib;

namespace DinnerTimeAPI.Controllers
{
    public class InstructionsController : ApiController
    {
        private DinnerTimeContext db = new DinnerTimeContext();

        // GET: api/Instructions
        public IQueryable<Instruction> GetInstructions()
        {
            return db.Instructions;
        }

        // GET: api/Instructions/5
        [ResponseType(typeof(Instruction))]
        public IHttpActionResult GetInstruction(int id)
        {
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return NotFound();
            }

            return Ok(instruction);
        }

        // PUT: api/Instructions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInstruction(int id, Instruction instruction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instruction.Id)
            {
                return BadRequest();
            }

            db.Entry(instruction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructionExists(id))
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

        // POST: api/Instructions
        [ResponseType(typeof(Instruction))]
        public IHttpActionResult PostInstruction(Instruction instruction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Instructions.Add(instruction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = instruction.Id }, instruction);
        }

        // DELETE: api/Instructions/5
        [ResponseType(typeof(Instruction))]
        public IHttpActionResult DeleteInstruction(int id)
        {
            Instruction instruction = db.Instructions.Find(id);
            if (instruction == null)
            {
                return NotFound();
            }

            db.Instructions.Remove(instruction);
            db.SaveChanges();

            return Ok(instruction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstructionExists(int id)
        {
            return db.Instructions.Count(e => e.Id == id) > 0;
        }
    }
}