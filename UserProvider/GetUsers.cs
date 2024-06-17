using System.Net;
using Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace UserProvider
{
    public class GetUsers(ILoggerFactory loggerFactory, DataContext context)
    {
        private readonly ILogger _logger = loggerFactory.CreateLogger<GetUsers>();
        private readonly DataContext _context = context;

        [Function("GetUsers")]
        public async Task <IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            var users = await _context.Users.ToListAsync();   
            return new OkObjectResult(users);
        }
    }
}
