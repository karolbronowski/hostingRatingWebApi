using System;

namespace hostingRatingWebApi.Models
{
    public class Rate: Entity
    {
        public RatingScale Points {get;protected set;}
        public Guid BrandPackageId {get;protected set;}
        public BrandPackage BrandPackage {get;set;}
        public Guid UserId {get;protected set;}
        public User User {get;set;}
        public Rate(Guid brandPackageId, Guid userId, RatingScale points)
        {
            BrandPackageId = brandPackageId;
            UserId = userId;
            Points = points;
        }

        public Rate()
        {

        }
        public enum RatingScale
        {
            VeryBad = 1,
            Bad = 2,
            Normal = 3,
            Good = 4,
            Excellent = 5

        }
    }
}