using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.parts
{
    /// <summary>
    /// клас для зберігання даних таблиці
    /// </summary>
    class ValueSells
    {
        public bool isNumber;
        public double resultNumber;
        public string resultText;
        // можливо доцільніше було замість цих 3-х змінних спробувати Generic, запізно зрозумів
        // перевести в Свойства isNumber resultNumber resultText

        char[] tipeOperation = { '+', '-', '*', '/' };
        SortedList<string, ValueSells> codeCells;

        public ValueSells(SortedList<string, ValueSells> codeCells)
        {
            this.codeCells = codeCells;
            EnterValue("0");
        }

        public ValueSells()
        {
            resultNumber = 0; resultText = "0"; isNumber = true;
        }

        public void EnterValue()
        {           
            string value = Console.ReadLine();
            EnterValue(value);
        }

        public void EnterValue (string value)
        {
            if (value [0] == '=')
            {
                resultNumber = 0; resultText = value;
                value = value.Substring(1);
                List<char> operation = new List<char>();
                foreach (char simbol in value)
                {
                    if (simbol == '+' || simbol == '-' || simbol == '*' || simbol == '/' ) // спростити
                        operation.Add(simbol);
                }
                
                for (int i = 0; i < 4; i++)
                {
                    value = value.Replace(tipeOperation[i], '_');
                }  
                
                string[] _numbers = value.Split(new char[] { '_' });
                List<double> numbers = Numbers(_numbers, codeCells);
                if (numbers != null && numbers.Count == operation.Count + 1)
                {
                    isNumber = true;
                    resultNumber = FindResult(numbers, operation);
                }
                else
                    isNumber = false;
            }
            else 
            {
                resultNumber = 0; resultText = value;
                isNumber = double.TryParse(value, out resultNumber);
                
            }
        }
        private List<double> Numbers (string [] numbers, SortedList<string, ValueSells> codeCells)
        {
            List<double> list = new List<double>();
            foreach (string number in numbers)
            {
                double value;
                bool isValue = double.TryParse(number, out value);
                if (isValue == true)
                    list.Add(value);
                else if (codeCells.ContainsKey(number) == true && codeCells.Values[codeCells.IndexOfKey(number)].isNumber == true)
                    list.Add(codeCells.Values[codeCells.IndexOfKey(number)].resultNumber);
                else
                    return null;
            }
            return list;
        }
         
        private double FindResult(List<double> numbers, List<char> operation)
        {
            double result = numbers[0];
            for (int i = 0; i < operation.Count; i++)
            {
                switch (operation[i])
                {
                    case '+':
                        result += numbers[i + 1];
                        break;
                    case '-':
                        result -= numbers[i + 1];
                        break;
                    case '/':
                        result /= numbers[i + 1];
                        break;
                    case '*':
                        result *= numbers[i + 1];
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public string SetInfo()
        {
            if (isNumber == true)
                return resultNumber.ToString();
            else
                return resultText;
            
        }
       
    }
}
