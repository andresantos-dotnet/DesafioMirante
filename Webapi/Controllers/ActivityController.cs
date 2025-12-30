using Domain.Dtos.Activity;
using Domain.Interfaces.Application;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DesafioMirante.Controllers
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
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //400 solicitacao invalida

            try
            {

                return Ok(await _activity.GetAll()); //200 sucesso
            }
            catch (ArgumentException a)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, a.Message);

            }
        }

        [HttpGet("{id}")]
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
        public async Task<ActionResult> Post([FromBody] ActivityDto activity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //400 solicitacao invalida

            try
            {
                var result = await _activity.Post(activity);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("Get", new { id = result.Id })), result);
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


        [HttpPut]
        public async Task<ActionResult> Put([FromBody] ActivityDto activity)
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

    }
}
