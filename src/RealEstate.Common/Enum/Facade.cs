using System.ComponentModel.DataAnnotations;

namespace src.RealEstate.Common.Enum
{
    public enum Facade : byte
    {
        [Display(Name = "Belirtilmemiş")]
        Unknown,

        [Display(Name = "Kuzey")]
        North,

        [Display(Name = "Güney")]
        South,

        [Display(Name = "Doğu")]
        East,

        [Display(Name = "Batı")]
        West,
    }
}
