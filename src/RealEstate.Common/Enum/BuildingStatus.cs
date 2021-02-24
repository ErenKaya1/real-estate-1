using System.ComponentModel.DataAnnotations;

namespace src.RealEstate.Common.Enum
{
    public enum BuildingStatus : byte
    {
        [Display(Name = "Belirtilmemiş")]
        Unknown,

        [Display(Name = "İnşaat Halinde")]
        UnderConstruction,

        [Display(Name = "Oturmaya Hazır")]
        Ready
    }
}
