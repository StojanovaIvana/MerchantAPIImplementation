using System.ComponentModel.DataAnnotations;

namespace MerchantApi.Models
{
    public class Merchant

    {
        public int MerchantId { get; set; }
        [Required]
        public string MerchantCode { get; set; }
        public string DisplayName { get; set; }
        [Required]
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string MerchantWebsite { get; set; }
        [Required]
        public string AccountNumber { get; set; }

       public ICollection<Store> Stores { get; set; }  

    }
}
