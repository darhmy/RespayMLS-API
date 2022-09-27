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
    public class productcategoriesController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public productcategoriesController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }
        /// <summary>
        /// Add Product Category
        /// </summary>
        /// <param name="productCategoryDTO"></param>
        /// <returns></returns>
        [HttpPost("CreateCategory")]
        public IActionResult Save([FromBody] ProductCategoryDTO productCategoryDTO)
        {
            if (productCategoryDTO == null)
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

                var productCategory = new ProductCategory
                {
                    ProductCategoryName = productCategoryDTO.ProductCategoryName,
                    ProductCategoryDescription = productCategoryDTO.ProductCategoryDescription
                };

                _productCategoryRepository.AddProductCategory(productCategory);


                var apiResponse = new ApiResponse
                {
                    Code = "201",
                    IsSuccessful = true,
                    Message = "Successful request, A new Product Category has been created",
                    Data = productCategoryDTO
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Get All Product Categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllProductCategory()
        {
            var getAllProductCategory = _productCategoryRepository.GetAllProductCategories();


            if (getAllProductCategory == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Product Category can not be found ",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                List<ProductCategoryListDTO> productCategories = new List<ProductCategoryListDTO>();

                foreach (var productCategory in getAllProductCategory)
                {
                    var productCategoryListDTO = new ProductCategoryListDTO
                    {
                        ProductCategoryId = productCategory.ProductCategoryId,
                        ProductCategoryName = productCategory.ProductCategoryName,
                        ProductCategoryDescription = productCategory.ProductCategoryDescription,
                    };
                    productCategories.Add(productCategoryListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Product Category",
                    Data = productCategories
                };

                return Ok(apiResponse);
            }
        }


        /// <summary>
        /// Get Product Category By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("{Id}")]
        public IActionResult GetProductCategory(int Id)
        {
            var getProductCategory = _productCategoryRepository.GetProductCategory(Id);

            if (getProductCategory == null)
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
                var productCategoryDetails = new ProductCategoryListDTO
                {
                    ProductCategoryId = getProductCategory.ProductCategoryId,
                    ProductCategoryName = getProductCategory.ProductCategoryName,
                    ProductCategoryDescription = getProductCategory.ProductCategoryDescription
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = productCategoryDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Product Category
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="productCategoryDTO"></param>
        /// <returns></returns>
        [HttpPatch("{Id}")]
        public IActionResult UpdateCategory(int Id, [FromBody] ProductCategoryDTO productCategoryDTO)
        {
            var getProductCategory = _productCategoryRepository.GetProductCategory(Id);

            if (getProductCategory == null)
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
                getProductCategory.ProductCategoryDescription = productCategoryDTO.ProductCategoryDescription;

                getProductCategory.ProductCategoryName = productCategoryDTO.ProductCategoryName;

                _productCategoryRepository.UpdateProductCategory(getProductCategory);

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Update Successful",
                    Data = productCategoryDTO
                };

                return Ok(apiResponse);

            }

        }

       /// <summary>
       /// Delete Product Category
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteProductCategory(int Id)
        {
            var getProductCategory = _productCategoryRepository.GetProductCategory(Id);

            if (getProductCategory == null)
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
                _productCategoryRepository.Delete(Id);

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
