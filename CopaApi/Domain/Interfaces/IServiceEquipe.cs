using CopaApi.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaApi.Domain.Interfaces
{
    public interface IServiceEquipe
    {
        Task<List<EquipeDTo>> GetEquipesAsync();

    }
}
