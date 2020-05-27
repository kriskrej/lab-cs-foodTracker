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
            currentRecipe.FindRecipe();
        }

        private void FindRecipe() {
            var query = new RecipePuppyQuery(ingredients);
        }

        void ShowIngredients() {
            Console.WriteLine("Składniki:");
            foreach (var ingredient in ingredients)
                Console.WriteLine(" * " + ingredient.englishName);
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


    public class Result {
        public string title;
        public string href;
        public string ingredients;
        public string thumbnail;
    }

    public class Example {
        public string title;
        public double version;
        public string href;
        public IList<Result> results;
    }
}
