using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
    public class EmployeeController : ControllerBase
    {
        private readonly IemployeeBLL _EmpBLL;
        private readonly IAddressBLL _addressBLL;
        private readonly AppSettings _appSettings;



        public EmployeeController(IemployeeBLL EmpBLL, IAddressBLL addressBLL, IOptions<AppSettings> appSettings)
        {
            _EmpBLL = EmpBLL;
            _addressBLL = addressBLL;
            _appSettings = appSettings.Value;

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(EmployeeLogin employeeLogin)
        {
            try
            {
                var result = await _EmpBLL.EmployeeLogin(employeeLogin);
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
                var userWithToken = new EmployeeToken
                {

                    Employee_ID = result.EmployeeId,
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


        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateEmployeeDTO employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _EmpBLL.Insertemployee(employee);

            if (result != null)
            {
                return Ok("Insert Successful"); // Or return any other success message
            }
            else
            {
                return StatusCode(500, "Failed to create employee."); // Or return a custom error message
            }
        }
        [Authorize(Roles = "Employee")]
        [HttpGet("employees/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _EmpBLL.GetEmployeesByID(id);
            if (employee == null)
            {
                return NotFound(); // Employee not found
            }
            return Ok(employee);
        }

        [HttpGet("employees/{id}/orderplaced")]
        public async Task<IActionResult> GetEmployeeOrderPlacedDTOs(int id)
        {
            var orders = await _EmpBLL.GetEmployee_OrderPlacedDTOs(id);
            if (orders == null)
            {
                return NotFound(); // No orders found for the employee
            }
            return Ok(orders);
        }

        [HttpGet("employees/{id}/pickups")]
        public async Task<IActionResult> GetPickups(int id)
        {
            var pickups = await _EmpBLL.GetPickups(id);
            if (pickups == null)
            {
                return NotFound(); // No pickups found for the employee
            }
            return Ok(pickups);
        }

        [HttpPost("addresses/employee")]
        public async Task<IActionResult> AddEmployeeAddress(EmployeeLocationCreateDTO employee_Location)
        {
            try
            {
                await _addressBLL.AddAddressEmp(employee_Location);
                return Ok(); // Address added successfully
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal server error
            }
        }

        [HttpPost("orders/{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId)
        {
            try
            {
                await _EmpBLL.UpdateOrderStatus(orderId);
                return Ok(); // Order status updated successfully
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal server error
            }
        }

        [HttpPost("pickups")]
        public async Task<IActionResult> AddPickup(EmployeeInsertPickup pickup)
        {
            try
            {
                await _EmpBLL.AddPickup(pickup);
                return Ok(); // Pickup added successfully
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal server error
            }
        }

        [HttpPost("employee/schedule")]
        public async Task<IActionResult> AddEmployeeSchedule(EmployeeCreateSchedule employee_Schedule)
        {
            try
            {
                await _EmpBLL.EmpSchedule(employee_Schedule);
                return Ok(""); // Employee schedule added successfully
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Internal server error
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, EmployeeUpdateDTO emp)
        {
            if (await _EmpBLL.GetEmployeesByID(id) == null)
            {
                return NotFound();
            }

            try
            {
                await _EmpBLL.UpdateEmployee(emp);
                return Ok("Update data success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
