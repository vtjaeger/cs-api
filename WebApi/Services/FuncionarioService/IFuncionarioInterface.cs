using WebApi.Models;

namespace WebApi.Services.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<Funcionario>>> GetFuncionariosList();
        Task<ServiceResponse<List<Funcionario>>> CreateFuncionario(Funcionario novoFuncionario);
        Task<ServiceResponse<Funcionario>> GetOneFuncionario(int id);
        Task<ServiceResponse<Funcionario>> UpdateFuncionario(Funcionario funcionario);
        Task<ServiceResponse<Funcionario>> DeleteFuncionario(int id);
        Task<ServiceResponse<List<Funcionario>>> InativaFuncionario(int id);
    }
}
