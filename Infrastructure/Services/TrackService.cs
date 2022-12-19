using AutoMapper;
using Domain.Dtos;
using Domain.Entitties;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class TrackService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TrackService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<GetTrack>>> GetTracks()
    {
        var list = _mapper.Map<List<GetTrack>>(_context.Tracks.ToList());
       return new Response<List<GetTrack>>(list);
    }
    public async Task<Response<AddTrack>> AddTrack(AddTrack track)
    {
        var newTrack = _mapper.Map<Track>(track);
        _context.Tracks.Add(newTrack);
        await _context.SaveChangesAsync();
        return new Response<AddTrack>(track);
    }

    public async Task<Response<AddTrack>> UpdateTrack(AddTrack track)
    {
        var find = await _context.Tracks.FindAsync(track.TrackId);
        find.TrackName = track.TrackName;

        await _context.SaveChangesAsync();
        return new Response<AddTrack>(track);
    }

    public async Task<Response<string>> DeleteTrack(int id)
    {
        var find = await _context.Tracks.FindAsync(id);
        _context.Tracks.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted");
    }

}
