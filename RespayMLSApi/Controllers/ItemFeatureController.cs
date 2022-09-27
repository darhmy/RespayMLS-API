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
    public class ItemFeatureController : ControllerBase
    {
        private readonly IItemFeatureRepository _itemFeatureRepository;
        private readonly ISectorRepository _sectorRepository;

        public ItemFeatureController(IItemFeatureRepository itemFeatureRepository, ISectorRepository sectorRepository)
        {
            _itemFeatureRepository = itemFeatureRepository;
            _sectorRepository = sectorRepository;
        }

        /// <summary>
        /// Add Item Feature
        /// </summary>
        /// <param name="itemFeatureDTO"></param>
        /// <returns></returns>
        [HttpPost("Add Item Feature")]
        public IActionResult Save([FromBody] ItemFeatureDTO itemFeatureDTO)
        {
            if (itemFeatureDTO == null)
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
                var checkSector = _sectorRepository.GetSector(itemFeatureDTO.SectorId);

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
                    if (!_itemFeatureRepository.isItemFeatureExist(featureName: itemFeatureDTO.FeatureName.Trim()))
                    {
                        var itemFeature = new ItemFeature
                        {
                            FeatureName = itemFeatureDTO.FeatureName,
                            Description = itemFeatureDTO.Description,
                            Sector = checkSector
                        };

                        _itemFeatureRepository.AddItemFeature(itemFeature);


                        var apiResponse = new ApiResponse
                        {
                            Code = "201",
                            IsSuccessful = true,
                            Message = "Successful request, A new Item Feature has been created",
                            Data = itemFeatureDTO
                        };

                        return Ok(apiResponse);
                    }
                    else
                    {
                        var apiResponse = new ApiResponse
                        {
                            Code = "400",
                            IsSuccessful = false,
                            Message = $"The Item Feature ({itemFeatureDTO.FeatureName}) Exist.",
                            Data = null
                        };

                        return BadRequest(apiResponse);
                    }
                }


            }
        }

        /// <summary>
        /// Get All Item Features
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllItemFeatures()
        {
            var getAllItemFeatures = await _itemFeatureRepository.GetAllItemFeatures("Sector");


            if (getAllItemFeatures == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Item Feature can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<ItemFeatureListDTO> itemFeatureListDTOs = new List<ItemFeatureListDTO>();

                foreach (var itemFeature in getAllItemFeatures)
                {
                    var itemFeatureListDTO = new ItemFeatureListDTO
                    {
                        ItemFeatureId = itemFeature.ItemFeatureId,
                        FeatureName = itemFeature.FeatureName,
                        Description = itemFeature.Description,
                        SectorId = itemFeature.Sector.SectorId,
                        Sector = itemFeature.Sector.SectorName
                    };

                    itemFeatureListDTOs.Add(itemFeatureListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Item Features",
                    Data = itemFeatureListDTOs
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get Item Feature By Id
        /// </summary>
        /// <param name="itemFeatureId"></param>
        /// <returns></returns>
        [HttpGet("{itemFeatureId}")]
        public IActionResult GetItemFeature(int itemFeatureId)
        {
            var getItemFeature = _itemFeatureRepository.GetItemFeature(itemFeatureId , "Sector");

            if (getItemFeature == null)
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
                var itemFeatureDetails = new ItemFeatureListDTO
                {
                    ItemFeatureId = getItemFeature.ItemFeatureId,
                    FeatureName = getItemFeature.FeatureName,
                    Description = getItemFeature.Description,
                    SectorId = getItemFeature.Sector.SectorId,
                    Sector = getItemFeature.Sector.SectorName
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = itemFeatureDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Item Feature
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="itemFeatureDTO"></param>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public IActionResult UpdateItemFeature(int Id, [FromBody] ItemFeatureDTO itemFeatureDTO)
        {
            var getItemFeature = _itemFeatureRepository.GetItemFeature(Id, "Sector");

            if (getItemFeature == null)
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
                var checkSector = _sectorRepository.GetSector(itemFeatureDTO.SectorId);

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
                    getItemFeature.FeatureName = itemFeatureDTO.FeatureName;
                    getItemFeature.Description = itemFeatureDTO.Description;
                    getItemFeature.Sector = checkSector;


                    _itemFeatureRepository.UpdateItemFeature(getItemFeature);

                    var apiResponse = new ApiResponse
                    {
                        Code = "200",
                        IsSuccessful = true,
                        Message = "Update Successful",
                        Data = itemFeatureDTO
                    };

                    return Ok(apiResponse);
                }

            }

        }

        /// <summary>
        /// Delete Item Feature
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteItemFeature(int Id)
        {
            var getItemFeature = _itemFeatureRepository.GetItemFeature(Id);

            if (getItemFeature == null)
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
                _itemFeatureRepository.Delete(Id);

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
