using assignment_api.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_api.Dtos
{
    public class PatientReadDto
    {
        public int Id { get; set; }//Id: GUID,
        public string Name { get; set; }//Name: String,
        public int FileNo { get; set; }// FileNo: Number, //(Max Length 10)
        public string CitizenId { get; set; }// CitizenId: String,
        public DateTime Birthdate { get; set; }// Birthdate: Date,
        public Genders Gender { get; set; }// Genders: 0 for Male  1 for Female,
        public string Natinality { get; set; }// Natinality: String,
        public string PhoneNumber { get; set; }// PhoneNumber: String, //Start with 0090
        public string Email { get; set; }// Email: String
    }
}
