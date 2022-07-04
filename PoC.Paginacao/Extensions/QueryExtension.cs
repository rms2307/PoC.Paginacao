using PoC.Paginacao.Dtos;
using System.Linq;

namespace PoC.Paginacao.Extensions
{
    public static class QueryExtension
    {
        public static ResultListDto<T> GetPage<T>(this IQueryable<T> query, int page, int perPage) where T : class
        {
            if (perPage > 100)
                perPage = 100;

            var skip = (page - 1) * perPage;
            var data = query.Skip(skip).Take(perPage).ToList();
            var total = query != null ? query.Count() : 0;

            return new ResultListDto<T>(page, perPage, total, data);
        }
    }
}
