using PoC.Paginacao.Context;
using PoC.Paginacao.Dtos;
using PoC.Paginacao.Extensions;
using PoC.Paginacao.Models;
using System.Linq;

namespace PoC.Paginacao.Repositories
{
    public class UserRepository
    {
        private readonly PoCContext _context;

        public UserRepository(PoCContext context)
        {
            _context = context;
        }

        public ResultListDto<User> GetAllUsers(PaginationDto pagination, FilterDto filter)
        {
            IQueryable<User> query = _context.Users.AsQueryable();

            query = Filter(query, filter);
            query = OrderBy(query, pagination.OrderBy, pagination.OrderByDesc);

            return query.GetPage(pagination.Page, pagination.PerPage);
        }

        private IQueryable<User> OrderBy(IQueryable<User> query, OrderByEnum orderBy, bool orderByDesc)
        {
            return orderBy switch
            {
                OrderByEnum.FirstName => orderByDesc
                                        ? query.OrderByDescending(x => x.FirstName)
                                        : query.OrderBy(x => x.FirstName),
                OrderByEnum.LastName => orderByDesc
                                        ? query.OrderByDescending(x => x.LastName)
                                        : query.OrderBy(x => x.LastName),
                OrderByEnum.DateOfBirth => orderByDesc
                                        ? query.OrderByDescending(x => x.DateOfBirth)
                                        : query.OrderBy(x => x.DateOfBirth),
                _ => orderByDesc
                                        ? query.OrderByDescending(x => x.FirstName)
                                        : query.OrderBy(x => x.FirstName),
            };
        }

        private IQueryable<User> Filter(IQueryable<User> query, FilterDto filter)
        {
            if (query == null)
                return query;

            if (!string.IsNullOrEmpty(filter.FirstName))
                query = query.Where(x => x.FirstName.Contains(filter.FirstName));

            if (!string.IsNullOrEmpty(filter.LastName))
                query = query.Where(x => x.LastName.Contains(filter.LastName));

            if (!string.IsNullOrEmpty(filter.Username))
                query = query.Where(x => x.Username.Contains(filter.Username));

            return query;
        }
    }
}
