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
    [Route("api/[controller]")]
    [ApiController]
    public class ItemSubFeatureController : ControllerBase
    {
        private readonly IItemSubFeatureRepository _itemSubFeatureRepository;
        private readonly ISectorRepository _sectorRepository;

        public ItemSubFeatureController(IItemSubFeatureRepository itemSubFeatureRepository, ISectorRepository sectorRepository)
        {
            _itemSubFeatureRepository = itemSubFeatureRepository;
            _sectorRepository = sectorRepository;
        }

        /// <summary>
        /// Add Item Sub-Feature
        /// </summary>
        /// <param name="itemSubFeatureDTO"></param>
        /// <returns></returns>
        [HttpPost("Add Item Feature")]
        public IActionResult Save([FromBody] ItemSubFeatureDTO itemSubFeatureDTO)
        {
            if (itemSubFeatureDTO == null)
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
                var checkSector = _sectorRepository.GetSector(itemSubFeatureDTO.SectorId);

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
                    var itemSubFeature = new ItemSubFeature
                    {
                        ItemSubFeatureName = itemSubFeatureDTO.ItemSubFeatureName,
                        Description = itemSubFeatureDTO.Description,
                        Sector = checkSector
                    };

                    _itemSubFeatureRepository.AddItemSubFeature(itemSubFeature);


                    var apiResponse = new ApiResponse
                    {
                        Code = "201",
                        IsSuccessful = true,
                        Message = "Successful request, A new Item sub Feature has been created",
                        Data = itemSubFeature
                    };

                    return Ok(apiResponse);
                }


            }
        }

        /// <summary>
        /// Get All Item Sub-Features
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllItemSubFeatures()
        {
            var getAllItemSubFeatures = await _itemSubFeatureRepository.GetAllItemSubFeatures("Sector");


            if (getAllItemSubFeatures == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Item Sub Feature can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<ItemSubFeatureListDTO> itemSubFeatureListDTOs = new List<ItemSubFeatureListDTO>();

                foreach (var itemSubFeature in getAllItemSubFeatures)
                {
                    var itemSubFeatureListDTO = new ItemSubFeatureListDTO
                    {
                        ItemSubFeatureId = itemSubFeature.ItemSubFeatureId,
                        ItemSubFeatureName = itemSubFeature.ItemSubFeatureName,
                        Description = itemSubFeature.Description,
                        SectorId = itemSubFeature.Sector.SectorId,
                        Sector = itemSubFeature.Sector.SectorName
                    };

                    itemSubFeatureListDTOs.Add(itemSubFeatureListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Item Sub Features",
                    Data = itemSubFeatureListDTOs
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get Item Sub-Feature By Id
        /// </summary>
        /// <param name="itemSubFeatureId"></param>
        /// <returns></returns>
        [HttpGet("{itemSubFeatureId}")]
        public IActionResult GetItemFeature(int itemSubFeatureId)
        {
            var getItemSubFeature = _itemSubFeatureRepository.GetItemSubFeature(itemSubFeatureId);

            if (getItemSubFeature == null)
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
                var itemSubFeatureDetails = new ItemSubFeatureListDTO
                {
                    ItemSubFeatureId = getItemSubFeature.ItemSubFeatureId,
                    ItemSubFeatureName = getItemSubFeature.ItemSubFeatureName,
                    Description = getItemSubFeature.Description,
                    SectorId = getItemSubFeature.Sector.SectorId,
                    Sector = getItemSubFeature.Sector.SectorName
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = itemSubFeatureDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Item Sub-Feature
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="itemSubFeatureDTO"></param>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public IActionResult UpdateItemSubFeature(int Id, [FromBody] ItemSubFeatureDTO itemSubFeatureDTO)
        {
            var getItemSubFeature = _itemSubFeatureRepository.GetItemSubFeature(Id, "Sector");

            if (getItemSubFeature == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the Item Feature Id",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                var checkSector = _sectorRepository.GetSector(itemSubFeatureDTO.SectorId);

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
                    getItemSubFeature.ItemSubFeatureName = itemSubFeatureDTO.ItemSubFeatureName;
                    getItemSubFeature.Description = itemSubFeatureDTO.Description;
                    getItemSubFeature.Sector = checkSector;


                    _itemSubFeatureRepository.UpdateItemSubFeature(getItemSubFeature);

                    var apiResponse = new ApiResponse
                    {
                        Code = "200",
                        IsSuccessful = true,
                        Message = "Update Successful",
                        Data = itemSubFeatureDTO
                    };

                    return Ok(apiResponse);
                }

            }

        }

        /// <summary>
        /// Delete Item Sub-Feature
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteItemFeature(int Id)
        {
            var getItemSubFeature = _itemSubFeatureRepository.GetItemSubFeature(Id);

            if (getItemSubFeature == null)
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
                _itemSubFeatureRepository.Delete(Id);

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
