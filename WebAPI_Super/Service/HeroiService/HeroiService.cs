using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebAPI_Super.DataContext;
using WebAPI_Super.Models;

namespace WebAPI_Super.Service.HeroiService
{
    public class HeroiService : IHeroiInterface
    {
        private readonly ApplicationDbContext _context;
        public HeroiService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<HeroiModel>>> CreateHeroi(HeroiModel novoHeroi)
        {
            ServiceResponse<List<HeroiModel>> serviceResponse = new ServiceResponse<List<HeroiModel>>();
            HeroiModel heroi = _context.Herois.FirstOrDefault(x => x.NomeHeroi == novoHeroi.NomeHeroi);

            try
            {
                if(novoHeroi == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                } else if(heroi != null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nome de Herói já existente. Escolha outro!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Add(novoHeroi);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Herois.ToList();

            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HeroiModel>>> DeleteHeroi(int id)
        {
            ServiceResponse<List<HeroiModel>> serviceResponse = new ServiceResponse<List<HeroiModel>>();

            try
            {

                HeroiModel heroi = _context.Herois.FirstOrDefault(x => x.Id == id);

                if (heroi == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Herói não encontrado!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Herois.Remove(heroi);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Herois.ToList();

            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<HeroiModel>> GetHeroiById(int id)
        {
            ServiceResponse<HeroiModel> serviceResponse = new ServiceResponse<HeroiModel>();

            try
            {

                HeroiModel heroi = _context.Herois.FirstOrDefault(x => x.Id == id);

                if(heroi == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Herói não encontrado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = heroi;

            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HeroiModel>>> GetHerois()
        {
            ServiceResponse<List<HeroiModel>> serviceResponse = new ServiceResponse<List<HeroiModel>>();

            try
            {
                serviceResponse.Dados = _context.Herois.ToList();

                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }

            }catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<HeroiModel>>> UpdateHeroi(HeroiModel editadoHeroi)
        {
            ServiceResponse<List<HeroiModel>> serviceResponse = new ServiceResponse<List<HeroiModel>>();

            try
            {
                HeroiModel heroi = _context.Herois.AsNoTracking().FirstOrDefault(x => x.Id == editadoHeroi.Id);
                HeroiModel heroiByNome = _context.Herois.FirstOrDefault(x => x.NomeHeroi == editadoHeroi.NomeHeroi);
                if (heroi == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Herói não encontrado!";
                    serviceResponse.Sucesso = false;
                }
                else if (heroiByNome != null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nome de Herói já existente. Escolha outro!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Herois.Update(editadoHeroi);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Herois.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
