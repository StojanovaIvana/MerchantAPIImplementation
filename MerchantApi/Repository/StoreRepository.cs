using AutoMapper;
using MerchantApi.Database;
using MerchantApi.Dto;
using MerchantApi.Models;

namespace MerchantApi.Repository
{
    public class StoreRepository : IStoreRepository
    {
        private readonly MerchantDbContext _merchantDbContext;
        private readonly IMapper _mapper;

        public StoreRepository(MerchantDbContext merchantDbContext, IMapper mapper)
        {
            _merchantDbContext = merchantDbContext;
            _mapper = mapper;   

        }
        public void CreateStore(StoreDto _store)
        {
            var store =_mapper.Map<Store>(_store);
            _merchantDbContext.Stores.Add(store);
            _merchantDbContext.SaveChanges();
        }

        public bool DeleteStore(string storeCode)
        {
            var merchantFromDb = _merchantDbContext.Stores.Where(x => x.StoreCode == storeCode).FirstOrDefault();
            if (merchantFromDb == null)
            {
                return false;
            }
            _merchantDbContext.Stores.Remove(merchantFromDb);
            _merchantDbContext.SaveChanges();
            return true;
        }

        public Store GetStore(string storeCode)
        {
            var store = _merchantDbContext.Stores.Where(x => x.StoreCode == storeCode).FirstOrDefault();
            return store;
        }

        public ICollection<Store> GetStores()
        {
            return _merchantDbContext.Stores.ToList();
        }

        public bool UpdateStore(string storeCode, StoreDto store)
        {
            var merchantFromDb = _merchantDbContext.Stores.Where(x => x.StoreCode == storeCode).FirstOrDefault();

            if (merchantFromDb == null)
            {
                return false;
            }
            merchantFromDb.StoreCode = store.StoreCode;
            merchantFromDb.MerchantCode= store.MerchantCode;
            merchantFromDb.StoreDisplayName = store.StoreDisplayName;   
            merchantFromDb.Address= store.Address;  
            merchantFromDb.PhoneNumber= store.PhoneNumber;  
            merchantFromDb.Email= store.Email;

            _merchantDbContext.SaveChanges();
            return true;
        }
    }
}
