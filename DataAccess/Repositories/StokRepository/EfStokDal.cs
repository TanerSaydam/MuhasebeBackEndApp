using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.StokRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.StokRepository
{
    public class EfStokDal : EfEntityRepositoryBase<Stok, SimpleContextDb>, IStokDal
    {
    }
}
