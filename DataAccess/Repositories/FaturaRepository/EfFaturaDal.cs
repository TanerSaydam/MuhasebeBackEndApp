using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.FaturaRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.FaturaRepository
{
    public class EfFaturaDal : EfEntityRepositoryBase<Fatura, SimpleContextDb>, IFaturaDal
    {
    }
}
