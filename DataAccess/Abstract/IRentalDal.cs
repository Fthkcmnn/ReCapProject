﻿using System.Linq.Expressions;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepository<Rental>
    {
        IEnumerable<RentalDetailDTOs> GetRentalDetails(Expression<Func<RentalDetailDTOs, bool>>? filter = null);
    }
}
