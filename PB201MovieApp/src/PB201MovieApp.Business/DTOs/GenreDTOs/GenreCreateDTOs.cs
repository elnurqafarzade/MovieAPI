using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Business.DTOs.GenreDTOs
{
    public record GenreCreateDTO(string Name, bool IsDeleted);

    public class GenreCreateDtoValidator : AbstractValidator<GenreCreateDTO>
    {
        public GenreCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().MaximumLength(50).MinimumLength(2);
            RuleFor(x => x.IsDeleted).NotNull();
        }
    }
}
