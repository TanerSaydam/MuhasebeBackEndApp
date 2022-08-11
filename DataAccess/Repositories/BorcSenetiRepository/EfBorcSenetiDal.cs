using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.BorcSenetiRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.BorcSenetiRepository
{
    public class EfBorcSenetiDal : EfEntityRepositoryBase<BorcSeneti, SimpleContextDb>, IBorcSenetiDal
    {
    }
}
