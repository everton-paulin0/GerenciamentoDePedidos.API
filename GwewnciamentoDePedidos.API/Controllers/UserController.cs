using GerenciamentoDePedidos.Application.Model;
using GerenciamentoDePedidos.Infrastruture.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDePedidos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GerenciamentoDbContext _context;
        public UserController(GerenciamentoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(CreateUserInputModel model)
        {
            var user = model.ToEntityUser();

            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(string search = "")
        {
            var users = _context.Users.Where(o => !o.IsDeleted && (search == "" || o.UserName.Contains(search)))
                .ToList();

            var model = users.Select(UserViewModel.FromEntityUser).ToList();


            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            var model = UserViewModel.FromEntityUser(user);

            return Ok(model);
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateUserInputModel model)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            user.UpdateUser(model.UserName, model.EmailAddress, model.DocNumber);

            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.SingleOrDefault(p => p.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            user.SetAsDeleted();
            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
