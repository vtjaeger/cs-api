using WebApi.DataContext;
using WebApi.Models;

namespace WebApi.Services.FuncionarioService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionarioService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<Funcionario>>> CreateFuncionario(Funcionario novoFuncionario)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                if(novoFuncionario == null)
                {
                    serviceResponse.Mensagem = "informar dados do funcionario";
                    serviceResponse.Sucesso = false;
                    serviceResponse.Dados = null;

                    return serviceResponse;
                }

                _context.Add(novoFuncionario);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Funcionarios.ToList(); 
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<Funcionario>> DeleteFuncionario(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<Funcionario>>> GetFuncionariosList()
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();
            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "nenhum dado";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<Funcionario>> GetOneFuncionario(int id)
        {
            ServiceResponse<Funcionario> serviceResponse = new ServiceResponse<Funcionario>();

            try
            {
                Funcionario funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                if(funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "user nao localizado";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                serviceResponse.Dados = funcionario;

            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Funcionario>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = new ServiceResponse<List<Funcionario>>();

            try
            {
                Funcionario funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuário não localizado!";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();

                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();
            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public Task<ServiceResponse<Funcionario>> UpdateFuncionario(Funcionario funcionario)
        {
            throw new NotImplementedException();
        }

        
    }
}
