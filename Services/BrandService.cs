using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using hostingRatingWebApi.DTO;
using hostingRatingWebApi.Models;
using hostingRatingWebApi.Repositories;

namespace hostingRatingWebApi.Services {
    public class BrandService : IBrandService {
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        

        public BrandService (IBrandRepository brandRepository, IMapper mapper) {
            _brandRepository = brandRepository;
            _mapper = mapper;
        }

        public async Task<List<BrandDTO>> BrowseAsync () {

            return _mapper.Map<List<BrandDTO>>(await _brandRepository.BrowseAsync());
        }

        public async Task<BrandDTO> CreateAsync (Brand brand) {
            return _mapper.Map<BrandDTO>(await _brandRepository.CreateAsync(brand));
        }

        public async Task DeleteAsync (Guid id) {
            var brand = await _brandRepository.GetAsync(id);
            await _brandRepository.DeleteAsync(brand);
        }

        public async Task<BrandDTO> GetAsync (Guid id) {
            return _mapper.Map<BrandDTO>(await _brandRepository.GetAsync(id));
        }
    }
}