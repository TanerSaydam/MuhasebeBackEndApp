using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.BorcCekiRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.BorcCekiRepository
{
    public class EfBorcCekiDal : EfEntityRepositoryBase<BorcCeki, SimpleContextDb>, IBorcCekiDal
    {
    }
}
