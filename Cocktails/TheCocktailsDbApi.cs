using System;
using System.Collections.Generic;
using System.Net;

internal class TheCocktailsDbApi {
    internal void FindWithIngredient(string ingredient) {
        var url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?i=" + ingredient;
        var broser = new WebClient();
        var json = broser.DownloadString(url);
        var cocktails = Newtonsoft.Json.JsonConvert.DeserializeObject<CocktailsList>(json);

        foreach (var drink in cocktails.drinks)
            Console.WriteLine(drink.strDrink);
    }

    public class Drink {
        public string strDrink;
        public string strDrinkThumb;
        public string idDrink;
    }

    public class CocktailsList {
        public List<Drink> drinks;
    }

}