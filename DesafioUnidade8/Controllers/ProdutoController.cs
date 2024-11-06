using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL: api/Produto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos() // Retorna todos os produtos
        {
            var produtos = await _context.Produtos.ToListAsync(); // Busca todos os produtos

            if (produtos == null)
            {
                return NotFound("Produtos não encontrados.");
            }

            return Ok(new {message= "Produtos encontrados com sucesso!", produtos}); // Retorna todos os produtos
        }

        // GET DETAILS BY ID: api/Produto/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id) // Retorna o produto pelo id
        {
            var produto = await _context.Produtos.FindAsync(id); // Busca o produto pelo id

            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(new {message= "Produto encontrado com sucesso!", produto}); // Retorna o produto
        }

        // POST: api/Produto
        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto) // Cria um novo produto
        {
            if (produto == null)
            {
                return BadRequest("Produto não informado.");
            }

            _context.Produtos.Add(produto); // Adiciona o produto
            await _context.SaveChangesAsync(); // Salva o produto no banco de dados

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id_Produto },  new {message= "Produto criado com sucesso!", produto}); // Retorna o produto criado
        }

        // PUT: api/Produto/1
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto) // Atualiza um produto
        {
            if (produto == null)
            {
                return BadRequest("Produto não informado.");
            }

            produto.Id_Produto = id; // Atribui o id da URL ao objeto produto

            _context.Entry(produto).State = EntityState.Modified; // Atualiza o produto

            try
            {
                await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound("Produto não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return Ok(new {message= "Produto atualizado com sucesso!", produto}); // Retorna o produto atualizado
        }

        // DELETE: api/Produto/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id) // Deleta um produto
        {
            var produto = await _context.Produtos.FindAsync(id); // Busca o produto pelo id
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            _context.Produtos.Remove(produto); // Remove o produto
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            return Ok(new {message= "Produto removido com sucesso!", produto}); // Retorna o produto removido
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id_Produto == id); // Verifica se o produto existe
        }
    }
}
