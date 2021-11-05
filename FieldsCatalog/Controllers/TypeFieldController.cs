using Application.Field.Interfaces.TypeFIeld;
using Domain.Configuration.Field.Input;
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
    public class TypeFieldController : ControllerBase
    {
        private readonly ITypeFieldApplication _typeFieldApplication;

        public TypeFieldController(ITypeFieldApplication typeFieldApplication)
        {
            _typeFieldApplication = typeFieldApplication;
        }

        // GET: api/<TypeFieldController>
        [HttpGet]
        public async Task<List<TypeFieldOutPut>> Get()
        {
            return await _typeFieldApplication.Get();
        }

        // GET api/<TypeFieldController>/5
        [HttpGet("{id}")]
        public async Task<TypeFieldOutPut> Get(Guid id)
        {
            return await _typeFieldApplication.GetById(id);
        }

        // POST api/<TypeFieldController>
        [HttpPost]
        public async Task<TypeFieldOutPut> Post([FromBody] TypeFieldInputCreate input)
        {
            return await _typeFieldApplication.Create(input);
        }

        // PUT api/<TypeFieldController>/5
        [HttpPut]
        public async Task<TypeFieldOutPut> Put([FromBody] TypeFieldInputUpdate input)
        {
            return await _typeFieldApplication.Update(input);
        }

        // DELETE api/<TypeFieldController>/5
        [HttpDelete]
        public async Task<TypeFieldOutPut> Delete(Guid id)
        {
            return await _typeFieldApplication.Delete(id);
        }
    }
}
