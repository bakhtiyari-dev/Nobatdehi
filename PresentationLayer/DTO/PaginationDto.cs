using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.DTO
{
    public class PaginationDto
    {
        [Range(1, 20)]
        public required int PageNumber { get; set; }
        [Range(1, 50)]
        public required int PageSize { get; set; }
    }
}
