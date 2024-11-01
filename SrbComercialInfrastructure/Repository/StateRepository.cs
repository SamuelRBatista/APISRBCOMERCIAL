using SrbComercialApplication.Common;
using SrbComercialDomain.Entities;
using SrbComercialInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrbComercialInfrastructure.Repository
{
    public class StateRepository : Repository<State>, IStateRepository
    {
        private readonly DataContext _db;

        public StateRepository(DataContext db) : base(db)
        {
            _db = db;

        }

        public void Update(State entity)
        {
            _db.Update(entity);
        }
    }
}
