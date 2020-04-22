using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Theatres.BLL.Contracts;
using Theatres.Client.DTO.Read;
using Theatres.Client.Requests.Create;
using Theatres.Client.Requests.Update;
using Theatres.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Theatres.WebAPI.Controllers
{
    [ApiController]
    [Route("api/perfomance")]
    public class PerfomanceController : ControllerBase
    {
        private ILogger<PerfomanceController> Logger { get; }
        private IPerfomanceCreateService perfomanceCreateService { get; }
        private IPerfomanceGetService perfomanceGetService { get; }
        private IPerfomanceUpdateService perfomanceUpdateService { get; }
        private IMapper Mapper { get; }

        public PerfomanceController(ILogger<PerfomanceController> logger, IMapper mapper, IPerfomanceCreateService perfomanceCreateService, IPerfomanceGetService perfomanceGetService, IPerfomanceUpdateService perfomanceUpdateService)
        {
            this.Logger = logger;
            this.perfomanceCreateService = perfomanceCreateService;
            this.perfomanceGetService = perfomanceGetService;
            this.perfomanceUpdateService = perfomanceUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<PerfomanceDTO> PutAsync(PerfomanceCreateDTO perfomance)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.perfomanceCreateService.CreateAsync(this.Mapper.Map<PerfomanceUpdateModel>(perfomance));

            return this.Mapper.Map<PerfomanceDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<PerfomanceDTO> PatchAsync(PerfomanceUpdateDTO perfomance)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.perfomanceUpdateService.UpdateAsync(this.Mapper.Map<PerfomanceUpdateModel>(perfomance));

            return this.Mapper.Map<PerfomanceDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<PerfomanceDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<PerfomanceDTO>>(await this.perfomanceGetService.GetAsync());
        }

        [HttpGet]
        [Route("{perfomanceId}")]
        public async Task<PerfomanceDTO> GetAsync(int perfomanceId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {perfomanceId}");

            return this.Mapper.Map<PerfomanceDTO>(await this.perfomanceGetService.GetAsync(new PerfomanceIdentityModel(perfomanceId)));
        }
    }
}