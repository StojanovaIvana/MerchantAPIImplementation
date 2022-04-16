using MerchantApi.Dto;
using MerchantApi.Models;

namespace MerchantApi.Repository
{
    public interface IStoreRepository
    {
        public ICollection<Store> GetStores();
       // public ICollection<Store> Merchants_GetStores();
        public Store GetStore(string storeCode);
        public void CreateStore(StoreDto store);
        public bool UpdateStore(string storeCode, StoreDto store);
        public bool DeleteStore(string storeCode);
    }
}
