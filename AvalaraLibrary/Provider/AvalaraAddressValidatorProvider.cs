using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    public class AvalaraAddressValidatorProvider
    {
        public ValidatedAddressInfo AddressValidation(AddressValidationInfo addressValidationInfoModel)
        {
            var validateModel = new ValidatedAddressInfo();
            try
            {
                var app = ConfigurationManager.AppSettings["AvalaraApp"].Split(';');
                var authentication = ConfigurationManager.AppSettings["AvalaraAuth"].Split(';');
                var addresses = new AvaTaxClient(app[0], app[1], Environment.MachineName, AvaTaxEnvironment.Sandbox)
                   .WithSecurity(authentication[0], authentication[1])
                   .ResolveAddressPost(addressValidationInfoModel);
                if (addresses.messages == null)
                {
                    validateModel.isValidate = true;
                    validateModel.line1 = addresses.validatedAddresses[0].line1.ToUpper();
                    validateModel.city = addresses.validatedAddresses[0].city.ToUpper();
                    validateModel.region = addresses.validatedAddresses[0].region.ToUpper();
                    validateModel.postalCode = addresses.validatedAddresses[0].postalCode.ToUpper();
                    validateModel.country = addresses.validatedAddresses[0].country.ToUpper();
                    return validateModel;
                }
                else
                {
                    validateModel.isValidate = false;
                    return validateModel;
                }
            }
            catch (Exception ex)
            {
                validateModel.isValidate = false;
              
                return validateModel;
            }
        }
    }
}
