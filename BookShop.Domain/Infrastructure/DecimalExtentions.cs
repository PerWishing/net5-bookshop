using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Domain.Infrastructure
{
    public static class DecimalExtentions
    {
        public static string GetValueString(this decimal value) =>
            $"₽{value.ToString("0.#####")}";
    }
}
