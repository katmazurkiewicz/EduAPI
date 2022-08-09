using EduAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduAPI.Data.DAL.Interfaces
{
    public interface IMaterialRepository: IReadRepo<Material>, ICudRepo<Material>
    { }
}
