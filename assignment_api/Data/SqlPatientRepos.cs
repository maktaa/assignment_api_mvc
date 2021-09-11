using assignment_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_api.Data
{
    public class SqlPatientRepos : IPatientRepos
    {
        private readonly PatientContext _context;

        public SqlPatientRepos(PatientContext context)
        {
            _context = context;
        }

        public void CreatePatient(Patient patient)
        {
            if(patient ==  null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            _context.Patients.Add(patient);
        }

        public void DeletePatient(Patient patient)
        {
            if (patient == null)
            {
                throw new ArgumentNullException(nameof(patient));
            }
            _context.Patients.Remove(patient);
        }

        IEnumerable<Patient> IPatientRepos.GetAallPatients()
        {
            return _context.Patients.OrderBy(x => x.Name).ThenBy(x => x.FileNo).ThenBy(x => x.FileNo)
                .ToList();
        }
        public async Task<IEnumerable<Patient>> GetAallPatientsAsync()
        {
            return _context.Patients.OrderBy(x => x.Name).ThenBy(x => x.FileNo).ThenBy(x => x.FileNo)
                .ToList();
        }

        public Patient GetPatientById(int Id)
        {
            return _context.Patients.FirstOrDefault(x => x.Id == Id);
        }

        public bool SaveChanes()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePatient(Patient patient)
        {

        }


    }
}
