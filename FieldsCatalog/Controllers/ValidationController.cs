using Application.Field.Interfaces.Validation;
using Domain.Configuration.Field.Output;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FieldsCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : ControllerBase
    {
        private readonly IValidationApplication _validationApplication;

        public ValidationController(IValidationApplication validationApplication) {
            _validationApplication = validationApplication;
        }

        // GET: api/<ValidationController>
        [HttpGet]
        public async Task<List<ValidationOutput>> Get()
        {
            return await _validationApplication.Get();
        }

        // GET api/<ValidationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValidationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValidationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValidationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
