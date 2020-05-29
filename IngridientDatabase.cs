using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_FoodTracker {
    internal class IngridientDatabase {
        List<Ingredient> ingredients = new List<Ingredient>() {
            new Ingredient(new List<string>(){"chicken", "kurczak", "chicen" }),
            new Ingredient(new List<string>(){"garlic", "czosnek", "garlick", "garlik" }),
        };

        public IngridientDatabase() {
        }

        public Ingredient Find(string name) {
            var ingredientFromList = ingredients.FirstOrDefault(i => i.IsNamed(name));
            if (ingredientFromList != null)
                return ingredientFromList;
            return new Ingredient(new List<string>() { name });
        }
    }
}