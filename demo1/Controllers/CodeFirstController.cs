using demo1.Data;
using demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace demo1.Controllers {
    [Route("api/CodeFirst")]
    [ApiController]
    public class CodeFirstController : ControllerBase {
        private readonly AppDbContext _appDbContext;

        public CodeFirstController(AppDbContext appDbContext) {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// used to get all value
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getvalue")]
        public List<Employees> GetEmployees() {
            return  _appDbContext.employees.ToList();
        }

        /// <summary>
        /// used to get record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("getById")]
        public async Task<object> GetEmployeesById(int id) {
            var employee = await _appDbContext.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        /// <summary>
        /// used to upsert record in table
        /// </summary>
        /// <param name="employee"></param>
        [HttpPost]
        [Route("upsert")]
        public async Task<bool> UpsertEmployees(Employees employee) {

            _appDbContext.employees.Add(employee);
            var res = await _appDbContext.SaveChangesAsync();
            if (res != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// used to delete record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Delete")]
        public async Task<bool> DeleteEmployee(int id) {
            var employee = await _appDbContext.employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _appDbContext.employees.Remove(employee);
            var res =  await _appDbContext.SaveChangesAsync();

            if (res != 0)
            {
                return true;
            }
            return false;
        }


    }
}
