using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XOMNI.SDK.Public.Models;
using XOMNI.SDK.Public.Models.Catalog;

namespace XOMNI.SDK.Public.Extensions
{
    public static class ValidatorExtension
    {
        public static Parameter<T> IsNotNull<T>(this Parameter<T> item) where T : class
        {
            if (item.Value == null)
            {
                throw new ArgumentNullException(string.Format("{0} can not be null.", item.ArgName));
            }
            return item;
        }

        public static Parameter<Nullable<double>> IsNotNull(this Parameter<Nullable<double>> item)
        {
            if(!item.Value.HasValue)
            {
                throw new ArgumentException(string.Format("{0} can not be null.", item.ArgName));
            }
            return item;
        }

        public static Parameter<string> IsNotNullOrEmpty(this Parameter<string> item)
        {
            if (string.IsNullOrEmpty(item.Value))
            {
                throw new ArgumentException(string.Format("{0} can not be empty or null.", item.ArgName));
            }
            return item;
        }
        public static Parameter<string> Contains(this Parameter<string> item, char character)
        {
            IsNotNullOrEmpty(item);

            if (!item.Value.Contains(character))
            {
                throw new ArgumentException(string.Format("{0} must be include ';' character.", item.ArgName));
            }
            return item;
        }

        public static Parameter<int> InRange(this Parameter<int> item, int minBound, int maxBound)
        {
            if (item.Value < minBound || maxBound < item.Value)
            {
                throw new ArgumentOutOfRangeException(item.ArgName, item.Value, string.Format("{0} must be in range ({1} - {2}).", item.ArgName, minBound, maxBound));
            }
            return item;
        }

        public static Parameter<double> InRange(this Parameter<double> item, double minBound, double maxBound)
        {
            if (item.Value < minBound || maxBound < item.Value)
            {
                throw new ArgumentOutOfRangeException(item.ArgName, item.Value, string.Format("{0} must be in range ({1} - {2}).", item.ArgName, minBound, maxBound));
            }
            return item;
        }

        public static Parameter<int> IsGreaterThanOrEqual(this Parameter<int> item, int bound)
        {
            if (item.Value < bound)
            {
                throw new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", item.ArgName, bound));
            }
            return item;
        }

        public static Parameter<int?> IsGreaterThanOrEqual(this Parameter<int?> item, int bound)
        {
            if (item.Value < bound)
            {
                throw new ArgumentException(string.Format("{0} must be greater than or equal to {1}.", item.ArgName, bound));
            }
            return item;
        }

        public static Parameter<int?> IsNotNull(this Parameter<int?> item)
        {
            if (!item.Value.HasValue)
            {
                throw new ArgumentNullException(string.Format("{0} can not be null.", item.ArgName));
            }
            return item;
        }

        public static Parameter<double?> IsLessThanOrEqual(this Parameter<double?> item, Parameter<double?> maxItem)
        {
            if (item.Value.HasValue && maxItem.Value.HasValue && item.Value > maxItem.Value)
            {
                throw new ArgumentException(string.Format("{0} can not be greater than {1}.", item.ArgName, maxItem.ArgName));
            }
            return item;
        }

        public static Parameter<string> KeyValuePairValid(this Parameter<string> item, char firstSeparatorCharacter, char secondSeparatorCharacter)
        {
            var keyValuePairs = item.Value.Split(firstSeparatorCharacter).Select(x => x.Split(secondSeparatorCharacter)).ToList();

            foreach (var pair in keyValuePairs)
            {
                if (pair.Count() != 2)
                {
                    throw new ArgumentException("Given string format is not correct.");
                }

                string key = pair[0];
                string value = pair[1];

                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                {
                    continue;
                }
                else
                {
                    throw new ArgumentException("Given string format is not correct.");
                }
            }

            return item;
        }

        public static Parameter<ItemSearchOptionsRequest> IsValid(this Parameter<ItemSearchOptionsRequest> item)
        {
            ValidateItemSearchRequest(item.Value);
            ValidateSearchRequest(item.Value);

            return item;
        }

        public static Parameter<ItemSearchRequest> IsValid(this Parameter<ItemSearchRequest> item)
        {
            ValidateItemSearchRequest(item.Value);
            ValidateSearchRequest(item.Value);

            return item;
        }

        public static Parameter<SearchRequest> InRange(this Parameter<SearchRequest> item)
        {
            ValidateSearchRequest(item.Value);
            return item;
        }

        private static void ValidateItemSearchRequest(ItemSearchRequest itemSearchRequest)
        {
            Validator.For(itemSearchRequest.Skip, "Skip").IsGreaterThanOrEqual(0);
            Validator.For(itemSearchRequest.Take, "Take").InRange(1,1000);
        }

        private static void ValidateSearchRequest(SearchRequest searchRequest)
        {
            List<MinMaxParameterPair> minAndMaxPairs = new List<MinMaxParameterPair>()
            {
                new MinMaxParameterPair()
                {
                    MaxParameter = new Parameter<double?>(searchRequest.MaxDepth,"MaxDepth"),
                    MinParameter = new Parameter<double?>(searchRequest.MinDepth,"MinDepth")
                },
                new MinMaxParameterPair()
                {
                    MaxParameter = new Parameter<double?>(searchRequest.MaxHeight,"MaxHeight"),
                    MinParameter = new Parameter<double?>(searchRequest.MinHeight,"MinHeight")
                },
                new MinMaxParameterPair()
                {
                    MaxParameter = new Parameter<double?>(searchRequest.MaxPrice,"MaxPrice"),
                    MinParameter =  new Parameter<double?>(searchRequest.MinPrice,"MinPrice")
                },
                new MinMaxParameterPair()
                {
                    MaxParameter = new Parameter<double?>(searchRequest.MaxWeight,"MaxWeight"),
                    MinParameter = new Parameter<double?>(searchRequest.MinWeight,"MinWeight")
                },
                new MinMaxParameterPair()
                {
                    MaxParameter = new Parameter<double?>(searchRequest.MaxWidth,"MaxWidth"),
                    MinParameter = new Parameter<double?>(searchRequest.MinWidth,"MinWidth")
                }
            };
            foreach (var values in minAndMaxPairs)
            {
                IsLessThanOrEqual(values.MinParameter, values.MaxParameter);
            }

            if (!string.IsNullOrEmpty(searchRequest.DelimitedDynamicAttributeValues))
            {
                Validator.For(searchRequest.DelimitedDynamicAttributeValues, "DelimitedDynamicAttributeValues").KeyValuePairValid(';', ':');
            }

            if (searchRequest.MinWeight.HasValue && searchRequest.MaxWeight.HasValue)
            {
                Validator.For(searchRequest.WeightTypeId, "WeightTypeId").IsNotNull();
            }

            if (searchRequest.MinWidth.HasValue && searchRequest.MinHeight.HasValue && searchRequest.MinDepth.HasValue)
            {
                Validator.For(searchRequest.DimensionTypeId, "DimensionTypeId").IsNotNull();
            }
        }
    }
}
