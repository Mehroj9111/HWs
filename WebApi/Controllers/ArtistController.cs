using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]



public class ArtistController
{
    private readonly ArtistService _artistService;
    public ArtistController(ArtistService artistService)
    {
        _artistService = artistService;
    }

    [HttpGet("Get")]
    public async Task<Response<List<GetArtist>>> GetArtists()
    {
        return await _artistService.GetArtist();
    }

    [HttpPost("Insert")]
    public async Task<Response<AddArtist>> AddArtist(AddArtist artist)
    {
        return await _artistService.AddArtist(artist);
    }

    [HttpPut("Update")]
    public async Task<Response<AddArtist>> UpdateArtist(AddArtist artist)
    {
        return await _artistService.UpdateArtist(artist);
    }

    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteArtist(int id)
    {
        return await _artistService.DeleteArtist(id);
    }
}
