using AutoMapper;
using Domain.Dtos;
using Domain.Entitties;

namespace Infrastructure.Mapper;

public class ServiceProfile:Profile
{
    public ServiceProfile()
    {
        CreateMap<Album, AddAlbum>().ReverseMap();
        CreateMap<Album, GetAlbum>().ReverseMap();
        CreateMap<GetAlbum, AddAlbum>().ReverseMap();
        CreateMap<Track, AddTrack>().ReverseMap();
        CreateMap<Track, GetTrack>().ReverseMap();
        CreateMap<GetTrack, AddTrack>().ReverseMap();
        CreateMap<Artist, AddArtist>().ReverseMap();
        CreateMap<Artist, GetArtist>().ReverseMap();
        CreateMap<GetArtist, AddArtist>().ReverseMap();
    }
}
