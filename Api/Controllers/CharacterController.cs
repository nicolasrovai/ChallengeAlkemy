using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs;
using Api.Entities;
using Api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize]
    [Route("character")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepo _characterRepo;
        private readonly IMapper _characterMapper;

        public CharacterController(ICharacterRepo characterRepo, IMapper characterMapper)
        {
            _characterRepo = characterRepo;
            _characterMapper = characterMapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CharacterReadDto>> Characters()
        {
            var characters = _characterRepo.GetCharacter();
            return Ok(_characterMapper.Map<IEnumerable<CharacterReadDto>>(characters));
        }

        [HttpGet("{id}", Name ="CharacterById")]
        public ActionResult<Character> CharacterById(int id)
        {
            var character = _characterRepo.GetCharacterById(id);
            if (character != null)
            {
                return Ok(_characterMapper.Map<CharacterReadDto>(character));
            }
            return NotFound();

        }

        [HttpPost]
        public ActionResult<CharacterReadDto> CreateCharacter(CharacterCreateDto characterCreateDto)
        {
            var character = _characterMapper.Map<Character>(characterCreateDto);
            _characterRepo.CreateCharacter(character);
            _characterRepo.SaveChanges();

            var characterReadDto = _characterMapper.Map<CharacterReadDto>(character);

            return CreatedAtRoute(nameof(CharacterById), new { Id = character.Id }, characterReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult CharacterUpdate(int id, CharacterUpdateDto characterUpdateDto)
        {
            var character = _characterRepo.GetCharacterById(id);
            if (character == null)
            {
                return NotFound();
            }

            _characterMapper.Map(characterUpdateDto, character);

            _characterRepo.UpdateCharacter(character);

            _characterRepo.SaveChanges();

            return NoContent();

        }

        [HttpPatch("{id}")]
        public ActionResult CharacterPartialUpdate(int id, JsonPatchDocument<CharacterUpdateDto> pactchDoc)
        {
            var character = _characterRepo.GetCharacterById(id);
            if (character == null)
            {
                return NotFound();
            }

            var characterToPatch = _characterMapper.Map<CharacterUpdateDto>(character);
            pactchDoc.ApplyTo(characterToPatch, ModelState);
            if (!TryValidateModel(characterToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _characterMapper.Map(characterToPatch, character);

            _characterRepo.UpdateCharacter(character);

            _characterRepo.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult CharacterDelete(int id)
        {
            var character = _characterRepo.GetCharacterById(id);
            if (character == null)
            {
                return NotFound();
            }

            _characterRepo.DeleteCharacter(character);
            _characterRepo.SaveChanges();
            return NoContent();
        }
    }
}
