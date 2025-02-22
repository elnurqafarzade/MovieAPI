﻿using PB201MovieApp.Business.DTOs.GenreDTOs;
using PB201MovieApp.Core.Entities;
using System.Linq.Expressions;


namespace PB201MovieApp.Business.Services.Interfaces
{
    public interface IGenreService
    {
        Task CreateAsync(GenreCreateDTO dto);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, GenreUpdateDTO dto);
        Task<GenreGetDTO> GetById(int id);
        Task<bool> IsExistAsync(Expression<Func<Genre, bool>>? expression = null);
        Task<ICollection<GenreGetDTO>> GetByExpression(bool asNoTracking = false, Expression<Func<Genre, bool>>? expression = null, params string[] includes);
        Task<GenreGetDTO> GetSingleByExpression(bool asNoTracking = false, Expression<Func<Genre, bool>>? expression = null, params string[] includes);
    }
}
