using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reference_number
{
    class classRef
    {
        public string RefNo(string iRef, string iType)
        {
            ulong hlpRef = UInt64.Parse(iRef);
            string strhlpRef = "";
            int j = 0;
            ulong k = 0;
            ulong hlpRef2 = 0;
            ulong nextzero = 0;
            ulong chkno = 0;
            string iStr = iRef;
            

            //Change type uLong --> String and change it's direction to backwards
            strhlpRef = (String)Convert.ChangeType(hlpRef, typeof(string));
            
            if (iType == "1")
            {
                strhlpRef = strhlpRef.Substring(0, strhlpRef.Length - 1);
            }

            strhlpRef = stringReverseString3b(strhlpRef);
            j = strhlpRef.Length;
  
            //Count check digit
            for (int i = 0; i < j; i++)
            {
                if (i == 0 || i == 3 || i == 6 || i == 9 || i == 12 || i == 15 || i == 18)
                {
                    k = 7;
                }
                else if (i == 1 || i == 4 || i == 7 || i == 10 || i == 13 || i == 16 || i == 19)
                {
                    k = 3;
                }
                else
                {
                    k = 1;
                }

                hlpRef2 = hlpRef2 + k * ulong.Parse(strhlpRef.Substring(i, 1));
            }

            nextzero = hlpRef2;
            j = Convert.ToString(nextzero).Length;

            //Following number which ends to zero
            for (int i = 0; i < 10; i++)
            {
                nextzero = nextzero + 1;

                if (Convert.ToString(nextzero).Substring(j - 1, 1) == "0")
                {
                    i = 10;
                }
            }


            if (iType == "1")
            {
                ulong hlpchkno = Convert.ToUInt64(iRef.Substring(iRef.Length - 1));
                chkno = nextzero - hlpRef2;
                if (hlpchkno != chkno)
                {
                    iRef = "0";
                }
            }
            else 
            {
                chkno = nextzero - hlpRef2;
                iRef = Convert.ToString(chkno);
                iRef = iStr + iRef;

                iStr = "";

                iRef = stringReverseString3b(iRef);

                for (int i = 0; i < iRef.Length; i++)
                    if (i == 4 || i == 9 || i == 14 || i == 19)
                        iStr = iStr + iRef.Substring(i, 1) + " ";
                    else
                        iStr = iStr + iRef.Substring(i, 1);


                iRef = stringReverseString3b(iStr);
            }
            return iRef;

        }

        //
        public string stringReverseString3b(string str)
        {
            char[] chars = new char[str.Length];
            for (int i = 0, j = str.Length - 1; i <= j; i++, j--)
            {
                chars[i] = str[j];
                chars[j] = str[i];
            }
            return new string(chars);
        }
        public string CreateRFRefNo(string RFRefNo)
        {
            string hlpiacc = RFRefNo;
            decimal intAcc = 0;
            decimal hlpmod = 0;
            decimal hlpmod2 = 0;
            string hlpAcc = "";
            //insert RF to numbers and two zeros
            hlpiacc = hlpiacc + "271500";
            //check if 
            if (decimal.TryParse(hlpiacc, out intAcc))
            {
                //if successful then modulo 97
                hlpmod = intAcc % 97;
                hlpmod2 = 98 - hlpmod;
                hlpAcc = Convert.ToString(hlpmod2);
                if (hlpmod2 < 10)
                {
                    hlpAcc = "0" + hlpAcc;
                }

                //int RFRefNolngth = RFRefNo.Length;

                RFRefNo = "RF" + hlpAcc + RFRefNo;
                }

            return RFRefNo;
        }
        public string formatstring(string RefNo)//, int iFormat)
        {
            string hlpRefNo = "";
            //int hlpFormat = 0;

            for (int i = 0; i < RefNo.Length; i++)
            {
                //if (iFormat / i == 1)
                if (i == 4 || i==8 || i==12 || i==16)
                    hlpRefNo = hlpRefNo + " " + RefNo.Substring(i,1);
                else
                    hlpRefNo = hlpRefNo + RefNo.Substring(i, 1);
            }

            RefNo = hlpRefNo;

            return RefNo;
        }
        public string checkRFRefNo(string RFRefNo)
        {
            string hlpRFRefno2 = RFRefNo.Substring(4);
            string hlpRFRefNo = RFRefNo.Substring(0,4);
            decimal intAcc = 0;
            decimal hlpmod = 0;
            
            
            //move four first digits to end of variable and change those letters to numbers R= 27 and F = 15
            hlpRFRefNo = hlpRFRefno2 + "2715" + hlpRFRefNo.Substring(2); // hlpRFRefNo;

            if (decimal.TryParse(hlpRFRefNo, out intAcc))
            {
                //if successful then modulo 97
                hlpmod = intAcc % 97;
                if (hlpmod==1)
                {
                    RFRefNo = "1";
                }
                else
                {
                    RFRefNo = "0";
                }
                
            }

            return RFRefNo;
        }
     }
}
