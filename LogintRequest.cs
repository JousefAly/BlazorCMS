using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AuctionTypesCMS
{
    public record LoginRequest(
        [Required(ErrorMessage = "incomplete.parameter")]
        string? UserName,
        [property: JsonProperty("fallback_value")]
       string? FirstName,
       string? LastName,
       string? FullName,
       string? Email,
       string? Uuid,
       string? Nationality,
       string? EmiratesIdNumber,
       string? Gender,
       string? Sub,
       string? FullnameAR,
       string? FirstnameAR,
       string? LastnameAR,
       string? NationalityAR,
       string? UserType,
       string? SPUuid,
       string? IdType,
       string? TitleEN,
       string? TitleAR,
       int? ProfileType,
       string? UnifiedID);
  
}
