using System.Text.Json.Serialization;
using Domain.SeedWork;

namespace Domain.Model
{
    public class Classification : ValueObject
    {
        public string Item { get; }
        public string Asset { get; }

        [JsonConstructor]
        public Classification(string item, string asset)
        {
            Item = item;
            Asset = asset;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Item;
            yield return Asset;
        }
    }
}