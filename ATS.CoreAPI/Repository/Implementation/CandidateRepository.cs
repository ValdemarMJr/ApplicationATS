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
            return _context.Candidates.FirstOrDefault(c => c.ID == id);
        }

        public List<CandidateAcademicEducation> GetAcademicEducationByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
               return _context.CandidateAcademicsEducation.Where(ce => ce.CandidateID == candidateID).ToList();
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
                return _context.CandidateExperiences.Where(ce => ce.CandidateID == candidateID).ToList();

            }
        }

        public List<CandidateImprovementCourse> GetImprovmentCoursesByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                return _context.CandidateImprovementCourses.Where(ce => ce.CandidateID == candidateID).ToList();

            }
        }

        public List<CandidatePersonalReference> GetPersonalReferencesByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                return _context.CandidatePersonalReferences.Where(ce => ce.CandidateID == candidateID).ToList();

            }
        }

        public List<CandidateRole> GetRolesByCandidate(int candidateID)
        {
            var candidateContext = _context.Candidates.FirstOrDefault(c => c.ID == candidateID);
            if (candidateContext is null)
                throw new CandidateNotExistsException();
            else
            {
                return _context.CandidateRoles.Where(ce => ce.CandidateID == candidateID).ToList();

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

            var candidateContext = _context.Candidates.FirstOrDefault(c => c.User.CPF == candidate.User.CPF);

            if (candidate.Contacts == null || candidate.Contacts.Count <= 0)
                throw new CandidateContactsIsRequiredException();
            else if (candidate.Address == null)
                    throw new CandidateAddressIsRequiredException();
            else if (candidate.Gender == null || candidate.GenderID <= 0)
                throw new GenderIsRequiredException();
            else if (candidate.CivilState == null || candidate.CivilStateID <= 0)
                throw new CivilStateIsRequiredException();
            else if (candidate.PlaceOfBirth == null || candidate.PlaceOfBirthID <= 0)
                throw new PlaceOfBirthIsRequiredException();
            else if (candidate.Nacionality == null || String.IsNullOrEmpty(candidate.Nacionality))
                throw new NacionalityIsRequiredException();
            else
            {
                if (candidateContext is null)
                {
                    addressID = _context.Adresses.Add(candidate.Address).Entity.ID;

                    #region INSERT ADDRESS

                    candidate.AddressID = addressID;

                    #endregion

                    candidateID = _context.Candidates.Add(candidate).Entity.ID;

                    #region INSERT CONTACTS

                    foreach (var contact in candidate.Contacts)
                    {
                        int contactID = _context.Contacts.Add(contact.Contact).Entity.ID;
                        contact.ContactID = contactID;
                        contact.CandidateID = candidateID;
                        _context.CandidateContacts.Add(contact);
                    }

                    #endregion

                    #region INSERT ACADEMIC EDUCATION

                    foreach (var academicEducation in candidate.AcademicsEducation)
                    {
                        if (academicEducation.AcademicEducationID <= 0)
                            academicEducationID = _context.AcademicsEducation.Add(academicEducation.AcademicEducation).Entity.ID;
                        else
                            academicEducationID = academicEducation.AcademicEducationID;

                        academicEducation.AcademicEducationID = academicEducationID;
                        academicEducation.CandidateID = candidateID;
                        _context.CandidateAcademicsEducation.Add(academicEducation);
                    }
                    #endregion

                    #region INSERT IMPROVMENT COURSES

                    foreach (var improvementCourse in candidate.ImprovementCourses)
                    {
                        if (improvementCourse.ImprovementCourseID <= 0)
                            improvmentCourseID = _context.ImprovementCourses.Add(improvementCourse.ImprovementCourse).Entity.ID;
                        else
                            improvmentCourseID = improvementCourse.ImprovementCourseID;

                        improvementCourse.ImprovementCourseID = improvmentCourseID;
                        improvementCourse.CandidateID = candidateID;
                        _context.CandidateImprovementCourses.Add(improvementCourse);

                    }
                    #endregion

                    #region INSERT EXPERIENCES

                    foreach (var experience in candidate.Experiences)
                    {
                        experience.CandidateID = candidateID;
                        _context.CandidateExperiences.Add(experience);
                    }

                    #endregion

                    #region INSERT PERSONAL REFERENCE

                    foreach (var personalReference in candidate.PersonalReferences)
                    {
                        if (personalReference.PersonalReferenceID <= 0)
                            personalReferenceID = _context.PersonalReferences.Add(personalReference.PersonalReference).Entity.ID;
                        else
                            personalReferenceID = personalReference.PersonalReferenceID;

                        personalReference.CandidateID = candidateID;
                        _context.CandidatePersonalReferences.Add(personalReference);
                    }

                    #endregion

                    #region INSERT ROLES

                    foreach (var role in candidate.Roles)
                    {
                        if (role.RoleID <= 0)
                            roleID = _context.Roles.Add(role.Role).Entity.ID;
                        else
                            roleID = role.RoleID;

                        role.CandidateID = candidateID;
                        role.RoleID = roleID;
                        _context.CandidateRoles.Add(role);
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

                        addressID = addressContext.ID;
                        addressContext.Street = candidate.Address.Street;
                        addressContext.Number = candidate.Address.Number;
                        addressContext.Complement = candidate.Address.Complement;
                        addressContext.ReferencePoint = candidate.Address.ReferencePoint;
                        addressContext.NeighborhoodID = candidate.Address.NeighborhoodID;
                        addressContext.ZipCode = candidate.Address.ZipCode;

                        _context.SaveChanges();

                    }
                    else if (candidate.Address != null && candidate.AddressID <= 0)
                    {
                        //SE NAO EXISITIA A INFORMAÇÃO DO ENDEREÇO DO CONTATO, INSERE
                        addressID = _context.Adresses.Add(candidate.Address).Entity.ID;
                    }

                    #endregion

                    #region UPDATE CONTACTS

                    foreach (var contact in candidate.Contacts)
                    {
                        int contactID = 0;

                        if (contact.ID <= 0) // NAO ENCONTROU NA CANDIDATO CONTRATO
                        {
                            contact.CandidateID = candidateID;

                            if (contact.ContactID <= 0) // NAO ENCONTROU NA CONTATO
                            {
                                //INSERIR REGISTRO NA CONTATO
                                contactID = _context.Contacts.Add(contact.Contact).Entity.ID;
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
                                contactID = _context.Contacts.Add(contact.Contact).Entity.ID;

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
                    #endregion

                    #region UPDATE ACADEMIC EDUCATION

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

                    #endregion

                    #region UPDATE IMPROVMENT COURSES

                    foreach (var improvementCourse in candidate.ImprovementCourses)
                    {
                        //SE NAO ESTA ASSOCIADO COM A CANDIDATO IMPROVMENT COURSE
                        if (improvementCourse.ID <= 0)
                        {
                            //SE NÃO EXISTE NA IMPROVMENT COURSE INSERE
                            if (improvementCourse.ImprovementCourseID <= 0)
                                improvmentCourseID = _context.ImprovementCourses.Add(improvementCourse.ImprovementCourse).Entity.ID;
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
                                improvmentCourseID = _context.ImprovementCourses.Add(improvementCourse.ImprovementCourse).Entity.ID;
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

                    #endregion

                    #region UPDATE EXPERIENCES

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

                    #endregion

                    #region UPDATE PERSONAL REFERENCE

                    foreach (var personalReference in candidate.PersonalReferences)
                    {
                        if (personalReference.ID <= 0)
                        {
                            if (personalReference.PersonalReferenceID <= 0)
                                personalReferenceID = _context.PersonalReferences.Add(personalReference.PersonalReference).Entity.ID;
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

                    #endregion

                    #region UPDATE ROLES

                    foreach (var role in candidate.Roles)
                    {
                        if (role.ID <= 0)
                        {
                            if (role.RoleID <= 0)
                                roleID = _context.Roles.Add(role.Role).Entity.ID;
                            else
                                roleID = role.RoleID;

                            role.RoleID = roleID;
                            role.CandidateID = candidateID;
                            _context.CandidateRoles.Add(role);
                        }
                        else
                        {
                            if (role.RoleID <= 0)
                                roleID = _context.Roles.Add(role.Role).Entity.ID;
                            else
                                roleID = role.RoleID;

                            CandidateRole candidateRoleContext = _context.CandidateRoles.FirstOrDefault(c => c.ID == role.ID);
                            candidateRoleContext.CandidateID = candidateID;
                            candidateRoleContext.RoleID = roleID;
                            _context.SaveChanges();
                        }
                    }

                    #endregion

                    candidateContext.BirthDate = candidate.BirthDate;
                    candidateContext.PlaceOfBirthID = candidate.PlaceOfBirthID;
                    candidateContext.GenderID = candidate.GenderID;
                    candidateContext.Nacionality = candidate.Nacionality;
                    candidateContext.CNH = candidate.CNH;
                    candidateContext.RG = candidate.RG;
                    candidateContext.CarteiraTrabalho = candidate.CarteiraTrabalho;
                    candidateContext.SerieCarteiraTrabalho = candidate.SerieCarteiraTrabalho;
                    candidateContext.UFCarteiraTrabalho = candidate.UFCarteiraTrabalho;
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
    }
}
