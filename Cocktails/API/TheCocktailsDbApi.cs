using System;
using System.Collections.Generic;
using System.Linq;
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


public class Drink {
    public string idDrink;
    public string strDrink;
    public object strDrinkAlternate;
    public object strTags;
    public object strVideo;
    public string strCategory;
    public object strIBA;
    public string strAlcoholic;
    public string strGlass;
    public string strInstructions;
    public object strInstructionsES;
    public string strInstructionsDE;
    public object strInstructionsFR;
    public string strDrinkThumb;
    public string strIngredient1;
    public string strIngredient2;
    public string strIngredient3;
    public string strIngredient4;
    public string strIngredient5;
    public string strIngredient6;
    public string strIngredient7;
    public string strIngredient8;
    public string strIngredient9;
    public string strIngredient10;
    public string strIngredient11;
    public string strIngredient12;
    public string strIngredient13;
    public string strIngredient14;
    public string strIngredient15;
    public string strMeasure1;
    public string strMeasure2;
    public string strMeasure3;
    public string strMeasure4;
    public object strMeasure5;
    public object strMeasure6;
    public object strMeasure7;
    public object strMeasure8;
    public object strMeasure9;
    public object strMeasure10;
    public object strMeasure11;
    public object strMeasure12;
    public object strMeasure13;
    public object strMeasure14;
    public object strMeasure15;
    public string strCreativeCommonsConfirmed;
    public string dateModified;

    public string GetNameAndIngredietnsString() {
        string text = strDrink;

        var ingredients = new List<string> { strIngredient1, strIngredient2, strIngredient3, strIngredient4, strIngredient5,
                                                strIngredient6, strIngredient7, strIngredient8, strIngredient9, strIngredient10,
                                                strIngredient11, strIngredient12, strIngredient13, strIngredient14, strIngredient15};
        ingredients = ingredients.Where(i => !string.IsNullOrEmpty(i)).ToList();
        text += " (" + string.Join(", ", ingredients) + ")";


        return text;
    }
}

public class RecipeList {
    public IList<Drink> drinks;
}
