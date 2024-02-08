using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RbPharma.Domain.Models.V1;
using RbPharma.Services.V1.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RbPharma.Function
{
    public class Function1
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public Function1(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }


        [FunctionName("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var response = new ResponseViewModel();
            try
            {
                log.LogInformation("start GetAllUsers");
                response = await _userService.GetAllUsers();
                log.LogInformation("end GetAllUsers");
            }
            catch (Exception ex)
            {
                log.LogError($"{ex.Message} - Unexpected Error");
                return new BadRequestObjectResult($"{ex.Message} -  Unexpected Error.");
            }

            return new OkObjectResult(JsonConvert.SerializeObject(response));

        }

        [FunctionName("GetUserById")]
        public async Task<IActionResult> GetUserById(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var response = new ResponseViewModel();
            try
            {
                log.LogInformation("start req.Query[id]");
                var userId = Convert.ToInt32(req.Query["id"]);
                log.LogInformation($"end req.Query[id] - userId = [{userId}]");

                log.LogInformation($"start GetById id = [{userId}]");
                response = await _userService.GetById(userId);
                log.LogInformation($"end GetById id = [{userId}]");
            }
            catch (Exception ex)
            {
                log.LogError($"{ex.Message} - Unexpected Error");
                return new BadRequestObjectResult($"{ex.Message} -  Unexpected Error.");
            }

            return new OkObjectResult(JsonConvert.SerializeObject(response));
        }

        [FunctionName("CreateUser")]
        public async Task<IActionResult> CreateUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var response = new ResponseViewModel();
            try
            {
                log.LogInformation("start StreamReader(req.Body)");
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                log.LogInformation("end StreamReader(req.Body)");

                log.LogInformation("start JsonConvert.DeserializeObject<RequestViewModel>(requestBody)");
                RequestViewModel requestViewModel = JsonConvert.DeserializeObject<RequestViewModel>(requestBody);
                log.LogInformation("end JsonConvert.DeserializeObject<RequestViewModel>(requestBody)");

                log.LogInformation($"start InsertUser user = [{requestViewModel}]");
                response = await _userService.InsertUser(requestViewModel);
                log.LogInformation($"end InsertUser user = [{requestViewModel}]");
            }
            catch (Exception ex)
            {
                log.LogError($"{ex.Message} - Unexpected Error");
                return new BadRequestObjectResult($"{ex.Message} -  Unexpected Error.");
            }

            return new OkObjectResult(JsonConvert.SerializeObject(response));
        }

        [FunctionName("UpdateUser")]
        public async Task<IActionResult> UpdateUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = null)] HttpRequest req,
            ILogger log)
        {
            var response = new ResponseViewModel();
            try
            {
                log.LogInformation("start StreamReader(req.Body)");
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                log.LogInformation("end StreamReader(req.Body)");

                log.LogInformation("start JsonConvert.DeserializeObject<RequestViewModel>(requestBody)");
                RequestViewModel requestViewModel = JsonConvert.DeserializeObject<RequestViewModel>(requestBody);
                log.LogInformation("end JsonConvert.DeserializeObject<RequestViewModel>(requestBody)");

                log.LogInformation($"start UpdateUser requestViewModel = [{requestViewModel}]");
                response = await _userService.UpdateUser(requestViewModel);
                log.LogInformation($"end UpdateUser requestViewModel = [{requestViewModel}]");
            }
            catch (Exception ex)
            {
                log.LogError($"{ex.Message} - Unexpected Error");
                return new BadRequestObjectResult($"{ex.Message} -  Unexpected Error.");
            }

            return new OkObjectResult(JsonConvert.SerializeObject(response));
        }

        [FunctionName("DeleteUser")]
        public async Task<IActionResult> DeleteUser(
            [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = null)] HttpRequest req,
            ILogger log)
        {
            var response = new ResponseViewModel();
            try
            {
                log.LogInformation("start StreamReader(req.Body)");
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                log.LogInformation("end StreamReader(req.Body)");

                log.LogInformation("start JsonConvert.DeserializeObject<RequestViewModel>(requestBody)");
                RequestViewModel requestViewModel = JsonConvert.DeserializeObject<RequestViewModel>(requestBody);
                log.LogInformation("end JsonConvert.DeserializeObject<RequestViewModel>(requestBody)");

                log.LogInformation($"start DeleteUser requestViewModel = [{requestViewModel}]");
                response = await _userService.DeleteUser(requestViewModel);
                log.LogInformation($"end DeleteUser requestViewModel = [{requestViewModel}]");
            }
            catch (Exception ex)
            {
                log.LogError($"{ex.Message} - Unexpected Error");
                return new BadRequestObjectResult($"{ex.Message} -  Unexpected Error.");
            }

            return new OkObjectResult(JsonConvert.SerializeObject(response));
        }

    }
}
