using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.MusteriCekiRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.MusteriCekiRepository
{
    public class EfMusteriCekiDal : EfEntityRepositoryBase<MusteriCeki, SimpleContextDb>, IMusteriCekiDal
    {
    }
}
