using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Application
{
    public interface IApplicationMethods
    {
        public PaginatedResult<T> GetPaginatedResult<T>(IEnumerable<T> source, int pageNumber, int pageSize);
    }
}
