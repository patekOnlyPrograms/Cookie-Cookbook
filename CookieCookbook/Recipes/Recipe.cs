namespace CookieCookbook.Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> Ingredients)
    {
        this.Ingredients = Ingredients;
    }

    public override string ToString()
    {
        var steps = new List<string>();
        foreach (var ingredient in Ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.PreperationInstructions} ");
        }

        return string.Join(Environment.NewLine, steps);
    }
}

