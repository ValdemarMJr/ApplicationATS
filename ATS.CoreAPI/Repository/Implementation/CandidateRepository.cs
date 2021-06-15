using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly SQLContext _context;

        public CandidateRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == id);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                _context.Candidates.Remove(candidateContext);
                _context.SaveChanges();
                return true;
            }
        }

        public Candidate Get(int id)
        {
            Candidate candidate = new Candidate();
            candidate = _context.Candidates.FirstOrDefault(c => c.ID == id);

            if (candidate != null)
            {

                if (candidate.CivilStateID > 0)
                    candidate.CivilState = _context.CivilStates.First(c => c.ID == candidate.CivilStateID);
                else
                    candidate.CivilState = new CivilState();

                if (candidate.GenderID > 0)
                    candidate.Gender = _context.Genders.First(g => g.ID == candidate.GenderID);
                else
                    candidate.Gender = new Gender();

                if (candidate.PlaceOfBirthID > 0)
                    candidate.PlaceOfBirth = _context.Cities.First(c => c.ID == candidate.PlaceOfBirthID);
                else
                    candidate.PlaceOfBirth = new City();

                if (candidate.AddressID > 0)
                {
                    candidate.Address = _context.Adresses.First(a => a.ID == candidate.AddressID);

                    if (candidate.Address != null && candidate.Address.NeighborhoodID > 0)
                    {
                        candidate.Address.Neighborhood = _context.Neighborhoods.First(n => n.ID == candidate.Address.NeighborhoodID);

                        if (candidate.Address.Neighborhood != null && candidate.Address.Neighborhood.ID > 0)
                        {
                            candidate.Address.Neighborhood.City = _context.Cities.First(c => c.ID == candidate.Address.Neighborhood.CityID);

                            if (candidate.Address.Neighborhood.City != null && candidate.Address.Neighborhood.City.ID > 0)
                                candidate.Address.Neighborhood.City.State = _context.States.First(s => s.ID == candidate.Address.Neighborhood.City.StateID);
                        }
                    }
                }
                else
                {
                    candidate.Address = new Address();
                    candidate.Address.Neighborhood = new Neighborhood();
                    candidate.Address.Neighborhood.City = new City();
                    candidate.Address.Neighborhood.City.State = new State();
                }
            }

            return candidate;
        }

        public List<CandidateAcademicEducation> GetAcademicEducationByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                List<CandidateAcademicEducation> candidateEducations = new List<CandidateAcademicEducation>();
                candidateEducations = _context.CandidateAcademicsEducation.Where(ce => ce.CandidateID == candidateID).ToList();

                if (candidateEducations != null)
                {
                    foreach (var item in candidateEducations)
                    {
                        if (item.AcademicEducationID > 0)
                            item.AcademicEducation = _context.AcademicsEducation.First(a => a.ID == item.AcademicEducationID);

                        if (item.SituationCourseID > 0)
                            item.CourseSituation = _context.CourseSituations.First(c => c.ID == item.SituationCourseID);
                    }
                }

                return candidateEducations;
            }
        }

        public Candidate GetByCPF(string CPF)
        {
            return _context.Candidates.FirstOrDefault(c => c.User.CPF == CPF);
        }

        public Candidate GetByEmail(string email)
        {
            return _context.Candidates.FirstOrDefault(c => c.User.Email == email);
        }

        public List<CandidateContact> GetContactsByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                return _context.CandidateContacts.Where(cc => cc.CandidateID == candidateID).ToList();

            }
        }

        public List<CandidateExperience> GetExperiencesByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                List<CandidateExperience> experiences = new List<CandidateExperience>();
                experiences = _context.CandidateExperiences.Where(ce => ce.CandidateID == candidateID).ToList();
                return experiences;

            }
        }

        public List<CandidateImprovementCourse> GetImprovmentCoursesByCandidate(int candidateID)
        {
            
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                List<CandidateImprovementCourse> courses = new List<CandidateImprovementCourse>();
                courses = _context.CandidateImprovementCourses.Where(ce => ce.CandidateID == candidateID).ToList();

                if(courses != null)
                {
                    foreach (var item in courses)
                    {
                        if(item.ImprovementCourseID > 0)
                            item.ImprovementCourse = _context.ImprovementCourses.First(a => a.ID == item.ImprovementCourseID);

                        if (item.SituationCourseID > 0)
                            item.SituationCourse = _context.CourseSituations.First(c => c.ID == item.SituationCourseID);
                    }
                }

                return courses;

            }
        }

        public List<CandidatePersonalReference> GetPersonalReferencesByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                List<CandidatePersonalReference> personalReferences = new List<CandidatePersonalReference>();
                personalReferences = _context.CandidatePersonalReferences.Where(ce => ce.CandidateID == candidateID).ToList();

                if(personalReferences != null)
                {
                    foreach (var item in personalReferences)
                    {
                        if(item.PersonalReferenceID > 0)
                            item.PersonalReference = _context.PersonalReferences.First(a => a.ID == item.PersonalReferenceID);

                        if (item.PersonalReference != null && item.PersonalReference.PersonalReferenceTypeID > 0)
                            item.PersonalReference.PersonalReferenceType = _context.PersonalReferenceTypes.First(a => a.ID == item.PersonalReference.PersonalReferenceTypeID);
                    }
                }

                return personalReferences;

            }
        }

        public List<CandidateRole> GetRolesByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                List<CandidateRole> roles = new List<CandidateRole>();
                roles = _context.CandidateRoles.Where(ce => ce.CandidateID == candidateID).ToList();

                if(roles != null)
                {
                    foreach (var item in roles)
                    {
                        if (item.RoleID > 0)
                            item.Role = _context.Roles.First(r => r.ID == item.RoleID);
                    }
                }
                return roles;

            }
        }

        public int Save(Candidate candidate)
        {
            int candidateID = 0;
            int addressID = 0;
            int personalReferenceID = 0;
            int improvmentCourseID = 0;
            int academicEducationID = 0;
            int roleID = 0;

            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidate.ID);

            /*if (candidate.Contacts == null || candidate.Contacts.Count <= 0)
                throw new CandidateContactsIsRequiredException();*/
            if (candidate.Address == null)
                throw new CandidateAddressIsRequiredException();
            else if (candidate.Gender == null || candidate.GenderID <= 0)
                throw new GenderIsRequiredException();
            else if (candidate.CivilState == null || candidate.CivilStateID <= 0)
                throw new CivilStateIsRequiredException();
            else if (candidate.PlaceOfBirth == null || candidate.PlaceOfBirthID <= 0)
                throw new PlaceOfBirthIsRequiredException();
            else
            {
                if (candidateContext is null)
                {
                    _context.Adresses.Add(candidate.Address);
                    addressID = candidate.Address.ID;

                    #region INSERT ADDRESS

                    candidate.AddressID = addressID;

                    #endregion

                    _context.Candidates.Add(candidate);
                    candidateID = candidate.ID;

                    #region INSERT CONTACTS
                    if (candidate.Contacts != null)
                    {
                        foreach (var contact in candidate.Contacts)
                        {
                            int contactID = _context.Contacts.Add(contact.Contact).Entity.ID;
                            contact.ContactID = contactID;
                            contact.CandidateID = candidateID;
                            _context.CandidateContacts.Add(contact);
                        }
                    }
                    #endregion

                    #region INSERT ACADEMIC EDUCATION
                    if (candidate.AcademicsEducation != null)
                    {
                        foreach (var academicEducation in candidate.AcademicsEducation)
                        {
                            if (academicEducation.AcademicEducationID <= 0)
                            {
                                _context.AcademicsEducation.Add(academicEducation.AcademicEducation);
                                academicEducationID = academicEducation.AcademicEducation.ID;
                            }
                            else
                                academicEducationID = academicEducation.AcademicEducationID;

                            academicEducation.AcademicEducationID = academicEducationID;
                            academicEducation.CandidateID = candidateID;
                            _context.CandidateAcademicsEducation.Add(academicEducation);
                        }
                    }
                    #endregion

                    #region INSERT IMPROVMENT COURSES
                    if (candidate.ImprovementCourses != null)
                    {
                        foreach (var improvementCourse in candidate.ImprovementCourses)
                        {
                            if (improvementCourse.ImprovementCourseID <= 0)
                            {
                                _context.ImprovementCourses.Add(improvementCourse.ImprovementCourse);
                                improvmentCourseID = improvementCourse.ImprovementCourse.ID;
                            }
                            else
                                improvmentCourseID = improvementCourse.ImprovementCourseID;

                            improvementCourse.ImprovementCourseID = improvmentCourseID;
                            improvementCourse.CandidateID = candidateID;
                            _context.CandidateImprovementCourses.Add(improvementCourse);

                        }
                    }
                    #endregion

                    #region INSERT EXPERIENCES
                    if (candidate.Experiences != null)
                    {
                        foreach (var experience in candidate.Experiences)
                        {
                            experience.CandidateID = candidateID;
                            _context.CandidateExperiences.Add(experience);
                        }
                    }
                    #endregion

                    #region INSERT PERSONAL REFERENCE
                    if (candidate.PersonalReferences != null)
                    {
                        foreach (var personalReference in candidate.PersonalReferences)
                        {
                            if (personalReference.PersonalReferenceID <= 0)
                            {
                                _context.PersonalReferences.Add(personalReference.PersonalReference);
                                personalReferenceID = personalReference.PersonalReference.ID;
                            }
                            else
                                personalReferenceID = personalReference.PersonalReferenceID;

                            personalReference.CandidateID = candidateID;
                            _context.CandidatePersonalReferences.Add(personalReference);
                        }
                    }
                    #endregion

                    #region INSERT ROLES
                    if (candidate.Roles != null)
                    {
                        foreach (var role in candidate.Roles)
                        {
                            if (role.RoleID <= 0)
                            {
                                _context.Roles.Add(role.Role);
                                roleID = role.Role.ID;
                            }
                            else
                                roleID = role.RoleID;

                            role.CandidateID = candidateID;
                            role.RoleID = roleID;
                            _context.CandidateRoles.Add(role);
                        }
                    }
                    #endregion

                    _context.SaveChanges();
                }
                else
                {

                    #region UPDATE ADDRESS

                    //SE JA EXISTIA ENDEREÇO PARA O CONTATO, ATUALIZA AS INFORMAÇÕES DO ENDEREÇO
                    if (candidate.Address != null && candidate.AddressID > 0)
                    {
                        Address addressContext = _context.Adresses.FirstOrDefault(a => a.ID == candidate.AddressID);

                        addressContext.Street = candidate.Address.Street;
                        addressContext.Number = candidate.Address.Number;
                        addressContext.Complement = candidate.Address.Complement;
                        addressContext.ReferencePoint = candidate.Address.ReferencePoint;
                        addressContext.NeighborhoodID = candidate.Address.NeighborhoodID;
                        addressContext.ZipCode = candidate.Address.ZipCode;

                        _context.SaveChanges();

                        addressID = addressContext.ID;

                    }
                    else if (candidate.Address != null && candidate.AddressID <= 0)
                    {
                        //SE NAO EXISITIA A INFORMAÇÃO DO ENDEREÇO DO CONTATO, INSERE
                        _context.Adresses.Add(candidate.Address);
                        addressID = candidate.Address.ID;
                    }

                    #endregion

                    #region UPDATE CONTACTS

                    if (candidate.Contacts != null)
                    {

                        foreach (var contact in candidate.Contacts)
                        {
                            int contactID = 0;

                            if (contact.ID <= 0) // NAO ENCONTROU NA CANDIDATO CONTRATO
                            {
                                contact.CandidateID = candidateID;

                                if (contact.ContactID <= 0) // NAO ENCONTROU NA CONTATO
                                {
                                    //INSERIR REGISTRO NA CONTATO
                                    _context.Contacts.Add(contact.Contact);
                                    contactID = contact.Contact.ID;
                                    contact.ContactID = contactID;

                                    //INSERE REGISTRO NA CANDIDADO CONTATO
                                    _context.CandidateContacts.Add(contact);
                                }
                                else // ENCONTROU NA CONTATO
                                {
                                    //ATUALIZA O CONTATO
                                    Contact contactContext = _context.Contacts.FirstOrDefault(c => c.ID == contact.ID);
                                    contactContext.ContactTypeID = contact.Contact.ContactTypeID;
                                    contactContext.Information = contact.Contact.Information;
                                    contactContext.Name = contact.Contact.Name;
                                    contact.ContactID = contactID;
                                    _context.SaveChanges();
                                }
                            }
                            else // ENCONTROU NA CANDIDATO CONTATO
                            {
                                //NAO ENCONTROU NA CONTATO
                                if (contact.ContactID <= 0)
                                {
                                    //INSERE NA CONTATO
                                    _context.Contacts.Add(contact.Contact);
                                    contactID = contact.Contact.ID;

                                    // INSERE NA CANDIDATO CONTATO
                                    contact.ContactID = contactID;
                                    _context.CandidateContacts.Add(contact);
                                }
                                else
                                {
                                    Contact contactContext = _context.Contacts.FirstOrDefault(c => c.ID == contact.ContactID);
                                    contactContext.ContactTypeID = contact.Contact.ContactTypeID;
                                    contactContext.Name = contact.Contact.Name;
                                    contactContext.Information = contact.Contact.Information;
                                    _context.SaveChanges();
                                }
                            }
                        }
                    }
                    #endregion

                    #region UPDATE ACADEMIC EDUCATION

                    if (candidate.AcademicsEducation != null)
                    {
                        foreach (var academicEducation in candidate.AcademicsEducation)
                        {
                            //NAO ENCONTROU NA CANDIDATO ACADEMICS EDUCATION
                            if (academicEducation.ID <= 0)
                            {
                                //INSERE NA CANDIDATO ACADEMICS EDUCATION
                                academicEducation.CandidateID = candidateID;
                                _context.CandidateAcademicsEducation.Add(academicEducation);
                            }
                            else // ENCONTROU NA CANDIDATO ACADEMICS EDUCATION
                            {
                                CandidateAcademicEducation candidateAcademicEducationContext = _context.CandidateAcademicsEducation.FirstOrDefault(a => a.ID == academicEducation.ID);
                                candidateAcademicEducationContext.AcademicEducationID = academicEducation.AcademicEducationID;
                                candidateAcademicEducationContext.SituationCourseID = academicEducation.SituationCourseID;
                                candidateAcademicEducationContext.DtStart = academicEducation.DtStart;
                                candidateAcademicEducationContext.DtFinish = academicEducation.DtFinish;
                                candidateAcademicEducationContext.CandidateID = candidateID;
                                _context.SaveChanges();
                            }
                        }
                    }
                    #endregion

                    #region UPDATE IMPROVMENT COURSES
                    if (candidate.ImprovementCourses != null)
                    {
                        foreach (var improvementCourse in candidate.ImprovementCourses)
                        {
                            //SE NAO ESTA ASSOCIADO COM A CANDIDATO IMPROVMENT COURSE
                            if (improvementCourse.ID <= 0)
                            {
                                //SE NÃO EXISTE NA IMPROVMENT COURSE INSERE
                                if (improvementCourse.ImprovementCourseID <= 0)
                                {
                                    _context.ImprovementCourses.Add(improvementCourse.ImprovementCourse);
                                    improvmentCourseID = improvementCourse.ImprovementCourse.ID;
                                }
                                else
                                    improvmentCourseID = improvementCourse.ImprovementCourseID;

                                //INSERE O VINCULO DO IMPROVMENT COURSE COM A CANDIDATO
                                improvementCourse.ImprovementCourseID = improvmentCourseID;
                                improvementCourse.CandidateID = candidateID;
                                _context.CandidateImprovementCourses.Add(improvementCourse);
                            }
                            else //SE ESTAVA CADASTRADO NA CANDIDATO IMPROVMENT COURSE, ALTERA AS INFORMAÇÕES
                            {

                                //SE NÃO EXISTE NA IMPROVMENT COURSE INSERE
                                if (improvementCourse.ImprovementCourseID <= 0)
                                {
                                    _context.ImprovementCourses.Add(improvementCourse.ImprovementCourse);
                                    improvmentCourseID = improvementCourse.ImprovementCourse.ID;
                                }
                                else
                                    improvmentCourseID = improvementCourse.ImprovementCourseID;

                                CandidateImprovementCourse improvementCourseContext = _context.CandidateImprovementCourses.FirstOrDefault(c => c.ID == improvementCourse.ID);
                                improvementCourseContext.CandidateID = improvementCourse.CandidateID;
                                improvementCourseContext.DtStart = improvementCourse.DtStart;
                                improvementCourseContext.DtFinish = improvementCourse.DtFinish;
                                improvementCourseContext.ImprovementCourseID = improvmentCourseID;
                                improvementCourseContext.SituationCourseID = improvementCourse.SituationCourseID;
                                improvementCourseContext.CandidateID = candidateID;
                                _context.SaveChanges();
                            }
                        }
                    }
                    #endregion

                    #region UPDATE EXPERIENCES
                    if (candidate.Experiences != null)
                    {
                        foreach (var experience in candidate.Experiences)
                        {
                            //SE A EXPERIENCIA NÃO ESTA CADASTRADA NA CANDIDATO EXPERIENCES
                            if (experience.ID <= 0)
                            {
                                //INSERE REGISTRO NA CANDIDATO EXPERIENCES
                                experience.CandidateID = candidateID;
                                _context.CandidateExperiences.Add(experience);
                            }
                            else // SE JA ESTA CADASTRADA NA CANDIDATO EXPERIENCES
                            {
                                CandidateExperience candidateExperienceContext = _context.CandidateExperiences.FirstOrDefault(c => c.ID == experience.ID);
                                candidateExperienceContext.CandidateID = candidateID;
                                candidateExperienceContext.Activities = experience.Activities;
                                candidateExperienceContext.Company = experience.Company;
                                candidateExperienceContext.DtAdmission = experience.DtAdmission;
                                candidateExperienceContext.DtResignation = experience.DtResignation;
                                _context.SaveChanges();
                            }
                        }
                    }
                    #endregion

                    #region UPDATE PERSONAL REFERENCE
                    if (candidate.PersonalReferences != null)
                    {
                        foreach (var personalReference in candidate.PersonalReferences)
                        {
                            if (personalReference.ID <= 0)
                            {
                                if (personalReference.PersonalReferenceID <= 0)
                                {
                                    _context.PersonalReferences.Add(personalReference.PersonalReference);
                                    personalReferenceID = personalReference.PersonalReference.ID;
                                }
                                else
                                    personalReferenceID = personalReference.PersonalReferenceID;

                                personalReference.PersonalReferenceID = personalReferenceID;
                                personalReference.CandidateID = candidateID;
                                _context.CandidatePersonalReferences.Add(personalReference);
                            }
                            else
                            {
                                if (personalReference.PersonalReferenceID <= 0)
                                    personalReferenceID = _context.PersonalReferences.Add(personalReference.PersonalReference).Entity.ID;
                                else
                                    personalReferenceID = personalReference.PersonalReferenceID;

                                CandidatePersonalReference candidatePersonalReferenceContext = _context.CandidatePersonalReferences.FirstOrDefault(c => c.ID == personalReference.ID);
                                candidatePersonalReferenceContext.CandidateID = candidateID;
                                candidatePersonalReferenceContext.PersonalReferenceID = personalReferenceID;
                                _context.SaveChanges();
                            }
                        }
                    }
                    #endregion

                    #region UPDATE ROLES
                    if (candidate.Roles != null)
                    {
                        foreach (var role in candidate.Roles)
                        {
                            if (role.ID <= 0)
                            {
                                if (role.RoleID <= 0)
                                {
                                    _context.Roles.Add(role.Role);
                                    roleID = role.Role.ID;
                                }
                                else
                                    roleID = role.RoleID;

                                role.RoleID = roleID;
                                role.CandidateID = candidateID;
                                _context.CandidateRoles.Add(role);
                            }
                            else
                            {
                                if (role.RoleID <= 0)
                                {
                                    _context.Roles.Add(role.Role);
                                    roleID = role.Role.ID;
                                }
                                else
                                    roleID = role.RoleID;

                                CandidateRole candidateRoleContext = _context.CandidateRoles.FirstOrDefault(c => c.ID == role.ID);
                                candidateRoleContext.CandidateID = candidateID;
                                candidateRoleContext.RoleID = roleID;
                                _context.SaveChanges();
                            }
                        }
                    }
                    #endregion

                    candidateContext.BirthDate = candidate.BirthDate;
                    candidateContext.PlaceOfBirthID = candidate.PlaceOfBirthID;
                    candidateContext.GenderID = candidate.GenderID;
                    candidateContext.CNH = candidate.CNH;
                    candidateContext.RG = candidate.RG;
                    candidateContext.CarteiraTrabalho = candidate.CarteiraTrabalho;
                    candidateContext.SerieCarteiraTrabalho = candidate.SerieCarteiraTrabalho;
                    candidateContext.CategoriaCNH = candidate.CategoriaCNH;
                    candidateContext.ExpirationDateCNH = candidate.ExpirationDateCNH;
                    candidateContext.CivilStateID = candidate.CivilStateID;
                    candidateContext.AddressID = addressID;
                    _context.SaveChanges();

                    candidateID = candidateContext.ID;
                }
            }
            return candidateID;
        }

        public int SaveCandidateImprovmentCourse(CandidateImprovementCourse candidateImprovmentCourse)
        {
            int candidateImprovmentCourseID = 0;
            var candidateImprovmentCourseContext = _context.CandidateImprovementCourses.FirstOrDefault(c => c.ID == candidateImprovmentCourse.ID);

            if (candidateImprovmentCourse.CandidateID == null || candidateImprovmentCourse.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateImprovmentCourse.ImprovementCourseID == null || candidateImprovmentCourse.ImprovementCourseID <=0)
                throw new ImprovmentCourseIsRequiredExceptions();
            else if (candidateImprovmentCourse.SituationCourseID == null || candidateImprovmentCourse.SituationCourseID <= 0)
                throw new SituationCourseIsRequiredExceptions();
            else if (candidateImprovmentCourse.DtStart == null || candidateImprovmentCourse.DtStart == DateTime.MinValue)
                throw new DateStartCourseIsRequiredExceptions();
            else
            {
                if (candidateImprovmentCourseContext is null)
                {
                    _context.CandidateImprovementCourses.Add(candidateImprovmentCourse);
                    _context.SaveChanges();

                    candidateImprovmentCourseID = candidateImprovmentCourse.ID;
                }
                else
                {
                    candidateImprovmentCourseContext.CandidateID = candidateImprovmentCourse.CandidateID;
                    candidateImprovmentCourseContext.ImprovementCourseID = candidateImprovmentCourse.ImprovementCourseID;
                    candidateImprovmentCourseContext.SituationCourseID = candidateImprovmentCourse.SituationCourseID;
                    candidateImprovmentCourseContext.DtStart = candidateImprovmentCourse.DtStart;
                    candidateImprovmentCourseContext.DtFinish = candidateImprovmentCourse.DtStart;

                    _context.SaveChanges();

                    candidateImprovmentCourseID = candidateImprovmentCourseContext.ID;
                }
            }

            return candidateImprovmentCourseID;
        }

        public int SaveCandidateAcademicEducation(CandidateAcademicEducation candidateAcademicEducation)
        {
            int candidateAcademicSituationID = 0;
            var candidateAcademicSituationContext = _context.CandidateAcademicsEducation.FirstOrDefault(c => c.ID == candidateAcademicEducation.ID);

            if (candidateAcademicEducation.CandidateID == null || candidateAcademicEducation.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateAcademicEducation.AcademicEducationID == null || candidateAcademicEducation.AcademicEducationID <= 0)
                throw new AcademicEducationIsRequiredExceptions();
            else if (candidateAcademicEducation.SituationCourseID == null || candidateAcademicEducation.SituationCourseID <= 0)
                throw new SituationCourseIsRequiredExceptions();
            else if (candidateAcademicEducation.DtStart == null || candidateAcademicEducation.DtStart == DateTime.MinValue)
                throw new DateStartCourseIsRequiredExceptions();
            else
            {
                if (candidateAcademicSituationContext is null)
                {
                    _context.CandidateAcademicsEducation.Add(candidateAcademicEducation);
                    _context.SaveChanges();

                    candidateAcademicSituationID = candidateAcademicEducation.ID;
                }
                else
                {
                    candidateAcademicSituationContext.CandidateID = candidateAcademicEducation.CandidateID;
                    candidateAcademicSituationContext.AcademicEducationID = candidateAcademicEducation.AcademicEducationID;
                    candidateAcademicSituationContext.SituationCourseID = candidateAcademicEducation.SituationCourseID;
                    candidateAcademicSituationContext.DtStart = candidateAcademicEducation.DtStart;
                    candidateAcademicSituationContext.DtFinish = candidateAcademicEducation.DtStart;

                    _context.SaveChanges();

                    candidateAcademicSituationID = candidateAcademicSituationContext.ID;
                }
            }

            return candidateAcademicSituationID;
        }

        public int SaveCandidateExperiences(CandidateExperience candidateExperience)
        {
            int candidateExperienceID = 0;
            var candidateExperienceContext = _context.CandidateExperiences.FirstOrDefault(c => c.ID == candidateExperience.ID);

            if (candidateExperience.CandidateID == null || candidateExperience.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateExperience.Company == null || String.IsNullOrEmpty(candidateExperience.Company))
                throw new CompanyNameIsRequiredExceptions();
            else if (candidateExperience.Activities == null || String.IsNullOrEmpty(candidateExperience.Activities))
                throw new ActivitiesIsRequiredExceptions();
            else if (candidateExperience.DtAdmission == null || candidateExperience.DtAdmission == DateTime.MinValue)
                throw new DateAdmissionIsRequiredExceptions();
            else
            {
                if (candidateExperienceContext is null)
                {
                    _context.CandidateExperiences.Add(candidateExperience);
                    _context.SaveChanges();

                    candidateExperienceID = candidateExperience.ID;
                }
                else
                {
                    candidateExperienceContext.CandidateID = candidateExperience.CandidateID;
                    candidateExperienceContext.Company = candidateExperience.Company;
                    candidateExperienceContext.Activities = candidateExperience.Activities;
                    candidateExperienceContext.DtAdmission = candidateExperience.DtAdmission;
                    candidateExperienceContext.DtResignation   = candidateExperience.DtResignation;

                    _context.SaveChanges();

                    candidateExperienceID = candidateExperienceContext.ID;
                }
            }

            return candidateExperienceID;
        }

        public int SaveCandidatePersonalReferences(CandidatePersonalReference candidatePersonalReference)
        {
            int candidatePersonalReferenceID = 0;
            var candidatePersonalReferenceContext = _context.CandidatePersonalReferences.FirstOrDefault(c => c.ID == candidatePersonalReference.ID);

            if (candidatePersonalReference.CandidateID == null || candidatePersonalReference.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidatePersonalReference.PersonalReference == null)
                throw new PersonalReferenceIsRequiredExceptions();
            else if (candidatePersonalReference.PersonalReference.Name == null || String.IsNullOrEmpty(candidatePersonalReference.PersonalReference.Name))
                throw new PersonalReferenceNameIsRequiredException();
            else if (candidatePersonalReference.PersonalReference.Telephone == null || String.IsNullOrEmpty(candidatePersonalReference.PersonalReference.Telephone))
                throw new PersonalReferenceTelehoneIsRequiredException();
            else if (candidatePersonalReference.PersonalReference.PersonalReferenceTypeID == null || candidatePersonalReference.PersonalReference.PersonalReferenceTypeID <= 0)
                throw new PersonalReferenceTypeIsRequiredException();
            else
            {
                if (candidatePersonalReferenceContext is null)
                {

                    if (candidatePersonalReference.PersonalReferenceID <= 0)
                    {
                        _context.PersonalReferences.Add(candidatePersonalReference.PersonalReference);
                        _context.SaveChanges();
                    }

                    _context.CandidatePersonalReferences.Add(candidatePersonalReference);
                    _context.SaveChanges();

                    candidatePersonalReferenceID = candidatePersonalReference.ID;
                }
                else
                {
                    if (candidatePersonalReference.PersonalReferenceID <= 0)
                    {
                        _context.PersonalReferences.Add(candidatePersonalReference.PersonalReference);
                        _context.SaveChanges();
                        _context.CandidatePersonalReferences.Add(candidatePersonalReference);
                    }
                    else
                    {
                        candidatePersonalReferenceContext.CandidateID = candidatePersonalReference.CandidateID;
                        candidatePersonalReferenceContext.PersonalReference.Name = candidatePersonalReference.PersonalReference.Name;
                        candidatePersonalReferenceContext.PersonalReference.Telephone = candidatePersonalReference.PersonalReference.Telephone;
                        candidatePersonalReferenceContext.PersonalReference.PersonalReferenceTypeID = candidatePersonalReference.PersonalReference.PersonalReferenceTypeID;
                    }

                    _context.SaveChanges();

                    candidatePersonalReferenceID = candidatePersonalReferenceContext.ID;
                }
            }

            return candidatePersonalReferenceID;
        }

        public int SaveCandidateRoles(CandidateRole candidateRole)
        {
            int candidateRoleID = 0;
            var candidateRoleContext = _context.CandidateRoles.FirstOrDefault(c => c.ID == candidateRole.ID);

            if (candidateRole.CandidateID == null || candidateRole.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateRole.RoleID == null || candidateRole.RoleID <= 0)
                throw new RoleIsRequiredException();
            else
            {
                if (candidateRoleContext is null)
                {
                    _context.CandidateRoles.Add(candidateRole);
                    _context.SaveChanges();

                    candidateRoleID = candidateRole.ID;
                }
                else
                {
                    candidateRoleContext.CandidateID = candidateRole.CandidateID;
                    candidateRoleContext.RoleID = candidateRole.RoleID;

                    _context.SaveChanges();

                    candidateRoleID = candidateRoleContext.ID;
                }
            }

            return candidateRoleID;
        }

    }
}
