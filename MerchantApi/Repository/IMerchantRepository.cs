using MerchantApi.Dto;
using MerchantApi.Models;
using MerchantApi.Models.Response;

namespace MerchantApi.Repository
{
    public interface IMerchantRepository
    {
        public MerchantResponse Merchants_GetList(int page, string? fullName);
        // list od merchants
        public ICollection<Merchant> Merchants_GetList();
        public Merchant Merchants_GetMerchant(string merchantCode);
        public void Merchants_CreateMerchant(MerchantDto merchant);  
        public bool Merchants_UpdateMerchant(string merchantCode, MerchantDto merchant);
        public bool Merchants_DeleteMerchant(string merchantCode);
        public ICollection<Store> Merchants_GetStores(string merchantCode);
    }
}
