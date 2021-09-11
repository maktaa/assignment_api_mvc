using assignment_api.Dtos;
using assignment_api.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_api.Profiles
{
    public class PatientProfile :Profile
    {
        public PatientProfile()
        {
            //CreateMap<Patient, PatientReadDto>();
            //CreateMap<PatientCreateDto, Patient>();
            //CreateMap<PatientUpdateDto, Patient>();
            //CreateMap<Patient, PatientUpdateDto>();

            CreateMap<PatientCreateDto, Patient>();
            CreateMap<Patient, PatientReadDto>();
            CreateMap<PatientCreateDto, PatientValidator>();
            CreateMap<PatientUpdateDto, PatientValidator>();
            CreateMap<PatientValidator, Patient>();
            CreateMap<PatientUpdateDto, Patient>();
            CreateMap<Patient, PatientUpdateDto>();
        }
    }
}
