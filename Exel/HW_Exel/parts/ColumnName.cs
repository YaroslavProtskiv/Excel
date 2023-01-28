using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excel.parts
{
    /// <summary>
    /// Клас для створення буквенного шифру по колонках
    /// </summary>
    class ColumnName
    {
      
        public List<string> codeColumn = new List<string>();
       
        private int rowsLench;
        public int RowsLench
        {
            get { return rowsLench; }
        }


        public ColumnName(int rows = 10, int collumns = 10)
        {
            rows = (rows < 1) ? 1 : rows;
            AddRows(rows);
            collumns = (collumns < 1) ? 1 : collumns;
           
            
                codeColumn.Add("A");
            

            AddCodeColumns(collumns);
        }

        public void AddRows(int newRows)
        {
            rowsLench += newRows;
        }

        public void AddCodeColumns (int newColumns)
        {
            for (int i = 1; i < newColumns; i++)
            {
                AddCodeColumn();
            }
        }

        private void AddCodeColumn()
        {
            int number = codeColumn.Count-1;
            string result = (codeColumn[number] == null) ? " ": codeColumn[number].ToString();
            char[] resultArr = result.ToCharArray();
            int index = result.Length - 1;
            result = AddCodeColumn(index, ref resultArr);
            
            codeColumn.Add(result);

        }

        private string AddCodeColumn(int index, ref char[] resultArr)
        {

            int _simbol = (int)resultArr[index];
            if (_simbol == 90)
            {
                resultArr[index] = 'A';

                if (index == 0)
                {
                    char[] _resultArr = new char[resultArr.Length+1];
                    _resultArr[0] = 'A';
                    for (int i = 1; i < _resultArr.Length; i++)
                    {
                        _resultArr[i] = resultArr[i - 1];
                    }
                    resultArr = _resultArr;
                }
                else
                {
                    index--;
                    AddCodeColumn(index, ref resultArr);
                }
            }
            else
            {
                resultArr[index] = (char)(_simbol + 1);
            }

            return new string(resultArr); 
        }

        // доціцьна реалізація видалення рядків і колонок
    }
}
