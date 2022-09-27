using AutoMapper;
using RespayMLS.Core.DTOs;
using RespayMLS.Core.Models;

namespace RespayMLS.Core.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Sector, SectorDTO>();

            CreateMap<Role, RoleDTO>();
        }
    }
}
