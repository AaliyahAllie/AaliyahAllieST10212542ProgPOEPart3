using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AaliyahAllieST10212542ProgPOEPart3;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class ResetWindow : Window
    {
        private List<Recipe> _recipes;

        public ResetWindow(List<Recipe> recipes)
        {
            InitializeComponent();
            _recipes = recipes;
            PopulateRecipeNames();
        }

        private void PopulateRecipeNames()
        {
            // Clear existing items
            RecipeComboBox.Items.Clear();

            // Populate the ComboBox with recipe names
            foreach (var recipe in _recipes)
            {
                RecipeComboBox.Items.Add(recipe.RecipeName);
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (RecipeComboBox.SelectedItem is string selectedRecipeName)
            {
                Recipe selectedRecipe = _recipes.Find(recipe => recipe.RecipeName == selectedRecipeName);
                if (selectedRecipe != null)
                {
                    // Reset the selected recipe
                    selectedRecipe.ResetRecipe();
                    MessageBox.Show($"Recipe '{selectedRecipeName}' has been reset.");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select a recipe to reset.");
            }
        }
    }
}
