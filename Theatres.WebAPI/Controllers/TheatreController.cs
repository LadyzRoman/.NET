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
    [Route("api/theatre")]
    public class TheatreController
    {
        private ILogger<TheatreController> Logger { get; }
        private ITheatreCreateService TheatreCreateService { get; }
        private ITheatreGetService TheatreGetService { get; }
        private ITheatreUpdateService TheatreUpdateService { get; }
        private IMapper Mapper { get; }

        public TheatreController(ILogger<TheatreController> logger, IMapper mapper, ITheatreCreateService theatreCreateService, ITheatreGetService theatreGetService, ITheatreUpdateService theatreUpdateService)
        {
            this.Logger = logger;
            this.TheatreCreateService = theatreCreateService;
            this.TheatreGetService = theatreGetService;
            this.TheatreUpdateService = theatreUpdateService;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("")]
        public async Task<TheatreDTO> PutAsync(TheatreCreateDTO cinema)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.TheatreCreateService.CreateAsync(this.Mapper.Map<TheatreUpdateModel>(cinema));

            return this.Mapper.Map<TheatreDTO>(result);
        }

        [HttpPatch]
        [Route("")]
        public async Task<TheatreDTO> PatchAsync(TheatreUpdateDTO cinema)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");

            var result = await this.TheatreUpdateService.UpdateAsync(this.Mapper.Map<TheatreUpdateModel>(cinema));

            return this.Mapper.Map<TheatreDTO>(result);
        }

        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<TheatreDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");

            return this.Mapper.Map<IEnumerable<TheatreDTO>>(await this.TheatreGetService.GetAsync());
        }

        [HttpGet]
        [Route("{theatreId}")]
        public async Task<TheatreDTO> GetAsync(int cinemaId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {cinemaId}");

            return this.Mapper.Map<TheatreDTO>(await this.TheatreGetService.GetAsync(new TheatreIdentityModel(cinemaId)));
        }
    }
}