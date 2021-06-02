using ATS.CoreAPI.Model.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Context
{
    public class SQLContext : DbContext
    {
        public SQLContext() { }
        public SQLContext(DbContextOptions<SQLContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=Valdemar; Database=ATSProject; Trusted_Connection=True;");
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CivilState> CivilStates { get; set; }
        public DbSet<ContactType> ContactTypes{ get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<CourseSituation> CourseSituations { get; set; }
        public DbSet<PersonalReferenceType> PersonalReferenceTypes { get; set; }
        public DbSet<ImprovementCourse> ImprovementCourses { get; set; }
        public DbSet<AcademicEducation> AcademicsEducation { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<JobOpportunity> JobOpportunities { get; set; }
        public DbSet<Address> Adresses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PersonalReference> PersonalReferences { get; set; }
        public DbSet<CandidateAcademicEducation> CandidateAcademicsEducation { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<CandidateContact> CandidateContacts { get; set; }
        public DbSet<CandidateExperience> CandidateExperiences { get; set; }
        public DbSet<CandidateImprovementCourse> CandidateImprovementCourses { get; set; }
        public DbSet<CandidatePersonalReference> CandidatePersonalReferences { get; set; }
        public DbSet<CandidateRole> CandidateRoles { get; set; }


    }
}
