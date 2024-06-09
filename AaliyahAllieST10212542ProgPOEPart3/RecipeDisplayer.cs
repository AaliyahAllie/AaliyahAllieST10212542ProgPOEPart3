using AaliyahAllieST10212542ProgPOEPart3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace  AaliyahAllieST10212542ProgPOEPart3
{
    public static class RecipeDisplayer
    {
        public static void DisplayRecipes(List<Recipe> recipes, TextBox recipeOutputTextBox)
        {
            // Sort recipes alphabetically by recipe name
            recipes.Sort((x, y) => string.Compare(x.RecipeName, y.RecipeName));

            StringBuilder recipeList = new StringBuilder();
            foreach (Recipe recipe in recipes)
            {
                recipeList.AppendLine($"Recipe Name: {recipe.RecipeName}");

                foreach (var ingredient in recipe.Ingredients)
                {
                    recipeList.AppendLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement} (Food Group: {ingredient.FoodGroup}, Calories: {ingredient.Calories})");
                }

                recipeList.AppendLine("Steps:");
                int stepNumber = 1;
                foreach (var step in recipe.Steps)
                {
                    recipeList.AppendLine($"Step {stepNumber}: {step}");
                    stepNumber++;
                }

                double totalCalories = recipe.CalculateTotalCalories();
                recipeList.Append($"Total Calories: {totalCalories} ");

                if (totalCalories >= 0 && totalCalories <= 300)
                {
                    recipeList.AppendLine($"(Total calories of {recipe.RecipeName} are between 0 and 300. This is still in a healthy calorie range.)");
                }
                else
                {
                    recipeList.AppendLine($"(ALERT!!! Calories above 300 may be unhealthy.)");
                    // Here you can invoke any necessary notifications for unhealthy recipes
                }

                recipeList.AppendLine("***********************************************");
            }

            // Assign the text to the TextBox
            recipeOutputTextBox.Text = recipeList.ToString();
        }

    }
}
