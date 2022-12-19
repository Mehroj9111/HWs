using AutoMapper;
using Domain.Dtos;
using Domain.Entitties;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ArtistService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public ArtistService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetArtist>>> GetArtist()
    {
        var list = _mapper.Map<List<GetArtist>>(_context.Artists.ToList());
       return new Response<List<GetArtist>>(list);
    }

    public async Task<Response<AddArtist>> AddArtist(AddArtist artist)
    {
        var newArtist = _mapper.Map<Artist>(artist);
        _context.Artists.Add(newArtist);
        await _context.SaveChangesAsync();
        return new Response<AddArtist>(artist);
    }

    public async Task<Response<AddArtist>> UpdateArtist(AddArtist artist)
    {
        var find = await _context.Artists.FindAsync(artist.ArtistId);
        find.ArtistName = artist.ArtistName;

        await _context.SaveChangesAsync();
        return new Response<AddArtist>(artist);
    }

    public async Task<Response<string>> DeleteArtist(int id)
    {
        var find = await _context.Artists.FindAsync(id);
        _context.Artists.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted");
    }
}
