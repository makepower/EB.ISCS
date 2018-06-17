using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EB.ISCS.FrameworkHelp.Tools
{
    public class AddressResolve
    {
        const string matchRegex = @"(.*?(?:省|区))(.*?市|.*?州)(.*?(?:区|县))(.*)";
        public static Address Resolve(string str)
        {
            var addr = new Address();
            if (string.IsNullOrEmpty(str))
                return addr;
            try
            {
                Match match = Regex.Match(str, matchRegex);
                var gp = match.Groups.Count;
                var street = string.Empty;
                for (int i = 0; i < gp; i++)
                {
                    if (i == 0)
                        addr.Provice = match.Groups[0].Value.Trim();
                    else if (i == 1)
                        addr.City = match.Groups[1].Value.Trim();
                    else if (i == 2)
                        addr.District = match.Groups[2].Value.Trim();
                    else
                        street += match.Groups[3].Value.Trim();
                }
                addr.Street = street;
            }
            catch (Exception ex)
            {
            }
            return addr;
        }
    }

    public class Address
    {
        public string Provice { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }
    }
}
