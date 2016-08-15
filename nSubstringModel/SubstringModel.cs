using System.Collections.Generic;

namespace nSubstringModel
{
    public class SubstringModel
    {
        public int ConvertedInput { get; set; }
        public int StartingNumber { get; set; }        
        public int SubstringSum { get; set; }                
        public string Input { get; set; }
        public string ErrorMessage { get; set; }
        public List<string> Results { get; set; }
        //Used to track roundtrip 
        public List<string> StatusMessages { get; set; }

        public SubstringModel() {
            Results = new List<string>();
            StatusMessages = new List<string>();
        }
    }
}
