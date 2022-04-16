using MerchantApi.Models;

namespace MerchantApi.Dto
{
    public class StoreDto
    {
        public int StoreId { get; set; }
        public string StoreCode { get; set; }
        public string MerchantCode { get; set; }
        public string StoreDisplayName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        

    }
}
