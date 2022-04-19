using System;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Week1_Patika.CakeShopOperations.CreateCake;
using Week1_Patika.CakeShopOperations.DeleteCake;
using Week1_Patika.CakeShopOperations.GetCakeDetails;
using Week1_Patika.CakeShopOperations.GetCakes;
using Week1_Patika.CakeShopOperations.UpdateCake;
using Week1_Patika.DbOperations;

namespace Week1_Patika.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class CakeController : ControllerBase
    {

        private readonly CakeShopDbContext _dbcontext;
        private readonly IMapper _mapper;

        public CakeController(CakeShopDbContext dbcontext, IMapper mapper)
        {
            this._dbcontext = dbcontext;
            this._mapper = mapper;
        }



        //GET METHOD

        [HttpGet]

        public IActionResult GetCakes()
        {
            GetCakesQuery query = new GetCakesQuery(_dbcontext, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        //GET BY ID METHOD


        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            CakeDetailsViewModel result;
            GetCakeDetailsQuery query = new GetCakeDetailsQuery(_dbcontext, _mapper);
            try
            {
                query.Id = id;
                GetCakeDetailsValidation validation = new GetCakeDetailsValidation();
                validation.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(result);
        }

        //CREATE NEW CAKE METHOD (POST)

        [HttpPost]

        public IActionResult CreateCake([FromBody] CreateCakeModel newCake)
        {
            CreateCakeCommand command = new CreateCakeCommand(_dbcontext, _mapper);
            try
            {
                command.Model = newCake;
                CreateCakeValidation validation = new CreateCakeValidation();
                validation.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        //UPDATE CAKE METHOD (PUT)
        [HttpPut("{id}")]
        public IActionResult UpdateCake(int id, [FromBody] UpdateCakeModel updatedCake)
        {
            UpdateCakeCommand command = new UpdateCakeCommand(_dbcontext);
            try
            {
                command.Model = updatedCake;
                command.Id = id;
                UpdateCakeValidation validation = new UpdateCakeValidation();
                validation.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        // DELETE METHOD

        [HttpDelete("{id}")]
        public IActionResult DeleteCake(int id)
        {
            try
            {
                DeleteCakeCommand command = new DeleteCakeCommand(_dbcontext);
                command.Id = id;
                DeleteCakeValidation validation = new DeleteCakeValidation();
                validation.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }





    }
}
