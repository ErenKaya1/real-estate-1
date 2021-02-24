using System.ComponentModel.DataAnnotations;

namespace src.RealEstate.Common.Enum
{
    public enum UsingStatus : byte
    {
        [Display(Name = "Belirtilmemiş")]
        Unknown,

        [Display(Name = "Ev Sahibi Oturuyor")]
        HostSitting,

        [Display(Name = "Kiracı Oturuyor")]
        TenantSitting,

        [Display(Name = "Boş")]
        Empty
    }
}
