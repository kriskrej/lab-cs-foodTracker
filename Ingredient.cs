using System.Collections.Generic;

namespace lab_FoodTracker {
    public class Ingredient {
        List<string> names;

        public Ingredient(List<string> names) {
            this.names = names;
        }

        public override string ToString() {
            return names[0];
        }

        public bool IsNamed(string name) {
            foreach (var n in names)
                if (string.Equals(n, name, System.StringComparison.InvariantCultureIgnoreCase))
                    return true;

            return false;
        }
    }
}
