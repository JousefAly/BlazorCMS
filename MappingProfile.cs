namespace AuctionTypesCMS
{
    // MappingProfile.cs
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            
        }
    }

}
