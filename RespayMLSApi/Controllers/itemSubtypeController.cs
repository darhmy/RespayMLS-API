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
    public class itemSubtypeController : ControllerBase
    {
        private readonly IItemSubTypeRepository _itemSubTypeRepository;

        public itemSubtypeController(IItemSubTypeRepository itemSubTypeRepository)
        {
            _itemSubTypeRepository = itemSubTypeRepository;
        }

        /// <summary>
        /// Add Item Subtype
        /// </summary>
        /// <param name="itemSubTypeDTO"></param>
        /// <returns></returns>
        [HttpPost("CreateItemSubType")]
        public IActionResult Save( [FromBody] ItemSubTypeDTO itemSubTypeDTO)
        {
            if (itemSubTypeDTO == null)
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
                var itemSubType = new ItemSubType
                {
                    SubTypeName = itemSubTypeDTO.SubTypeName
                };


                _itemSubTypeRepository.AddItemSubType(itemSubType);


                var apiResponse = new ApiResponse
                {
                    Code = "201",
                    IsSuccessful = true,
                    Message = "Successful request, A new Item Type has been created",
                    Data = itemSubTypeDTO
                };

                return Ok(apiResponse);
                


            }
        }

        /// <summary>
        /// Get All Item Subtypes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllISubtemTypes()
        {
            var getAllItemSubTypes =  _itemSubTypeRepository.GetAllItemSubTypes();


            if (getAllItemSubTypes == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Item Sub Types can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<ItemSubTypeListDTO> itemSubTypeListDTOs = new List<ItemSubTypeListDTO>();

                foreach (var itemSubType in getAllItemSubTypes)
                {
                    var itemSubTypeListDTO = new ItemSubTypeListDTO
                    {
                        ItemSubTypeId = itemSubType.ItemSubTypeId,
                        SubTypeName = itemSubType.SubTypeName
                    };

                    itemSubTypeListDTOs.Add(itemSubTypeListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Roles",
                    Data = itemSubTypeListDTOs
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get Item Subtype by Id
        /// </summary>
        /// <param name="itemSubTypeId"></param>
        /// <returns></returns>
        [HttpGet("{itemSubTypeId}")]
        public IActionResult GetItemType(int itemSubTypeId)
        {
            var getItemSubType = _itemSubTypeRepository.GetItemSubType(itemSubTypeId);

            if (getItemSubType == null)
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
                var itemSubTypeDetails = new ItemSubTypeListDTO
                {
                    ItemSubTypeId = getItemSubType.ItemSubTypeId,
                    SubTypeName = getItemSubType.SubTypeName
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = itemSubTypeDetails
                };

                return Ok(apiResponse);
            }
        }


        /// <summary>
        /// Update Item Subtype
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="itemSubTypeDTO"></param>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public IActionResult UpdateItemType(int Id, [FromBody] ItemSubTypeDTO itemSubTypeDTO)
        {
            var getItemSubType = _itemSubTypeRepository.GetItemSubType(Id);

            if (getItemSubType == null)
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
                getItemSubType.SubTypeName = itemSubTypeDTO.SubTypeName;


                _itemSubTypeRepository.UpdateItemSubType(getItemSubType);

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Update Successful",
                    Data = itemSubTypeDTO
                };

                return Ok(apiResponse);

            }

        }

        /// <summary>
        /// Delete Item Subtype
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteItemSubType(int Id)
        {
            var getItemType = _itemSubTypeRepository.GetItemSubType(Id);

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
                _itemSubTypeRepository.Delete(Id);

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
