using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models; 
using WebAPI.Context; 

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL: api/Pedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidos() // Retorna todos os pedidos
        {
            var pedidos = await _context.Pedidos
                .Include(p => p.PedidoTemProdutos) // Inclui os produtos em cada pedido
                .ToListAsync();

            if (pedidos == null)
            {
                return NotFound("Pedidos não encontrados.");
            }

            return pedidos; // Retorna os pedidos
        }

        // GET DETAILS BY ID: api/Pedido/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> GetPedido(int id) // Retorna o pedido pelo id
        {
            var pedido = await _context.Pedidos
                .Include(p => p.PedidoTemProdutos) // Inclui os produtos em cada pedido
                .FirstOrDefaultAsync(p => p.Id_Pedido == id); // Busca o pedido pelo id

            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return pedido; // Retorna o pedido
        }

        // POST: api/Pedido
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido) // Cria um novo pedido
        {
            if (pedido == null)
            {
                return BadRequest("Pedido não informado.");
            }

            _context.Pedidos.Add(pedido); // Adiciona o pedido
            await _context.SaveChangesAsync(); // Salva o pedido no banco de dados

            return CreatedAtAction(nameof(GetPedido), new { id = pedido.Id_Pedido }, pedido); // Retorna o pedido criado
        }

        // PUT: api/Pedido/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, Pedido pedido) // Atualiza um pedido
        {
            if (id != pedido.Id_Pedido)
            {
                return BadRequest("Id do pedido não corresponde.");
            }

            _context.Entry(pedido).State = EntityState.Modified; // Atualiza o pedido

            try
            {
                await _context.SaveChangesAsync(); // Salva as alterações
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoExists(id))
                {
                    return NotFound("Pedido não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(pedido); // Retorna o pedido atualizado
        }

        // DELETE: api/Pedido/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id) // Deleta um pedido
        {
            var pedido = await _context.Pedidos.FindAsync(id); // Busca o pedido pelo id
            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            _context.Pedidos.Remove(pedido); // Remove o pedido
            await _context.SaveChangesAsync(); // Salva as alterações

            return Ok(pedido); // Retorna o pedido removido
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id_Pedido == id); // Verifica se o pedido existe
        }
    }
}
