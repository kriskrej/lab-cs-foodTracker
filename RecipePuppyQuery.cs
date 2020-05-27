using System;
using System.Collections.Generic;
using System.Net;

namespace lab_FoodTracker {
    public class RecipePuppyQuery {
        private List<Ingredient> ingredients;

        public RecipePuppyQuery(List<Ingredient> ingredients) {
            this.ingredients = ingredients;
            var url = "http://www.recipepuppy.com/api/?i=" + string.Join(',', ingredients);
            var client = new WebClient();
            var json = client.DownloadString(url);
            var queryResult = Newtonsoft.Json.JsonConvert.DeserializeObject<QueryResult>(json);
            ShowResults(queryResult.results);
        }

        void ShowResults(IList<Result> results) {
            foreach (var recipe in results)
                ShowResult(recipe);
        }

        void ShowResult(Result recipe) {
            Console.WriteLine(recipe.title);
            Console.WriteLine("> " + recipe.ingredients);
            Console.WriteLine("> " + recipe.href);
        }
    }

    public class Result {
        public string title;
        public string href;
        public string ingredients;
        public string thumbnail;
    }

    public class QueryResult {
        public string title;
        public double version;
        public string href;
        public IList<Result> results;
    }
}