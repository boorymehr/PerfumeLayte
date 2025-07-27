using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeLayte.Comman
{
    public static class Pagination
    {

        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowsCount)
        {
            rowsCount = (source.Count() % pageSize) == 0 ? source.Count() / pageSize : source.Count() / pageSize + 1;
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
