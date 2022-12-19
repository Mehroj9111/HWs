using AutoMapper;
using Domain.Dtos;
using Domain.Entitties;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;   

namespace Infrastructure.Services;

public class AlbumService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AlbumService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<GetAlbum>>> GetAlbums()
    {
        var list = _mapper.Map<List<GetAlbum>>(_context.Albums.ToList());
       return new Response<List<GetAlbum>>(list);
    }

    public async Task<Response<AddAlbum>> AddAlbum(AddAlbum album)
    {
        var newAlbum = _mapper.Map<Album>(album);
        _context.Albums.Add(newAlbum);
        await _context.SaveChangesAsync();
        return new Response<AddAlbum>(album);
    }

    public async Task<Response<AddAlbum>> UpdateAlbum(AddAlbum album)
    {
        var find = await _context.Albums.FindAsync(album.AlbumId);
        find.Title = album.Title;
        await _context.SaveChangesAsync();
        return new Response<AddAlbum>(album);
    }

    public async Task<Response<string>> DeleteAlbum(int id)
    {
        var find = await _context.Albums.FindAsync(id);
        _context.Albums.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Deleted");
    }

}
