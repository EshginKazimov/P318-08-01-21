using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DomainModel.Dto;
using DomainModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Repository.Contracts;

namespace API.Controllers
{
    //Pattern
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class StudentsController : ControllerBase
    {
        private readonly IRepository<Student> _repository;
        private readonly IMapper _mapper;

        public StudentsController(IMapper mapper, IRepository<Student> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            //var students = await _repository.GetAllAsync();
            var students = await _repository.GetAllAsync(x => x.Name.StartsWith("R"));

            return Ok(_mapper.Map<List<StudentDto>>(students));
        }

        //DTO - Data Transfer Object
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return BadRequest();

            var student = await _repository.GetAsync(id.Value);
            if (student == null)
                return NotFound("Bele id-de student yoxdur.");

            var studentDto = _mapper.Map<StudentDto>(student);

            return Ok(studentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] /*[FromForm]*/ StudentDto studentDto)
        {
            try
            {
                var student = _mapper.Map<Student>(studentDto);

                var isAdded = await _repository.AddAsync(student);
                if (!isAdded)
                    return BadRequest();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int? id, [FromBody] StudentDto studentDto)
        {
            if (id == null)
                return BadRequest();

            if (id != studentDto.Id)
                return BadRequest();

            var existStudent = await _repository.GetAsync(id.Value);
            if (existStudent == null)
                return NotFound();

            var student = _mapper.Map<Student>(studentDto);

            //existStudent.Name = studentDto.Name;
            //SaveChanges();

            await _repository.UpdateAsync(student);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _repository.GetAsync(id.Value);
            if (student == null)
                return NotFound();

            await _repository.DeleteAsync(student);

            return NoContent();
        }
    }
}
