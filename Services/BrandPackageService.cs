using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using hostingRatingWebApi.DTO;
using hostingRatingWebApi.Models;
using hostingRatingWebApi.Repositories;

namespace hostingRatingWebApi.Services
{
public class BrandPackageService : IBrandPackageService {
        private readonly IBrandPackageRepository _brandPackageRepository;
        private readonly IMapper _mapper;
        

        public BrandPackageService (IBrandPackageRepository brandPackageRepository, IMapper mapper) {
            _brandPackageRepository = brandPackageRepository;
            _mapper = mapper;
        }

        public async Task<List<BrandPackageDTO>> BrowseAsync () {

            return _mapper.Map<List<BrandPackageDTO>>(await _brandPackageRepository.BrowseAsync());
        }

        public async Task<BrandPackageDTO> CreateAsync (BrandPackage brandPackage) {
            return _mapper.Map<BrandPackageDTO>(await _brandPackageRepository.CreateAsync(brandPackage));
        }
        public async Task DeleteAsync (Guid id) {
            var brandPackage = await _brandPackageRepository.GetAsync(id);
            await _brandPackageRepository.DeleteAsync(brandPackage);
        }
        public async Task<BrandPackageDTO> GetAsync (Guid id) {
            return _mapper.Map<BrandPackageDTO>(await _brandPackageRepository.GetAsync(id));
        }

    }
}