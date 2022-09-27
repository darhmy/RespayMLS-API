using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespayMLS.Core.DTOs;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLSApi.Extension;
using System.Collections.Generic;

namespace RespayMLSApi.Controllers
{
    [Route("v1/admin/internal/[controller]")]
    [ApiController]
    public class listingtypesController : ControllerBase
    {
        private readonly IListingTypeRepository _listingTypeRepository;
        private readonly ISectorRepository _sectorRepository;
        private readonly IRoleRepository _roleRepository;

        public listingtypesController(IListingTypeRepository listingTypeRepository, ISectorRepository sectorRepository, 
                                      IRoleRepository roleRepository)
        {
            _listingTypeRepository = listingTypeRepository;
            _sectorRepository = sectorRepository;
            _roleRepository = roleRepository;
        }

        /// <summary>
        /// Add Lisiting Type
        /// </summary>
        /// <param name="listingTypeDTO"></param>
        /// <returns></returns>
        [HttpPost("AddListingType")]
        public IActionResult Save([FromBody] ListingTypeDTO listingTypeDTO)
        {
            if (listingTypeDTO == null)
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
                var checkSector = _sectorRepository.GetSector(listingTypeDTO.SectorId);

                var checkRole = _roleRepository.GetRole(listingTypeDTO.RoleId);

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
                if (checkRole == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Role Not Found. Check the RoleID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                else
                {
                    var listingType = new ListingType
                    {
                        Platforms = listingTypeDTO.Platforms,
                        Sector = checkSector,
                        Role= checkRole,
                    };

                    //role.Sector = _sectorRepository.GetSector(sectorId);

                    _listingTypeRepository.AddListingType(listingType);


                    var apiResponse = new ApiResponse
                    {
                        Code = "201",
                        IsSuccessful = true,
                        Message = "Successful request, A new Listing Type has been created",
                        Data = listingTypeDTO
                    };

                    return Ok(apiResponse);
                }


            }
        }

        /// <summary>
        /// Get All Listing Type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllListingTypes()
        {
            var getAllListingTypes = _listingTypeRepository.GetAllListingTypes();


            if (getAllListingTypes == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Listing Types can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<ListingTypeListDTO> listingTypeListDTOs = new List<ListingTypeListDTO>();

                foreach (var listingType in getAllListingTypes)
                {
                    var listingTypeListDTO = new ListingTypeListDTO
                    {
                        ListingTypeId = listingType.ListingTypeId,
                        Platforms = listingType.Platforms,
                        RoleId = listingType.Role.RoleId,
                        Role = listingType.Role.RoleName,
                        SectorId = listingType.Sector.SectorId,
                        Sector = listingType.Sector.SectorName
                    };

                    listingTypeListDTOs.Add(listingTypeListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Listing Types",
                    Data = listingTypeListDTOs
                };

                return Ok(apiResponse);
            }
        }


        /// <summary>
        /// Get Lisiting Type By Id
        /// </summary>
        /// <param name="listingTypeId"></param>
        /// <returns></returns>
        [HttpGet("{listingTypeId}")]
        public IActionResult GetListingType(int listingTypeId)
        {
            var getListingType = _listingTypeRepository.GetListingType(listingTypeId);

            if (getListingType == null)
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
                var listingTypeDetails = new ListingTypeListDTO
                {
                    ListingTypeId = getListingType.ListingTypeId,
                    Platforms = getListingType.Platforms,
                    RoleId = getListingType.Role.RoleId,
                    Role = getListingType.Role.RoleName,
                    SectorId = getListingType.Sector.SectorId,
                    Sector = getListingType.Sector.SectorName
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = listingTypeDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Lisiting Type
        /// </summary>
        /// <param name="listingTypeId"></param>
        /// <param name="listingTypeDTO"></param>
        /// <returns></returns>
        [HttpPatch("{listingTypeId}")]
        public IActionResult UpdateListingType(int listingTypeId, [FromBody] ListingTypeDTO listingTypeDTO)
        {
            var getListingType = _listingTypeRepository.GetListingType(listingTypeId);

            if (getListingType == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the Lisitng TyeId",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                var checkSector = _sectorRepository.GetSector(listingTypeDTO.SectorId);

                var checkRole = _roleRepository.GetRole(listingTypeDTO.RoleId);

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
                if (checkRole == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Role Not Found. Check the RoleID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                else
                {
                    getListingType.Platforms=listingTypeDTO.Platforms;

                    getListingType.Sector = checkSector;

                    getListingType.Role = checkRole;


                    _listingTypeRepository.UpdateListingType(getListingType);

                    var apiResponse = new ApiResponse
                    {
                        Code = "200",
                        IsSuccessful = true,
                        Message = "Update Successful",
                        Data = listingTypeDTO
                    };

                    return Ok(apiResponse);
                }
            }

        }

       
        /// <summary>
        /// Delete Listing Type
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            var getListingType = _listingTypeRepository.GetListingType(Id);

            if (getListingType == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "400",
                    IsSuccessful = false,
                    Message = "Not Found. Check the ID",
                    Data = null
                };
                return BadRequest(apiResponse);
            }
            else
            {
                _listingTypeRepository.Delete(Id);

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
