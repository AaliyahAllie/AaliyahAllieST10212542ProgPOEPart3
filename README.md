Link To GitHub Repository:

This is how to run/compile my prog poe (part 3)
Initially if you are using Visual Studio 2022 if you have the project file open on your application you can press "F5" to run the project from the main window, or you can run it using the tab run with the little green triangle to run the main window. A more indepth approach would be to:
How to Compile and Run
To compile and run this WPF application, follow these steps:

**Prerequisites**
  Visual Studio: Ensure you have Visual Studio installed on your machine. This guide assumes you are using Visual Studio for compilation.
  Steps
  
**Clone the Repository:**
  Clone the repository containing the WPF application code.
  Open Solution in Visual Studio:

**Launch Visual Studio.**
  Go to File -> Open -> Project/Solution....
  Navigate to the directory where you cloned the repository and select the solution file (*.sln) for the project.
  
**Restore NuGet Packages:**
  If prompted, restore the NuGet packages required for the project.
  Build the Solution:
  Once the solution is loaded, go to Build -> Build Solution (or simply press Ctrl+Shift+B) to compile the application.
  
**Set as Startup Project:**
  Right-click on the project (AaliyahAllieST10212542ProgPOEPart3) in the Solution Explorer.
  Select Set as Startup Project.
  
**Run the Application:**
  Press F5 or go to Debug -> Start Debugging to run the application.
  
**Interact with the Application:**
  The application window titled "Recipe App" will appear.
  You can interact with various buttons (Add Recipe, Display All Recipes, etc.) to perform actions as described in the application's functionality.

**Exit the Application:**
  Click on the Exit button to close the application.
  Application Structure
  MainWindow.xaml: Defines the UI layout using XAML.
  MainWindow.xaml.cs: Contains the code-behind logic for handling button clicks and interacting with recipes.
  Recipe.cs (Assumed): Represents the Recipe class structure used in the application.
  
**Notes**
  Ensure all dependencies and references are resolved during the build process.
  Debugging and error handling messages are provided through MessageBox prompts.
  Make sure your development environment is configured properly for WPF application development.
  By following these steps, you should be able to successfully compile, run, and interact with the ProgPOE WPF application.
  Alternatively check the project file for a run down of how each window functions, check the user manual to navigate the windows of the application.
