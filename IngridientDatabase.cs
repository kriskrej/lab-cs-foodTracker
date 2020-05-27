using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_FoodTracker {
    internal class IngridientDatabase {
        List<Ingredient> ingredients = new List<Ingredient>() {
            new Ingredient("kurczak")
        };

        public IngridientDatabase() {
        }

        public Ingredient Find(string name) {
            return ingredients.FirstOrDefault(i => i.name == name);
        }
    }
}