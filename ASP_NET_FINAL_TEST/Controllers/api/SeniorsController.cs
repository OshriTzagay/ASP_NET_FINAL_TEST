using ASP_NET_FINAL_TEST.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ASP_NET_FINAL_TEST.Controllers.api
{
    public class SeniorsController : ApiController
    {
        public static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=OldMenDB;Integrated Security=True;Pooling=False";
        public OldMenDataContextDataContext OldMenDB = new OldMenDataContextDataContext(connString);
        // GET: api/Seniors

        public IHttpActionResult Get()
        {
            try
            {
                List<Senior> SeniorList = OldMenDB.Seniors.ToList();
                return Ok(new { SeniorList });

            }
            catch (SqlException)
            {
                return BadRequest("Sql Exception");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Seniors/5
        public IHttpActionResult Get(int id)
        {
            try
            {

                Senior ChosenSenior = OldMenDB.Seniors.First((item) => item.Id == id);
                return Ok(new { ChosenSenior });
            }
            catch (SqlException)
            {
                return BadRequest("SQL BAD Request");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Seniors
        public IHttpActionResult Post([FromBody] Senior SeniorToAdd)
        {
            try
            {

                OldMenDB.Seniors.InsertOnSubmit(SeniorToAdd);
                OldMenDB.SubmitChanges();

                return Ok("Added Senior Successfully");
            }
            catch (SqlException)
            {
                return BadRequest("Sql Exception");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/Seniors/5
        public IHttpActionResult Put(int id, [FromBody] Senior EditedSenior)
        {
            try
            {

                Senior seniortoEdit = OldMenDB.Seniors.First(item => item.Id == id);
                seniortoEdit.Id = EditedSenior.Id;
                seniortoEdit.FirstName = EditedSenior.FirstName;
                seniortoEdit.BirthDay = EditedSenior.BirthDay;
                seniortoEdit.Seniority = EditedSenior.Seniority;
                OldMenDB.SubmitChanges();
                return Ok("Edited Senior Successfully .");
            }
            catch (SqlException)
            {
                return BadRequest("Sql Exception Here..");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Seniors/5
        public IHttpActionResult Delete(int id)
        {
            try
            {

                Senior SeniorToDelete = OldMenDB.Seniors.First(item => item.Id == id);
                OldMenDB.Seniors.DeleteOnSubmit(SeniorToDelete);
                OldMenDB.SubmitChanges();
                return Ok("Deleted Successfully.");
            }
            catch (SqlException)
            {
                return BadRequest("Thats a Sql Exception");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
