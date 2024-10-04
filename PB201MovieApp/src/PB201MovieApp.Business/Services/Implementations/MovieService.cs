using AutoMapper;
using PB201MovieApp.Business.DTOs.MovieDTOs;
using PB201MovieApp.Business.Exceptions;
using PB201MovieApp.Business.Services.Interfaces;
using PB201MovieApp.Business.Utilities;
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
    public class MovieService : IMovieService
    {


        private readonly IMovieRepository _movieRepository;
        private readonly IMapper mapper;
        private readonly IGenreService genreService;
        private readonly IWebHostEnvironment env;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, IGenreService genreService, IWebHostEnvironment env)
        {
            _movieRepository = movieRepository;
            this.mapper = mapper;
            this.genreService = genreService;
            this.env = env;
        }

        public async Task<MovieGetDTO> CreateAsync(MovieCreateDTO dto)
        {

            if (!await genreService.IsExistAsync(x => x.Id == dto.GenreId && x.IsDeleted == false)) throw new EntityNotFoundException();
            Movie movie = mapper.Map<Movie>(dto);
            string imageUrl = dto.ImageFile.SaveFile(env.WebRootPath, "Uploads");
            movie.MovieImage = new List<MovieImage>();
            MovieImage movieImage = new MovieImage()
            {
                ImageUrl = imageUrl,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            };

            movie.MovieImages.Add(movieImage);
            movie.CreatedDate = DateTime.Now;
            movie.ModifiedDate = DateTime.Now;



            await _movieRepository.CreateAsync(movie);
            await _movieRepository.CommitAsync();
            MovieGetDTO getDto = new MovieGetDTO(movie.Id, movie.Title, movie.Desc, movie.IsDeleted, movie.CreatedDate, movie.ModifiedDate, movie.GenreId);

            return getDto;
        }
        public async Task DeleteAsync(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await _movieRepository.GetByIdAsync(id);
            if (data is null) throw new EntityNotFoundException(404, "EntityNotFound");
            _movieRepository.Delete(data);
            await _movieRepository.CommitAsync();
        }

        public async Task<ICollection<MovieGetDTO>> GetByExpression(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var datas = await _movieRepository.GetByExpression(asNoTracking, expression, includes).ToListAsync();

            ICollection<MovieGetDTO> dtos = datas.Select(data => new MovieGetDTO(data.Id, data.Title, data.Desc, data.IsDeleted, data.CreatedAt, data.ModifiedAt, data.GenreId)).ToList();

            return dtos;
        }

        public async Task<MovieGetDTO> GetById(int id)
        {
            if (id < 1) throw new InvalidIdException();
            var data = await _movieRepository.GetByIdAsync(id);

            if (data is null) throw new EntityNotFoundException(404, "EntityNotFound");


            MovieGetDTO dto = mapper.Map<MovieGetDTO>(data);

            return dto;
        }

        public async Task<MovieGetDTO> GetSingleByExpression(bool asNoTracking = false, Expression<Func<Movie, bool>>? expression = null, params string[] includes)
        {
            var data = await _movieRepository.GetByExpression(asNoTracking, expression, includes).FirstOrDefaultAsync();
            if (data is null) throw new EntityNotFoundException(404, "EntityNotFound");

            MovieGetDTO dto = new MovieGetDTO(data.Id, data.Title, data.Desc, data.IsDeleted, data.CreatedAt, data.ModifiedAt, data.GenreId);

            return dto;
        }

        public async Task UpdateAsync(int? id, MovieUpdateDto dto)
        {
            if (!await genreService.IsExistAsync(x => x.Id == dto.GenreId && x.IsDeleted == false)) throw new EntityNotFoundException();
            if (id < 1 || id is null) throw new InvalidIdException();

            var data = await _movieRepository.GetByIdAsync((int)id);

            if (data is null) throw new EntityNotFoundException();

            string imageUrl = dto.ImageFile.SaveFile(env.WebRootPath, "Uploads");
            data.MovieImages = new List<MovieImage>();
            MovieImage movieImage = new MovieImage()
            {
                ImageUrl = imageUrl,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            };

            data.MovieImages.Add(movieImage);

            mapper.Map(dto, data);

            data.ModifiedAt = DateTime.Now;

            await _movieRepository.CommitAsync();
        }
    }
}
