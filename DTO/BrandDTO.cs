using System;
using System.Collections.Generic;
using System.Linq;
using hostingRatingWebApi.Models;

namespace hostingRatingWebApi.DTO
{
    public class BrandDTO
    {
        public Guid Id { get; set; }
        public string ImageUrl { get;  set; }
        public string Name { get;  set; }
        public List<BrandPackageDTO> BrandPackages{get;set;}
    }
}