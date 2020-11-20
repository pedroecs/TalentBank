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
    [Route("api/vacancies")]//v1
    public class VacanciesController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async  Task<ActionResult<List<Vacancies>>> Get([FromServices] DataContext context)
        {
            var vacancies = await context.Vacancies.ToListAsync();
            return vacancies;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Vacancies>> Get([FromServices] DataContext context, int id)
        {
            var vacancies = await context.Vacancies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return vacancies;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Vacancies>> Post(
            [FromServices] DataContext context,
            [FromBody]Vacancies model)
            {
                if(ModelState.IsValid)
                {
                    context.Vacancies.Add(model);
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
        public async Task<ActionResult<Vacancies>> Put(
            [FromServices] DataContext context,
            [FromBody]Vacancies model, int id)
            {
                var vacancies = await context.Vacancies.FindAsync(id);
                // model.Id = vacancies.Id;
                vacancies.NameVacancies = model.NameVacancies;
                vacancies.Requirements = model.Requirements;
                vacancies.Stack = model.Stack;
                vacancies.Differentials = model.Differentials;
               
                if(vacancies.Id == id && ModelState.IsValid)
                {
                    context.Vacancies.Update(vacancies);
                    // Console.WriteLine(context.Vacancies.Update(vacancies));
                    // Console.WriteLine("model.Id/n");
                    // Console.WriteLine(model.Id);
                    context.Entry(vacancies).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return vacancies;
                    
                }
                else
                {
                  return BadRequest(ModelState);
                    
                }
            }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Vacancies>> Delete(
            [FromServices] DataContext context,
            [FromRoute] int id)
            {
                var vacancies = await context.Vacancies.FindAsync(id);
                Console.WriteLine(vacancies.Id);
                if(vacancies.Id == id)
                {
                   
                    context.Vacancies.Remove(vacancies);
                    await context.SaveChangesAsync();
                    return vacancies;
                }
                else
                {
                   return BadRequest(ModelState); 
                }
            }
    }
}