using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    public class AlavaraController
    {
        public ValidatedAddressInfo AddressValidation(string line1, string line2, string line3, string city, string postalCode, string region)
        {
            var provider = new AvalaraAddressValidatorProvider();
            var addressValidationInfoModel = new AddressValidationInfo();
            addressValidationInfoModel.textCase = TextCase.Upper;
            addressValidationInfoModel.line1 = line1.Trim();
            addressValidationInfoModel.line2 = line2.Trim();
            addressValidationInfoModel.line3 = line3.Trim();
            addressValidationInfoModel.city = city.Trim();
            addressValidationInfoModel.region = region.Trim();
            addressValidationInfoModel.country = "US";
            addressValidationInfoModel.postalCode = postalCode.Trim();
            var validateAddress = provider.AddressValidation(addressValidationInfoModel);
            return validateAddress;
        }

        public TaxRateModel GetTaxByAddress(string line1, string line2, string line3, string city, string postalCode, string region)
        {
            var provider = new AvalaraTaxProvider();
            var addressValidationInfoModel = new AddressValidationInfo();
            addressValidationInfoModel.textCase = TextCase.Upper;
            addressValidationInfoModel.line1 = line1.Trim();
            addressValidationInfoModel.line2 = line2.Trim();
            addressValidationInfoModel.line3 = line3.Trim();
            addressValidationInfoModel.city = city.Trim();
            addressValidationInfoModel.region = region.Trim();
            addressValidationInfoModel.country = "US";
            addressValidationInfoModel.postalCode = postalCode.Trim();
            var result = provider.GetTaxByAddress(addressValidationInfoModel);
            return result;

        }
    }
}
