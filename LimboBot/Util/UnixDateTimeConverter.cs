using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace LimboBot.Util
{
    /// <summary>
    /// Used for converting timestamps to/from JSON via Json.net
    /// 
    /// Taken from:
    /// https://cgeers.wordpress.com/2011/09/25/writing-a-custom-json-net-datetime-converter/#unix
    /// </summary>
    public class UnixDateTimeConverter : DateTimeConverterBase
    {
        /// <summary>
        /// Used for reading the integer timestamp in
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="objectType"></param>
        /// <param name="existingValue"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType != JsonToken.Integer)
            {
                throw new Exception(String.Format("Error parsing datetime/timestamp; expected Integer, got {0}.", reader.TokenType));
            }

            var ticks = (long)reader.Value;

            var date = new DateTime(1970, 1, 1);
            date = date.AddSeconds(ticks);

            return date;
        }

        /// <summary>
        /// Converts Datetime into Unix timestamp
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="serializer"></param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            long ticks = 0;

            if (value is DateTime)
            {
                var epoc = new DateTime(1970, 1, 1);
                var secondsSinceEpoc = ((DateTime)value) - epoc;

                ticks = (long)secondsSinceEpoc.TotalSeconds;
            }
            else
            {
                throw new Exception("Expected DateTime object value.");
            }

            writer.WriteValue(ticks);
        }
    }
}
