using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EB.ISCS.Common.Models
{
    partial class NameValuePair
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public NameValuePair(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("[");
            builder.Append(Name);
            builder.Append(", ");
            builder.Append(Value);
            builder.Append("]");
            return builder.ToString();
        }
    }

    public class ApiRequestSignature
    {
        private static readonly string[] TimestampFormats =
        {
            "o",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffffK",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffK",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffffK",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'ffK",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fK",
            "yyyy'-'MM'-'dd'T'HH':'mm':'ssK",
        };

        public string AppId { get; set; }
        public string TimestampString { get; private set; }
        public string Hash { get; set; }
        public DateTime Timestamp { get; private set; }

        public ApiRequestSignature()
        {
            Timestamp = DateTime.UtcNow;
            TimestampString = Timestamp.ToString("o", CultureInfo.InvariantCulture);
        }

        public override string ToString()
        {
            return string.Join(";", AppId, TimestampString, Hash);
        }

        //public static bool TryParse(string input, out ApiRequestSignature parsedValue)
        //{
        //    parsedValue = null;
        //    var success = false;

        //    var parts = input?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        //    if (parts?.Length == 3)
        //    {
        //        if (parts[2].Length == 64)
        //        {
        //            if (DateTime.TryParseExact(parts[1], TimestampFormats, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out var timestamp))
        //            {
        //                parsedValue = new ApiRequestSignature
        //                {
        //                    AppId = parts[0],
        //                    TimestampString = parts[1],
        //                    Hash = parts[2],
        //                    Timestamp = timestamp,
        //                };
        //                success = true;
        //            }
        //        }
        //    }

        //    return success;
        //}
    }

}
