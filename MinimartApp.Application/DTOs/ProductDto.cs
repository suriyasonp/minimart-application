namespace MinimartApp.Application.DTOs
{
    public class ProductBasedDto
    {       
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Category { get; set; } = null!;
    }

    public class ProductResponseDto : ProductBasedDto
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
    }

    public class ProductCreateDto : ProductBasedDto
    {        
    }

    public class ProductUpdateDto : ProductBasedDto
    {
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    }


}
