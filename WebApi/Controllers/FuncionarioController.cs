using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services.FuncionarioService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionariointerface;
        public FuncionarioController(IFuncionarioInterface funcionarioInterface)
        {
            _funcionariointerface = funcionarioInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> GetFuncionarios()
        {
            return Ok(await _funcionariointerface.GetFuncionariosList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Funcionario>>> GetOneFuncionario(int id)
        {
            ServiceResponse<Funcionario> service = await _funcionariointerface.GetOneFuncionario(id);
            return Ok(service);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> CreateFuncionario(Funcionario funcionario)
        {
            return Ok(await _funcionariointerface.CreateFuncionario(funcionario));
        }

        [HttpPut("/id")]
        public async Task<ActionResult<ServiceResponse<List<Funcionario>>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<Funcionario>> serviceResponse = await _funcionariointerface.InativaFuncionario(id);
            return Ok(serviceResponse);
        } 

    }
}
