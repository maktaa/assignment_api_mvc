using assignment_api.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_api.Dtos
{
    public class PatientUpdateDto
    {
        [Required]
        public string Name { get; set; }//Name: String,
        [Required]
        public int FileNo { get; set; }// FileNo: Number, //(Max Length 10)
        [Required]
        public string CitizenId { get; set; }// CitizenId: String,
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthdate { get; set; }// Birthdate: Date,
        [Required]
        public Genders Gender { get; set; }// Genders: 0 for Male  1 for Female,
        [Required]
        public string Natinality { get; set; }// Natinality: String,
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }// PhoneNumber: String, //Start with 0090
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }// Email: String
    }
}
