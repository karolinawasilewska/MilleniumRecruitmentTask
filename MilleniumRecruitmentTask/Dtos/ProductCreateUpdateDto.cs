using System.ComponentModel.DataAnnotations;

namespace MilleniumRecruitmentTask.Dtos
{
    public class ProductCreateUpdateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
