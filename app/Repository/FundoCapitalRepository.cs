using System;
using System.Collections.Generic;
using System.Linq;
using app.Models;

namespace app.Repository
{
    public class FundoCapitalRepository : IFundoCapitalRepository
    {
        
        private readonly List<FundoCapital> _storage;

        public FundoCapitalRepository()
        {
            _storage = new List<FundoCapital>();
        }

        public void Add(FundoCapital fundoCapital)
        {
            _storage.Add(fundoCapital);
        }

        public void Delete(Guid id)
        {
            var index = _storage.FindIndex(0, 1, x => x.Id == id);
            _storage.RemoveAt(index);
        }

        public void Edit(Guid id, FundoCapital fundoCapital)
        {
            var index = _storage.FindIndex(0, 1, x => x.Id == id);
            _storage[index] = fundoCapital;
        }

        public IEnumerable<FundoCapital> GetAll()
        {
            return _storage;
        }

        public FundoCapital GetById(Guid id)
        {
            return _storage.FirstOrDefault(x => x.Id == id);
        }
    }
}