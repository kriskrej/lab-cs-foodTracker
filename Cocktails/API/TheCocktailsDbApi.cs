using System;
using System.Net;

internal partial class TheCocktailsDbApi {
    internal void FindWithIngredient(string ingredient) {
        var url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=" + ingredient;
        var broser = new WebClient();
        var json = broser.DownloadString(url);
        var cocktails = Newtonsoft.Json.JsonConvert.DeserializeObject<CocktailsList>(json);

        Console.WriteLine("Pasujące drinki:");

        foreach (var drinkInfo in cocktails.drinks) {
            var drink = DownloadRecipe(drinkInfo.idDrink);
            Console.WriteLine(" * " + drink.GetNameAndIngredietnsString());
        }

    }

    Drink DownloadRecipe(string idDrink) {
        var browser = new WebClient();
        var json = browser.DownloadString("https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + idDrink);
        json = json.Replace("-", "_");
        var recipes = Newtonsoft.Json.JsonConvert.DeserializeObject<RecipeList>(json);
        var recipe = recipes.drinks[0];
        return recipe;
    }
}
