using System;
using System.Net;
using DockerSample.Application.Interfaces;
using DockerSample.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DockerSample.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonAppService _personAppService;

        public PersonController(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            return Ok(_personAppService.GetAll(null));
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult Get(string id)
        {
            return Ok(_personAppService.GetById(Guid.Parse(id)));
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonVm personVm)
        {
            personVm.Id = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                _personAppService.Save(personVm);
            }
            else
            {
                return BadRequest();
            }

            return Ok(personVm);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonVm personVm)
        {
            if (String.IsNullOrEmpty(personVm.Id.ToString()))
                return BadRequest();

            if(!ModelState.IsValid)
                return BadRequest();

            _personAppService.Update(personVm);
            return Ok(personVm);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            _personAppService.Remove(id);

            return Ok();
        }
    }
}