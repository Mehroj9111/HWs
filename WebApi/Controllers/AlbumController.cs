namespace WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;

[ApiController]
[Route("[controller]")]


public class AlbumController
{
    private readonly AlbumService _albumService;

    public AlbumController(AlbumService albumService)
    {
        _albumService = albumService;
    }

    [HttpGet("Get")]
    public async Task<Response<List<GetAlbum>>> GetAlbums()
    {
        return await _albumService.GetAlbums();
    }

    [HttpPost("Insert")]
    public async Task<Response<AddAlbum>> AddAlbum(AddAlbum album)
    {
        return await _albumService.AddAlbum(album);
    }

    [HttpPut("Update")]
    public async Task<Response<AddAlbum>> UpdateAlbum(AddAlbum album)
    {
        return await _albumService.UpdateAlbum(album);
    }

    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteAllbum(int id)
    {
        return await _albumService.DeleteAlbum(id);
    }
}
