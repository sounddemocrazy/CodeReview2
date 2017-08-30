using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraLibrary.Avalara
{
    public class AvalaraTaxProvider
    {
        public TaxRateModel GetTaxByAddress(AddressValidationInfo addressValidationInfoModel)
        {


            var app = ConfigurationManager.AppSettings["AvalaraApp"].Split(';');
            var authentication = ConfigurationManager.AppSettings["AvalaraAuth"].Split(';');
            var avaTaxEnvironment = Convert.ToInt32(ConfigurationManager.AppSettings["AvaTaxEnvironment"]);
            var environment = AvaTaxEnvironment.Production;
            if (avaTaxEnvironment == 0)
            {
                environment = AvaTaxEnvironment.Sandbox;
            }
            try
            {
                var validateAddress = new AvalaraAddressValidatorProvider().AddressValidation(addressValidationInfoModel);
                if (validateAddress.isValidate)
                {
                    var taxRate = new AvaTaxClient(app[0], app[1], Environment.MachineName, environment)
                                  .WithSecurity(authentication[0], authentication[1])
                                  .TaxRatesByAddress(addressValidationInfoModel);
                    return taxRate;
                }
                else
                {
                    var errorMessage = new TaxRateModel();
                    errorMessage.message = "Please Enter Valid Address";
                    return errorMessage;
                }


            }
            catch (Exception ex)
            {

                var errorMessage = new TaxRateModel();
                errorMessage.message = "Please Enter Valid Address" + ex;
                return errorMessage;
            }



        }
    }
}
