using System;

namespace hostingRatingWebApi.Commands {
    public class CreateBrandPackage {

        public CreateBrandPackage (Guid brandId, string packageName, string accountCapacity, string monthlyTransfer, string emailAccount, string domains, string databases, string ftpAccounts, decimal priceForYear, decimal priceForNextYear) {
            this.BrandId = brandId;
            this.PackageName = packageName;
            this.AccountCapacity = accountCapacity;
            this.MonthlyTransfer = monthlyTransfer;
            this.EmailAccount = emailAccount;
            this.Domains = domains;
            this.Databases = databases;
            this.FtpAccounts = ftpAccounts;
            this.PriceForYear = priceForYear;
            this.PriceForNextYear = priceForNextYear;

        }
        public Guid BrandId { get; set; }
        public string PackageName { get; set; }
        public string AccountCapacity { get; set; }
        public string MonthlyTransfer { get; set; }
        public string EmailAccount { get; set; }
        public string Domains { get; set; }
        public string Databases { get; set; }
        public string FtpAccounts { get; set; }
        public decimal PriceForYear { get; set; }
        public decimal PriceForNextYear { get; set; }

    }
}