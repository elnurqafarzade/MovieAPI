using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Business.DTOs.GenreDTOs
{
    public record GenreUpdateDTO(string Name, bool IsDeleted);
}
