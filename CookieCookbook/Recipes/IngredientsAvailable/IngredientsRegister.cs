namespace CookieCookbook.Recipes.IngredientsAvailable;

public class IngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };

    public Ingredient GetByID(int result)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.ID == result)
            {
                return ingredient;
            }
        }

        return null;
    }
}