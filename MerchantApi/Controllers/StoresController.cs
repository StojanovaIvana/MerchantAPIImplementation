using AutoMapper;
using MerchantApi.Dto;
using MerchantApi.Models;
using MerchantApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerchantApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;
        public StoresController(IMerchantRepository merchantRepository, IStoreRepository storeRepository, IMapper mapper)
        {
            _merchantRepository = merchantRepository;
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<Store>> GetStores()
        {
            return _storeRepository.GetStores().ToList();
        }
        [HttpPost]
        public ActionResult CreateStore([FromBody] StoreDto store)
        {
            _storeRepository.CreateStore(store);
            return Ok();

        }

        [HttpPut("{storeCode}")]
        public ActionResult UpdateStore([FromRoute] string storeCode, [FromBody] StoreDto store)
        {
            var result = _storeRepository.UpdateStore(storeCode, store);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{storeCode}")]
        public ActionResult DeleteStore([FromRoute] string storeCode)
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
