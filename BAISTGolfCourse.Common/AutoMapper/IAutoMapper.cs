using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Common.AutoMapper
{
    public interface IAutoMapper
    {
        T Map<T>(object objectToMap);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
