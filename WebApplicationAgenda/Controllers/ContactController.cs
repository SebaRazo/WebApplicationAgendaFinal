﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationAgenda.Data;
using WebApplicationAgenda.Data.Repository.Interfaces;
using WebApplicationAgenda.Entities;
using WebApplicationAgenda.Models.Dtos;

namespace WebApplicationAgenda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IUserRepository _userRepository;
        //inyecta las dependencias 
        public ContactController(IContactRepository contactRepository, IUserRepository userRepository)
        {
            _contactRepository = contactRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
            return Ok(await _contactRepository.GetAllByUser(userId));
        }

        [HttpGet]
        public async Task<IActionResult> GetOne(int id)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
                List<Contact> contacts = await _contactRepository.GetAllByUser(userId);
                Contact contact = contacts.FirstOrDefault(x => x.Id == id);
                if (contact != null)
                {
                    return Ok(contact);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                    return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateAndUpdateContact createContactDto)
        {
            try
            {

                int userId = Int32.Parse(HttpContext.User.Claims.FirstOrDefault(x => x.Type.Contains("nameidentifier")).Value);
                await _contactRepository.Create(createContactDto, userId);



                return Created("Created", createContactDto);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(int id, CreateAndUpdateContact dto)
        {
            try
            {
                await _contactRepository.Update(id, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        /// HACER METODO GET PARA CONTACTOS EN LISTA NEGRA


        [HttpDelete]
        public async Task<IActionResult> DeleteContactById(int id)
        {
            try
            {
                await _contactRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }
    }
}
