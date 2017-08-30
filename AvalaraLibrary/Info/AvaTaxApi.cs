using AvalaraLibrary.Avalara;
using System;
using System.Collections.Generic;
#if PORTABLE
using System.Net.Http;
using System.Threading.Tasks;
#endif

/*
 * AvaTax Software Development Kit for C#
 *
 * (c) 2004-2017 Avalara, Inc.
 *
 * For the full copyright and license information, please view the LICENSE
 * file that was distributed with this source code.
 *
 * @author     Ted Spence <ted.spence@avalara.com>
 * @author     Zhenya Frolov <zhenya.frolov@avalara.com>
 * @copyright  2004-2017 Avalara, Inc.
 * @license    https://www.apache.org/licenses/LICENSE-2.0
 * @version    17.6.0-89
 * @link       https://github.com/avadev/AvaTax-REST-V2-DotNet-SDK
 */

namespace AvalaraLibrary.Avalara
{
    public partial class AvaTaxClient
    {
        /// <summary>
        /// Returns the version number of the API used to generate this class
        /// </summary>
        public static string API_VERSION { get { return "17.6.0-89"; } }


        /// <summary>
        /// Retrieve geolocation information for a specified address
        /// </summary>
        /// <remarks>
        /// Resolve an address against Avalara's address-validation system. If the address can be resolved, this API 
        /// provides the latitude and longitude of the resolved location. The value 'resolutionQuality' can be used 
        /// to identify how closely this address can be located. If the address cannot be clearly located, use the 
        /// 'messages' structure to learn more about problems with this address.
        /// This is the same API as the POST /api/v2/addresses/resolve endpoint.
        /// Both verbs are supported to provide for flexible implementation.
        /// </remarks>
        /// <param name="line1">Line 1</param>
        /// <param name="line2">Line 2</param>
        /// <param name="line3">Line 3</param>
        /// <param name="city">City</param>
        /// <param name="region">State / Province / Region</param>
        /// <param name="postalCode">Postal Code / Zip Code</param>
        /// <param name="country">Two character ISO 3166 Country Code (see /api/v2/definitions/countries for a full list)</param>
        /// <param name="textCase">selectable text case for address validation</param>
        /// <param name="latitude">Geospatial latitude measurement</param>
        /// <param name="longitude">Geospatial longitude measurement</param>
        public AddressResolutionModel ResolveAddress(String line1, String line2, String line3, String city, String region, String postalCode, String country, TextCase? textCase, Decimal? latitude, Decimal? longitude)
        {
            var path = new AvaTaxPath("/api/v2/addresses/resolve");
            path.AddQuery("line1", line1);
            path.AddQuery("line2", line2);
            path.AddQuery("line3", line3);
            path.AddQuery("city", city);
            path.AddQuery("region", region);
            path.AddQuery("postalCode", postalCode);
            path.AddQuery("country", country);
            path.AddQuery("textCase", textCase);
            path.AddQuery("latitude", latitude);
            path.AddQuery("longitude", longitude);
            return RestCall<AddressResolutionModel>("Get", path, null);
        }


        /// <summary>
        /// Retrieve geolocation information for a specified address
        /// </summary>
        /// <remarks>
        /// Resolve an address against Avalara's address-validation system. If the address can be resolved, this API 
        /// provides the latitude and longitude of the resolved location. The value 'resolutionQuality' can be used 
        /// to identify how closely this address can be located. If the address cannot be clearly located, use the 
        /// 'messages' structure to learn more about problems with this address.
        /// This is the same API as the GET /api/v2/addresses/resolve endpoint.
        /// Both verbs are supported to provide for flexible implementation.
        /// </remarks>
        /// <param name="model">The address to resolve</param>
        public AddressResolutionModel ResolveAddressPost(AddressValidationInfo model)
        {
            var path = new AvaTaxPath("/api/v2/addresses/resolve");
            return RestCall<AddressResolutionModel>("Post", path, model);
        }
        /// <summary>
        /// Create a new transaction
        /// </summary>
        /// <remarks>
        /// Records a new transaction in AvaTax.
        /// 
        /// The `CreateTransaction` endpoint uses the configuration values specified by your company to identify the correct tax rules
        /// and rates to apply to all line items in this transaction, and reports the total tax calculated by AvaTax based on your
        /// company's configuration and the data provided in this API call.
        /// 
        /// If you don't specify type in the provided data, a new transaction with type of SalesOrder will be recorded by default.
        /// 
        /// A transaction represents a unique potentially taxable action that your company has recorded, and transactions include actions like
        /// sales, purchases, inventory transfer, and returns (also called refunds).
        /// You may specify one or more of the following values in the '$include' parameter to fetch additional nested data, using commas to separate multiple values:
        ///  
        /// * Lines
        /// * Details (implies lines)
        /// * Summary (implies details)
        /// * Addresses
        ///  
        /// If you don't specify '$include' parameter, it will include both details and addresses.
        /// </remarks>
        /// <param name="include">A comma separated list of child objects to return underneath the primary object.</param>
        /// <param name="model">The transaction you wish to create</param>
        public TransactionModel CreateTransaction(String include, CreateTransactionModel model)
        {
            var path = new AvaTaxPath("/api/v2/transactions/create");
            path.AddQuery("$include", include);
            return RestCall<TransactionModel>("Post", path, model);
        }

        /// <summary>
        /// FREE API - Sales tax rates for a specified address
        /// </summary>
        /// <remarks>
        /// # Free-To-Use
        /// 
        /// The TaxRates API is a free-to-use, no cost option for estimating sales tax rates.
        /// Any customer can request a free AvaTax account and make use of the TaxRates API.
        /// 
        /// Usage of this API is subject to rate limits. Users who exceed the rate limit will receive HTTP
        /// response code 429 - `Too Many Requests`.
        /// 
        /// This API assumes that you are selling general tangible personal property at a retail point-of-sale
        /// location in the United States only. 
        /// 
        /// For more powerful tax calculation, please consider upgrading to the `CreateTransaction` API,
        /// which supports features including, but not limited to:
        /// 
        /// * Nexus declarations
        /// * Taxability based on product/service type
        /// * Sourcing rules affecting origin/destination states
        /// * Customers who are exempt from certain taxes
        /// * States that have dollar value thresholds for tax amounts
        /// * Refunds for products purchased on a different date
        /// * Detailed jurisdiction names and state assigned codes
        /// * And more!
        /// 
        /// Please see [Estimating Tax with REST v2](http://developer.avalara.com/blog/2016/11/04/estimating-tax-with-rest-v2/)
        /// for information on how to upgrade to the full AvaTax CreateTransaction API.
        /// </remarks>
        /// <param name="line1">The street address of the location.</param>
        /// <param name="line2">The street address of the location.</param>
        /// <param name="line3">The street address of the location.</param>
        /// <param name="city">The city name of the location.</param>
        /// <param name="region">The state or region of the location</param>
        /// <param name="postalCode">The postal code of the location.</param>
        /// <param name="country">The two letter ISO-3166 country code.</param>
        public TaxRateModel TaxRatesByAddress(AddressValidationInfo model)
        {
            var path = new AvaTaxPath("/api/v2/taxrates/byaddress");
            path.AddQuery("line1", model.line1);
            path.AddQuery("line2", model.line2);
            path.AddQuery("line3", model.line3);
            path.AddQuery("city", model.city);
            path.AddQuery("region", model.region);
            path.AddQuery("postalCode", model.postalCode);
            path.AddQuery("country", model.country);
            return RestCall<TaxRateModel>("Get", path, null);
        }

        /// <summary>
        /// FREE API - Sales tax rates for a specified country and postal code
        /// </summary>
        /// <remarks>
        /// # Free-To-Use
        /// 
        /// The TaxRates API is a free-to-use, no cost option for estimating sales tax rates.
        /// Any customer can request a free AvaTax account and make use of the TaxRates API.
        /// 
        /// Usage of this API is subject to rate limits. Users who exceed the rate limit will receive HTTP
        /// response code 429 - `Too Many Requests`.
        /// 
        /// This API assumes that you are selling general tangible personal property at a retail point-of-sale
        /// location in the United States only. 
        /// 
        /// For more powerful tax calculation, please consider upgrading to the `CreateTransaction` API,
        /// which supports features including, but not limited to:
        /// 
        /// * Nexus declarations
        /// * Taxability based on product/service type
        /// * Sourcing rules affecting origin/destination states
        /// * Customers who are exempt from certain taxes
        /// * States that have dollar value thresholds for tax amounts
        /// * Refunds for products purchased on a different date
        /// * Detailed jurisdiction names and state assigned codes
        /// * And more!
        /// 
        /// Please see [Estimating Tax with REST v2](http://developer.avalara.com/blog/2016/11/04/estimating-tax-with-rest-v2/)
        /// for information on how to upgrade to the full AvaTax CreateTransaction API.
        /// </remarks>
        /// <param name="country">The two letter ISO-3166 country code.</param>
        /// <param name="postalCode">The postal code of the location.</param>
        public TaxRateModel TaxRatesByPostalCode(String country, String postalCode)
        {
            var path = new AvaTaxPath("/api/v2/taxrates/bypostalcode");
            path.AddQuery("country", country);
            path.AddQuery("postalCode", postalCode);
            return RestCall<TaxRateModel>("Get", path, null);
        }

    }
}
