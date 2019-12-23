using System;
using System.Collections.Generic;
using app.Models;

namespace app.Repository
{
    public interface  IFundoCapitalRepository
    {
        IEnumerable<FundoCapital> GetAll();

        void Add(FundoCapital fundoCapital);

        void Edit(Guid id, FundoCapital fundoCapital);

        FundoCapital GetById(Guid id);

        void Delete(Guid id);
    }
}