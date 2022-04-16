using AutoMapper;
using MerchantApi.Dto;
using MerchantApi.Models;
using MerchantApi.Models.Response;
using MerchantApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchantApi.Controllers
{
    [Route("api/merchants")]
    [ApiController]
    public class MerchantsController : ControllerBase
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public MerchantsController(IMerchantRepository merchantRepository, IStoreRepository storeRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<MerchantResponse> Merchants_GetList([FromQuery] int? page, string? fullName)
        {
            if(!page.HasValue || page== 0)
            {
                page = 1;
            }
            return _merchantRepository.Merchants_GetList(page.Value, fullName); 
        }
        //[HttpGet]
        //public ActionResult Merchants_GetList()
       // {
        //    var merchants = _mapper.Map<List<MerchantDto>>(_merchantRepository.Merchants_GetList());
         //   return Ok(merchants);
       // }


        [HttpPost]
        public ActionResult Merchants_CreateMerchant([FromBody] MerchantDto merchant)
        {
            _merchantRepository.Merchants_CreateMerchant(merchant);
            return Ok();

        }

        [HttpGet("{merchantCode}")]
        public ActionResult Merchants_GetMerchant([FromRoute] string merchantCode)
        {
            var merchant = _merchantRepository.Merchants_GetMerchant(merchantCode);
            if (merchant == null)
            {
                return NotFound();
            }
            return Ok(merchant);
        }
        [HttpPut("{merchantCode}")]
        public ActionResult Merchants_UpdateMerchant([FromRoute] string merchantCode, [FromBody] MerchantDto merchant)
        {
            var result = _merchantRepository.Merchants_UpdateMerchant(merchantCode, merchant);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{merchantCode}")]
        public ActionResult Merchants_DeleteMerchant([FromRoute] string merchantCode)
        {
            var result = _merchantRepository.Merchants_DeleteMerchant(merchantCode);
            if (!result)
            {
                return NotFound();
            }
            return Ok();


        }
        [HttpGet("{merchantCode}/stores")]
        public ActionResult Merchants_GetStores(string merchantCode) {

            var stores = _merchantRepository.Merchants_GetStores(merchantCode);
            return Ok(stores);

        }

       [HttpPost("{merchantCode}/stores")]
        public ActionResult Merchants_Create([FromRoute]string merchantCode,[FromBody] StoreDto store)
        {
            _storeRepository.CreateStore(store);
            return Ok();
        }
        [HttpGet("{merchantCode}/stores/{storeCode}")]
        public ActionResult Merchants_GetStore([FromRoute] string merchantCode, [FromRoute] string storeCode)
        {
            var store = _storeRepository.GetStore(storeCode);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }
        [HttpPut("{merchantCode}/stores/{storeCode}")]
        public ActionResult Merchants_UpdateStore([FromRoute] string merchantCode, [FromBody] StoreDto store, [FromRoute] string storeCode)
        {
            var result = _storeRepository.UpdateStore(storeCode, store);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete("{merchantCode}/stores/{storeCode}")]
        public ActionResult Merchants_DeleteStore([FromRoute] string merchantCode, [FromRoute] string storeCode)
        {
            var result = _storeRepository.DeleteStore(storeCode);
            if (!result)
            {
                return NotFound();
            }
            return Ok();

        }
    }
}
