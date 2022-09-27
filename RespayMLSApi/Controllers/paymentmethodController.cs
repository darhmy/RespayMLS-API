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
    public class paymentmethodController : ControllerBase
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public paymentmethodController(IPaymentMethodRepository paymentMethodRepository)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        /// <summary>
        /// Add Payment Method
        /// </summary>
        /// <param name="paymentMethodDTO"></param>
        /// <returns></returns>
        [HttpPost("CreatePaymentMethod")]
        public IActionResult Save([FromBody] PaymentMethodDTO paymentMethodDTO)
        {
            if (paymentMethodDTO == null)
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

                var paymentMethod = new PaymentMethod
                {
                    PaymentMethodName = paymentMethodDTO.PaymentMethodName,
                };

                _paymentMethodRepository.AddPaymentMethod(paymentMethod);


                var apiResponse = new ApiResponse
                {
                    Code = "201",
                    IsSuccessful = true,
                    Message = "Successful request, A new Payment Method has been created",
                    Data = paymentMethodDTO
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get All Payment Method
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPaymentMethod()
        {
            var getAllPaymentMethod = _paymentMethodRepository.GetAllPaymentMethods();


            if (getAllPaymentMethod == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Payment Method can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<PaymentMethodListDTO> paymentMethodListDTOs = new List<PaymentMethodListDTO>();

                foreach (var paymentMethod in getAllPaymentMethod)
                {
                    var paymentMethodListDTO = new PaymentMethodListDTO
                    {
                        PaymentMethodId = paymentMethod.PaymentMethodId,
                        PaymentMethodName = paymentMethod.PaymentMethodName
                    };
                    paymentMethodListDTOs.Add(paymentMethodListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Payment Methods",
                    Data = paymentMethodListDTOs
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get Payment Method By Id
        /// </summary>
        /// <param name="paymentMethodId"></param>
        /// <returns></returns>
        [HttpGet("{paymentMethodId}")]
        public IActionResult GetPaymentMethod(int paymentMethodId)
        {
            var getPaymentMethod = _paymentMethodRepository.GetPaymentMethod(paymentMethodId);

            if (getPaymentMethod == null)
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
                var paymentMethodListDetails = new PaymentMethodListDTO
                {
                    PaymentMethodId= getPaymentMethod.PaymentMethodId,
                    PaymentMethodName = getPaymentMethod.PaymentMethodName,
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = paymentMethodListDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Payment Method
        /// </summary>
        /// <param name="paymentMethodId"></param>
        /// <param name="paymentMethodDTO"></param>
        /// <returns></returns>
        [HttpPatch("{paymentMethodId}")]
        public IActionResult UpdatePaymentMethod(int paymentMethodId, [FromBody] PaymentMethodDTO paymentMethodDTO)
        {
            var getPaymentMethod = _paymentMethodRepository.GetPaymentMethod(paymentMethodId);

            if (getPaymentMethod == null)
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
                getPaymentMethod.PaymentMethodName = paymentMethodDTO.PaymentMethodName;

                _paymentMethodRepository.UpdatePaymentMethod(getPaymentMethod);


                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Update Successful",
                    Data = paymentMethodDTO
                };

                return Ok(apiResponse);

            }

        }

       /// <summary>
       /// Delete Payment Method
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeletePaymentMethod(int Id)
        {
            var getPaymentMethod = _paymentMethodRepository.GetPaymentMethod(Id);

            if (getPaymentMethod == null)
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
                _paymentMethodRepository.Delete(Id);

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
