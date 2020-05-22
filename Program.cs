using System;
using System.Collections.Generic;

namespace lab_FoodTracker {
    class Program {
        List<Ingredient> ingredients;
        IngridientDatabase ingridientDb = new IngridientDatabase();

        static void Main() {
            var currentRecipe = new Program();
            currentRecipe.AskPlayerForIngridients();
            currentRecipe.ShowIngredients();
        }

        void ShowIngredients() {
            Console.WriteLine("Składniki:");
            foreach (var ingredient in ingredients)
                Console.WriteLine(" * " + ingredient.name);
        }

        void AskPlayerForIngridients() {
            ingredients = new List<Ingredient>();
            Console.WriteLine("Wymień po przecinku listę składników");
            var input = Console.ReadLine();
            var ingredientNames = input.Split(',');
            foreach (var name in ingredientNames)
                TryToAddIngredient(name.Trim());
        }

        private void TryToAddIngredient(string name) {
            Ingredient found = ingridientDb.Find(name);
            if (found == null)
                Console.WriteLine("Nie mamy składnika w bazie: " + name);
            else
                ingredients.Add(found);
        }
    }
}
