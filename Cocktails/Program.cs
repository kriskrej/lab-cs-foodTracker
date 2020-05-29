using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        var barman = new Barman();
        barman.HelpUserToComposeCocktail();
    }
}

internal class Barman {
    TheCocktailsDbApi cocktailsDbApi = new TheCocktailsDbApi();

    internal void HelpUserToComposeCocktail() {
        var ingredients = GetIngredientsFromUser();
        cocktailsDbApi.FindWithIngredient(ingredients[0]);
    }

    private List<string> GetIngredientsFromUser() {
        Console.WriteLine("Podaj listę składników rozdzieloną przecinkami.");
        var input = Console.ReadLine();
        var ingredients = input.Split(',');
        return ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList();
    }
}