using System.ComponentModel.DataAnnotations;

namespace src.RealEstate.Common.Enum
{
    public enum SaleType : byte
    {
        [Display(Name = "Belirtilmemiş")]
        Unknown,

        [Display(Name = "Satılık")]
        ForSale,

        [Display(Name = "Kiralık")]
        ForRent,

        [Display(Name = "Günlük Kiralık")]
        DailyRent
    }
}
