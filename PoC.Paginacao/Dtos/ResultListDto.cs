using System;
using System.Collections.Generic;

namespace PoC.Paginacao.Dtos
{
    public class ResultListDto<TList> where TList : class
    {
        public ResultListDto(int currentPage, int perPage, int total, IList<TList> data)
        {
            CurrentPage = currentPage;
            PerPage = perPage;
            Total = total;
            Data = data;
        }

        public int CurrentPage { get; private set; }
        public int PerPage { get; private set; }
        public int Total { get; private set; }
        public int LastPage => GetTotalPage();
        public IList<TList> Data { get; private set; }

        private int GetTotalPage()
        {
            return PerPage > 0 ? Convert.ToInt32(Math.Ceiling((double)Total / PerPage)) : 1;
        }
    }
}
