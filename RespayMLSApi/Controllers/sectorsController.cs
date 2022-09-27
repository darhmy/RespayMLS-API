using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespayMLS.Core.DTOs;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLSApi.Extension;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RespayMLSApi.Controllers
{
    [Route("v1/admin/internal/[controller]")]
    [ApiController]
    public class sectorsController : ControllerBase
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly IItemTypeRepository _itemTypeRepository;

        public sectorsController(ISectorRepository sectorRepository, IItemTypeRepository itemTypeRepository)
        {
            _sectorRepository = sectorRepository;
            _itemTypeRepository = itemTypeRepository;
        }

        /// <summary>
        /// Add Sector
        /// </summary>
        /// <param name="sectorDTO"></param>
        /// <returns></returns>
        [HttpPost("AddSector")]
        public IActionResult Save([FromBody] SectorDTO sectorDTO)
        {
            if (sectorDTO == null)
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
                if (!_sectorRepository.isSectorExist(sectorName: sectorDTO.SectorName.Trim()))
                {
                    var sector = new Sector
                    {
                        SectorName = sectorDTO.SectorName,
                    };

                    _sectorRepository.AddSector(sector);


                    var apiResponse = new ApiResponse
                    {
                        Code = "201",
                        IsSuccessful = true,
                        Message = "Successful request, A new Sector has been created",
                        Data = sectorDTO
                    };

                    return Ok(apiResponse);
                }
                else
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "400",
                        IsSuccessful = false,
                        Message = $"The Sector ({sectorDTO.SectorName}) Exist.",
                        Data = null
                    };

                    return BadRequest(apiResponse);
                }
            }
        }

        /// <summary>
        /// Get All Sector
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllSector()
        {
            var getAllSector = _sectorRepository.GetAllSectors();


            if (getAllSector == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Sector can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<SectorListDTO> sectors = new List<SectorListDTO>();

                foreach (var sector in getAllSector)
                {
                    var sectorListDTO = new SectorListDTO
                    {
                        SectorId = sector.SectorId,
                        SectorName = sector.SectorName,
                    };
                    sectors.Add(sectorListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Sector",
                    Data = sectors
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get Sector By Id
        /// </summary>
        /// <param name="sectorId"></param>
        /// <returns></returns>
        [HttpGet("{sectorId}")]
        public IActionResult GetSector(int sectorId)
        {
            var getSector = _sectorRepository.GetSector(sectorId);

            if (getSector == null)
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
                var sectorListDetails = new SectorListDTO
                {
                    SectorId = getSector.SectorId,
                    SectorName = getSector.SectorName,
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = sectorListDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Sector
        /// </summary>
        /// <param name="sectorId"></param>
        /// <param name="sectorDTO"></param>
        /// <returns></returns>
        [HttpPatch("{sectorId}")]
        public IActionResult UpdateSector(int sectorId, [FromBody] SectorDTO sectorDTO)
        {
            var getSector = _sectorRepository.GetSector(sectorId);

            if (getSector == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the SectorID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                getSector.SectorName = sectorDTO.SectorName;

                _sectorRepository.Update(getSector);

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Update Successful",
                    Data = sectorDTO
                };

                return Ok(apiResponse);

            }

        }

       

        /// <summary>
        /// Delete Sector
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteSector(int Id)
        {
            var getSector = _sectorRepository.GetSector(Id);

            if (getSector == null)
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
                _sectorRepository.Delete(Id);

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

        /// <summary>
        /// Get Item Types By SectorId
        /// </summary>
        /// <param name="sectorId"></param>
        /// <returns></returns>
        [HttpGet("{sectorId}/types")]
        public async Task<IActionResult> GetItemTypes(int sectorId)
        {
            var getSector = _sectorRepository.GetSector(sectorId);

            if (getSector == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the Sector ID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {

                var getSectorItemType = await _itemTypeRepository.GetItemSector(sectorId);

                if (getSectorItemType == null)
                {

                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Not Found. No Item Type",
                        Data = null
                    };
                    return NotFound(apiResponse);
                }

                else
                {
                    List<SectorItemDTO> sectorItemDTOs = new List<SectorItemDTO>();

                    foreach (var itemTypes in getSectorItemType) {

                        var sectorItemDTO = new SectorItemDTO
                        {
                            ItemTypeId = itemTypes.ItemTypeId,
                            ItemTypeName = itemTypes.TypeName,
                            SectorId = itemTypes.Sector.SectorId,
                            SectorName = itemTypes.Sector.SectorName
                           
                        };

                        sectorItemDTOs.Add(sectorItemDTO);
                    }

                    var apiResponse = new ApiResponse
                    {
                        Code = "200",
                        IsSuccessful = true,
                        Message = "List of Item Types",
                        Data = sectorItemDTOs
                    };

                    return Ok(apiResponse);
                }
            }
        }

    }
}
