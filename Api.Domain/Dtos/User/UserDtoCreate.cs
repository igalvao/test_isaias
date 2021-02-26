using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.LegalCase
{
    public class LegalCaseDtoCreate
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CourtName é um campo obrigatório")]
        public string CourtName { get; set; }
    }
}
