using System.ComponentModel.DataAnnotations;

namespace src.RealEstate.Common.Enum
{
    public enum FurnitureStatus : byte
    {
        [Display(Name = "Belirtilmemiş")]
        Unknown,

        [Display(Name = "Eşyalı")]
        Furnished,

        [Display(Name = "Eşyasız")]
        Unfurnished
    }
}
