using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Business.DTOs.MovieDTOs
{
    public record MovieGetDTO(int Id, string Title, string Desc, bool IsDeleted, DateTime CreatedAt, DateTime ModifiedAt, int GenreId);
    
}
