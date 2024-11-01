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
        public async Task<ActionResult<IEnumerable<Pedido_tem_Produto>>> GetPedidoTemProdutos()
        {
            return await _context.PedidoTemProdutos
                .Include(p => p.Pedido)  // Inclui as informações do pedido
                .Include(p => p.Produto)  // Inclui as informações do produto
                .ToListAsync();
        }

        // GET DETAILS BY ID: api/PedidoTemProduto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido_tem_Produto>> GetPedidoTemProduto(int id)
        {
            var pedidoTemProduto = await _context.PedidoTemProdutos
                .Include(p => p.Pedido)  // Inclui as informações do pedido
                .Include(p => p.Produto)  // Inclui as informações do produto
                .FirstOrDefaultAsync(p => p.Id_PedidoProduto == id); // Aqui você deve verificar o ID que está utilizando

            if (pedidoTemProduto == null)
            {
                return NotFound();
            }

            return pedidoTemProduto;
        }

        // POST: api/PedidoTemProduto
        [HttpPost]
        public async Task<ActionResult<Pedido_tem_Produto>> PostPedidoTemProduto(Pedido_tem_Produto pedidoTemProduto)
        {
            _context.PedidoTemProdutos.Add(pedidoTemProduto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedidoTemProduto), new { id = pedidoTemProduto.Id_PedidoProduto }, pedidoTemProduto);
        }

        // PUT: api/PedidoTemProduto/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedidoTemProduto(int id, Pedido_tem_Produto pedidoTemProduto)
        {
            if (id != pedidoTemProduto.Id_PedidoProduto)
            {
                return BadRequest();
            }

            _context.Entry(pedidoTemProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PedidoTemProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/PedidoTemProduto/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoTemProduto(int id)
        {
            var pedidoTemProduto = await _context.PedidoTemProdutos.FindAsync(id);
            if (pedidoTemProduto == null)
            {
                return NotFound();
            }

            _context.PedidoTemProdutos.Remove(pedidoTemProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PedidoTemProdutoExists(int id)
        {
            return _context.PedidoTemProdutos.Any(e => e.Id_PedidoProduto == id);
        }
    }
}
