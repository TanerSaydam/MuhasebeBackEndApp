using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.BorcCekiHareketRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.BorcCekiHareketRepository
{
    public class EfBorcCekiHareketDal : EfEntityRepositoryBase<BorcCekiHareket, SimpleContextDb>, IBorcCekiHareketDal
    {
    }
}
