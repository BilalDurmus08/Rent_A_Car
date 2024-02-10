using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilites.Results.Abstract
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }

    }

}
