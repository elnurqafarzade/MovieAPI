using PB201MovieApp.Business.DTOs.MovieDTOs;
using PB201MovieApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Business.Services.Interfaces
{
    public interface IMovieService
    {
        Task<MovieGetDTO> CreateAsync(MovieCreateDTO dto);
        Task UpdateAsync(int? id, MovieUpdateDto dto);
        Task DeleteAsync(int id);
        Task<MovieGetDTO> GetById(int id);
        Task<ICollection<MovieGetDTO>> GetByExpression(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
        Task<MovieGetDTO> GetSingleByExpression(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes);
    }
}
