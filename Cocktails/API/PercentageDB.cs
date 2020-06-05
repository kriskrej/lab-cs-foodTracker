using System;
using System.Collections.Generic;
using System.Text;

namespace Cocktails.API {
    static class PercentageDB {
        static int GetAlcoholAmount(string ingredient) {
            ingredient = ingredient.ToLower();

            if (ingredient == "vodka") return 40;
            return 0;
        }
    }
}
