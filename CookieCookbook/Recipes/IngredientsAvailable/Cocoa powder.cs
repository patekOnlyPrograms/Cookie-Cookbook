namespace CookieCookbook.Recipes.IngredientsAvailable;

public class CocoaPowder : Ingredient
{
    public override int ID => 8;
    public override string Name => "Cocoa Powder";
    public override string PreperationInstructions => $"{base.PreperationInstructions}";
}