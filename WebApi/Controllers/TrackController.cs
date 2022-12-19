using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Wrapper;
using Domain.Dtos;


namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]


public class TrackController
{
    private readonly TrackService _trackService;
    public TrackController(TrackService trackService)
    {
        _trackService = trackService;
    }

    [HttpGet("Get")]
    public async Task<Response<List<GetTrack>>> GetTracks()
    {
        return await _trackService.GetTracks();
    }

    [HttpPost("Insert")]
    public async Task<Response<AddTrack>> AddTrack(AddTrack track)
    {
        return await _trackService.AddTrack(track);
    }

    [HttpPut("Update")]
    public async Task<Response<AddTrack>> UpdateTrack(AddTrack track)
    {
        return await _trackService.UpdateTrack(track);
    }

    [HttpDelete("Delete")]
    public async Task<Response<string>> DeleteTrack(int id)
    {
        return await _trackService.DeleteTrack(id);
    }

    
}
