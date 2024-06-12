// ViewRecipeWindow.xaml.cs
using System.Windows;
using static AaliyahAllieST10212542ProgPOEPart3.Recipe;

namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class ViewRecipeWindow : Window
    {
        public ViewRecipeWindow()
        {
            InitializeComponent();
            PopulateRecipeComboBox();
        }

        private void PopulateRecipeComboBox()
        {
            foreach (Recipe recipe in MainWindow.Recipes)
            {
                RecipeComboBox.Items.Add(recipe.RecipeName);
            }
        }

        private void RecipeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedRecipeName = RecipeComboBox.SelectedItem as string;
            if (selectedRecipeName != null)
            {
                DisplayRecipeDetails(selectedRecipeName);
            }
        }

        private void DisplayRecipeDetails(string recipeName)
        {
            Recipe selectedRecipe = MainWindow.Recipes.Find(r => r.RecipeName == recipeName);
            if (selectedRecipe != null)
            {
                IngredientsListBox.Items.Clear();
                StepsListBox.Items.Clear();

                foreach (Ingredient ingredient in selectedRecipe.Ingredients)
                {
                    IngredientsListBox.Items.Add($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement} (Food Group: {ingredient.FoodGroup}, Calories: {ingredient.Calories})");
                }

                var stepsObservableCollection = new System.Collections.ObjectModel.ObservableCollection<string>(selectedRecipe.Steps);
                StepsListBox.ItemsSource = stepsObservableCollection;
            }
        }

        private void CompletedButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeComboBox.SelectedItem as string;
            MessageBox.Show($"{recipeName} completed.");
        }
    }
}
