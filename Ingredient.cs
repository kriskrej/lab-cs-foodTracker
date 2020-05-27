namespace lab_FoodTracker {
    public class Ingredient {
        public string englishName;

        public Ingredient(string name) {
            this.englishName = name.Trim();
        }


        public override string ToString() {
            return englishName;
        }
    }
}
