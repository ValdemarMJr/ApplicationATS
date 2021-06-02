using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class AtsDbContext : DbContext
    {
        public AtsDbContext()
        {
        }

        public AtsDbContext(DbContextOptions<AtsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicEducation> AcademicEducations { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateAcademicEducation> CandidateAcademicEducations { get; set; }
        public virtual DbSet<CandidateAddress> CandidateAddresses { get; set; }
        public virtual DbSet<CandidateContact> CandidateContacts { get; set; }
        public virtual DbSet<CandidateExperience> CandidateExperiences { get; set; }
        public virtual DbSet<CandidateImprovementCourse> CandidateImprovementCourses { get; set; }
        public virtual DbSet<CandidatePersonalReference> CandidatePersonalReferences { get; set; }
        public virtual DbSet<CandidateRole> CandidateRoles { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CivilStatus> CivilStatuses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<CourseSituation> CourseSituations { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<ImprovementCourse> ImprovementCourses { get; set; }
        public virtual DbSet<JobOpportunity> JobOpportunities { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public virtual DbSet<PersonalReference> PersonalReferences { get; set; }
        public virtual DbSet<PersonalReferenceType> PersonalReferenceTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<State> States { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Valdemar;Initial Catalog=ATSProject;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<AcademicEducation>(entity =>
            {
                entity.HasKey(e => e.CdAcademicEducation);

                entity.ToTable("AcademicEducation");

                entity.Property(e => e.DsCourse)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.CdAddress);

                entity.ToTable("Address");

                entity.Property(e => e.DsComplement).HasMaxLength(200);

                entity.Property(e => e.DsNumber).HasMaxLength(20);

                entity.Property(e => e.DsReferencePoint).HasMaxLength(200);

                entity.Property(e => e.DsStreet)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DsZipCode).HasMaxLength(100);
            });

            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.HasKey(e => e.CdCandidate);

                entity.ToTable("Candidate");

                entity.Property(e => e.CdUfcarteiraTrabalho).HasColumnName("CdUFCarteiraTrabalho");

                entity.Property(e => e.DsCarteiraTrabalho).HasMaxLength(20);

                entity.Property(e => e.DsCategoriaCnh)
                    .HasMaxLength(6)
                    .HasColumnName("DsCategoriaCNH");

                entity.Property(e => e.DsCnh)
                    .HasMaxLength(30)
                    .HasColumnName("DsCNH");

                entity.Property(e => e.DsCpf)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("DsCPF");

                entity.Property(e => e.DsEmail)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DsName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DsRg)
                    .HasMaxLength(20)
                    .HasColumnName("DsRG");

                entity.Property(e => e.DsSerieCarteiraTrabalho).HasMaxLength(10);

                entity.Property(e => e.DsSurname)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DtBirth).HasColumnType("date");

                entity.Property(e => e.DtVencCnh)
                    .HasColumnType("date")
                    .HasColumnName("DtVencCNH");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CdCivilStatusNavigation)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.CdCivilStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidate_CivilStatus");

                entity.HasOne(d => d.CdGenderNavigation)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.CdGender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidate_Gender");

                entity.HasOne(d => d.CdNacionalityNavigation)
                    .WithMany(p => p.CandidateCdNacionalityNavigations)
                    .HasForeignKey(d => d.CdNacionality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Candidate_State");

                entity.HasOne(d => d.CdUfcarteiraTrabalhoNavigation)
                    .WithMany(p => p.CandidateCdUfcarteiraTrabalhoNavigations)
                    .HasForeignKey(d => d.CdUfcarteiraTrabalho)
                    .HasConstraintName("FK_Candidate_UFCarteiraTrabalho_State");
            });

            modelBuilder.Entity<CandidateAcademicEducation>(entity =>
            {
                entity.HasKey(e => e.CdCandidateAcademicEducation);

                entity.ToTable("CandidateAcademicEducation");

                entity.Property(e => e.DtFinish).HasColumnType("date");

                entity.Property(e => e.DtStart).HasColumnType("date");

                entity.HasOne(d => d.CdAcademicEducationNavigation)
                    .WithMany(p => p.CandidateAcademicEducations)
                    .HasForeignKey(d => d.CdAcademicEducation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateAcademicEducation_AcademicEducation");

                entity.HasOne(d => d.CdCandidateNavigation)
                    .WithMany(p => p.CandidateAcademicEducations)
                    .HasForeignKey(d => d.CdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateAcademicEducation_Candidate");

                entity.HasOne(d => d.CdSituationCourseNavigation)
                    .WithMany(p => p.CandidateAcademicEducations)
                    .HasForeignKey(d => d.CdSituationCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateAcademicEducation_SituationCourse");
            });

            modelBuilder.Entity<CandidateAddress>(entity =>
            {
                entity.HasKey(e => e.CdCandidateAddress);

                entity.ToTable("CandidateAddress");

                entity.HasOne(d => d.CdAddressNavigation)
                    .WithMany(p => p.CandidateAddresses)
                    .HasForeignKey(d => d.CdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateAddress_Address");

                entity.HasOne(d => d.CdCandidateNavigation)
                    .WithMany(p => p.CandidateAddresses)
                    .HasForeignKey(d => d.CdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateAddress_Candidate");
            });

            modelBuilder.Entity<CandidateContact>(entity =>
            {
                entity.HasKey(e => e.CdCandidateContact);

                entity.ToTable("CandidateContact");

                entity.HasOne(d => d.CdCandidateNavigation)
                    .WithMany(p => p.CandidateContacts)
                    .HasForeignKey(d => d.CdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateContact_Candidate");

                entity.HasOne(d => d.CdContactNavigation)
                    .WithMany(p => p.CandidateContacts)
                    .HasForeignKey(d => d.CdContact)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateContact_Contact");
            });

            modelBuilder.Entity<CandidateExperience>(entity =>
            {
                entity.HasKey(e => e.CdCandidateExperiences);

                entity.Property(e => e.DsCompany)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DtAdmission).HasColumnType("date");

                entity.Property(e => e.DtResignation).HasColumnType("date");
            });

            modelBuilder.Entity<CandidateImprovementCourse>(entity =>
            {
                entity.HasKey(e => e.CdCandidateImprovementCourse);

                entity.ToTable("CandidateImprovementCourse");

                entity.Property(e => e.DtFinish).HasColumnType("date");

                entity.Property(e => e.DtStart).HasColumnType("date");

                entity.HasOne(d => d.CdCandidateNavigation)
                    .WithMany(p => p.CandidateImprovementCourses)
                    .HasForeignKey(d => d.CdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateImprovementCourse_Candidate");

                entity.HasOne(d => d.CdImprovementCourseNavigation)
                    .WithMany(p => p.CandidateImprovementCourses)
                    .HasForeignKey(d => d.CdImprovementCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateImprovementCourse_ImprovementCourse");

                entity.HasOne(d => d.CdSituationCourseNavigation)
                    .WithMany(p => p.CandidateImprovementCourses)
                    .HasForeignKey(d => d.CdSituationCourse)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateImprovementCourse_SituationCourse");
            });

            modelBuilder.Entity<CandidatePersonalReference>(entity =>
            {
                entity.HasKey(e => e.CdCandidatePersonalReference);

                entity.ToTable("CandidatePersonalReference");

                entity.HasOne(d => d.CdCandidateNavigation)
                    .WithMany(p => p.CandidatePersonalReferences)
                    .HasForeignKey(d => d.CdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatePersonalReference_Candidate");

                entity.HasOne(d => d.CdPersonalReferenceNavigation)
                    .WithMany(p => p.CandidatePersonalReferences)
                    .HasForeignKey(d => d.CdPersonalReference)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidatePersonalReference_PersonalReference");
            });

            modelBuilder.Entity<CandidateRole>(entity =>
            {
                entity.HasKey(e => e.CdCandidateRole);

                entity.ToTable("CandidateRole");

                entity.HasOne(d => d.CdCandidateNavigation)
                    .WithMany(p => p.CandidateRoles)
                    .HasForeignKey(d => d.CdCandidate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateRole_Candidate");

                entity.HasOne(d => d.CdRoleNavigation)
                    .WithMany(p => p.CandidateRoles)
                    .HasForeignKey(d => d.CdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CandidateRole_Role");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CdCity);

                entity.ToTable("City");

                entity.Property(e => e.DsCity)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CdStateNavigation)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City_State");
            });

            modelBuilder.Entity<CivilStatus>(entity =>
            {
                entity.HasKey(e => e.CdCivilStatus);

                entity.ToTable("CivilStatus");

                entity.Property(e => e.DsCivilStatus)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.StInactive)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.CdContact);

                entity.ToTable("Contact");

                entity.Property(e => e.DsContact)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DsContactName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.CdContactTypeNavigation)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.CdContactType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Contact_Contact");
            });

            modelBuilder.Entity<ContactType>(entity =>
            {
                entity.HasKey(e => e.CdContactType);

                entity.ToTable("ContactType");

                entity.Property(e => e.DsContactType)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CourseSituation>(entity =>
            {
                entity.HasKey(e => e.CdSituationCourse)
                    .HasName("PK_SituationCourse");

                entity.ToTable("CourseSituation");

                entity.Property(e => e.DsSituationCourse)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.HasKey(e => e.CdGender);

                entity.ToTable("Gender");

                entity.Property(e => e.DsGender)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ImprovementCourse>(entity =>
            {
                entity.HasKey(e => e.CdImprovementCourses)
                    .HasName("PK_ImprovementCourses");

                entity.ToTable("ImprovementCourse");

                entity.Property(e => e.DsImprovementCourses)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<JobOpportunity>(entity =>
            {
                entity.HasKey(e => e.CdJobOpportunity);

                entity.ToTable("JobOpportunity");

                entity.Property(e => e.DsJobOpportunity)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.HasKey(e => e.CdNeighborhood);

                entity.ToTable("Neighborhood");

                entity.Property(e => e.DsNeighborhood)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<PersonalReference>(entity =>
            {
                entity.HasKey(e => e.CdPersonalReference);

                entity.ToTable("PersonalReference");

                entity.Property(e => e.DsName)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.DsTelephone)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersonalReferenceType>(entity =>
            {
                entity.HasKey(e => e.CdPersonalReferenceType)
                    .HasName("PK_TypePersonalReferences");

                entity.ToTable("PersonalReferenceType");

                entity.Property(e => e.DsPersonalReferenceType)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.CdRole)
                    .HasName("PK_Role_1");

                entity.ToTable("Role");

                entity.Property(e => e.DsRole)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.CdState);

                entity.ToTable("State");

                entity.Property(e => e.DsName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DsShorName)
                    .IsRequired()
                    .HasMaxLength(5);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
