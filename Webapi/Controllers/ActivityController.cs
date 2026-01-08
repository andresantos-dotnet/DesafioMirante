using Domain.Dtos.Activity;
using Domain.Enums;
using Domain.Interfaces.Application;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace webapi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private IActivityApplication _activity;

        public ActivityController(IActivityApplication activity)
        {
            _activity = activity;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var activities = await _activity.GetAll();
            
            try
            {
                return Ok(activities);
            }
            catch (ArgumentException a)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);
            }

        }

        [HttpGet]
        [Route("{id}", Name = "GetById")]
        public async Task<ActionResult> Get(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //400 solicitacao invalida

            try
            {

                return Ok(await _activity.Get(id)); //200 sucesso
            }
            catch (ArgumentException a)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ActivityDtoCreate dto)
        {

            if (!ModelState.IsValid) return BadRequest(ModelState); //400 solicitacao invalida

            var result = await _activity.Post(dto);

            if (result != null)
            {
                return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ActivityDtoUpdate activity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //400 solicitacao invalida

            try
            {
                var result = await _activity.Put(activity);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException a)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //400 solicitacao invalida

            try
            {

                return Ok(await _activity.Delete(id)); //200 sucesso
            }
            catch (ArgumentException a)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);

            }
        }

        [HttpPost("CreateUow")]
        public async Task<ActionResult> CreateUow([FromBody] ActivityDtoCreate activity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //400 solicitacao invalida

            try
            {
                var result = await _activity.Create(activity);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException a)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);
            }
        }

    }
}
