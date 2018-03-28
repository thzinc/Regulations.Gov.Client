using System;
using Newtonsoft.Json;
using DestructureExtensions;

namespace Regulations.Gov.Client
{
    public class WeirdDateTimeOffsetConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType) => false;

        public override bool CanWrite => false;

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            else if (reader.TokenType == JsonToken.String)
            {
                var str = reader.ReadAsString();
                if (DateTimeOffset.TryParse(str, out var dto))
                {
                    return dto;
                }
                else
                {
                    var (date, time, _) = str.Split(new[] { 'T' }, 2);
                    var (timeOfDay, zone, _) = time.Split(new[] { '-' }, 2);
                    var (hour, minute, _) = zone.Split(new[] { ':' });
                    str = $"{date}T${timeOfDay}-{hour}:{minute}";
                    if (DateTimeOffset.TryParse(str, out dto))
                    {
                        return dto;
                    }
                }

                return null;
            }

            return serializer.Deserialize(reader, objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}