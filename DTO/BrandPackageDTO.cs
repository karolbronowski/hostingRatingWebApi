using System;
using System.Collections.Generic;
using System.Linq;
using hostingRatingWebApi.Models;

namespace hostingRatingWebApi.DTO
{
    public class BrandPackageDTO
    {
        public Guid Id { get; set; }
        public BrandDTO Brand {get;set;}
        public string PackageName { get;  set; }
        public string AccountCapacity { get;  set; }
        public string MonthlyTransfer { get;  set; }
        public string EmailAccount { get;  set; }
        public string Domains { get;  set; }
        public string Databases { get;  set; }
        public string FtpAccounts { get;  set; }
        public decimal PriceForYear { get;  set; }
        public decimal PriceForNextYear { get;  set; }
        public int Points => GetPoints();
        public List<Rate> Rates {get;set;}
        public double Rate => GetRate();
        public int RateCount => Rates.Count();
        public double GetRate()
        {
            if(Rates.Count()> 0)
            {
                return Rates.Select(x=>(int)x.Points).Average();
            }
            else
            {
                return 3d;
            }
        }
        public int GetPoints()
        {
            int points = 0;
            int intValue = 0;
            
            //acount cap
            if(int.TryParse(AccountCapacity,out intValue))
            {
                if(intValue> 0 && intValue<5) points += 1;
                else if(intValue>= 5 && intValue<20) points += 2;
                else if(intValue>= 25 && intValue<50) points += 4;
                else if(intValue>= 50 && intValue<100) points += 6;
                else if(intValue>= 100 && intValue<200) points += 8;
                else if(intValue>= 200) points += 9;
            }
            else if(AccountCapacity == "bez limitu")
            {
                points += 10;
            }

            intValue = 0;
            //transfer miesieczny
            if(int.TryParse(MonthlyTransfer,out intValue))
            {
                if(intValue> 0 && intValue<5) points += 1;
                else if(intValue>= 5 && intValue<20) points += 2;
                else if(intValue>= 25 && intValue<50) points += 4;
                else if(intValue>= 50 && intValue<200) points += 6;
                else if(intValue>= 200 && intValue<500) points += 8;
                else if(intValue>= 500) points += 9;
            }
            else if(MonthlyTransfer == "bez limitu")
            {
                points += 10;
            }
            intValue = 0;
            //transfer miesieczny
            if(int.TryParse(EmailAccount,out intValue))
            {
                if(intValue> 0 && intValue<2) points += 1;
                else if(intValue>= 2 && intValue<5) points += 2;
                else if(intValue>= 5 && intValue<20) points += 4;
                else if(intValue>= 20 && intValue<50) points += 6;
                else if(intValue>= 50 && intValue<100) points += 8;
                else if(intValue>= 100) points += 9;
            }
            else if(EmailAccount == "bez limitu")
            {
                points += 10;
            }
            intValue = 0;
            //transfer miesieczny
            if(int.TryParse(Domains,out intValue))
            {
                if(intValue> 0 && intValue<2) points += 1;
                else if(intValue>= 2 && intValue<5) points += 2;
                else if(intValue>= 5 && intValue<20) points += 4;
                else if(intValue>= 20 && intValue<50) points += 6;
                else if(intValue>= 50 && intValue<100) points += 8;
                else if(intValue>= 100) points += 9;
            }
            else if(Domains == "bez limitu")
            {
                points += 10;
            }
            intValue = 0;
            //transfer miesieczny
            if(int.TryParse(Databases,out intValue))
            {
                if(intValue> 0 && intValue<2) points += 1;
                else if(intValue>= 2 && intValue<5) points += 2;
                else if(intValue>= 5 && intValue<20) points += 4;
                else if(intValue>= 20 && intValue<50) points += 6;
                else if(intValue>= 50 && intValue<100) points += 8;
                else if(intValue>= 100) points += 9;
            }
            else if(Databases == "bez limitu")
            {
                points += 10;
            }
            intValue = 0;
            //transfer miesieczny
            if(int.TryParse(FtpAccounts,out intValue))
            {
                if(intValue> 0 && intValue<2) points += 1;
                else if(intValue>= 2 && intValue<5) points += 2;
                else if(intValue>= 5 && intValue<20) points += 4;
                else if(intValue>= 20 && intValue<50) points += 6;
                else if(intValue>= 50 && intValue<100) points += 8;
                else if(intValue>= 100) points += 9;
            }
            else if(FtpAccounts == "bez limitu")
            {
                points += 10;
            }
            if(PriceForYear < 20) points += 10;
            else if(PriceForYear >=20 && PriceForYear <50) points += 7;
            else if(PriceForYear >=50 && PriceForYear <100) points += 5;
            else if(PriceForYear >=100 && PriceForYear <200) points += 3;
            else if(PriceForYear >=200) points += 1;

            if(PriceForNextYear < 100) points += 10;
            else if(PriceForNextYear >=100 && PriceForNextYear <150) points += 7;
            else if(PriceForNextYear >=150 && PriceForNextYear <200) points += 5;
            else if(PriceForNextYear >=200 && PriceForNextYear <300) points += 3;
            else if(PriceForNextYear >=300) points += 1;
            //ocena 5 = 20pkt; 
            if(Rates.Count()>0) points = points + (int)Math.Round(Rates.Select(x=>(int)x.Points).Average() * 4);
            
            return points;
        }
    }
}