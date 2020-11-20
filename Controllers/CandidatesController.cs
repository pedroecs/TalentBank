using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TalentBankBackend.Models;
using TalentBankBackend.Data;

namespace TalentBankBackend.Controllers
{
    [ApiController]
    [Route("api/candidates")]//v1
    public class CandidatesController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async  Task<ActionResult<List<Candidates>>> Get([FromServices] DataContext context)
        {
            var candidates = await context.Candidates.ToListAsync();
            return candidates;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Candidates>> Post(
            [FromServices] DataContext context,
            [FromBody]Candidates model)
            {
                if(ModelState.IsValid)
                {
                    context.Candidates.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else
                {
                   return BadRequest(ModelState); 
                }
            }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Candidates>> Put(
            [FromServices] DataContext context,
            [FromBody]Candidates model,[FromRoute] int id)
            {
                var candidates = await context.Candidates.FindAsync(id);
                // Console.WriteLine(candidates.Id);
                candidates.Name = model.Name;
                candidates.Skill = model.Skill;
                candidates.Stack = model.Stack;
                candidates.Experience = model.Experience;
                if(candidates.Id == id && ModelState.IsValid)
                {                  
                    context.Candidates.Update(candidates);
                    context.Entry(candidates).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return candidates;
                }
                else
                {
                   return BadRequest(ModelState); 
                }
            }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Candidates>> Delete(
            [FromServices] DataContext context,
            [FromRoute] int id)
            {
                var candidates = await context.Candidates.FindAsync(id);
                Console.WriteLine(candidates.Id);
                if(candidates.Id == id)
                {
                   
                    context.Candidates.Remove(candidates);
                    await context.SaveChangesAsync();
                    return candidates;
                }
                else
                {
                   return BadRequest(ModelState); 
                }
            }
    }
}