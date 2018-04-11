using System;
using System.Configuration;
using MedicalWorm.Core.Interfaces;

namespace MedicalWorm.Core.Models
{
    public class Janitor : IEmployee
    {
        private static decimal _minWage = Convert.ToDecimal(ConfigurationManager.AppSettings["MinWage"]);

        public string ExternalAgencyId { get; set; }

        public string ExternalAgencyName { get; set; }

        public string Name { get; set; }

        public decimal HoursWorked { get; set; }

        public string PrintBadge()
        {
            return $"{Name} ({ExternalAgencyName})";
        }

        public decimal CalculatePay()
        {
            return HoursWorked * _minWage;
        }
    }
}
