using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Context;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoTemProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PedidoTemProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL: api/PedidoTemProduto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedido_tem_Produto>>> GetPedidoTemProdutos() // Retorna todos os pedidos
        {
            var pedidosTemProdutos = await _context.PedidoTemProdutos
                .Include(p => p.Pedido)  // Inclui as informações do pedido
                .Include(p => p.Produto)  // Inclui as informações do produto
                .ToListAsync(); // Busca todos os pedidos

            if (pedidosTemProdutos == null)
            {
                return NotFound("Pedidos não encontrados.");
            }

            return Ok(new {message= "Pedidos encontrados com sucesso!", pedidosTemProdutos}); // Retorna todos os pedidos
        }

        // GET DETAILS BY ID: api/PedidoTemProduto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido_tem_Produto>> GetPedidoTemProduto(int id) // Retorna o pedido pelo id
        {
            var pedidoTemProduto = await _context.PedidoTemProdutos
                .Include(p => p.Pedido)  // Inclui as informações do pedido
                .Include(p => p.Produto)  // Inclui as informações do produto
                .FirstOrDefaultAsync(p => p.Id_PedidoProduto == id); // Busca pelo id

            if (pedidoTemProduto == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return Ok(new {message= "Pedido encontrado com sucesso!", pedidoTemProduto}); // Retorna o pedido
        }

        // POST: api/PedidoTemProduto
        [HttpPost]
        public async Task<ActionResult<Pedido_tem_Produto>> PostPedidoTemProduto(Pedido_tem_Produto pedidoTemProduto) // Cria um novo pedido
        {
            if (pedidoTemProduto == null)
            {
                return BadRequest("Pedido não informado.");
            }

            _context.PedidoTemProdutos.Add(pedidoTemProduto); // Adiciona o pedido
            await _context.SaveChangesAsync(); // Salva o pedido no banco de dados

            return CreatedAtAction(nameof(GetPedidoTemProduto), new { id = pedidoTemProduto.Id_PedidoProduto }, new {message= "Pedido criado com sucesso!", pedidoTemProduto}); // Retorna o pedido criado
        }

        // PUT: api/PedidoTemProduto/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoTemProduto(int id, Pedido_tem_Produto pedidoTemProduto) // Atualiza um pedido
        {
            if (pedidoTemProduto == null)
            {
                return BadRequest("Pedido não informado.");
            }

            pedidoTemProduto.Id_PedidoProduto = id; // Atribui o id da URL ao objeto pedido

            _context.Entry(pedidoTemProduto).State = EntityState.Modified; // Atualiza o pedido

            try
            {
                await _context.SaveChangesAsync(); // Salva as alterações
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoTemProdutoExists(id))
                {
                    return NotFound("Pedido não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(new {message= "Pedido atualizado com sucesso!", pedidoTemProduto}); // Retorna o pedido atualizado
        }

        // DELETE: api/PedidoTemProduto/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoTemProduto(int id) // Deleta um pedido
        {
            var pedidoTemProduto = await _context.PedidoTemProdutos.FindAsync(id); // Busca o pedido pelo id
            if (pedidoTemProduto == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            _context.PedidoTemProdutos.Remove(pedidoTemProduto); // Remove o pedido
            await _context.SaveChangesAsync(); // Salva as alterações

            return Ok(new {message= "Pedido removido com sucesso!", pedidoTemProduto}); // Retorna o pedido removido
        }

        private bool PedidoTemProdutoExists(int id)
        {
            return _context.PedidoTemProdutos.Any(e => e.Id_PedidoProduto == id); // Verifica se o pedido existe
        }
    }
}
