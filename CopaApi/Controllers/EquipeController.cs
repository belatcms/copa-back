using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaApi.Domain.Entities.DTOs;
using CopaApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CopaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipeController : ControllerBase
    {
        private readonly ILogger<EquipeController> _logger;
        private readonly IServiceEquipe _service;
        private readonly IServicePostEquipe _servicePost;

        public EquipeController(ILogger<EquipeController> logger, IServiceEquipe serviceEquipe, IServicePostEquipe servicePostEquipe)
        {
            _logger = logger;
            _service = serviceEquipe;
            _servicePost = servicePostEquipe;
        }

        [HttpGet]
        public async Task<IEnumerable<EquipeDTo>> Get()
        {
            return await _service.GetEquipesAsync();
        }

        [HttpPost]
        public async Task<IEnumerable<EquipeDTo>> Post(List<EquipeDTo> Equipes)
        {

            return await _servicePost.PostCopaAsync(Equipes);
        }
    }
}
