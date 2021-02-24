using System.ComponentModel.DataAnnotations;

namespace src.RealEstate.Common.Enum
{
    public enum BuildingState : byte
    {
        [Display(Name = "Belirtilmemiş")]
        Unknown,

        [Display(Name = "Sıfır")]
        BrandNew,

        [Display(Name = "İkinci El")]
        SecondHand
    }
}
