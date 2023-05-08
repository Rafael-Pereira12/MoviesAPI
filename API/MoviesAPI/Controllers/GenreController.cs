using BeeEngineering.Learning.MoviesApp.Data;
using Business;
using Business.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Model;
using MoviesAPI.Requests;
using MoviesAPI.Responses;
using System;

namespace MoviesAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Authorize(Roles = "User")]
    [Route("api/genre")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreBusinessObject _bo;

        public GenreController(IGenreBusinessObject bo)
        {
            _bo = bo;
        }

        [HttpGet("list")]
        public async Task<ActionResult<List<GenreResult>>> ListAsync()
        {
            var operationResult = await _bo.List();
            if (operationResult.IsSuccessful)
            {
                var result = operationResult.Result?.Select(x => GenreResult.FromModel(x));
                return Ok(result);
            }
            return Problem(operationResult.Exception?.Message);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> InsertAsync([FromBody] GenreRequest genre)
        {
            var model = genre.ToModel();
            var result = await _bo.Insert(model);
            if (result.IsSuccessful) return Created("", null);
            if (result.Exception is IncompleteModelException) return BadRequest(result.Exception.Message);
            if (result.Exception is RecordAlreadyExistsException) return Conflict(result.Exception?.Message);
            return Problem(result.Exception?.Message);
        }

        [HttpGet("{uuid}")]
        public async Task<ActionResult<GenreResult?>> GetAsync(Guid uuid)
        {
            var operationResult = await _bo.Get(uuid);
            if (operationResult.IsSuccessful)
            {
                var result = GenreResult.FromModel(operationResult.Result);
                return Ok(result);
            }
            if (operationResult.Exception is RecordNotFoundException) return NotFound(operationResult.Exception?.Message);
            return Problem(operationResult.Exception?.Message);
        }

        [HttpPut("update/{uuid}")]
        public async Task<IActionResult> UpdateAsync(Guid uuid, [FromBody] GenreRequest genre)
        {
            //var model = genre.ToModel();
            //model.Uuid = uuid;
            var operationResult = await _bo.Get(uuid);
            if (operationResult.IsSuccessful)
            {
                operationResult.Result.UpdateAt = DateTime.Now;
                operationResult.Result.Name = genre.Name;
            }
            var result = await _bo.Update(operationResult.Result);
            if (result.IsSuccessful) return Ok();
            if (result.Exception is IncompleteModelException || result.Exception is SameModelDataException) return BadRequest(result.Exception.Message);
            if (result.Exception is RecordNotFoundException) return NotFound(result.Exception?.Message);
            if (result.Exception is EmptyModelException) return NoContent();
            return Problem(result.Exception?.Message);
        }

        [HttpDelete("delete/{uuid}")]
        public async Task<IActionResult> DeleteAsync(Guid uuid)
        {
            //var model = new Genre() { Uuid = uuid };
            var model = await _bo.Get(uuid);
            var result = await _bo.Delete(model.Result);
            if (result.IsSuccessful) return Ok();
            if (result.Exception is RecordNotFoundException) return NotFound(result.Exception?.Message);
            return Problem(result.Exception?.Message);
        }
    }
}
