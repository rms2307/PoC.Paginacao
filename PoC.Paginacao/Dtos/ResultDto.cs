using System.Collections.Generic;

namespace PoC.Paginacao.Dtos
{
    public class ResultDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; private set; } = new();

        public ResultDto(T data)
        {
            Data = data;
        }

        public ResultDto(List<string> errors)
        {
            Errors = errors;
        }

        public ResultDto(string error)
        {
            Errors.Add(error);
        }

        public ResultDto(T data, List<string> errors)
        {
            Data = data;
            Errors = errors;
        }
    }
}
