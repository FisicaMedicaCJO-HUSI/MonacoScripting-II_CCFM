using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPlanWithUserInput
{
    public partial class FormUserInput : Form
    {
        public string PatientID { get; set; }
        public string PlanTemplate { get; set; }
        public double TotalDose { get; set; }
        public int FractionNumb { get; set; }
        public string TU { get; set; }


        public FormUserInput()
        {
            Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void FormUserInput_Load(object sender, EventArgs e)
        {
            var planTemplateList = ConfigurationManager.AppSettings["PlanTemplateList"]
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToArray();
            comboBoxPlanTemplate.Items.AddRange(planTemplateList);
            if (comboBoxPlanTemplate.Items.Count > 0)
                comboBoxPlanTemplate.SelectedIndex = 0;

            var tuList = ConfigurationManager.AppSettings["TU"]
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToArray();
            comboBoxTU.Items.AddRange(tuList);
            if (comboBoxTU.Items.Count > 0)
                comboBoxTU.SelectedIndex = 0;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                PatientID = textBoxPatientID.Text;
                PlanTemplate = comboBoxPlanTemplate.Text;
                TotalDose = double.Parse(textBoxTotalDose.Text);
                FractionNumb = int.Parse(textBoxFractionation.Text);
                TU = comboBoxTU.Text;

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
