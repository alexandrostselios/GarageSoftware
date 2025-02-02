using GarageAPI.Data;
using GarageAPI.Enum;
using GarageAPI.Models.EngineerSpecialities;
using GarageAPI.Models.EngineerSpeciality;
using GarageAPI.Models.User;
using GarageAPI.Models.User.Engineer;
using GarageAPI.Models.User.Engineers;
using GarageAPI.Models.User.Engineer;
using GarageAPI.Models.User.Engineers;
using GarageAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using GarageAPI.Models.User.Customers;

namespace GarageAPI.Controllers
{
    [ApiController]
    public class EngineerController : Controller
    {
        private readonly GarageAPIDbContext dbContext;
        private readonly IEmailSender _emailSender;
        private readonly System.Net.Http.IHttpClientFactory _httpClientFactory;


        public EngineerController(GarageAPIDbContext context, IEmailSender emailSender, IHttpClientFactory httpClientFactory)
        {
            dbContext = context;
            this._emailSender = emailSender;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("api/GetEngineersToList/{garageID:long}")]
        public async Task<IActionResult> GetEngineersToList(long garageID)
        {
            var query = from engineer in dbContext.Engineer
                        join user in dbContext.Users
                        on engineer.UserID equals user.ID
                        where engineer.GarageID == garageID
                        select new EngineerViewModel
                        {
                            EngineerID = engineer.EngineerID,
                            EngineerSurname = engineer.EngineerSurname,
                            EngineerName = engineer.EngineerName,
                            EngineerEmail = engineer.EngineerEmail,
                            CreationDate = engineer.CreationDate,
                            ModifiedDate = engineer.ModifiedDate,
                            GarageID = engineer.GarageID,
                            UserID = engineer.UserID,
                            EngineerHomePhone = engineer.EngineerHomePhone,
                            EngineerMobilePhone = engineer.EngineerMobilePhone,
                            EngineerComment = engineer.EngineerComment,
                            // Additional properties from Users table
                            EnableAccess = (long)user.EnableAccess,
                            LastLoginDate = user.LastLoginDate,
                            EngineerPhoto = engineer.EngineerPhoto
                        };

            var engineerViewModels = await query.ToListAsync();

            if (engineerViewModels.Any())
            {
                return Ok(engineerViewModels);
            }
            else
            {
                return NotFound();
            }
            //return Ok(await dbContext.Engineer.Where(c => c.GarageID == garageID).ToListAsync());
        }

        [HttpGet]
        [Route("api/GetEngineerByID/{engineerID:long}/{garageID:long}")]
        public async Task<IActionResult> GetEngineerByID([FromRoute] long engineerID, long garageID)
        {
            // Query Engineer by ID
            var engineer = await dbContext.Engineer.FirstOrDefaultAsync(e => e.EngineerID == engineerID && e.GarageID == garageID);

            if (engineer == null)
            {
                return NotFound();
            }

            // Query EngineerSpecialities for the given engineerID
            var engineerSpecialities = await dbContext.EngineerSpecialities
                .Where(es => es.EngineerID == engineerID)
                .Select(es => es.SpecialityID) // Select only the SpecialityID
                .ToListAsync();

            // Query the table containing SpecialityDescription
            var specialities = await dbContext.EngineerSpeciality
                .Where(sp => engineerSpecialities.Contains(sp.ID)) // Filter by SpecialityID
                .Select(sp => new EngineerSpeciality
                {
                    ID = sp.ID,
                    Speciality = sp.Speciality
                })
                .ToListAsync();

            var query = from engineerGet in dbContext.Engineer
                        join user in dbContext.Users
                        on engineerGet.UserID equals user.ID
                        where engineerGet.EngineerID == engineerID && engineerGet.GarageID == garageID
                        select new EngineerViewModel
                        {
                            EngineerID = engineerGet.EngineerID,
                            EngineerSurname = engineerGet.EngineerSurname,
                            EngineerName = engineerGet.EngineerName,
                            EngineerEmail = engineerGet.EngineerEmail,
                            CreationDate = engineerGet.CreationDate,
                            ModifiedDate = engineerGet.ModifiedDate,
                            GarageID = engineerGet.GarageID,
                            UserID = engineerGet.UserID,
                            EngineerHomePhone = engineerGet.EngineerHomePhone,
                            EngineerMobilePhone = engineerGet.EngineerMobilePhone,
                            EngineerComment = engineerGet.EngineerComment,
                            // Populate additional properties from Users table
                            EnableAccess = (long)user.EnableAccess,
                            LastLoginDate = user.LastLoginDate,
                            EngineerPhoto = engineerGet.EngineerPhoto,
                            EngineerSpecialities = specialities
                        };

            var engineerViewModel = await query.FirstOrDefaultAsync();

            return Ok(engineerViewModel);
        }

        [HttpGet]
        [Route("api/CheckEngineerExist/{engineerID:long}/{garageID:long}")]
        public async Task<IActionResult> CheckEngineerExist([FromRoute] long engineerID, long garageID)
        {
            return Ok(dbContext.Engineer.Any(e => e.EngineerID == engineerID && e.GarageID == garageID));
        }

        [HttpGet]
        [Route("api/GetEngineerSpecialitiesByEngineerID/{engineerID:long}/{garageID:long}")]
        public async Task<IActionResult> GetEngineerSpecialitiesByEngineerID([FromRoute] long engineerID,long garageID)
        {
            var query = from engineer in dbContext.Engineer
                        join engineerSpecialities in dbContext.EngineerSpecialities
                        on new { EngineerID = engineer.EngineerID, GarageID = engineer.GarageID }
                        equals new { EngineerID = engineerSpecialities.EngineerID, GarageID = engineerSpecialities.GarageID }
                        join engineerSpeciality in dbContext.EngineerSpeciality
                        on new { SpecialityID = engineerSpecialities.SpecialityID, GarageID = engineerSpecialities.GarageID }
                        equals new { SpecialityID = engineerSpeciality.ID, GarageID = engineerSpeciality.GarageID }
                        where engineer.EngineerID == engineerID && engineer.GarageID == garageID
                        group engineerSpeciality.Speciality by new
                        {
                            engineer.EngineerID,
                            engineer.EngineerName,
                            engineer.EngineerSurname,
                            engineer.EngineerEmail,
                            engineer.UserID      
                        } into g
                        select new
                        {
                            EngineerID = g.Key.EngineerID,
                            EngineerName = g.Key.EngineerName,
                            EngineerSurname = g.Key.EngineerSurname,
                            EngineerEmail = g.Key.EngineerEmail,
                            UserID = g.Key.UserID,
                            Specialities = g.ToList()
                        };

            var result = await query.FirstOrDefaultAsync();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/AddEngineer")]
        public async Task<IActionResult> AddEngineer(AddEngineerRequest addEngineerRequest)
        {
            // Create the engineer user entity
            var user = new Users()
            {
                Email = addEngineerRequest.EngineerEmail,
                Password = addEngineerRequest.EngineerPassword,
                CreationDate = addEngineerRequest.CreationDate,
                UserType = Enum.UserType.Engineer,
                EnableAccess = addEngineerRequest.EnableAccess
            };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();

            // Create the engineer entity
            var engineer = new Engineer()
            {
                EngineerSurname = addEngineerRequest.EngineerSurname,
                EngineerName = addEngineerRequest.EngineerName,
                EngineerEmail = addEngineerRequest.EngineerEmail,
                GarageID = addEngineerRequest.GarageID,
                CreationDate = addEngineerRequest.CreationDate,
                EngineerPhoto = addEngineerRequest.UserPhoto,
                EngineerComment = addEngineerRequest.EngineerComment,
                EngineerHomePhone = addEngineerRequest.EngineerHomePhone,
                EngineerMobilePhone = addEngineerRequest.EngineerMobilePhone,
                UserID = user.ID
            };
            await dbContext.Engineer.AddAsync(engineer);
            await dbContext.SaveChangesAsync();

            if (addEngineerRequest.EngineerSpecialities != null)
            {
                // Associate engineer with EngineerSpecialities
                foreach (var specialityId in addEngineerRequest.EngineerSpecialities)
                {
                    var engineerSpeciality = new EngineerSpecialities()
                    {
                        EngineerID = engineer.EngineerID,
                        SpecialityID = specialityId,
                        GarageID = engineer.GarageID
                    };
                    await dbContext.EngineerSpecialities.AddAsync(engineerSpeciality);
                }
                await dbContext.SaveChangesAsync();
            }

            var specialities = await dbContext.EngineerSpecialities
                        .Where(es => es.EngineerID == engineer.EngineerID && es.GarageID == engineer.GarageID)
                        .Select(es => es.SpecialityID)
                        .Join(dbContext.EngineerSpeciality,
                            es => es,
                            esd => esd.ID,
                            (es, esd) => esd.Speciality)
                        .ToListAsync();

            var result = new
            {
                engineer,
                specialities
            };

            return Ok(result);
        }

        [HttpPost]
        [Route("api/AddEngineerSpecialities")]
        public async Task<IActionResult> AddEngineerSpecialities(AddEngineerSpecialitiesRequest addEngineerSpecialitiesRequest)
        {
            try
            {
                foreach (var specialityId in addEngineerSpecialitiesRequest.EngineerSpecialities)
                {
                    // Check if the combination already exists
                    var combinationExists = await dbContext.EngineerSpecialities
                        .AnyAsync(es => es.EngineerID == addEngineerSpecialitiesRequest.EngineerID
                                    && es.SpecialityID == specialityId
                                    && es.GarageID == addEngineerSpecialitiesRequest.GarageID);

                    if (combinationExists)
                    {
                        return Conflict("The combination of EngineerID and SpecialityID already exists.");
                    }
                }

                // Associate engineer with EngineerSpecialities
                foreach (var specialityId in addEngineerSpecialitiesRequest.EngineerSpecialities)
                {
                    var engineerSpeciality = new EngineerSpecialities()
                    {
                        // ID will be auto-generated by the database
                        EngineerID = addEngineerSpecialitiesRequest.EngineerID,
                        SpecialityID = specialityId,
                        GarageID = addEngineerSpecialitiesRequest.GarageID
                    };
                    await dbContext.EngineerSpecialities.AddAsync(engineerSpeciality);
                }
                await dbContext.SaveChangesAsync();

                // Query to retrieve engineer with associated specialities and EngineerSpeciality data
                var engineer = await dbContext.Engineer
                    .Where(e => e.EngineerID == addEngineerSpecialitiesRequest.EngineerID
                             && e.GarageID == addEngineerSpecialitiesRequest.GarageID)
                    .FirstOrDefaultAsync();

                if (engineer != null)
                {
                    var specialities = await dbContext.EngineerSpecialities
                        .Where(es => es.EngineerID == engineer.EngineerID && es.GarageID == engineer.GarageID)
                        .Select(es => es.SpecialityID)
                        .Join(dbContext.EngineerSpeciality,
                            es => es,
                            esd => esd.ID,
                            (es, esd) => esd.Speciality)
                        .ToListAsync();

                    var result = new
                    {
                        engineer,
                        specialities
                    };

                    return Ok(result);
                }
                else
                {
                    return NotFound("Engineer not found.");
                }
            }
            catch (DbUpdateException ex)
            {
                // Handle database update exception
                return StatusCode(500, "An error occurred while processing your request.");
            }
            catch (Exception)
            {
                // Handle other exceptions
                throw;
            }

        }

        [HttpPut]
        [Route("api/UpdateEngineer/{engineerID:long}")]
        public async Task<IActionResult> UpdateEngineer([FromRoute] long engineerID, UpdateEngineerRequest updateEngineerRequest)
        {
            // Find the Engineer entity by ID
            var engineer = await dbContext.Engineer.FindAsync(engineerID);

            if (engineer != null)
            {
                // Update properties of the Engineer entity
                if (!(updateEngineerRequest.EngineerName is null)) engineer.EngineerName = updateEngineerRequest.EngineerName;
                if (!(updateEngineerRequest.EngineerSurname is null)) engineer.EngineerSurname = updateEngineerRequest.EngineerSurname;
                if (!(updateEngineerRequest.EngineerEmail is null)) engineer.EngineerEmail = updateEngineerRequest.EngineerEmail;
                if (!(updateEngineerRequest.ModifiedDate is null)) engineer.ModifiedDate = updateEngineerRequest.ModifiedDate;
                if (!(updateEngineerRequest.EngineerPhoto is null)) engineer.EngineerPhoto = updateEngineerRequest.EngineerPhoto;
                if (!(updateEngineerRequest.EngineerHomePhone is null)) engineer.EngineerHomePhone = updateEngineerRequest.EngineerHomePhone;
                if (!(updateEngineerRequest.EngineerMobilePhone is null)) engineer.EngineerMobilePhone = updateEngineerRequest.EngineerMobilePhone;
                if (!(updateEngineerRequest.EngineerComment is null)) engineer.EngineerComment = updateEngineerRequest.EngineerComment;
                

                // Get existing engineer specialities
                var existingSpecialities = await dbContext.EngineerSpecialities
                    .Where(es => es.EngineerID == engineerID && es.GarageID == engineer.GarageID)
                    .Select(es => es.SpecialityID)
                    .ToListAsync();

                try
                {
                    // Ensure updateEngineerRequest.EngineerSpecialities and existingSpecialities are not null
                    if (updateEngineerRequest.EngineerSpecialitiesID == null)
                    {
                        // Handle the case where updateEngineerRequest.EngineerSpecialities is null
                        // You may want to log a warning or return an appropriate error response
                        return BadRequest("Engineer specialities list is null.");
                    }

                    if (existingSpecialities == null)
                    {
                        // Handle the case where existingSpecialities is null
                        // You may want to log a warning or return an appropriate error response
                        return BadRequest("Existing specialities list is null.");
                    }

                    // Identify new specialities to be added
                    var newSpecialities = updateEngineerRequest.EngineerSpecialitiesID
                        .Where(specialityId => !existingSpecialities.Contains(specialityId))
                    .ToList();

                    // Create the AddEngineerSpecialitiesRequest object
                    var addEngineerSpecialitiesRequest = new AddEngineerSpecialitiesRequest
                    {
                        EngineerID = engineerID, // Set the EngineerID
                        GarageID = updateEngineerRequest.GarageID, // Set the GarageID
                        EngineerSpecialities = updateEngineerRequest.EngineerSpecialitiesID.Where(specialityId => !existingSpecialities.Contains(specialityId)).ToList() // Set the list of new specialities
                    };

                    string ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.ToString();
                    //string baseAddress = $"http://{ipAddress}:7096/"; // For production
                    string baseAddress = "https://localhost:7096/"; // For localhost
                    var httpClient = _httpClientFactory.CreateClient();
                    httpClient.BaseAddress = new Uri(baseAddress);

                    var response = await httpClient.PostAsJsonAsync("api/AddEngineerSpecialities", addEngineerSpecialitiesRequest);

                }
                catch (Exception ex)
                {
                    // Return a generic error response
                    return StatusCode(500, "An error occurred while processing the request.");
                }

                //// Save changes to the database
                //await dbContext.SaveChangesAsync();

                // Find the user entity associated with the Engineer
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.ID == engineer.UserID);

                if (user != null)
                {
                    // Update properties of the user entity
                    if (updateEngineerRequest.EnableAccess != null) user.EnableAccess = (EnableAccess)updateEngineerRequest.EnableAccess;
                    if (updateEngineerRequest.LastLoginDate != null) user.LastLoginDate = updateEngineerRequest.LastLoginDate;
                    if (updateEngineerRequest.ModifiedDate != null) user.ModifiedDate = updateEngineerRequest.ModifiedDate;
                    if (updateEngineerRequest.EngineerEmail != null) user.Email = updateEngineerRequest.EngineerEmail;
                    if (updateEngineerRequest.EngineerPassword != null) user.Password = updateEngineerRequest.EngineerPassword;

                    // Save changes to both entities
                    await dbContext.SaveChangesAsync();

                    return Ok(new { Engineer = engineer, User = user }); // Return updated entities
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            else
            {
                return NotFound("Engineer not found");
            }
        }

        [HttpPut]
        [Route("api/UpdateEngineerLogin/{engineerID:long}")]
        public async Task<IActionResult> UpdateEngineerLogin([FromRoute] long engineerID, UpdateCustomerLogin updateEngineerLogin)
        {
            // Find the customer entity by ID
            var engineer = await dbContext.Customer.FindAsync(engineerID);

            if (engineer != null)
            {
                // Find the user entity associated with the customer
                var user = await dbContext.Users.FirstOrDefaultAsync(u => u.ID == engineer.UserID);

                if (user != null)
                {
                    if (updateEngineerLogin.LastLoginDate != null) user.LastLoginDate = updateEngineerLogin.LastLoginDate;
                    // Save changes to both entities
                    await dbContext.SaveChangesAsync();
                    return Ok(new { Engineer = engineer, User = user }); // Return updated entities
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            else
            {
                return NotFound("Customer not found");
            }
        }
    }
}