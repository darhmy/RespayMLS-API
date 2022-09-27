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
    public class currencyController : ControllerBase
    {
        private readonly ICurrencyRepository _currencyRepository;

        public currencyController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        /// <summary>
        /// Add Currency
        /// </summary>
        /// <param name="currencyDTO"></param>
        /// <returns></returns>
        [HttpPost("CreateCurrency")]
        public IActionResult Save([FromBody] CurrencyDTO currencyDTO)
        {
            if (currencyDTO == null)
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
                if (!_currencyRepository.isCurrencyExist(currencyName: currencyDTO.CurrencyName.Trim()))
                {

                    var currency = new Currency
                    {
                        CurrencyName = currencyDTO.CurrencyName,
                        CurrencySymbol = currencyDTO.CurrencySymbol
                    };

                    _currencyRepository.AddCurrency(currency);


                    var apiResponse = new ApiResponse
                    {
                        Code = "201",
                        IsSuccessful = true,
                        Message = "Successful request, A new Currency has been created",
                        Data = currencyDTO
                    };

                    return Ok(apiResponse);

                }
                else
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "400",
                        IsSuccessful = false,
                        Message = $"The Currency ({currencyDTO.CurrencyName}) Exist.",
                        Data = null
                    };

                    return BadRequest(apiResponse);
                }
            }
        }

        /// <summary>
        /// Get All Currencies
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllCurrency")]
        public IActionResult GetAllCurrency()
        {
            var getAllCurrency = _currencyRepository.GetAllCurrencies();


            if (getAllCurrency == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Currency can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<CurrencyDTO> currencies = new List<CurrencyDTO>();

                foreach (var currency in getAllCurrency)
                {
                    var currencyDTO = new CurrencyDTO
                    {
                        CurrencyName = currency.CurrencyName,
                        CurrencySymbol = currency.CurrencySymbol
                    };
                    currencies.Add(currencyDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Currencies",
                    Data = currencies
                };

                return Ok(apiResponse);
            }
        }


        /// <summary>
        /// Get Currency By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetCurrency(int Id)
        {
            var getCurrency = _currencyRepository.GetCurrency(Id);

            if (getCurrency == null)
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
                var currencyDetails = new CurrencyDTO
                {
                    CurrencyName = getCurrency.CurrencyName,
                    CurrencySymbol = getCurrency.CurrencySymbol
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = currencyDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Currency
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="currencyDTO"></param>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public IActionResult UpdateCurrency(int Id, [FromBody] CurrencyDTO currencyDTO)
        {
            var getCurrency = _currencyRepository.GetCurrency(Id);

            if (getCurrency == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the CurrencyID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                getCurrency.CurrencyName = currencyDTO.CurrencyName;

                getCurrency.CurrencySymbol = currencyDTO.CurrencySymbol;

                _currencyRepository.UpdateCurrency(getCurrency);

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Update Successful",
                    Data = currencyDTO
                };

                return Ok(apiResponse);

            }

        }

       /// <summary>
       /// Delete Currency
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteCurrency(int Id)
        {
            var getCurrency = _currencyRepository.GetCurrency(Id);

            if (getCurrency == null)
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
                _currencyRepository.Delete(Id);

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
