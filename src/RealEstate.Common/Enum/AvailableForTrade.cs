using System.ComponentModel.DataAnnotations;

namespace src.RealEstate.Common.Enum
{
    public enum AvailableForTrade : byte
    {
        [Display(Name = "Belirtilmemiş")]
        Unknown,

        [Display(Name = "Uygun")]
        Available,

        [Display(Name = "Uygun Değil")]
        Unavailable
    }
}
