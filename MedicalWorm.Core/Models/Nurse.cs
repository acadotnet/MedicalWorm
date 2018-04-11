using System.Collections.Generic;
using MedicalWorm.Core.Enums;
using MedicalWorm.Core.Interfaces;
using System.Linq;

namespace MedicalWorm.Core.Models
{
    public class Nurse : EmployeeBase, IEmployee
    {
        private const decimal PAY_RATE = 150;

        public bool IsRegisteredNurse { get; set; }
        public List<NursingCertification> Certifications { get; set; }
        public IEnumerable<int> FloorsWorked { get; set; }

        public string PrintBadge()
        {
            var certsFormatted = string.Join(", ", Certifications.Select(c => c.NursingCertificationFormatted(IsRegisteredNurse)).ToList());
            var floorsFormatted = string.Join(", ", FloorsWorked);

            return $"{Name}, {certsFormatted} ({floorsFormatted}) ({EmployeeId})";
        }

        public decimal CalculatePay()
        {
            if (HoursWorked > 40)
            {
                var extraTime = HoursWorked - 40;
                var extraRate = PAY_RATE * 1.5M;

                return 40 * PAY_RATE + extraTime * extraRate;
            }

            return HoursWorked * PAY_RATE;
        }

        public override void TakeVacation(int numberOfDays)
        {
            HoursWorked = HoursWorked - (decimal)numberOfDays / 2;
        }
    }
}
