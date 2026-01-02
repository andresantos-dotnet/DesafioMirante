using Domain.Dtos.Activity;
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

        [HttpGet("getAllStringStatus")]
        public async Task<IActionResult> GetAllStringStatus()
        {
            var activities = await _activity.GetAll();
             var result =  activities.Select(a => new ActivityDtoReturn
                {
                    Title = a.Title,
                    Description = a.Description,
                    TaskStatus = ((Status)a.TaskStatus).ToString(), 
                    DueDate = a.DueDate,
                })
                .ToList();
            try
            {
                return Ok(result);
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
        public async Task<ActionResult> Post([FromBody] ActivityDtoCreate activity)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //400 solicitacao invalida

            try
            {
                var result = await _activity.Post(activity);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
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

        [HttpPost("createWithStatusString")]
        public async Task<IActionResult> CreateWithStatus([FromBody] ActivityDtoCreateStringStatus dto)
        {
            if (!Enum.TryParse<Status>(dto.TaskStatus, true, out var statusEnum))
            {
                return BadRequest(new { error = "Status inválido. Valores aceitos: Pendente, EmAndamento, Concluido" });
            }

            int statusInt = (int)statusEnum;

            var activity = new ActivityDtoCreate
            {
                Title = dto.Title,
                Description = dto.Description,
                TaskStatus = (short)statusInt,
                DueDate = dto.DueDate,
                CreateDate = dto.CreateDate
            };

            var result = await _activity.Post(activity);

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



        [HttpPost("Create")]
        public async Task<ActionResult> Create([FromBody] ActivityDtoCreate activity)
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
