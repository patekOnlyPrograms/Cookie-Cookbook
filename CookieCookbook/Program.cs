using CookieCookbook.Recipes;
using CookieCookbook.Recipes.IngredientsAvailable;

namespace CookieCookbook;

public class Program
{
    public static void Main(string[] args)
    {
        var cookiesRecipeApp = new cookiesRecipeApp(new RecipesRepository(
                new StringsTextualRepository(), new IngredientsRegister()), 
            new RecipesUserInteraction(new IngredientsRegister()));
        cookiesRecipeApp.Run("recipes.txt");
    }
}

public class cookiesRecipeApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public cookiesRecipeApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }
    
    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();
        if (ingredients.Count() > 0)
        {
            var recipes = new Recipe(ingredients);
            allRecipes.Add(recipes);
            _recipesRepository.Write(filePath,allRecipes);
            _recipesUserInteraction.ShowMessage("Recipe Added: ");
            _recipesUserInteraction.ShowMessage(recipes.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage("No ingredients have been selected. Recipe will not be saved.");
        }

        _recipesUserInteraction.Exit();
    }
}