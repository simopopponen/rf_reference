using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFreference
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;
            bool result = false;
            string uRefNo = "";
            Reference_number.classRef iRef = new Reference_number.classRef();
            Console.WriteLine("Give option 1 to check RFrefnumber; option 2 to create RFrefnumber:");
            result = int.TryParse(Console.ReadLine(), out option);

            if (result == true)
            {
                if (option == 1)
                {
                    Console.WriteLine("Give RFreference number to check:");
                    uRefNo = Console.ReadLine();

                    string uReference = uRefNo;
                    string uReference_number = iRef.checkRFRefNo(uRefNo);

                    if (uReference_number != "0")
                    {
                        Console.WriteLine("{0} -OK", uRefNo);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Reference number Incorrect");
                        Console.ReadLine();
                    }

                }
                else 
                {
                    Console.WriteLine("Give RFreference number for create:");

                    uRefNo = Console.ReadLine();
                    if (result)
                    {
                        //Create domestic reference number
                        string RefNo = iRef.RefNo(uRefNo, Convert.ToString(option-1));
                        string RFRefNo = iRef.CreateRFRefNo(RefNo);
                        string formatRefNo = iRef.formatstring(RFRefNo);//,4);

                        Console.WriteLine("Reference number {0}", formatRefNo);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Not a valid reference");
                        Console.ReadLine();
                    }

                }

                }
            
            else
            {
                Console.WriteLine("Give option 1,2 or 3");
                Console.ReadLine();
            }
        }
    }
}
