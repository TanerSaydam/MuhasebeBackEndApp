using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StokHareketiRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.StokHareketiRepository
{
    public class EfStokHareketiDal : EfEntityRepositoryBase<StokHareketi, SimpleContextDb>, IStokHareketiDal
    {
    }
}
