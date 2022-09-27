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
    public class frequenciesController : ControllerBase
    {
        private readonly IFrequencyRepository _frequencyRepository;

        public frequenciesController(IFrequencyRepository frequencyRepository)
        {
            _frequencyRepository = frequencyRepository;
        }

        /// <summary>
        /// Add Frequency
        /// </summary>
        /// <param name="frequencyDTO"></param>
        /// <returns></returns>
        [HttpPost("CreateFrequency")]
        public IActionResult Save([FromBody] FrequencyDTO frequencyDTO)
        {
            if (frequencyDTO == null)
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
                if (!_frequencyRepository.isFrequencyExist(frequencyName: frequencyDTO.FrequencyName.Trim()))
                {

                    var frequency = new Frequency
                    {
                        FrequencyName = frequencyDTO.FrequencyName,
                        FrequencyTenure = frequencyDTO.FrequencyTenure,
                        DaysInPeriod = frequencyDTO.DaysInPeriod
                    };

                    _frequencyRepository.AddFrequency(frequency);


                    var apiResponse = new ApiResponse
                    {
                        Code = "201",
                        IsSuccessful = true,
                        Message = "Successful request, A new Frequency has been created",
                        Data = frequencyDTO
                    };

                    return Ok(apiResponse);
                }
                else
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "400",
                        IsSuccessful = false,
                        Message = $"The Freqency ({frequencyDTO.FrequencyName}) Exist.",
                        Data = null
                    };

                    return BadRequest(apiResponse);
                }
            }
        }

        /// <summary>
        /// Get All Frequencies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllFrequencies()
        {
            var getAllFrequency = _frequencyRepository.GetAllFrequencies();


            if (getAllFrequency == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Frequency can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<FrequencyListDTO> frequencyListDTOs = new List<FrequencyListDTO>();

                foreach (var frequency in getAllFrequency)
                {
                    var frequencyListDTO = new FrequencyListDTO
                    {
                        FrquencyId = frequency.FrequencyId,
                        FrequencyName = frequency.FrequencyName,
                        FrequencyTenure = frequency.FrequencyTenure,
                        DaysInPeriod = frequency.DaysInPeriod
                    };
                    frequencyListDTOs.Add(frequencyListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Frequencies",
                    Data = frequencyListDTOs
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get Frequency By Id
        /// </summary>
        /// <param name="frquencyId"></param>
        /// <returns></returns>
        [HttpGet("{frquencyId}")]
        public IActionResult GetFrequency(int frquencyId)
        {
            var getFrequency = _frequencyRepository.GetFrequency(frquencyId);

            if (getFrequency == null)
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
                var frequencyListDetails = new FrequencyListDTO
                {
                    FrquencyId = getFrequency.FrequencyId,
                    FrequencyName = getFrequency.FrequencyName,
                    FrequencyTenure = getFrequency.FrequencyTenure,
                    DaysInPeriod = getFrequency.DaysInPeriod
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = frequencyListDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Frequency
        /// </summary>
        /// <param name="frquencyId"></param>
        /// <param name="frequencyDTO"></param>
        /// <returns></returns>
        [HttpPatch("{frquencyId}")]
        public IActionResult UpdateFrequency(int frquencyId, [FromBody] FrequencyDTO frequencyDTO)
        {
            var getFrequency = _frequencyRepository.GetFrequency(frquencyId);

            if (getFrequency == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the FrequencyID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                getFrequency.FrequencyName = frequencyDTO.FrequencyName;

                getFrequency.FrequencyTenure = frequencyDTO.FrequencyTenure;

                getFrequency.DaysInPeriod = frequencyDTO.DaysInPeriod;

                _frequencyRepository.UpdateFrequency(getFrequency);


                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Update Successful",
                    Data = frequencyDTO
                };

                return Ok(apiResponse);

            }

        }

        /// <summary>
        /// Delete Frequency
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteFrequency(int Id)
        {
            var getFrequency = _frequencyRepository.GetFrequency(Id);

            if (getFrequency == null)
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
                _frequencyRepository.Delete(Id);

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
