using System;
using System.Collections.Generic;

namespace lab_FoodTracker {
    internal class RecipePuppyQuery {
        private List<Ingredient> ingredients;

        public RecipePuppyQuery(List<Ingredient> ingredients) {
            this.ingredients = ingredients;
            var url = "http://www.recipepuppy.com/api/?i=" + string.Join(',', ingredients);
            Console.WriteLine(url);
        }
    }
}