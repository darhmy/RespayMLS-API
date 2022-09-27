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
    public class itemTypeController : ControllerBase
    {
        private readonly IItemTypeRepository _itemTypeRepository;
        private readonly ISectorRepository _sectorRepository;

        public itemTypeController(IItemTypeRepository itemTypeRepository, ISectorRepository sectorRepository)
        {
            _itemTypeRepository = itemTypeRepository;
            _sectorRepository = sectorRepository;
        }

        /// <summary>
        /// Add Item Type
        /// </summary>
        /// <param name="itemTypeDTO"></param>
        /// <returns></returns>
        [HttpPost("CreateType")]
        public IActionResult Save([FromBody] ItemTypeDTO itemTypeDTO)
        {
            if (itemTypeDTO == null)
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
                var checkSector = _sectorRepository.GetSector(itemTypeDTO.SectorId);

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
                    var itemType = new ItemType
                    {
                        TypeName = itemTypeDTO.TypeName
                    };

                    itemType.Sector = _sectorRepository.GetSector(itemTypeDTO.SectorId);

                    _itemTypeRepository.AddItemType(itemType);


                    var apiResponse = new ApiResponse
                    {
                        Code = "201",
                        IsSuccessful = true,
                        Message = "Successful request, A new Item Type has been created",
                        Data = itemTypeDTO
                    };

                    return Ok(apiResponse);
                }


            }
        }

        /// <summary>
        /// Get All Item Types
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllItemTypes()
        {
            var getAllItemTypes = await _itemTypeRepository.GetAllItemTypes("Sector");


            if (getAllItemTypes == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Item Types can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<ItemTypeListDTO> itemTypeListDTOs = new List<ItemTypeListDTO>();

                foreach (var itemType in getAllItemTypes)
                {
                    var itemTypeListDTO = new ItemTypeListDTO
                    {
                        ItemTypeId = itemType.ItemTypeId,
                        TypeName = itemType.TypeName,
                        SectorId = itemType.Sector.SectorId,
                        Sector = itemType.Sector.SectorName
                    };

                    itemTypeListDTOs.Add(itemTypeListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Roles",
                    Data = itemTypeListDTOs
                };

                return Ok(apiResponse);
            }
        }


        /// <summary>
        /// Get Item Type by Id
        /// </summary>
        /// <param name="itemTypeId"></param>
        /// <returns></returns>
        [HttpGet("{itemTypeId}")]
        public IActionResult GetItemType(int itemTypeId)
        {
            var getItemType = _itemTypeRepository.GetItemType(itemTypeId);

            if (getItemType == null)
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
                var itemTypeDetails = new ItemTypeListDTO
                {
                    SectorId = getItemType.Sector.SectorId,
                    TypeName = getItemType.TypeName,
                    ItemTypeId = getItemType.ItemTypeId,
                    Sector = getItemType.Sector.SectorName
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = itemTypeDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Item Type
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="itemTypeDTO"></param>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public IActionResult UpdateItemType(int Id, [FromBody] ItemTypeDTO itemTypeDTO)
        {
            var getItemType = _itemTypeRepository.GetItemType(Id);

            if (getItemType == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the TypeID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                var checkSector = _sectorRepository.GetSector(itemTypeDTO.SectorId);

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
                    getItemType.TypeName = itemTypeDTO.TypeName;


                    _itemTypeRepository.UpdateItemType(getItemType);

                    var apiResponse = new ApiResponse
                    {
                        Code = "200",
                        IsSuccessful = true,
                        Message = "Update Successful",
                        Data = itemTypeDTO
                    };

                    return Ok(apiResponse);
                }

            }

        }


        /// <summary>
        /// Delete Item Type
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteItemType(int Id)
        {
            var getItemType = _itemTypeRepository.GetItemType(Id);

            if (getItemType == null)
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
                _itemTypeRepository.Delete(Id);

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
