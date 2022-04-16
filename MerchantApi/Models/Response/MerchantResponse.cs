using MerchantApi.Dto;

namespace MerchantApi.Models.Response
{
    public class MerchantResponse
    {
        public ICollection<MerchantDto> Merchants { get; set; }   
        public int CurrentPage { get; set; }    
        public int Pages { get; set; }

    }
}
