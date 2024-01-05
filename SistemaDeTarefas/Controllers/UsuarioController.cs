using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;
namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")] //rpta da API
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio){
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet] 
        public async Task <ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios); //vai retornar 200, ou seja uma mensagem de sucesso
        }
        
        [HttpGet("{id}")] 
        public async Task <ActionResult<List<UsuarioModel>>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario); //vai retornar 200, ou seja uma mensagem de sucesso
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }
    }
}
