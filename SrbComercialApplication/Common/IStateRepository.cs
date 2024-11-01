using SrbComercialDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrbComercialApplication.Common
{
    public interface IStateRepository : IRepository<State>
    {
        void Update(State entity);
    }
}
