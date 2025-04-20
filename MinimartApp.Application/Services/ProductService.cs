using MinimartApp.Application.DTOs;
using MinimartApp.Application.Interfaces;
using MinimartApp.Domain.Entities;

namespace MinimartApp.Application.Services
{
    public class ProductService(IProductRepository productRepository)
    {
        public async Task<List<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await productRepository.GetAllAsync();
            return [.. products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Category = p.Category,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = p.UpdatedAt
            })];
        }
        public async Task<ProductResponseDto> GetProductByIdAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product == null) throw new KeyNotFoundException($"Product with ID {id} not found.");

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = product.UpdatedAt
            };
        }
        public async Task<ProductResponseDto> AddProductAsync(ProductCreateDto productCreateDto)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productCreateDto.Name,
                Price = productCreateDto.Price,
                Category = productCreateDto.Category,
                CreatedAt = DateTimeOffset.UtcNow
            };
            await productRepository.AddAsync(product);

            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = product.UpdatedAt
            };
        }
        public async Task<ProductResponseDto> UpdateProductAsync(Guid id, ProductUpdateDto productUpdateDto)
        {
            var product = await productRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Product with ID {id} not found.");
            product.Name = productUpdateDto.Name;
            product.Price = productUpdateDto.Price;
            product.Category = productUpdateDto.Category;
            product.UpdatedAt = DateTimeOffset.UtcNow;
            await productRepository.UpdateAsync(product);
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = product.UpdatedAt
            };
        }
        public async Task DeleteProductAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Product with ID {id} not found.");
            await productRepository.DeleteAsync(product.Id);
        }
    }
}