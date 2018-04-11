using System;
using System.Linq;

namespace MedicalWorm.Core.Enums
{
    public static class EnumExtensions
    {
        public static string MedicalLicenseFormatted2(this MedicalLicense license, bool isUpperCase = true, bool usePeriods = true)
        {       
            var abbrev = string.Empty;
            switch (license)
            {
                case MedicalLicense.DoctorofMedicine:
                    abbrev = usePeriods 
                        ? "M.D." 
                        : "MD";
                    break;

                case MedicalLicense.DoctorofOsteopathicMedicine:
                    abbrev = usePeriods
                        ? "D.O."
                        : "DO";
                    break;
            }

            return isUpperCase
                ? abbrev.ToUpper()
                : abbrev.ToLower();
        }

        public static string NursingCertificationFormatted(this NursingCertification certification, bool isRegistered)
        {
            return isRegistered
                ? $"RN-{certification}"
                : certification.ToString();
        }
    }
}
