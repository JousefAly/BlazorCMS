using System.ComponentModel.DataAnnotations;

namespace AuctionTypesCMS.Entities
{
    public class AuctionType
    {
        public int Id { get; set; }
        [StringLength(100)]
        public string NameEn { get; set; }
        [StringLength(100)]
        public string NameAr { get; set; }
        [StringLength(100)]
        public string Key{ get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
