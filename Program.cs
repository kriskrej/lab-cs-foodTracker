using System;
using System.Collections.Generic;

namespace lab_FoodTracker {
    class Program {
        List<Ingredient> ingredients;

        static void Main() {
            var thisProgram = new Program();
            thisProgram.AskPlayerForIngridients();
            thisProgram.ShowIngredients();
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
                ingredients.Add(new Ingredient(name));
        }
    }

    public class Ingredient {
        public string name;

        public Ingredient(string name) {
            this.name = name.Trim();
        }
    }
}
