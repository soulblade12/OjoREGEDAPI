using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OjoREGED.BLL.DTOs;
using OjoREGED.BLL.Interfaces;
using OjoREGEDAPI.BLL.DTOs;
using OjoREGEDAPI.BLL.Interfaces;
using OjoREGEDAPI.Helpers;
using OjoREGEDAPI.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OjoREGEDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerBLL _customerBLL;
        private readonly IAddressBLL _addressBLL;
        private readonly ISubscriptionBLL _subsBLL;
        private readonly AppSettings _appSettings;


        public CustomerController(ICustomerBLL customerBLL, IAddressBLL addressBLL, ISubscriptionBLL subsBLL, IOptions<AppSettings> appSettings)
        {
            _customerBLL = customerBLL;
            _addressBLL = addressBLL;
            _subsBLL = subsBLL;
            _appSettings = appSettings.Value;
        }

        [HttpGet("{id}")]
        public async Task<CustomerDTO> Get(int id)
        {
            var result = await _customerBLL.CustomerGetByID(id);
            return result;
        }
        [HttpPost("AddressCustomer")]
        public async Task<IActionResult> Post(AddressAddCustomer addcustomer)
        {
            try
            {
                await _addressBLL.AddAddressCust(addcustomer);
                return Ok("Insert data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Post(CustomerCreateDTO userCreate)
        {
            if (userCreate == null)
            {
                return BadRequest();
            }

            try
            {
                await _customerBLL.InsertCustomer(userCreate);
                return Ok("Insert data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Subscription")]
        public async Task<IEnumerable<SubscriptionLevelDTO>> GetSubs()
        {
            var result = await _subsBLL.GetAllSubs();
            return result;


        }

        [HttpPost("UpdateSubs")]
        public async Task<IActionResult> Post(SubscriptionUpdate subscriptionUpdate)
        {
            if (subscriptionUpdate == null)
            {
                return BadRequest();
            }

            try
            {
                await _subsBLL.UpdateSubscription(subscriptionUpdate);
                return Ok("update subscription success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddBooking")]
        public async Task<IActionResult> PostBooking(InsertBookingSP bookingSP)
        {
            if (bookingSP == null)
            {
                return BadRequest();
            }

            try
            {
                await _customerBLL.AddBooking(bookingSP);
                return Ok("update subscription success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("orderCustomer")]
        public async Task<IEnumerable<OrderPlacedDTO>> GetOrderbyCust(int id)
        {
            var result = await _customerBLL.custGetOrderByCustomeromergetbyid(id);
            return result;
        }

        [HttpPost("LoginCustomer")]
        public async Task<IActionResult> Login(CustomerLogin loginDTO)
        {
            try
            {
                var result = await _customerBLL.CustomerLogin(loginDTO);
                List<Claim> claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Role, result.Role.RoleName));

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var userWithToken = new CustomerToken
                {

                    Customer_ID = result.CustomerId,
                    Role_Name = result.Role.RoleName,
                    First_Name = result.FirstName,
                    Middle_Name = result.MiddleName,
                    Last_Name = result.LastName,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(userWithToken);
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
