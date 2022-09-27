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
    public class productController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IFrequencyRepository _frequencyRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IPlanTypeRepository _planTypeRepository;
        private readonly ISectorRepository _sectorRepository;

        public productController(IProductRepository productRepository, IFrequencyRepository frequencyRepository,
                                 ICurrencyRepository currencyRepository, IProductCategoryRepository productCategoryRepository,
                                 IPlanTypeRepository planTypeRepository, ISectorRepository sectorRepository)
        {
            _productRepository = productRepository;
            _frequencyRepository = frequencyRepository;
            _currencyRepository = currencyRepository;
            _productCategoryRepository = productCategoryRepository;
            _planTypeRepository = planTypeRepository;
            _sectorRepository = sectorRepository;
        }

        /// <summary>
        /// Add Product
        /// </summary>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        [HttpPost("AddProduct")]
        public IActionResult Save([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
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
                var checkFrequency = _frequencyRepository.GetFrequency(productDTO.FrequencyId);

                var checkCurrency = _currencyRepository.GetCurrency(productDTO.CurrencyId);

                var checkCategory = _productCategoryRepository.GetProductCategory(productDTO.CategoryId);

                var checkPlanType = _planTypeRepository.GetPlanType(productDTO.PlanTypeId);

                var checkSector = _sectorRepository.GetSector(productDTO.SectorId);

                if (checkFrequency == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Frequency Not Found. Check the FrequencyID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                if (checkCurrency == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Currency Not Found. Check the CurrencyID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                if (checkCategory == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Category Not Found. Check the CategoryID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                if (checkPlanType == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Plan Type Not Found. Check the PlanTypeID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
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
                    var product = new Product
                    {
                        Amount = productDTO.Amount,
                        MaximumListing = productDTO.MaximumListing,
                        ProductName = productDTO.ProductName,
                        SetupFee = productDTO.SetupFee,
                        
                    };

                    product.Sector = _sectorRepository.GetSector(productDTO.SectorId);

                    product.ProductCategory = _productCategoryRepository.GetProductCategory(productDTO.CategoryId);

                    product.Currency = _currencyRepository.GetCurrency(productDTO.CurrencyId);

                    product.Frequency = _frequencyRepository.GetFrequency(productDTO.FrequencyId);

                    product.PlanType = _planTypeRepository.GetPlanType(productDTO.PlanTypeId);

                    _productRepository.AddProduct(product);


                    var apiResponse = new ApiResponse
                    {
                        Code = "201",
                        IsSuccessful = true,
                        Message = "Successful request, A new Product has been created",
                        Data = productDTO
                    };

                    return Ok(apiResponse);
                }


            }
        }

        /// <summary>
        /// Get ALl Products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var getAllProduct = await _productRepository.GetAllProducts("Frequency", "Currency", "PlanType", "Sector", "ProductCategory");


            if (getAllProduct == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Product can not be found ",
                    Data = null
                };
                return BadRequest(apiResponse);
            }
            else
            {
                List<ProductListDTO> productListDTOs = new List<ProductListDTO>();

                foreach (var product in getAllProduct)
                {
                    var getSector = _sectorRepository.GetSector(product.Sector.SectorId);

                    var getCurrency = _currencyRepository.GetCurrency(product.Currency.CurrencyId);

                    var getFrequency = _frequencyRepository.GetFrequency(product.Frequency.FrequencyId);

                    var getCategory = _productCategoryRepository.GetProductCategory(product.ProductCategory.ProductCategoryId);

                    var getPlanType = _planTypeRepository.GetPlanType(product.PlanType.PlanTypeId);

                    var productListDTO = new ProductListDTO
                    {
                        CategoryId = getCategory.ProductCategoryId,
                        CategoryName = getCategory.ProductCategoryName,
                        CurrencyId = getCurrency.CurrencyId,
                        CurrencySymbol = getCurrency.CurrencySymbol,
                        FrequencyId = getFrequency.FrequencyId,
                        Frequency = getFrequency.FrequencyName,
                        PlanTypeId = getPlanType.PlanTypeId,
                        PlanTypeName = getPlanType.PlanTypeName,
                        SectorId = getSector.SectorId,
                        Sector = getSector.SectorName,
                        ProductName = product.ProductName,
                        MaximumListing = product.MaximumListing,
                        Amount = product.Amount,
                        SetupFee = product.SetupFee,
                    };

                    productListDTOs.Add(productListDTO);
                }

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "List of Products",
                    Data = productListDTOs
                };

                return Ok(apiResponse);
            }
        }


        /// <summary>
        /// Get Product By Id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public IActionResult GetProduct(int productId)
        {
            var getProduct = _productRepository.GetProduct(productId, "Frequency", "Currency", "PlanType", "Sector", "ProductCategory");

            if (getProduct == null)
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
                var getSector = _sectorRepository.GetSector(getProduct.Sector.SectorId);

                var getCurrency = _currencyRepository.GetCurrency(getProduct.Currency.CurrencyId);

                var getFrequency = _frequencyRepository.GetFrequency(getProduct.Frequency.FrequencyId);

                var getCategory = _productCategoryRepository.GetProductCategory(getProduct.ProductCategory.ProductCategoryId);

                var getPlanType = _planTypeRepository.GetPlanType(getProduct.PlanType.PlanTypeId);

                var productDetails = new ProductListDTO
                {
                    CurrencyId = getCurrency.CurrencyId,
                    CurrencySymbol = getCurrency.CurrencySymbol,
                    CategoryId = getCategory.ProductCategoryId,
                    CategoryName = getCategory.ProductCategoryName,
                    PlanTypeId = getPlanType.PlanTypeId,
                    PlanTypeName = getPlanType.PlanTypeName,
                    SectorId = getSector.SectorId,
                    Sector = getSector.SectorName,
                    FrequencyId = getFrequency.FrequencyId,
                    Frequency = getFrequency.FrequencyName,
                    ProductName = getProduct.ProductName,
                    MaximumListing = getProduct.MaximumListing,
                    Amount = getProduct.Amount,
                    SetupFee = getProduct.SetupFee
                };

                var apiResponse = new ApiResponse
                {
                    Code = "200",
                    IsSuccessful = true,
                    Message = "Successful Fetch",
                    Data = productDetails
                };

                return Ok(apiResponse);
            }
        }

        /// <summary>
        /// Update Product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productDTO"></param>
        /// <returns></returns>
        [HttpPatch("{productId}")]
        public IActionResult UpdateProduct(int productId, [FromBody] ProductDTO productDTO)
        {
            var getProduct = _productRepository.GetProduct(productId);

            if (getProduct == null)
            {
                var apiResponse = new ApiResponse
                {
                    Code = "404",
                    IsSuccessful = false,
                    Message = "Not Found. Check the ProductID",
                    Data = null
                };
                return NotFound(apiResponse);
            }
            else
            {
                var checkFrequency = _frequencyRepository.GetFrequency(productDTO.FrequencyId);

                var checkCurrency = _currencyRepository.GetCurrency(productDTO.CurrencyId);

                var checkCategory = _productCategoryRepository.GetProductCategory(productDTO.CategoryId);

                var checkPlanType = _planTypeRepository.GetPlanType(productDTO.PlanTypeId);

                var checkSector = _sectorRepository.GetSector(productDTO.SectorId);

                if (checkFrequency == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Frequency Not Found. Check the FrequencyID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                if (checkCurrency == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Currency Not Found. Check the CurrencyID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                if (checkCategory == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Category Not Found. Check the CategoryID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
                if (checkPlanType == null)
                {
                    var apiResponse = new ApiResponse
                    {
                        Code = "404",
                        IsSuccessful = false,
                        Message = "Plan Type Not Found. Check the PlanTypeID",
                        Data = null
                    };

                    return NotFound(apiResponse);
                }
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
                    getProduct.Sector = _sectorRepository.GetSector(productDTO.SectorId);

                    getProduct.ProductCategory = _productCategoryRepository.GetProductCategory(productDTO.CategoryId);

                    getProduct.Currency = _currencyRepository.GetCurrency(productDTO.CurrencyId);

                    getProduct.Frequency = _frequencyRepository.GetFrequency(productDTO.FrequencyId);

                    getProduct.PlanType = _planTypeRepository.GetPlanType(productDTO.PlanTypeId);

                    getProduct.Amount = productDTO.Amount;

                    getProduct.ProductName = productDTO.ProductName;

                    getProduct.MaximumListing = productDTO.MaximumListing;

                    getProduct.SetupFee = productDTO.SetupFee;


                    _productRepository.UpdateProduct(getProduct);

                    var apiResponse = new ApiResponse
                    {
                        Code = "200",
                        IsSuccessful = true,
                        Message = "Update Successful",
                        Data = productDTO
                    };

                    return Ok(apiResponse);
                }

            }

        }


       /// <summary>
       /// Delete Product
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            var getProduct = _productRepository.GetProduct(Id);

            if (getProduct == null)
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
                _productRepository.Delete(Id);

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
