using OrdinarioAPIPOO.Data;
using OrdinarioAPIPOO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace OrdinarioAPIPOO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerPoster : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "a3aac1ed"; 
        private const string BaseUrl = "http://www.omdbapi.com/";

        public ControllerPoster(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET: api/ControllerPoster
        [HttpGet]
        public async Task<IActionResult> GetMovies([FromQuery] string title)
        {
            // Si no se pasa un título, devolver un error
            if (string.IsNullOrEmpty(title))
            {
                return BadRequest("El titulo es necesario");
            }

            // Construir la URL para la API de OMDB
            string url = $"{BaseUrl}?s={title}&apikey={ApiKey}";

            // Hacer la solicitud HTTP GET
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from OMDB.");
            }

            // Obtener el contenido de la respuesta
            var content = await response.Content.ReadAsStringAsync();

            return Ok(content); // Retorna el contenido de la respuesta
        }

        // GET: api/ControllerPoster/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(string id)
        {
            // Construir la URL para obtener la película por ID
            string url = $"{BaseUrl}?i={id}&apikey={ApiKey}";

            // Hacer la solicitud HTTP GET
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Error fetching data from OMDB.");
            }

            // Obtener el contenido de la respuesta
            var content = await response.Content.ReadAsStringAsync();

            return Ok(content); // Retorna el contenido de la respuesta
        }
    }
}
