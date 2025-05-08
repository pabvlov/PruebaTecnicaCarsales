using Microsoft.AspNetCore.Mvc;
using BFFRickAndMorty.Models;
using BFFRickAndMorty.Services.Interfaces;
using BFFRickAndMorty.Repository;

[ApiController]
[Route("api/[controller]")]
public class EpisodeController : ControllerBase
{
    private readonly IEpisodeService _episodeService;
    private readonly IEpisodeRepository _episodeRepository;

    public EpisodeController(IEpisodeService episodeService, IEpisodeRepository episodeRepository)
    {
        _episodeService = episodeService;
        _episodeRepository = episodeRepository;
    }

    [HttpGet]
    public async Task<ActionResult<PagedEpisodeDTO>> Get([FromQuery] int? page)
    {
        try
        {
            int currentPage = page ?? 1;
            var episodes = await _episodeService.GetPagedEpisodesAsync(currentPage);

            var dtoList = episodes.Select(e => new EpisodeDTO
            {
                Id = e.Id,
                Name = e.Name,
                AirDate = e.AirDate,
                EpisodeCode = e.EpisodeCode,
                Url = e.Url,
                Created = e.Created,
                Characters = e.Characters
            }).ToList();

            var pagedResponse = new PagedEpisodeDTO
            {
                Results = dtoList,
                CurrentPage = currentPage,
                Next = $"api/episode?page={currentPage + 1}",
                Prev = currentPage > 1 ? $"api/episode?page={currentPage - 1}" : null
            };

            return Ok(pagedResponse);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al procesar la solicitud: {ex.Message}");
            return StatusCode(500, "Ocurrió un error interno al procesar los episodios.");
        }
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<Episode>> GetById(int id)
    {
        var episode = await _episodeService.GetEpisodeByIdAsync(id);

        if (episode == null)
            return NotFound();

        var dto = new EpisodeDTO
        {
            Id = episode.Id,
            Name = episode.Name,
            AirDate = episode.AirDate,
            EpisodeCode = episode.EpisodeCode,
            Url = episode.Url,
            Created = episode.Created,
            Characters = episode.Characters
        };

        return Ok(dto);
    }
}