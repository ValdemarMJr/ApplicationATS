using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CandidateRoleRepository : ICandidateRoleRepository
    {
        private readonly SQLContext _context;

        public CandidateRoleRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var candidateRole = _context.CandidateRoles.FirstOrDefault(cr => cr.ID == id);
            if (candidateRole is null)
                throw new CandidateRoleNotExistsException();
            else
            {
                _context.CandidateRoles.Remove(candidateRole);
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteByCandidateID(int candidateID)
        {
            List<CandidateRole> candidateRoles = _context.CandidateRoles.Where(cr => cr.CandidateID == candidateID).ToList();
            if (candidateRoles is null || candidateRoles.Count <= 0)
                throw new CandidateRoleNotExistsException();
            else
            {
                foreach (var item in candidateRoles)
                {
                    _context.CandidateRoles.Remove(item);
                }

                _context.SaveChanges();

                return true;
            }
        }

        public CandidateRole Get(int id)
        {
            var candidateRoles = _context.CandidateRoles.FirstOrDefault(cr => cr.ID == id);
            if (candidateRoles is null)
                throw new CandidateRoleNotExistsException();
            else
            {
                return candidateRoles;
            }
        }

        public List<CandidateRole> GetByCandidate(int candidateID)
        {
            return _context.CandidateRoles.Where(cr => cr.CandidateID == candidateID).ToList();
        }

        public int Save(CandidateRole candidateRole)
        {
            int candidateRoleID = 0;
            var candidateRoleContext = _context.CandidateRoles.FirstOrDefault(cr => cr.ID == candidateRole.ID);

            if (candidateRole.CandidateID == null || candidateRole.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateRole.CandidateID != null && candidateRole.CandidateID > 0)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(c => c.ID == candidateRole.CandidateID);

                if (candidate == null || candidate.ID <= 0)
                    throw new CandidateIsInvalidExceptions();
            }
            else if (candidateRole.RoleID == null || candidateRole.RoleID <= 0)
                throw new RoleIsRequiredException();
            else if (candidateRole.RoleID != null && candidateRole.RoleID > 0)
            {
                Role role = _context.Roles.FirstOrDefault(r => r.ID == candidateRole.RoleID);

                if (role == null || role.ID <= 0)
                    throw new RoleIsInvalidException();
            }
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
