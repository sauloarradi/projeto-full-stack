using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Super.Models;
using WebAPI_Super.Service.HeroiService;

namespace WebAPI_Super.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IHeroiInterface _heroiInterface;
        public HeroiController(IHeroiInterface heroiInterface)
        {
            _heroiInterface = heroiInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<HeroiModel>>>> GetHerois()
        {
            return Ok( await _heroiInterface.GetHerois());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<HeroiModel>>> GetHeroiById(int id)
        {
            ServiceResponse<HeroiModel> serviceResponse = await _heroiInterface.GetHeroiById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<HeroiModel>>>> CreateHeroi(HeroiModel novoHeroi)
        {
            return Ok(await _heroiInterface.CreateHeroi(novoHeroi));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<HeroiModel>>>> UpdateHeroi(HeroiModel editadoHeroi)
        {
            ServiceResponse<List<HeroiModel>> serviceResponse = await _heroiInterface.UpdateHeroi(editadoHeroi);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<HeroiModel>>>> DeleteHeroi(int id)
        {
            ServiceResponse<List<HeroiModel>> serviceResponse = await _heroiInterface.DeleteHeroi(id);

            return Ok(serviceResponse);
        }
    }
}
