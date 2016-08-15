using nSubstringModel;
using nSubstringValidation;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;

namespace nSubstring {
    class Program {
        private static BackgroundWorker backgroundWorker;

        static void Main(string[] args) {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            InitializeBackgroundWorker();

            //Gather inputs
            SubstringModel substringModel = new SubstringModel();
            substringModel.SubstringSum = Properties.Settings.Default.SubstringSum;
            substringModel.StartingNumber = Properties.Settings.Default.SubstringStartingNumber;
            
            Console.WriteLine(string.Concat(substringModel.SubstringSum, " Substring Program"));
            Console.WriteLine(string.Concat("Starting number for nSubstring:  ", substringModel.StartingNumber));
            Console.WriteLine(string.Concat("Sum of nSubstring:  ", substringModel.SubstringSum));
            Console.WriteLine("Please enter a number to process...");
            
            substringModel.Input = Console.ReadLine();

            Console.WriteLine(string.Concat("Processing for:  ", substringModel.Input, ".  ", "Please wait..."));
            backgroundWorker.RunWorkerAsync(substringModel);

            Console.Read();
        }

        private static void InitializeBackgroundWorker() {
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
        }

        private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            SubstringModel substringModel = (e.Argument as SubstringModel);

            //Check for valid input
            bool isNumberValid = SubstringValidation.ValidateConvertInput(substringModel);

            //Proccess number
            if (isNumberValid) {                
                worker.ReportProgress(10, "Input is a valid number");
                e.Result = ProcessNumber(worker, substringModel);
            }
            else {
                worker.ReportProgress(10, substringModel.ErrorMessage);
            }
        }

        private static SubstringModel ProcessNumber(BackgroundWorker worker, SubstringModel substringModel) {
            using (HttpClient client = new HttpClient()) {
                worker.ReportProgress(20, "Running Calculation...");

                string json = new JavaScriptSerializer().Serialize(substringModel);
                StringContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(Properties.Settings.Default.SubstringServiceURL, httpContent).Result;

                if (response.IsSuccessStatusCode) {
                    var data = response.Content.ReadAsStringAsync().Result;                    
                    substringModel = (SubstringModel)new JavaScriptSerializer().Deserialize(data, typeof(SubstringModel));
                }
                else {                    
                    substringModel.ErrorMessage = response.ReasonPhrase;
                }
            }

            return substringModel;
        }

        private static void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            Console.WriteLine(e.UserState.ToString());
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                Console.WriteLine(e.Error.Message);
            }            

            SubstringModel substringModel = (e.Result as SubstringModel);

            if (substringModel != null) {

                if (!string.IsNullOrEmpty(substringModel.ErrorMessage)) {
                    Console.WriteLine(substringModel.ErrorMessage);
                }

                for (int i = 0; i < substringModel.Results.Count; i++) {
                    Console.WriteLine(substringModel.Results[i]);
                }

                Console.WriteLine("Calculation complete.");
            }            
        }
    }
}
