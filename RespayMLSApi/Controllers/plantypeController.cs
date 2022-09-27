using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RespayMLS.Core.DTOs;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLSApi.Extension;
using System.Collections.Generic;

namespace RespayMLSApi.Controllers
{
    [Route("v1/utility/[controller]")]
    [ApiController]
    public class plantypeController : ControllerBase
    {
        private readonly IPlanTypeRepository _planTypeRepository;

        public plantypeController(IPlanTypeRepository planTypeRepository)
        {
            _planTypeRepository = planTypeRepository;
        }

        /// <summary>
        /// Add Plan Type
        /// </summary>
        /// <param name="planTypeDTO"></param>
        /// <returns></returns>
        [HttpPost("CreatePlanType")]
        public IActionResult Save([FromBody] PlanTypeDTO planTypeDTO)
        {
            if (planTypeDTO == null)
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

                var planType = new PlanType
                {
                    PlanTypeName = planTypeDTO.PlanTypeName
                };

                _planTypeRepository.AddPlanType(planType);


                var apiResponse = new ApiResponse
                {
                    Code = "201",
                    IsSuccessful = true,
                    Message = "Successful request, A new Plan Type has been created",
                    Data = planTypeDTO
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get All Plan Type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPlanType()
        {
            var getAllPlanType = _planTypeRepository.GetAllPlanTypes();


            if (getAllPlanType == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Plan Type can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<PlanTypeListDTO> planTypes = new List<PlanTypeListDTO>();

                foreach (var planType in getAllPlanType)
                {
                    var planTypeListDTO = new PlanTypeListDTO
                    {
                        PlanTypeId = planType.PlanTypeId,
                        PlanTypeName = planType.PlanTypeName
                    };
                    planTypes.Add(planTypeListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Plan Types",
                    Data = planTypes
                };

                return Ok(apiResponse);
            }
        }


        /// <summary>
        /// Get Plan Type By Id
        /// </summary>
        /// <param name="planTypeId"></param>
        /// <returns></returns>
        [HttpGet("{planTypeId}")]
        public IActionResult GetPlanType(int planTypeId)
        {
            var getPlanType = _planTypeRepository.GetPlanType(planTypeId);

            if (getPlanType == null)
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
                var planTypeListDetails = new PlanTypeListDTO
                {
                    PlanTypeId = getPlanType.PlanTypeId,
                    PlanTypeName = getPlanType.PlanTypeName
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = planTypeListDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Plan Type
        /// </summary>
        /// <param name="planTypeId"></param>
        /// <param name="planTypeDTO"></param>
        /// <returns></returns>
        [HttpPatch("{planTypeId}")]
        public IActionResult UpdatePlanType(int planTypeId, [FromBody] PlanTypeDTO planTypeDTO)
        {
            var getPlanType = _planTypeRepository.GetPlanType(planTypeId);

            if (getPlanType == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the Plan Type ID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                getPlanType.PlanTypeName = planTypeDTO.PlanTypeName;

                _planTypeRepository.UpdatePlanType(getPlanType);

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Update Successful",
                    Data = planTypeDTO
                };

                return Ok(apiResponse);

            }

        }

        /// <summary>
        /// Delete Plan Type
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeletePlanType(int Id)
        {
            var getPlanType = _planTypeRepository.GetPlanType(Id);

            if (getPlanType == null)
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
                _planTypeRepository.Delete(Id);

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
