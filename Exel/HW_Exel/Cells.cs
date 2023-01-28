using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel.parts;

namespace Excel
{
    /// <summary>
    /// заповнення комірок з посиланнями індексів
    /// </summary>
    class Cells
    {
        private SortedList<string,ValueSells> codeCells;

        ColumnName columnName;

        public Cells(int rows = 10, int columns = 10)
        {
            columnName = new ColumnName(rows, columns);
            codeCells = new SortedList<string, ValueSells>();
            AddCodeSells();
        }

        private void AddCodeSells(int startWith = 1)
        {

            foreach (var colum in columnName.codeColumn)
            {
                for (int i = startWith; i <= columnName.RowsLench; i++)
                {

                    codeCells.Add(colum + i,new ValueSells(codeCells));
                }
            }
        }

        public void AddRows(int newRows = 1)
        {
            int startWith = columnName.RowsLench + 1;
            columnName.AddRows(newRows);
            AddCodeSells(startWith);
            
        }

        public void AddColumns(int newColumn = 1)
        {
            columnName.AddCodeColumns(newColumn + 1);
            for (int i = 0; i < newColumn; i++)
            {
                for (int j = 1; j <= columnName.RowsLench; j++)
                {
                    codeCells.Add(columnName.codeColumn[^(1 + i)] + j, new ValueSells(codeCells));
                }
            }
            
        }

        public void Show(bool showKey = true)
        {
            int i = 1;
            if (showKey == true)
            {
                foreach (var cellName in codeCells)
                {
                    
                    if (i % columnName.RowsLench != 0)
                        Console.Write(cellName.Key + "\t");
                    else
                        Console.WriteLine(cellName.Key);
                    i++;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int j = 0; j <= columnName.RowsLench; j++)
                {
                    Console.Write((j==0)? "nn"+"\t":j+ "\t");
                }
                Console.Write("\n" + columnName.codeColumn[i / columnName.RowsLench] + "\t");
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (var cellName in codeCells)
                {
                    if (i % columnName.RowsLench != 0)
                        Console.Write(cellName.Value.SetInfo() + "\t");
                    else
                    {
                        Console.WriteLine(cellName.Value.SetInfo());
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write( (columnName.codeColumn.Count <= i / columnName.RowsLench) 
                            ? "":(columnName.codeColumn[i / columnName.RowsLench] + "\t") );
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                        
                    i++;
                }
                Console.WriteLine();
            }
                
            Console.WriteLine("\n" + new string('*', 20));
        }

        // Show потрібно змінити відображення рядки/стовпці

        /**
         param name="keySell" ABC
         */
        public void ChangeCellAndUpdate(string keySell, string _value = null)
        {
            ChangeValueCell(keySell, _value);
            UpdateCells();
        }

        private void ChangeValueCell(string keySell, string _value = null)
        {            
            if (codeCells.IndexOfKey(keySell) == -1)
                Console.WriteLine("Sell {0} does not exist!! Enter correct sell's name!!", keySell);
            else if (_value == null)
            {
                Console.WriteLine("Enter info in cell {0}!!", keySell);
                // або ввести значення bool в codeCells[keySell].EnterValue() для вибору режиму;
                codeCells[keySell].EnterValue();
            }    
            else
                codeCells[keySell].EnterValue(_value);
        }
        public void UpdateCells()
        {
            foreach (var item in codeCells)
            {
                ChangeValueCell(item.Key, item.Value.resultText);
            }
        }
    }


}
