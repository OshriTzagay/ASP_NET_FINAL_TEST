using ASP_NET_FINAL_TEST.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ASP_NET_FINAL_TEST.Controllers.api
{
    public class CitizensController : ApiController
    {
        public VillageDatabaseContext VillageDB = new VillageDatabaseContext();
        // GET: api/Citizens
        public IHttpActionResult Get()
        {
            try
            {
                List<Citizen> CitizensList = VillageDB.Citizens.ToList();
                return Ok(new { CitizensList });
            }
            catch (SqlException)
            {
                return BadRequest("There is a SQL Exception");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Citizens/5
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {

                Citizen ChosenCitizen = await VillageDB.Citizens.FindAsync(id);
                return Ok(new { ChosenCitizen });
            }
            catch (SqlException)
            {
                return BadRequest("Sql Excepttion Here . ");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Citizens
        public async Task<IHttpActionResult> Post([FromBody] Citizen CitizenToAdd)
        {
            try
            {
                VillageDB.Citizens.Add(CitizenToAdd);
                await VillageDB.SaveChangesAsync();

                return Ok(new { Added = CitizenToAdd });

            }
            catch (SqlException)
            {
                return BadRequest("SQL EXCEPTION.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Citizens/5
        public async Task<IHttpActionResult> Put(int id, [FromBody] Citizen EditedCitizen)
        {
            try
            {

                Citizen citizenToChange = await VillageDB.Citizens.FindAsync(id);
                citizenToChange.Id = EditedCitizen.Id;
                citizenToChange.FullName = EditedCitizen.FullName;
                citizenToChange.FatherName = EditedCitizen.FatherName;
                citizenToChange.Gender = EditedCitizen.Gender;
                citizenToChange.BirthDay = EditedCitizen.BirthDay;
                await VillageDB.SaveChangesAsync();

                return Ok("Edited Citizen Successfully");
            }
            catch (SqlException)
            {
                return BadRequest("SQL EXCEPTION HERE");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE: api/Citizens/5
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {

                Citizen CitizenToDelete = await VillageDB.Citizens.FindAsync(id);
                VillageDB.Citizens.Remove(CitizenToDelete);
                await VillageDB.SaveChangesAsync();

                return Ok("Removed Citizen Successfully. ");
            }
            catch (SqlException)
            {
                return BadRequest("There is a Sql Ex");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
