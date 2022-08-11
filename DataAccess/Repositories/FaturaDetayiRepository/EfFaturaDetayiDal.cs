using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.FaturaDetayiRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.FaturaDetayiRepository
{
    public class EfFaturaDetayiDal : EfEntityRepositoryBase<FaturaDetayi, SimpleContextDb>, IFaturaDetayiDal
    {
    }
}
