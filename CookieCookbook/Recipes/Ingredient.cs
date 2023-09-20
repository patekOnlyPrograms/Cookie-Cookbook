namespace CookieCookbook.Recipes;

public abstract class Ingredient
{
    public abstract int ID { get; }
    public abstract string Name { get; }
    public virtual string PreperationInstructions => "Add to other ingredients";
    public override string ToString() => $"{ID}. {Name}";
}