using System.ComponentModel.DataAnnotations;

namespace MerchantApi.Models
{
    public class Store
    {
        public int StoreId { get; set; }
        [Required]
        public string StoreCode { get; set; }
        [Required]
        public string MerchantCode { get; set; }
       // [Required]
       // public  Merchant Merchant { get; set; }
        [Required]
        public string StoreDisplayName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
            
    }
}
