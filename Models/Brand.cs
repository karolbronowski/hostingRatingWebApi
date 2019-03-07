using System;
using System.Collections.Generic;
using System.Linq;
using hostingRatingWebApi.Commands;

namespace hostingRatingWebApi.Models
{
    public class Brand:Entity
    {
        public string ImageUrl { get; protected set; }
        public string Name { get; protected set; }

        
        public Guid CreatorId {get;protected set;}
        public User Creator {get;protected set;}
        public List<BrandPackage> BrandPackages {get;set;}
        public Brand(Guid creatorId, string name, string imageUrl)
        {
            CreatorId = creatorId;
            Name = name;
            ImageUrl = imageUrl;
        }
        public Brand(Guid creatorId, CreateBrand command)
        {
            CreatorId = creatorId;
            ImageUrl  = command.ImageUrl;
            Name  = command.Name;
        }
        public Brand()
        {

        }
    }
}