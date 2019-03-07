using System;

namespace hostingRatingWebApi.Commands
{
    public class CreateBrandPackage
    {
        public Guid BrandId { get; set; }
        public string PackageName { get;  set; }
        public string AccountCapacity { get;  set; }
        public string MonthlyTransfer { get;  set; }
        public string EmailAccount { get;  set; }
        public string Domains { get;  set; }
        public string Databases { get;  set; }
        public string FtpAccounts { get;  set; }
        public decimal PriceForYear { get;  set; }
        public decimal PriceForNextYear { get;  set; }
    }
}