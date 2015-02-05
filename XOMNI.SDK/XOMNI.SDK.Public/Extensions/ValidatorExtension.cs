﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOMNI.SDK.Public.Extensions
{
    public static class ValidatorExtension
    {
        public static Parameter<T> NotNull<T>(this Parameter<T> item) where T : class
        {
            if (item.Value == null)
            {
                throw new ArgumentNullException(string.Format("{0} can not be null.", item.ArgName));
            }
            return item;
        }
        public static Parameter<string> IsEmpty(this Parameter<string> item)
        {
            if (item.Value.Length == 0)
            {
                throw new ArgumentException(string.Format("{0} can not be empty.", item.ArgName));
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

    }
}