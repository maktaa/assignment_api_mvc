using assignment_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment_api.Data
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> opt) : base(opt)
        {

        }

        //Represent our object as a dataset from DB
        public DbSet<Patient> Patients { get; set; }
    }
}
