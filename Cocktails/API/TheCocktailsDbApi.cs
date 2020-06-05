using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

internal partial class TheCocktailsDbApi {
    internal void FindWithIngredients(List<string> ingredients) {
        CocktailsList cocktails = DownloadNamesOfCocktailsWith(ingredients[0]);
        List<Recipe> recipes = DownloadRecipesOf(cocktails);
        var coctailsSortedByMatchingIngredients = GetCoctailsSortedByMatchingIngredients(recipes, ingredients);
        Console.WriteLine("Pasujące drinki:");
        foreach (var cocktail in coctailsSortedByMatchingIngredients)
            Console.WriteLine(" * " + cocktail.GetNameAndIngredietnsString());
        

    }

    private List<Recipe> GetCoctailsSortedByMatchingIngredients(List<Recipe> recipes, List<string> ingredients) {
        return recipes.OrderByDescending(r => r.CountMatchingIngredients(ingredients)).ToList();
    }

    private List<Recipe> DownloadRecipesOf(CocktailsList cocktails) {
        var recipes = new List<Recipe>();
        foreach (var drinkInfo in cocktails.drinks) {
            var drink = DownloadRecipe(drinkInfo.idDrink);
            recipes.Add(drink);
        }
        return recipes;
    }



    private static CocktailsList DownloadNamesOfCocktailsWith(string ingredient) {
        var url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=" + ingredient;
        var broser = new WebClient();
        var json = broser.DownloadString(url);
        var cocktails = Newtonsoft.Json.JsonConvert.DeserializeObject<CocktailsList>(json);
        return cocktails;
    }

    Recipe DownloadRecipe(string idDrink) {
        var browser = new WebClient();
        var json = browser.DownloadString("https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + idDrink);
        json = json.Replace("-", "_");
        var recipes = Newtonsoft.Json.JsonConvert.DeserializeObject<RecipeList>(json);
        var recipe = recipes.drinks[0];
        return recipe;
    }
}
