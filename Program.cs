/*************************************************************************************************************************************
 * This script NewPlanProstata automates steps of creating a VMAT Prostate plan from plan template UHPROSTATA2FSCRIPT in the Centro Javeriano de Oncología.
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
 * 
 *************************************************************************************************************************************/
// Imports the following libraries
using System;
using System.Configuration;
using System.Windows.Forms;
using Elekta.MonacoScripting.API;
using Elekta.MonacoScripting.API.General;
using Elekta.MonacoScripting.API.Planning;
using Elekta.MonacoScripting.DataType;
using Elekta.MonacoScripting.API.IMRTConstraints;
using Elekta.MonacoScripting.API.PrescriptionInfo;
using System.Runtime.InteropServices;
using NewPlanWithUserInput;

namespace CreatePlan
{
    class Program
    {
        // Script variables in App.config
        private static string Installation = ConfigurationManager.AppSettings["Installation"];
        private static string Clinic = ConfigurationManager.AppSettings["Clinic"];
        private static string Iso = ConfigurationManager.AppSettings["IsoLocation"];
        private static string DoseConstraints = ConfigurationManager.AppSettings["DoseConstraints"];

        // Script variables via Pop-up dialog
        private static string PatientID;
        private static string PlanTemplate;
        private static double TotalDose;
        private static int FractionNumb;
        private static string TU;

        #region MinimizeCmdWindow
        //Works together with following script step to minimize windows command window during script run
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        #endregion


        [STAThread]
        static void Main(string[] args)
        {
            MonacoApplication app = MonacoApplication.Instance;

            // Step 1: Pop up the dialog of Script Variables Input.
            //This code imports the necessary libraries and creates a class called Program. 
            //The class begins by defining some script variables, which are read from the App.config file and from a pop-up dialog box.
            #region 0. Pop up the dialog of Script Variables Input 
            var form = new FormUserInput();

            if (form.ShowDialog() == DialogResult.OK)
            {
                PatientID = form.PatientID;
                PlanTemplate = form.PlanTemplate;
                TotalDose = form.TotalDose;
                FractionNumb = form.FractionNumb;
                TU = form.TU;
            }
            else
            {
                Console.WriteLine("User selected cancel in the dialog of script variables input...");
                return;
            }
            #endregion
            // Step 2: MinimizeCmdWindow
            #region 1. MinimizeCmdWindow
            //Minimize the windows command window which appears during script run to display script logs
            IntPtr intptr = FindWindow("ConsoleWindowClass", null);
            if (intptr != IntPtr.Zero)
                ShowWindow(intptr, 6);
            #endregion

            try
            {
                // Step 3: Launch Monaco
                // This code minimizes the Windows command window, which appears during script run to display script logs.
                app.LaunchMonaco();
                
                // Step 4: Load the patient
                // This code launches the Monaco application and loads the patient into Monaco.
                PatientSelection PS = app.GetPatientSelection(); // Activate Patient selection dialog
                PS.LoadPatient(Installation, Clinic, PatientID); // Load the patient 


                #region 4. New Plan from template
                //// Step 5: New Plan from template UHPROSTATA2FSCRIPT.
                NewMonacoPlanCreator monacoPlanCreator = app.GetNewMonacoPlanCreator("SS_CT2");

                // Step 6: Set new plan name and description in New Plan dialog
                var PlanName = DateTime.Now.ToString("ddMMHHmm"); //Use the timestamp as plan name
                monacoPlanCreator.SetNewPlanNameAndDescription(PlanName, "by Scripts"); // Enter Plan name and description

                monacoPlanCreator.SelectDelivery(Delivery.VMAT); // select delivery mode
                monacoPlanCreator.SelectTemplateToImport(PlanTemplate); // select a plan template

                // Step 8: Set Mosaiq Options
                monacoPlanCreator.SetMosaiqOptions(1, PlanIntent.Curative, "Clinical"); // Set Mosaiq Options. This fiedls will be available only if auto dicom export is configured.

                // Step 9: Select Treatment machine 4433 and Isocenter location
                monacoPlanCreator.SelectBeamTreatmentUnit(TU); // Select Treatment machine
                monacoPlanCreator.SelectBeamIsocenterLocation(Iso); // Change isocenter 

                // Step 10: Click OK to close new plan dialog
                monacoPlanCreator.ClickOK(); //click OK button to close new plan dialog 
                #endregion

                // Step 11: Set total dose and fractions in Prescription tab
                #region 5. Set total dose and fractions in Prescription tab
                Prescription intent = app.GetPrescription();
                intent.SetPhysicianIntentRxDose(TotalDose);//pass from pop-up dialog
                intent.SetPhysicianIntentNumberOfFractions(FractionNumb); //pass from pop-up dialog 
                #endregion

                // Step 12: Set Dose constraints
                #region 6. Set Dose constraints
                var DVH = app.GetDVHStatisticsSpreadsheet(); // Activate DVH Statistics tab

                //Set Dose Criteria with the pre-defined .json file. 
                //A sample of dose criteria json file is given in ../SampleData/.
                //The API "ConvertDosimetricCriterionToJson" can also be used to save current Dose Criteria into a json file to understand dose criteria json file structure.
                DVH.SetDVHStatistics(DoseConstraints); 
                #endregion

                // Step 13: Save Patient
                app.SavePatient();

                // Step 14: IMRT Constraints and Optimization
                // Start Optimization Phase 1
                #region 7. IMRT Constraints and Optimization
                
                app.ExecuteOptimizationPhase1(); // Start Optimization Phase 1

                //  Step 15:Go to IMRT Constraints spreadsheet
                IMRTConstraintsSpreadsheet imrtConstraints = app.GetIMRTConstraintsSpreadsheet();
                
                //  Step 16:Turn off a couple of MCOs
                // Refer to Monaco Scripting APIIndex file for details (e.g, meaning of parameters) of ToggleMultiCriterial method.
                imrtConstraints.ToggleMultiCriterial("Recto", 0, false);
                imrtConstraints.ToggleMultiCriterial("Recto", 1, false);
                imrtConstraints.ToggleMultiCriterial("Vejiga", 0, false);
                imrtConstraints.ToggleMultiCriterial("Vejiga", 1, false);
                
                //  Step 17: Start batch optimization
                app.ExecuteBatchOptimization(); // Start batch optimization

                //  Step 18:Save Patient
                app.SavePatient();
                #endregion

                //  Step 19:Check if Dose Criteria is fully met after optimization completes
                if(!DVH.IsDosimetricCriteriafulfilledMet())
                {
                    MessageBox.Show($"Dose Criteria is not fully met.", "Optimization result", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }

                else
                {
                    app.ClosePatient();
                }



            }
            ////Step 20: Exception handling
            //This will display a message box with the exception message.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occurred", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

    }
}
