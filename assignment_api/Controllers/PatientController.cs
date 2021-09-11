using assignment_api.Dtos;
using assignment_api.Data;
using assignment_api.Models;
using assignment_api.Util;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment_api.Util.Pagination;

namespace assignment_api.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientRepos _repository;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public PatientController(IPatientRepos repository, IMapper mapper, IUriService  uriService)
        {
            _repository = repository;
            _mapper = mapper;
            _uriService = uriService;
        }
        [HttpGet]
        public async Task< ActionResult<IEnumerable<PatientReadDto>>> GetAllPatients([FromQuery] PaginationFilter filter)
        {
            var patientItems = await _repository.GetAallPatientsAsync();

            var route = Request.Path.Value;
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData =  patientItems
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToList();
            var pagedReponse = PaginationHelper.CreatePagedReponse(pagedData, validFilter, patientItems.Count(), _uriService, route);
            return Ok(pagedReponse);
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<PatientReadDto>> GetAllPatients()
        //{
        //    var patientItems = _repository.GetAallPatients();
        //    //yield return patientItems;
        //    if (patientItems != null && patientItems.Count() > 0)
        //    {
        //        return Ok(_mapper.Map<IEnumerable<PatientReadDto>>(patientItems));
        //    }
        //    else
        //    {
        //        return NotFound();

        //    }
        //}
        [HttpGet("{Id}", Name = "GetPatientById")]
        public ActionResult<PatientReadDto> GetPatientById(int Id)
        {
            var patientItems = _repository.GetPatientById(Id);
            //return patientItems;
            if (patientItems != null)
            {
                return Ok(_mapper.Map<PatientReadDto>(patientItems));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public ActionResult<PatientReadDto> CreatePatient(PatientCreateDto patientCreateDto)
        {
            var patientModelva = _mapper.Map<PatientValidator>(patientCreateDto);
            var patientModel = _mapper.Map<Patient>(patientCreateDto);
            var valRes = patientModelva.Validate(patientModel);
            if (!valRes.IsValid)
            {
                return Ok(new Response<object> { Succeeded = false, Message = "Check enterd data" , Errors = valRes.Errors.Select(x=>x.ErrorMessage).ToArray()  });
            }

            _repository.CreatePatient(patientModel);
            _repository.SaveChanes();
            var patientReadDto = _mapper.Map<PatientReadDto>(patientModel);
            return CreatedAtRoute(nameof(GetPatientById), new { Id = patientReadDto.Id }, patientReadDto);
            //return Ok(patientReadDto);
        }

        [HttpPut("{Id}")]
        public ActionResult UpdatePatient(int Id, PatientUpdateDto patientUpdateDto)
        {
            var patientModelva = _mapper.Map<PatientValidator>(patientUpdateDto);
            var patientModel = _mapper.Map<Patient>(patientUpdateDto);
            var valRes = patientModelva.Validate(patientModel);
            if (!valRes.IsValid)
            {
                return Ok(new Response<object> { Succeeded = false, Message = "Check enterd data", Errors = valRes.Errors.Select(x => x.ErrorMessage).ToArray() });
            }

            var patientModelFromRpos = _repository.GetPatientById(Id);
            if (patientModelFromRpos != null)
            {
                _mapper.Map(patientUpdateDto, patientModelFromRpos);
                _repository.UpdatePatient(patientModelFromRpos);
                _repository.SaveChanes();
                var patientReadDto = _mapper.Map<PatientReadDto>(patientModelFromRpos);
                return CreatedAtRoute(nameof(GetPatientById), new { Id = patientReadDto.Id }, patientReadDto); ;
            }
            else
            {
                return NotFound();
            }
        }


        [HttpDelete("{Id}")]
        public ActionResult DeletePatient(int Id)
        {
            var patientModelFromRpos = _repository.GetPatientById(Id);
            if (patientModelFromRpos != null)
            {
                _repository.DeletePatient(patientModelFromRpos);
                _repository.SaveChanes();
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

    }
}
