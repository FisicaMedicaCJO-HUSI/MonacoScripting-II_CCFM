# MonacoScripting-II_CCFM
This script NewPlanProstata automates steps of creating a VMAT Prostate plan from plan template UHPROSTATA2FSCRIPT in the Centro Javeriano de Oncología.
 * 1.This code imports the necessary libraries and creates a class called Program. 
 * The class begins by defining some script variables, which are read from the App.config file and from a pop-up dialog box.
 * The variables used in this script are given via App.config as well as customizable pop-up dialog.
 * 2.It starts by prompting the user for some script variables, uch as the patient ID, plan template, total dose, number of fractions, and treatment unit. 
 * 3.Then, it launches Monaco and loads the patient.
 * 4. Next, the script creates a new plan from the specified template UHPROSTATA2FSCRIPT. 
 * It sets the plan name and description, selects the delivery mode, and imports the plan template UHPROSTATA2FSCRIPT. 
 * It also sets the Mosaiq options, selects the beam treatment unit 4433, and changes the isocenter location.
 * 5. After creating the new plan, the script sets the total dose and number of fractions in the Prescription tab.
 * A It also sets the dose constraints using a pre-defined JSON file.
 * 6.Once the plan has been set up, the script saves the patient and executes optimization phase 1.
 * Then, it goes to the IMRT Constraints spreadsheet and turns off a couple of MCOs. Finally, it executes batch optimization and saves the patient again.
 * 7. The script ends by checking if the dose criteria is fully met. If it is not, the script displays a message box to the user. 
 * If it is met, the script  NewPlanProstata closes the patient. 
