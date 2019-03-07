using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using hostingRatingWebApi.Commands;
using hostingRatingWebApi.Database;
using hostingRatingWebApi.DTO;
using hostingRatingWebApi.Handlers.Interfaces;
using hostingRatingWebApi.Models;
using hostingRatingWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hostingRatingWebApi.Controllers {
    [Route ("api")]
    public class ApiController : Controller {
        protected Guid LoggedId => User?.Identity.IsAuthenticated == true ?
            Guid.Parse (User.Identity.Name) :
            Guid.Empty;
        private readonly DatabaseContext _dbContext;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;

        private readonly IBrandService _brandService;

        private readonly IBrandPackageService _brandPackageService;

        public ApiController (IMapper mapper, DatabaseContext dbContext, IJwtHandler jwtHandler, IBrandService brandService, IBrandPackageService brandPackageService) {
            _brandPackageService = brandPackageService;
            _brandService = brandService;
            _jwtHandler = jwtHandler;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        #region User
        [HttpPost ("account/login")]
        public async Task<IActionResult> Login ([FromBody] UserLogin command) 
        {
            var user = _dbContext.Users.FirstOrDefault (x => x.Email == command.Email);
            if (user == null) {
                throw new Exception ("Invalid credentials");
            }
            if (command.Password != user.Password) {
                throw new Exception ("Invalid credentials");
            }
            var jwt = _jwtHandler.CreateToken (user.Id, user.Role.ToString ());
            var token = new TokenDTO {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role.ToString ()
            };
            return Json (await Task.FromResult (token));
        }

        [HttpPost ("account/register")]
        public async Task<IActionResult> Register ([FromBody] UserLogin command) {
            var user = _dbContext.Users.FirstOrDefault (x => x.Email == command.Email);
            if (user != null) {
                throw new Exception ("Email already exist");
            } else {
                await _dbContext.AddAsync (new User (command.Email, command.Password));
                await _dbContext.SaveChangesAsync ();
            }
            var jwt = _jwtHandler.CreateToken (user.Id, user.Role.ToString ());
            var token = new TokenDTO {
                Token = jwt.Token,
                Expires = jwt.Expires,
                Role = user.Role.ToString ()
            };
            return Json (await Task.FromResult (token));
        }

        #endregion
        #region Brands
        [HttpGet ("brands/list")]
        public async Task<IActionResult> GetBrandsAsync ()
        {
            var brands = await _brandService.BrowseAsync();
            return Json (_mapper.Map<List<BrandDTO>> (brands));
        }

        [HttpGet ("brands/packages/list")]
        public async Task<IActionResult> GetBrandsPackagesAsync ()
        {
            var brands = await _brandPackageService.BrowseAsync();
            return Json (_mapper.Map<List<BrandPackageDTO>> (brands.OrderByDescending (x => x.GetPoints ())));
        }

        [Authorize]
        [HttpPost ("brands/create")]
        public async Task<IActionResult> CreateBrandAsync ([FromBody] CreateBrand command) 
        {
            var brand = new Brand (LoggedId, command);
            return Json (await _brandService.CreateAsync(brand));
        }

        [Authorize]
        [HttpDelete ("brands/packages/{id}/delete")]
        public async Task<IActionResult> DeleteBrandPackageAsync (Guid id) 
        {
           
            await _brandPackageService.DeleteAsync(id);
            return Ok ();
        }

        [Authorize]
        [HttpDelete ("brands/{id}/delete")]
        public async Task<IActionResult> DeleteBrandAsync (Guid id) 
        {
            await _brandService.DeleteAsync(id);
            return Ok ();
        }

        [Authorize]
        [HttpPost ("brands/packages/create")]
        public async Task<IActionResult> CreateBrandPackageAsync ([FromBody] CreateBrandPackage command) 
        {
            var brand = new BrandPackage (LoggedId, command);
            return Json (await _brandPackageService.CreateAsync(brand));
        }
        #endregion
    }
}