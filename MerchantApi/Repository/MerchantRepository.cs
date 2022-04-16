using AutoMapper;
using MerchantApi.Database;
using MerchantApi.Dto;
using MerchantApi.Models;
using MerchantApi.Models.Response;

namespace MerchantApi.Repository
{
    public class MerchantRepository : IMerchantRepository
    {
        private readonly MerchantDbContext _merchantDbContext;
        private readonly IMapper _mapper;
        public MerchantRepository(MerchantDbContext merchantDbContext, IMapper mapper)
        {
            _merchantDbContext = merchantDbContext;
            _mapper = mapper;

        }
        public void Merchants_CreateMerchant(MerchantDto _merchant)
        {
            var merchant = _mapper.Map<Merchant>(_merchant);
            _merchantDbContext.Merchants.Add(merchant);
            _merchantDbContext.SaveChanges();
        }

        public bool Merchants_DeleteMerchant(string merchantCode)
        {
            var merchantFromDb = _merchantDbContext.Merchants.Where(x => x.MerchantCode == merchantCode).FirstOrDefault();
            if (merchantFromDb == null)
            {
                return false;
            }
            _merchantDbContext.Merchants.Remove(merchantFromDb);
            _merchantDbContext.SaveChanges();
            return true;
        }

        public Merchant Merchants_GetMerchant(string merchantCode)
        {
            var merchant = _merchantDbContext.Merchants.Where(x => x.MerchantCode == merchantCode).FirstOrDefault();
            return merchant;
        }

        public ICollection<Merchant> Merchants_GetList()
        {
            return _merchantDbContext.Merchants.ToList();
        }

        public ICollection<Store> Merchants_GetStores(string MerchantCode)
        {
            var storesInMerchant = _merchantDbContext.Stores.Where(x => x.MerchantCode == MerchantCode).ToList();

            return storesInMerchant;
        }

        public bool Merchants_UpdateMerchant(string merchantCode, MerchantDto _merchant)
        {
            var merchantFromDb = _merchantDbContext.Merchants.Where(x => x.MerchantCode == merchantCode).FirstOrDefault();

            if (merchantFromDb == null)
            {
                return false;
            }
            merchantFromDb.MerchantCode = _merchant.MerchantCode;
            merchantFromDb.DisplayName = _merchant.DisplayName;
            merchantFromDb.FullName = _merchant.FullName;
            merchantFromDb.Address = _merchant.Address;
            merchantFromDb.PhoneNumber = _merchant.PhoneNumber;
            merchantFromDb.Email = _merchant.Email;
            merchantFromDb.MerchantWebsite = _merchant.MerchantWebsite;
            merchantFromDb.AccountNumber = _merchant.AccountNumber;


            _merchantDbContext.SaveChanges();
            return true;
        }

        public MerchantResponse Merchants_GetList(int page, string? fullName)
        {
            var defaultPageSize = 10f;
            var merchants = _mapper.Map<List<MerchantDto>>(_merchantDbContext.Merchants.ToList());

            var pageCount = Math.Ceiling(merchants.Count / defaultPageSize);

            if (!string.IsNullOrEmpty(fullName) && merchants.Count > 0)
            {
                merchants = merchants.Where(x => x.FullName == fullName).ToList();
                pageCount = Math.Ceiling(merchants.Count / defaultPageSize);
            }

            var merchantsPaged = merchants.Skip((page - 1) * (int)defaultPageSize).Take((int)defaultPageSize).ToList();

            MerchantResponse merchantResponse = new MerchantResponse
            {
                Merchants = merchantsPaged,
                CurrentPage = page,
                Pages = (int)pageCount
            };

            return merchantResponse;
        }
    }
}
