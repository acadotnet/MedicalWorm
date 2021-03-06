﻿using System;
using System.Collections.Generic;
using MedicalWorm.Core.Enums;
using MedicalWorm.Core.Interfaces;
using System.Linq;

namespace MedicalWorm.Core.Models
{
    public class Doctor : EmployeeBase, IEmployee
    {
        private const int _payRate = 180;

        public MedicalSpeciality Speciality { get; set; }
        public MedicalLicense LicenseObtained { get; set; }

        public List<Nurse> Nurses { get; set; }

        public Nurse PrimaryNurse => Nurses.Any(n => n.IsRegisteredNurse) 
            ? Nurses.Where(n => n.IsRegisteredNurse).FirstOrDefault() 
            : Nurses.OrderBy(n => n.HoursWorked).FirstOrDefault();

        public Guid PrescriptionAuthorizationId { get; set; }

        public string PrintBadge()
        {
            return $"{Name}, {LicenseObtained.MedicalLicenseFormatted()} ({EmployeeId})";
        }

        public decimal CalculatePay()
        {
            var nameOnCheck = $"{Name}, {LicenseObtained.MedicalLicenseFormatted(true, false)}";

            return HoursWorked * _payRate;
        }

        public override void TakeVacation(int numberOfDays)
        {
            VacationDays = VacationDays - (decimal)numberOfDays / 2;
        }

        public override decimal CalculateRemainingVacationDays()
        {
            if (VacationDays < 8)
            {
                VacationDays = 8;
            }

            return base.CalculateRemainingVacationDays();
        }
    }
}
