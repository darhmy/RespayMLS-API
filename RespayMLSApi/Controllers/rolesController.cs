using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespayMLS.Core.DTOs;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLSApi.Extension;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RespayMLSApi.Controllers
{
    [Route("v1/admin/internal/[controller]")]
    [ApiController]
    public class rolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ISectorRepository _sectorRepository;

        public rolesController(IRoleRepository roleRepository, ISectorRepository sectorRepository)
        {
            _roleRepository = roleRepository;
            _sectorRepository = sectorRepository;
        }

        /// <summary>
        /// Add Role
        /// </summary>
        /// <param name="roleDTO"></param>
        /// <returns></returns>
        [HttpPost("CreateRole")]
        public IActionResult Save([FromBody] RoleDTO roleDTO)
        {
            if (roleDTO == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "400",
                    IsSuccessful = false,
                    Message = "Unable to create. Check all parameters",
                    Data = null
                };
                return BadRequest(apiResponse);
            }

            else
            {
                var checkSector = _sectorRepository.GetSector(roleDTO.SectorId);

                if (checkSector == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Sector Not Found. Check the SectorID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                else
                {
                    if (!_roleRepository.isRoleExist(roleName: roleDTO.RoleName.Trim()))
                    {
                        var role = new Role
                        {
                            RoleName = roleDTO.RoleName.Trim(),
                            Sector = checkSector
                        };

                        role.RoleNumber = Guid.NewGuid().ToString();

                        //role.Sector = _sectorRepository.GetSector(sectorId);

                        _roleRepository.AddRole(role);


                        var apiResponse = new ApiResponse
                        {
                            Code = "201",
                            IsSuccessful = true,
                            Message = "Successful request, A new Role has been created",
                            Data = roleDTO
                        };

                        return Ok(apiResponse);
                    }
                    else
                    {
                        var apiResponse = new ApiResponse
                        {
                            Code = "400",
                            IsSuccessful = false,
                            Message = $"The Role ({roleDTO.RoleName}) Exist.",
                            Data = null
                        };

                        return BadRequest(apiResponse);
                    }
                }

               
            }
        }

        /// <summary>
        /// Get All Roles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            var getAllRoles = await _roleRepository.GetAllRoles("Sector");


            if (getAllRoles == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Role can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<RoleSectorDTO> roleSector = new List<RoleSectorDTO>();

                foreach (var role in getAllRoles)
                {
                    var roleSectorDTO = new RoleSectorDTO
                    {
                        RoleId = role.RoleId,
                        RoleName = role.RoleName,
                        RoleNumber = role.RoleNumber,
                        SectorId = role.Sector.SectorId,
                        SectorName = role.Sector.SectorName
                    };

                    roleSector.Add(roleSectorDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Roles",
                    Data = roleSector
                };

                return Ok(apiResponse);
            }
        }


        /// <summary>
        /// Get Role By Id
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        [HttpGet("{roleId}")]
        public IActionResult GetRole(int roleId)
        {
            var getRole = _roleRepository.GetRole(roleId,"Sector");

            if (getRole == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the ID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                var roleSectorDetails = new RoleSectorDTO
                {
                    RoleId = getRole.RoleId,
                    RoleName = getRole.RoleName,
                    RoleNumber = getRole.RoleNumber,
                    SectorId = getRole.Sector.SectorId,
                    SectorName = getRole.Sector.SectorName
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = roleSectorDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Role
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="roleDTO"></param>
        /// <returns></returns>
        [HttpPatch("{roleId}")]
        public IActionResult UpdateRole(int roleId, [FromBody] RoleDTO roleDTO)
        {
            var getRole = _roleRepository.GetRole(roleId);

            if (getRole == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the RoleID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                var checkSector = _sectorRepository.GetSector(roleDTO.SectorId);

                if (checkSector == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Sector Not Found. Check the SectorID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                else
                {
                    getRole.RoleName = roleDTO.RoleName;

                    getRole.Sector = checkSector;


                    _roleRepository.UpdateRole(getRole);

                    var apiResponse = new ApiResponse
                    {
                        Code = "200",
                        IsSuccessful = true,
                        Message = "Update Successful",
                        Data = roleDTO
                    };

                    return Ok(apiResponse);
                }
            }

        }

        
        /// <summary>
        /// Delete Role
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteRole(int Id)
        {
            var getRole = _roleRepository.GetRole(Id);

            if (getRole == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the ID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                _roleRepository.Delete(Id);

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successfully Deleted",
                    Data = null
                };


                return Ok(apiResponse);

            }

        }

    }
}
