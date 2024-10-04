using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PB201MovieApp.Business.DTOs.GenreDTOs;
using PB201MovieApp.Business.Exceptions;
using PB201MovieApp.Business.Services.Interfaces;
using PB201MovieApp.Core.Entities;
using PB201MovieApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Business.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(GenreCreateDTO dto)
        {
            Genre data = _mapper.Map<Genre>(dto);

            data.CreatedDate = DateTime.Now;
            data.ModifiedDate = DateTime.Now;
            await _genreRepository.CreateAsync(data);
            await _genreRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();

            var data = await _genreRepository.GetByIdAsync(id);

            if (data is null) throw new EntityNotFoundException();

            _genreRepository.Delete(data);
            await _genreRepository.CommitAsync();
        }

        public async Task<ICollection<GenreGetDTO>> GetByExpression(bool asNoTracking = false, Expression<Func<Genre, bool>>? expression = null, params string[] includes)
        {
            var datas = await _genreRepository.GetByExpression(asNoTracking, expression, includes).ToListAsync();

            return _mapper.Map<ICollection<GenreGetDTO>>(datas);
        }

        public async Task<GenreGetDTO> GetById(int id)
        {
            if (id < 1) throw new InvalidIdException();

            var data = await _genreRepository.GetByIdAsync(id);

            if (data is null) throw new EntityNotFoundException();

            return _mapper.Map<GenreGetDTO>(data);
        }

        public async Task<GenreGetDTO> GetSingleByExpression(bool asNoTracking = false, Expression<Func<Genre, bool>>? expression = null, params string[] includes)
        {
            var data = await _genreRepository.GetByExpression(asNoTracking, expression, includes).FirstOrDefaultAsync();

            return _mapper.Map<GenreGetDTO>(data);
        }

        public async Task<bool> IsExistAsync(Expression<Func<Genre, bool>>? expression = null)
        {
            return await _genreRepository.Table.AnyAsync(expression);
        }

        public async Task UpdateAsync(int id, GenreUpdateDTO dto)
        {
            if (id < 1) throw new InvalidIdException();

            var data = await _genreRepository.GetByIdAsync(id);

            if (data is null) throw new EntityNotFoundException();

            _mapper.Map(dto, data);

            data.ModifiedAt = DateTime.Now;

            await _genreRepository.CommitAsync();
            {
            }
        }
    }
}
