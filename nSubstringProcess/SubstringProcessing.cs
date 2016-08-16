using nSubstringModel;
using System.Collections.Generic;

namespace nSubstringProcess
{
    public class SubstringProcessing
    {
        public static SubstringModel ProcessNumber(SubstringModel substringModel) {
            substringModel.StatusMessages.Add("Hello from SubstringProcessing");

            for (int i = 0; i < substringModel.ConvertedInput; i++) {
                int[] t = GetIntArray(i);

                if (t.Length == 1) {
                    continue;
                }

                int counter = 0;
                int sum = 0;

                //Tracking number pieces 
                List<int> myNum = new List<int>();

                while (counter < t.Length) {
                    myNum.Add(t[counter]);
                    sum += t[counter];  
                  
                    if (sum == substringModel.SubstringSum) {
                        if (!substringModel.Results.Exists(x => x == i)) {
                            substringModel.Results.Add(i);
                        }
                        
                        break;
                    }

                    counter += 1;
                }
            }

            return substringModel;
        }

        private static int[] GetIntArray(int num) {
            List<int> listOfInts = new List<int>();

            while (num > 0) {
                listOfInts.Add(num % 10);
                num = num / 10;
            }

            listOfInts.Reverse();

            return listOfInts.ToArray();
        }

    }
}
