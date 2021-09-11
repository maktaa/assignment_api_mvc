using assignment_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_api.Data
{
    public interface IPatientRepos
    {
        bool SaveChanes();
        Task <IEnumerable<Patient>> GetAallPatientsAsync();
        IEnumerable<Patient> GetAallPatients();
        Patient GetPatientById(int Id);
        void CreatePatient(Patient patient);
        void UpdatePatient(Patient patient);
        void DeletePatient(Patient patient);
    }
}
