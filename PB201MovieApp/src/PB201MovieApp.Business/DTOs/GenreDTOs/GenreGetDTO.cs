using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Business.DTOs.GenreDTOs
{
    public record GenreGetDTO(int Id, string Name, bool IsDeleted, DateTime CreatedAt, DateTime ModifiedAt);
}
