using System;
using Microsoft.AspNetCore.Mvc;
using MimicAPI.Database;
using MimicAPI.Models;

namespace MimicAPI.Controllers
{
    [Route("api/words")]
    public class WordsController : ControllerBase
    {
        private readonly MimicContext _database;

        public WordsController(MimicContext database) 
        {
            _database = database;
        }

        [Route("")]
        [HttpGet]
        public ActionResult GetAll() 
        { 
             return Ok(_database.Words); 
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult Get(int id)  
        {
            try
            {
                var obj = _database.Words.Find(id);

                if (obj == null)
                    return NotFound();

            }catch(Exception)
            {

            }
            
            return Ok(_database.Words.Find(id)); 
        }

        [Route("")]
        [HttpPost]
        public ActionResult Insert([FromBody]Words words)
        {
            try
            {
                _database.Words.Add(words);

                 
            }
            catch(Exception ex)
            {
                
            }

            _database.SaveChanges();

            return Ok();

        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult Update(int id, [FromBody] Words words)
        {
            _database.Words.Update(words);

            _database.SaveChanges();

            return Ok();
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var word = _database.Words.Find(id);

            if (word == null)
                return NotFound();

            word.Active = false;

            _database.Words.Remove(_database.Words.Find(id));

            _database.SaveChanges();

            return Ok();
        }

    }
}
