using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models; 
using WebAPI.Context; 

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClienteController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL: api/Cliente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes() // Retorna todos os clientes
        {
            var clientes = await _context.Clientes
                .Include(c => c.Pedidos) // Inclui os pedidos relacionados
                    .ThenInclude(p => p.PedidoTemProdutos) // Inclui os produtos em cada pedido
                .ToListAsync(); // Busca todos os clientes

            if (clientes == null)
            {
                return NotFound("Clientes não encontrados.");
            }

            return clientes; // Retorna os clientes            
        }

        // GET DETAILS BY ID: api/Cliente/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id) // Retorna o cliente pelo id
        {
            var cliente = await _context.Clientes
                .Include(c => c.Pedidos) // Inclui os pedidos do cliente
                    .ThenInclude(p => p.PedidoTemProdutos) // Inclui os produtos em cada pedido
                .FirstOrDefaultAsync(c => c.Id_Cliente == id); // Busca o cliente pelo id        

            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return cliente; // Retorna o cliente
        }

        // POST: api/Cliente
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente) // Cria um novo cliente
        {
            if (cliente == null)
            {
                return BadRequest("Cliente não informado.");
            }

            _context.Clientes.Add(cliente); // Adiciona o cliente
            await _context.SaveChangesAsync(); // Salva o cliente no banco de dados

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id_Cliente }, cliente); // Retorna o cliente criado
        }

        // PUT: api/Cliente/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente) // Atualiza um cliente
        {
            if (id != cliente.Id_Cliente)
            {
                return BadRequest("Id do cliente não corresponde.");
            }

            _context.Entry(cliente).State = EntityState.Modified; // Atualiza o cliente

            try
            {
                await _context.SaveChangesAsync(); // Salva as alterações
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound("Cliente não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(cliente); // Retorna o cliente atualizado
        }

        // DELETE: api/Cliente/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id) // Deleta um cliente
        {
            var cliente = await _context.Clientes.FindAsync(id); // Busca o cliente pelo id
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _context.Clientes.Remove(cliente); // Remove o cliente
            await _context.SaveChangesAsync(); // Salva as alterações

            return Ok(cliente); // Retorna o cliente removido
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id_Cliente == id); // Verifica se o cliente existe
        }
    }
}
