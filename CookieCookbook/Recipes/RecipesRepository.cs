using CookieCookbook.Recipes.IngredientsAvailable;

namespace CookieCookbook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IngredientsRegister _ingredientsRegister;

    public RecipesRepository(IStringsRepository _stringsRepository, IngredientsRegister _ingredientsRegister)
    {
        this._stringsRepository = _stringsRepository;
        this._ingredientsRegister = _ingredientsRegister;
    }
    public List<Recipe> Read(string filePath)
    {
        var recipesFromFile = _stringsRepository.Read(filePath);
        var recipes = new List<Recipe>();
        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = recipeFromString(recipeFromFile);
            recipes.Add(recipe);
            
        }

        return recipes;
    }

    public Recipe recipeFromString(string recipeFromFile)
    {
        var textualIds = recipeFromFile.Split(",");
        var ingredients = new List<Ingredient>();

        foreach (var textualId in textualIds)
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientsRegister.GetByID(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.ID);
            }
            recipesAsStrings.Add(string.Join(",",allIds));
        }
        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}

public class StringsTextualRepository : IStringsRepository
{
    private static readonly string seperator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return fileContents.Split(seperator).ToList();
        }
        else
        {
            return new List<string>();
        }
        
    }

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath,string.Join(seperator,strings));
    }
}