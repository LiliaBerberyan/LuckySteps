using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLuckySteps
{
   static class StepResultRandomChoose
    {
    //    public static T NextEnum<T>(this Random random)
    //    {
    //        var values = Enum.GetValues(typeof(T));
    //        return (T)values.GetValue(random.Next(values.Length));
        
        public static StepResult Choose()
        {
            Random random = new Random();

            Type type = typeof(StepResult);
            Array values = type.GetEnumValues();
            int index = random.Next(values.Length);
            StepResult value = (StepResult)values.GetValue(index);
            return value;
        }
    }
}
