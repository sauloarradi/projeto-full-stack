using WebAPI_Super.Models;

namespace WebAPI_Super.Service.HeroiService
{
    public interface IHeroiInterface
    {
        Task<ServiceResponse<List<HeroiModel>>> GetHerois();
        Task<ServiceResponse<List<HeroiModel>>> CreateHeroi(HeroiModel novoHeroi);
        Task<ServiceResponse<HeroiModel>> GetHeroiById(int id);
        Task<ServiceResponse<List<HeroiModel>>> UpdateHeroi(HeroiModel editadoHeroi);
        Task<ServiceResponse<List<HeroiModel>>> DeleteHeroi(int id);
    }
}
