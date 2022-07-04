using System.ComponentModel.DataAnnotations;

namespace PoC.Paginacao.Dtos
{
    public class PaginationDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Não permitido valores negativos")]
        public int Page { get; set; } = 1;

        [Range(0, 100, ErrorMessage = "Intervalo permitido: 0 - 100")]
        public int PerPage { get; set; } = 10;

        public OrderByEnum OrderBy { get; set; } = OrderByEnum.FirstName;
        public bool OrderByDesc { get; set; } = true;
    }
}
