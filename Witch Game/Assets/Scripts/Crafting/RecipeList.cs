using System.Collections.Generic;
using System.Linq;

public class RecipeList{
    private static RecipeList Instance;

    private List<Recipe> recipeList;

    private RecipeList()
    {
        FillDictionary();
    }

    public static RecipeList GetInstance()
    {
        Instance ??= new RecipeList();

        return Instance;
    }

    public Recipe GetRecipe(Item[] items)
    {
        foreach (Recipe recipe in recipeList)
        {
            if (recipe.items.SequenceEqual(items)) return recipe;
        }

        return null;
    }

    private void FillDictionary()
    {
        recipeList = new List<Recipe>()
        {
            HealthPotion(),
            SpellPotion(),
            SpeedPotion(),
        };
    }

    private Recipe HealthPotion()
    {
        Item glass = EquippableList.GetInstance().GetItem("Glass Shard");
        Item paint = EquippableList.GetInstance().GetItem("Red Paint");

        return FormRecipe(paint, paint, glass, glass, EquippableList.GetInstance().GetPotion("Health Potion"));
    }

    private Recipe SpellPotion()
    {
        Item glass = EquippableList.GetInstance().GetItem("Glass Shard");
        Item paint = EquippableList.GetInstance().GetItem("Blue Paint");

        return FormRecipe(paint, paint, glass, glass, EquippableList.GetInstance().GetPotion("Spell Potion"));
    }

    private Recipe SpeedPotion()
    {
        Item glass = EquippableList.GetInstance().GetItem("Glass Shard");
        Item redPaint = EquippableList.GetInstance().GetItem("Red Paint");
        Item bluePaint = EquippableList.GetInstance().GetItem("Blue Paint");

        return FormRecipe(redPaint, bluePaint, glass, glass, EquippableList.GetInstance().GetPotion("Speed Potion"));
    }

    private Recipe FormRecipe(Item i1, Item i2, Item i3, Item i4, Potion potion)
    {
        Item[] items = {i1, i2, i3, i4};

        return new Recipe(items, potion);
    }
}