using MerchantApi.Models;

namespace MerchantApi.Dto
{
    public class MerchantDto
    {
        public int MerchantId { get; set; }

        public string MerchantCode { get; set; }
        public string DisplayName { get; set; }
     
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MerchantWebsite { get; set; }
        public string AccountNumber { get; set; }
       // public ICollection<Store> Stores { get; set; }
    }
}
