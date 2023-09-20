using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid.Models;
using Vivid.ViewModels;

namespace Vivid.Data.Interfaces
{
    public interface IActorRepository
    {
        Task<List<Actor>> GetAllActors();
        Task<Actor> GetActorById(int id);
        Task<Actor> CreateActor(CreateActorViewModel actor);
        Task UpdateActor(int id, EditActorViewModel editActorVM);
        Task DeleteActor(int id);
        Task<bool> IsNameExists(string name);
    }
}
