using AvalaraLibrary.Avalara;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalaraTax
{
    class Program
    {
        static void Main(string[] args)
        {
            var avalaraLibrary = new AlavaraController();

            Console.WriteLine("What you want to do, \n (1) Validate Address \n (2) Get Tax");
            string value = Console.ReadLine();
            if (value == "1" || value == "2")
            {
                // please enter the address to validate.
                Console.WriteLine("--------------------------------");
                Console.WriteLine("\n Example of complete Address : Line1 : 432 Erickson Ave NE , City: Bainbridge Island, Postal code : 98110-1896, Region or State: WA");
                Console.WriteLine("Enter Line1 : ");
                string line1 = Console.ReadLine().Trim();
                Console.WriteLine();
                string line2 = "";
                string line3 = "";
                Console.WriteLine("Enter City: ");
                string city = Console.ReadLine().Trim();
                Console.WriteLine("Enter Postal Code: ");
                string postalCode = Console.ReadLine().Trim();
                Console.WriteLine("Enter region Or State (Only Symbols Like AZ, CA etc): ");
                string region = Console.ReadLine().Trim();
                switch (value)
                {
                    case "1":
                        //For Address Validator
                      
                        var validate = avalaraLibrary.AddressValidation(line1, line2, line3, city, postalCode, region);
                        if (validate.isValidate)
                        {
                            Console.WriteLine("\n Success, The address You enter is valid");
                        }
                        else
                        {
                            Console.WriteLine("\n Failure,  The address You enter is invalid");
                        }
                        break;
                    case "2":
                        //Get Tax by Address

                        var getTax = avalaraLibrary.GetTaxByAddress(line1, line2, line3, city, postalCode, region);
                        if (getTax.message == "" || getTax.message == null)
                        { 
                            string rateByState = "", ratebyCounty = "", rateByCity = "";
                            foreach (var item in getTax.rates)
                            {
                                if (item.type.ToString() == "State")
                                {
                                    rateByState = item.rate.ToString();
                                }
                                if (item.type.ToString() == "County")
                                {
                                    ratebyCounty = item.rate.ToString();
                                }
                                if (item.type.ToString() == "City")
                                {
                                    rateByCity = item.rate.ToString();
                                }
                            }
                            Console.WriteLine("Success");
                            Console.WriteLine("Total Tax Rate ={0} \n Rate By City = {1} \n Rate By County = {2} \n Rate By City = {3}", getTax.totalRate, rateByCity, ratebyCounty, rateByState);
                        }
                        else
                        {
                            Console.WriteLine("Failure");
                        }
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}
