using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.LegalCase
{
    public class LegalCaseDtoUpdate
    {
        [Required(ErrorMessage = "Id é um campo obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CourtName é um campo obrigatório")]
        [StringLength(100, ErrorMessage = "CourtName deve ter no máximo {1} caracteres.")]
        public string CourtName { get; set; }
    }
}
