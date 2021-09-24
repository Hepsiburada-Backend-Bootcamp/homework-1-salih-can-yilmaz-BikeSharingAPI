using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeSharingAPI.Tools
{
    public class IgnoreNullResolver : IMemberValueResolver<object, object, object, object>
    {
        public object Resolve(object source, object destination, object sourceMember, object destinationMember, ResolutionContext context)
        {
            return sourceMember ?? destinationMember;
        }
    }
}
