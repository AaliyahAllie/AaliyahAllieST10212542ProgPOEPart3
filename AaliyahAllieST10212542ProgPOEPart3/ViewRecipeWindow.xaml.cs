// ViewRecipeWindow.xaml.cs

using System.Windows;
using static AaliyahAllieST10212542ProgPOEPart3.Recipe; // Import Recipe class statically

//this code will let user check off there steps as they do the recipe
namespace AaliyahAllieST10212542ProgPOEPart3
{
    public partial class ViewRecipeWindow : Window
    {
        public ViewRecipeWindow()
        {
            InitializeComponent();
            PopulateRecipeComboBox(); // Initialize the window and populate the recipe combobox
        }

        // Method to populate the recipe combobox with recipe names
        private void PopulateRecipeComboBox()
        {
            foreach (Recipe recipe in MainWindow.Recipes) // Iterate through recipes in MainWindow
            {
                RecipeComboBox.Items.Add(recipe.RecipeName); // Add each recipe's name to the combobox
            }
        }

        // Event handler for when the selection in RecipeComboBox changes
        private void RecipeComboBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string selectedRecipeName = RecipeComboBox.SelectedItem as string; // Get the selected recipe name
            if (selectedRecipeName != null)
            {
                DisplayRecipeDetails(selectedRecipeName); // Display details of the selected recipe
            }
        }

        // Method to display details of the selected recipe
        private void DisplayRecipeDetails(string recipeName)
        {
            Recipe selectedRecipe = MainWindow.Recipes.Find(r => r.RecipeName == recipeName); // Find the selected recipe by name
            if (selectedRecipe != null)
            {
                IngredientsListBox.Items.Clear(); // Clear previous ingredients list
                StepsListBox.Items.Clear(); // Clear previous steps list

                // Display each ingredient's details in the IngredientsListBox
                foreach (Ingredient ingredient in selectedRecipe.Ingredients)
                {
                    IngredientsListBox.Items.Add($"{ingredient.Name}: {ingredient.Quantity} {ingredient.UnitOfMeasurement} (Food Group: {ingredient.FoodGroup}, Calories: {ingredient.Calories})");
                }

                // Use ObservableCollection to display steps in StepsListBox
                var stepsObservableCollection = new System.Collections.ObjectModel.ObservableCollection<string>(selectedRecipe.Steps);
                StepsListBox.ItemsSource = stepsObservableCollection;
            }
        }

        // Event handler for when the CompletedButton is clicked
        private void CompletedButton_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = RecipeComboBox.SelectedItem as string; // Get the selected recipe name
            MessageBox.Show($"{recipeName} completed."); // Show a message that the recipe is completed
        }
    }
}
