using nSubstringModel;

namespace nSubstringValidation
{
    public class SubstringValidation
    {
        public static bool ValidateConvertInput(SubstringModel substringModel) {
            bool isValid = true;
            int convertedNumber;

            substringModel.StatusMessages.Add("Hello from SubstringValidation");            

            if (int.TryParse(substringModel.Input, out convertedNumber)) {
                substringModel.ConvertedInput = convertedNumber;
            }
            else {
                substringModel.ErrorMessage = "Not a valid number";
                isValid = false;
            }

            return isValid;
        }
    }
}
