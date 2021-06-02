using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectATS.Models;
using ProjectATS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectATS.Controllers
{
    [Authorize]
    public class CandidateController : Controller
    {
        private readonly CandidateService _candidateSvc;

        public CandidateController(CandidateService candidateService)
        {
            _candidateSvc = candidateService;
        }

        [AllowAnonymous]
        public ActionResult<IList<CandidateService>> Index() => View(_candidateSvc.Read());

        [HttpGet]
        public ActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<Candidate> Create(Candidate candidate)
        {
            //candidate.Created = candidate.LastUpdated = DateTime.Now;
            candidate.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            candidate.UserName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _candidateSvc.Create(candidate);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult<Candidate> Edit(string id) =>
            View(_candidateSvc.Find(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Candidate candidate)
        {
            //candidate.LastUpdated = DateTime.Now;
            //candidate.Created = candidate.Created.ToLocalTime();
            if (ModelState.IsValid)
            {
                if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value != candidate.UserId)
                {
                    return Unauthorized();
                }
                _candidateSvc.Update(candidate);
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _candidateSvc.Delete(id);
            return RedirectToAction("Index");
        }
    }9m ,
    12
    0
}
