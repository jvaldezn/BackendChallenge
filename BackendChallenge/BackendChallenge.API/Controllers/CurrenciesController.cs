using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendChallenge.API.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BackendChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly CurrencyContext _context;
        private readonly ApplicationSettings _appSettings;

        public CurrenciesController(CurrencyContext context, IOptions<ApplicationSettings> appSettings)
        {
            _context = context;
            _context.SeedInfo();

            _appSettings = appSettings.Value;
        }

        //[HttpGet("Get/{amount}/{from}/{to}")]
        [HttpGet("Get/{amount}/{from}/{to}")]
        [Authorize]
        public async Task<ActionResult> GetAmount(double amount, string from, string to)
        {
            int currencyId_From = await _context.Currency.Where(s => s.Code == from).Select(z => z.CurrencyId).SingleAsync();
            int currencyId_To = await _context.Currency.Where(s => s.Code == to).Select(z => z.CurrencyId).SingleAsync();
            double equivalent = await (from c in _context.CurrencyExchange
                                       where c.CurrencyId_From == currencyId_From && c.CurrencyId_To == currencyId_To
                                       select c.Equivalent).SingleAsync();

            double amountConverted = amount * equivalent;
            amountConverted = Math.Round(amountConverted, 2);

            return Ok(new { OriginCurrency = from, DestinationCurrency = to, Amount = amount, AmountConverted = amountConverted });
        }

        //[HttpGet("Update/{amount}/{from}/{to}")]
        [HttpPut("Update/{amount}/{from}/{to}")]
        [Authorize]
        public async Task<ActionResult> UpdateAmount(double amount, string from, string to)
        {
            int currencyId_From = await _context.Currency.Where(s => s.Code == from).Select(z => z.CurrencyId).SingleAsync();
            int currencyId_To = await _context.Currency.Where(s => s.Code == to).Select(z => z.CurrencyId).SingleAsync();

            if (currencyId_From != 0 && currencyId_To != 0)
            {
                var data = await (from c in _context.CurrencyExchange
                                  where c.CurrencyId_From == currencyId_From && c.CurrencyId_To == currencyId_To
                                  select c).FirstOrDefaultAsync();
                try
                {
                    data.Equivalent = amount;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { success = false, msg = ex.Message });
                }

                return Ok(new { success = true, msg = "Successfully updated." });
            }
            else {
                return NotFound(new { success = false, msg = "The currency From or To doesnt exist." });
            }
        }

        // GET: api/Currencies
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Currency>>> GetCurrency()
        {
            return await _context.Currency.ToListAsync();
        }

        [HttpGet]
        [Route("CurrencyExchange")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<CurrencyExchange>>> GetCurrencyExchange()
        {
            return await _context.CurrencyExchange.ToListAsync();
        }

        [HttpGet]
        [Route("Users")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        #region Security Login Token
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(User user)
        {
            var data = await (from c in _context.User
                              where c.Username == user.Username && c.Password == user.Password
                              select c).FirstOrDefaultAsync();
            if (data != null)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("Username", data.Username)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { success = false, msg = "Username or Password is incorrect." });
            }
        }
        #endregion

        // GET: api/Currencies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Currency>> GetCurrency(int id)
        {
            var currency = await _context.Currency.FindAsync(id);

            if (currency == null)
            {
                return NotFound();
            }

            return currency;
        }

        // PUT: api/Currencies/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(int id, Currency currency)
        {
            if (id != currency.CurrencyId)
            {
                return BadRequest();
            }

            _context.Entry(currency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Currencies
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Currency>> PostCurrency(Currency currency)
        {
            _context.Currency.Add(currency);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurrency", new { id = currency.CurrencyId }, currency);
        }

        // DELETE: api/Currencies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Currency>> DeleteCurrency(int id)
        {
            var currency = await _context.Currency.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            _context.Currency.Remove(currency);
            await _context.SaveChangesAsync();

            return currency;
        }

        private bool CurrencyExists(int id)
        {
            return _context.Currency.Any(e => e.CurrencyId == id);
        }
    }
}
