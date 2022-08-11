using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.MusteriSenetiRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.MusteriSenetiRepository
{
    public class EfMusteriSenetiDal : EfEntityRepositoryBase<MusteriSeneti, SimpleContextDb>, IMusteriSenetiDal
    {
    }
}
