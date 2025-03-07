﻿using Application.Field.Interfaces.Validation;
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
        public async Task<ValidationOutput> Get(Guid id)
        {
            return await _validationApplication.GetById(id);
        }

        // POST api/<ValidationController>
        [HttpPost]
        public async Task<Domain.Field.Validation> Post([FromBody] ValidationInputCreate input)
        {
            return await _validationApplication.Create(input);
        }

        // PUT api/<ValidationController>/5
        [HttpPut]
        public async Task<Domain.Field.Validation> Put([FromBody] ValidationInputUpdate input)
        {
            return await _validationApplication.Update(input);
        }

        // DELETE api/<ValidationController>/5
        [HttpDelete("{id}")]
        public async Task<Domain.Field.Validation> Delete(Guid id)
        {
            return await _validationApplication.Delete(id);
        }
    }
}
