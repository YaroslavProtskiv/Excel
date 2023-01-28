using Excel.parts;
using System;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] arr = {
                // A              B           C            D
                { "12",           "=C2",      "3",         "'Sample"},    
                {"=A1+B1*C1/5",   "=A2*B1",   "=B3-C3",    "'Spread" },   
                { "'Test",        "=4-3",     "5",         "'Sheet" }

                }; 
            Cells wayToCells = new Cells(5, 5);// недолік через автосортування збиваються колонки при завершенні алфавіту
            // або налаштувати сортування, або ColumnNames монтувати в Cells.codeCells.Key
            

            wayToCells.ChangeCellAndUpdate("A1", arr[0, 0]);
            wayToCells.ChangeCellAndUpdate("B1", arr[0, 1]);
            wayToCells.ChangeCellAndUpdate("C1", arr[0, 2]);
            wayToCells.ChangeCellAndUpdate("D1", arr[0, 3]);

            wayToCells.ChangeCellAndUpdate("A2", arr[1, 0]);
            wayToCells.ChangeCellAndUpdate("B2", arr[1, 1]);
            wayToCells.ChangeCellAndUpdate("C2", arr[1, 2]);
            wayToCells.ChangeCellAndUpdate("D2", arr[1, 3]);

            wayToCells.ChangeCellAndUpdate("A3", arr[2, 0]);
            wayToCells.ChangeCellAndUpdate("B3", arr[2, 1]);
            wayToCells.ChangeCellAndUpdate("C3", arr[2, 2]);
            wayToCells.ChangeCellAndUpdate("D3", arr[2, 3]);

            wayToCells.Show(false);

            wayToCells.ChangeCellAndUpdate("C1", "4");
            wayToCells.Show(false);

            wayToCells.AddColumns(2);
            wayToCells.Show(false);

            wayToCells.AddRows();
            wayToCells.Show(false);

            Console.ReadKey();
        }
    }
}
