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
    [Route("api/schedule")]
    public class ScheduleController
    {
        private ILogger<ScheduleController> Logger { get; }
        private IScheduleCreateService ScheduleCreateService { get; }
        private IScheduleGetService ScheduleGetService { get; }
        private IScheduleUpdateService ScheduleUpdateService { get; }
        private IMapper Mapper { get; }

        public ScheduleController(ILogger<ScheduleController> logger, IMapper mapper, IScheduleCreateService scheduleCreateService, IScheduleGetService scheduleGetService, IScheduleUpdateService scheduleUpdateService)
        {
            this.Logger = logger;
            this.ScheduleCreateService = scheduleCreateService;
            this.ScheduleGetService = scheduleGetService;
            this.ScheduleUpdateService = scheduleUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<ScheduleDTO> PutAsync(ScheduleCreateDTO schedule)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ScheduleCreateService.CreateAsync(this.Mapper.Map<ScheduleUpdateModel>(schedule));

            return this.Mapper.Map<ScheduleDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<ScheduleDTO> PatchAsync(ScheduleUpdateDTO scheudle)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.ScheduleUpdateService.UpdateAsync(this.Mapper.Map<ScheduleUpdateModel>(scheudle));

            return this.Mapper.Map<ScheduleDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<ScheduleDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<ScheduleDTO>>(await this.ScheduleGetService.GetAsync());
        }

        [HttpGet]
        [Route("{scheduleId}")]
        public async Task<ScheduleDTO> GetAsync(int scheduleId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {scheduleId}");

            return this.Mapper.Map<ScheduleDTO>(await this.ScheduleGetService.GetAsync(new ScheduleIdentityModel(scheduleId)));
        }
    }
}