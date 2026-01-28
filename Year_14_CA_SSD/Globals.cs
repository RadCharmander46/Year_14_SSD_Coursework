using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Year_14_CA_SSD
{
    static class Globals
    {
        public static string connectionString;
        public static bool signedIn = false;
        public static int? loginId = 0;
        public static bool isManager = false;
        public static Settings settings = SettingsLoading.Load_Settings();
        public static bool checkStringLength(string testString,int maxLength,int minLength)
        {
            try
            {
                if (testString.Length > maxLength)
                {
                    return false;
                }
                if (testString.Length < minLength)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool validString(string testString, int maxLength,int minLength,bool lettersOnly, bool numericAllowed, bool specialCharactersAllowed,bool spaceAllowed)
        {
            try
            {
               if(!checkStringLength(testString,maxLength,minLength))
                {
                    return false;
                }
               if(minLength != 0 && (testString[0] == ' ' || testString[testString.Length-1] == ' ') )//can't have leading or lagging whitespace
                {
                    return false;
                }

                foreach(char character in testString)
                {
                    if (!Char.IsLetter(character) && lettersOnly)
                    {
                        return false;
                    }
                    if (Char.IsNumber(character) && !numericAllowed)
                    {
                        return false;
                    }
                    if(Char.IsWhiteSpace(character) && !spaceAllowed)
                    {
                        return false;
                    }
                    if(Char.IsControl(character))
                    {
                        return false;
                    }
                    if(Char.IsSurrogate(character))
                    {
                        return false;
                    }
                    if(Char.IsPunctuation(character) && !specialCharactersAllowed)
                    {
                        return false;
                    }
                    if(Char.IsSymbol(character) && !specialCharactersAllowed)
                    {
                        return false;
                    }
                    if(Char.IsSeparator(character) && !Char.IsWhiteSpace(character))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static char[] baseLetters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        public static bool containsAccentedCharacters(string testString)
        {
            for(int i = 0;i< testString.Length;i++)
            {
                if(Char.IsLetter(testString[i])) //need to check
                {
                    if(!baseLetters.Contains(Char.ToLower(testString[i])))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static bool validName(string name)
        {
            bool validString = Globals.validString(name, 50, 1, false, false, true, true);
            if(!validString)
            {
                return false;
            }
            Regex doubleSpaceRg = new Regex("\\s{2,}");
            if(doubleSpaceRg.IsMatch(name))
            {
                return false;
            }
            foreach(char character in name)
            {
                if(Char.IsLetter(character))
                {
                    continue;
                }
                if(character == '\'')
                {
                    continue;
                }
                if(Char.IsWhiteSpace(character))
                {
                    continue;
                }
                return false;
            }
            return true;
        }
        public static bool typedNameInvalid(string name)
        {
            bool validString = Globals.validString(name, 50, 0, false, false, true, true);
            if (!validString)
            {
                return true;
            }
            Regex doubleSpaceRg = new Regex("\\s{2,}");
            if (doubleSpaceRg.IsMatch(name))
            {
                return true;
            }
            Regex doubleApostRg = new Regex("'{2,}");
            if (doubleApostRg.IsMatch(name))
            {
                return true;
            }
            foreach (char character in name)
            {
                if (Char.IsLetter(character))
                {
                    continue;
                }
                if(character == ' ')
                {
                    continue;
                }
                if (character == '\'')
                {
                    continue;
                }
                return true;
            }
            return false;
        }
        public static bool validAddress(string address)
        {
            bool validString = Globals.validString(address, 50, 1, false, true, true, true);
            if(!validString)
            {
                return false;
            }
            if( !isAlphaNumeric(address[0].ToString(), true) || !isAlphaNumeric(address[address.Length - 1].ToString(), true)) // first or last character can't be a special character
            {
                return false;
            }
            bool lastCharacterSpecial = false;
            foreach(char character in address)
            {
                if(Char.IsLetter(character))
                {
                    lastCharacterSpecial = false;
                    continue;
                }
                if(Char.IsDigit(character))
                {
                    lastCharacterSpecial = false;
                    continue;
                }
                if(character == ' ')
                {
                    lastCharacterSpecial = false;
                    continue;
                }
                if(character == '/' || character == '.' || character == '\'' || character == '-')
                {
                    if (lastCharacterSpecial)
                    {
                        return true;
                    }
                    lastCharacterSpecial = true;
                    continue;
                }
                return false;
            }
            return true;
        }
        public static bool typedAddressInvalid(string address)
        {
            if(address.Length > 50)
            {
                return true;
            }
            if(address.Length == 0)
            {
                return false;
            }
            if (!isAlphaNumeric(address[0].ToString(), true))
            {
                return true;
            }
            bool lastCharacterSpecial = false;
            bool lastCharSpace = false;
            foreach (char character in address)
            {
                if (Char.IsLetter(character))
                {
                    lastCharacterSpecial = false;
                    lastCharSpace = false;
                    continue;
                }
                if (Char.IsDigit(character))
                {
                    lastCharacterSpecial = false;
                    lastCharSpace = false;
                    continue;
                }
                if (character == ' ')
                {
                    if(lastCharSpace)
                    {
                        return true;
                    }
                    lastCharSpace = true;
                    lastCharacterSpecial = false;
                    continue;
                }
                if (character == '/' || character == '.' || character == '\'' || character == '-')
                {
                    if(lastCharacterSpecial)
                    {
                        return true;
                    }
                    lastCharacterSpecial = true;
                    lastCharSpace = false;
                    continue;
                }
                return true;
            }
            return false;
        }
        public static bool validPostCode(string postCode)
        {
            try
            {
                if (!validString(postCode, 8, 5, false, true, false, true)) //checks only contains numbers and lettera
                {
                    return false;
                }
                if(containsAccentedCharacters(postCode))
                {
                    return false;
                }
                if(!postCode.Contains(" "))
                {
                    return false;
                }
                string[] codes = postCode.Split(' ');
                if(codes.Length != 2) //checks has only one space
                {
                    return false;
                }
                string outwardCode = codes[0];
                if(!checkStringLength(outwardCode,4,2))
                {
                    return false;
                }
                string inwardCode = codes[1];
                if(inwardCode.Length != 3)
                {
                    return false;
                }
                Regex outrg = new Regex("[A-Z]{1,2}[0-9][0-9|A-Z]?");
                if(!outrg.IsMatch(outwardCode))
                {
                    return false;
                }
                Regex inrg = new Regex("[0-9][A-Z]{1,2}");
                if(!inrg.IsMatch(inwardCode))
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string postCodeInsertSpace(string postCode)
        {
            try
            {
                if (postCode.Length <= 2) //space can't be needed yet
                {
                    return postCode;
                }
                if (postCode.Contains(" "))
                {
                    return postCode;
                }
                Regex endRg = new Regex("[A-Z]{1,2}$");
                if(!endRg.IsMatch(postCode)) //checking theres enough information to insert a space
                {
                    return postCode;
                }
                Regex spiltRg = new Regex("[0-9][0-9|A-Z]?[0-9]");
                string text = spiltRg.Match(postCode).Value;
                string newText= "";
                if (text.Length == 3)
                {
                    newText = text[0].ToString() + text[1].ToString() + " " + text[2].ToString();
                }
                if (text.Length == 2)
                {
                    newText = text[0] + " " + text[1];
                }
                return postCode.Replace(text, newText);
            }
            catch
            {
                return postCode;
            }
        }
        public static bool validPhoneNumber(string phoneNumber)
        {
            try
            {
                if (phoneNumber.Length != 10 && phoneNumber.Length != 11)
                {
                    return false;
                }
                if (phoneNumber[0] != '0')
                {
                    return false;
                }
                if (phoneNumber.Contains(" "))
                {
                    return false;
                }
                long number = Convert.ToInt64(phoneNumber);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public static bool typedPhoneNumberInvalid(string phoneNumber)
        {
            try
            {
                foreach(char character in phoneNumber)
                {
                    int num = Convert.ToInt32(character);
                }
                return false;
            }
            catch
            {
                return true;
            }
        }
        public static bool validDriversNumber(string text, DateTime DOB = new DateTime(), string firstName = null, string middleName = null, string lastName = null)
        {
            if (text.Length == 8)
            {
                return validNIDriversNumber(text);
            }
            else if (text.Length == 16 || text.Length == 18)
            {
                try
                {
                    if (firstName != "" && lastName != "" && DOB > new DateTime(1900, 0, 0))
                    {
                        return validGBDriversNumber(text, DOB, firstName, middleName, lastName);
                    }
                }
                catch
                {
                    return false;
                }
            }
            else if(text.Length == 9)
            {
                return validIRDriversNumber(text);
            }
            return false;
        }
        public static bool validNIDriversNumber(string text)
        {
            try
            {
                if (text.Length == 8)
                {
                    int number = Convert.ToInt32(text);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool validGBDriversNumber(string driverNumber, DateTime DOB, string firstName, string middleName, string lastName)
        {
            try
            {
                Regex macRg = new Regex("^[Mm]ac");
                string lastNameCode = macRg.Replace(lastName, "Mc");
                for (int i = 0; i < 4; i++) //checking first 5 characters
                {
                    if (i < lastNameCode.Length) //checking the name is long enough
                    {
                        if (driverNumber[i] != lastNameCode[i])
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (driverNumber[i] != '9') //should be padded with 9 if not long enough
                        {
                            return false;
                        }
                    }
                }
                if (driverNumber[5] != DOB.Year.ToString()[2]) //checking the 6th character is the decade of the driver's DOB
                {
                    return false;
                }
                int driverMonth = Convert.ToInt32(driverNumber[6].ToString() + driverNumber[7].ToString());
                if(driverMonth != DOB.Month && driverMonth != DOB.Month + 50) //checking the 7&8 characters is the month of the DOB or 50 + the month
                {
                    return false;
                }
                int driverDay = Convert.ToInt32(driverNumber[8].ToString() + driverNumber[9].ToString()); // checking the 9&10 characters is the day of the DOB
                if(driverDay != DOB.Day)
                {
                    return false;
                }
                if(driverNumber[10] != DOB.Year.ToString()[3]) // checking the 11th charcter is the year digit of the DOB
                {
                    return false;
                }
                if(driverNumber[11] != '9' && driverNumber[11] != firstName[0]) //check 12th char is first name inital or 9
                {
                    return false;
                }
                if(driverNumber[12] != '9' && driverNumber[12] != middleName[0]) //cheking 13th char is middle name initial or 9
                {
                    return false;
                }
                int num = Convert.ToInt32(driverNumber[13]); //checking 14th char is number
                bool charactersValid = validString(driverNumber[14].ToString() + driverNumber[15].ToString(), 2, 2, false, true, false, false);
                if(!charactersValid) //checking the 15th & 16th characters are alphanumeric
                {
                    return false;
                }
                if(driverNumber.Length == 16) //paper licenses don't have an issue number so are only 16 long
                {
                    return true;
                }
                else if (driverNumber.Length == 18)
                {
                    int nums = Convert.ToInt32(driverNumber[16].ToString() + driverNumber[17].ToString());
                    return true; //cheking the last two character are numbers
                }
                else //invalid length
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool validIRDriversNumber(string text)
        {
            try
            {
                if(text.Length == 9)
                {
                    int num = Convert.ToInt32(text);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string boolToYN(bool input)
        {
            if(input)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        public static string boolToYN(string input)
        {
            if(input.ToLower() == "true")
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        public static string splitEmailTwoRows(string email, int maxLength)
        {
            try
            {
                if (email.Length <= maxLength)
                {
                    return email;
                }
                email = email.Trim();
                Regex atRg = new Regex("@\\S+");
                string atString = atRg.Match(email).Value;
                string nameString = email.Replace(atString," ");
                if(atString.Length > maxLength)
                {
                    atString = atString.Substring(0, maxLength - 3);
                    atString += "...";
                }
                if(nameString.Length > maxLength)
                {
                    nameString = nameString.Substring(0, maxLength - 3);
                    nameString += "...";
                }
                return nameString + atString;
            }
            catch
            {
                return email;
            }
        }
        public static bool validEmail(string email)
        {
            string[] splitEmail = email.Split('@');
            if(splitEmail.Length != 2) //doesn't have 1 @ symbol
            {
                return false;
            }
            string localAddress = splitEmail[0];
            string domain = splitEmail[1];

            if(localAddress.Length > 64 || localAddress.Length < 1)
            {
                return false;
            }
            Regex validCharactersRg = new Regex("[!#$%&'*+\\-/=?^_`{|}~A-Za-z0-9.]+");
            if(validCharactersRg.Match(localAddress).Value != localAddress) //checking the entire address follows the regex statement
            {
                return false;
            }
            Regex doubleDotRg = new Regex("[.]{2,}");
            if(doubleDotRg.IsMatch(localAddress)) //checking if there are consecutive '.'s which is not allowed
            {
                return false;
            }

            if(domain.Length > 255 || domain.Length < 1)
            {
                return false;
            }
            string[] dnsLabels = domain.Split('.');
            if(!domain.Contains('.'))
            {
                return false;
            }
            foreach(string label in dnsLabels)
            {
                if(label.Length > 63 || label.Length < 1)
                {
                    return false;
                }
                if(label[0] == '-' || label[label.Length-1] == '-') //hypen can't be first of last letter of a dns label
                {
                    return false;
                }
                Regex validRg = new Regex("[A-Za-z0-9\\-]+");
                if(validRg.Match(label).Value != label)
                {
                    return false;
                }
            }

            return true;


        }
        public static bool typedEmailInvalid(string email) //checking if the email is invalid as it is being typed
        {
            string[] splitEmail = email.Split('@');
            if (splitEmail.Length > 2) //doesn't have 2@s symbol
            {
                return true;
            }
            string localAddress = splitEmail[0];

            if (localAddress.Length > 64)
            {
                return true;
            }
            Regex validCharactersRg = new Regex("[!#$%&'*+\\-/=?^_`{|}~A-Za-z0-9.]+");
            if (validCharactersRg.Match(localAddress).Value != localAddress) //checking the entire address follows the regex statement
            {
                return true;
            }
            Regex doubleDotRg = new Regex("[.]{2,}");
            if (doubleDotRg.IsMatch(localAddress)) //checking if there are consecutive '.'s which is not allowed
            {
                return true;
            }

            try
            {
                string domain = splitEmail[1];

                if (domain.Length > 255)
                {
                    return true;
                }
                string[] dnsLabels = domain.Split('.');
                foreach (string label in dnsLabels)
                {
                    if (label.Length > 63)
                    {
                        return true;
                    }
                    if (label[0] == '-' || label[label.Length - 1] == '-') //hypen can't be first of last letter of a dns label
                    {
                        return true;
                    }
                    Regex validRg = new Regex("[A-Za-z0-9\\-]+");
                    if (validRg.Match(label).Value != label)
                    {
                        return true;
                    }
                }
            }
            catch
            {

            }

            return false;


        }
        public static string capitaliseString(string text)
        {
            try
            {
                string newString = "";
                bool firstLetter = true;
                for(int i = 0; i< text.Length;i++)
                {
                    if (Char.IsLetter(text[i]) && firstLetter == true)
                    {
                        firstLetter = false;
                        newString += text[i].ToString().ToUpper();
                    }
                    else
                    {
                        if (text[i] == ' ') //capitalise word after a space
                        {
                            firstLetter = true;
                        }
                        newString += text[i].ToString();
                    }
                }
                return newString;
            }
            catch

            {
                return text;
            }
        }
        public static string removeWhitespace(string text)
        {
            text = text.Trim();
            Regex rg = new Regex("\\s+");
            return rg.Replace(text, " ");
        }
        public static string removeSeconds(string text)
        {
            DateTime time = Convert.ToDateTime(text);
            return time.ToString("yyyy/MM/dd HH:mm");
        }
        public static string removeTime(string text)
        {
            DateTime time = Convert.ToDateTime(text);
            return time.ToString("d");
        }
        public static string getYear(string text)
        {
            DateTime time = Convert.ToDateTime(text);
            return time.Year.ToString();
        }
        public static bool timeIsInFuture(DateTime time)
        {
            try
            {
                if (time < DateTime.Now)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static string addCommaToNumber(int number)
        {
            string numText = number.ToString();
            return addCommaToNumber(numText);
        }
        public static string addCommaToNumber(string numText)
        {
            string newText = "";
            int offset = numText.Length % 4; //don't minus 1 so the first thing isn't a comam
            for (int i = numText.Length - 1; i >= 0; i--)
            {
                char digit = numText[i];
                if (i % 4 == offset)  //happens every 4th number
                {
                    newText = digit + "," + newText;
                }
                else
                {
                    newText = digit + newText;
                }
            }
            return newText;
        }
        public static DateTime maxDateTime(DateTime dateTime1, DateTime dateTime2)
        {
            if(dateTime1 > dateTime2)
            {
                return dateTime1;
            }
            else
            {
                return dateTime2;
            }
        }
        public static bool isAlphaNumeric(string testString,bool unicodeCharacters)
        {
            foreach(char character in testString)
            {
                if(baseLetters.Contains(Char.ToLower(character)))
                {
                    continue;
                }
                if(char.IsDigit(character))
                {
                    continue;
                }
                if(char.IsLetter(character) && unicodeCharacters)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool typedLicenseInvalid(string testString)
        {
            if(testString.Length > 16)
            {
                return true;
            }
            return !(isAlphaNumeric(testString, false));
        }
        public static void Remove_Illegal_Characters(TextBox textBox, Func<string, bool> illegalEvaulator)
        {
            int index = textBox.SelectionStart;
            if (illegalEvaulator(textBox.Text))
            {
                textBox.Text = (string)textBox.Tag;
                index--;
            }
            textBox.SelectionStart = index;
            textBox.SelectionLength = 0;
            textBox.Tag = textBox.Text;
        }
        public static bool typedUsernameInvalid(string testString)
        {
            if (testString.Length > 10)
            {
                return true;
            }
            return !(isAlphaNumeric(testString, false));
        }
        public static bool validPassword(string password)
        {
            //must be longer than 8 characters
            //can't be longer than 50 characters
            //needs mixed case
            //needs a digit
            //needs a special character
            //no whitespace
            if(password.Length < 8)
            {
                return false;
            }

            if (password.Length > 50)
            {
                return false;
            }
            bool lowerCaseCharacter = false;
            bool upperCaseCharacter = false;
            bool specialCharacter = false;
            bool numberCharacter = false;
            foreach(char character in  password)
            {
                if(Char.IsDigit(character))
                {
                    numberCharacter = true;
                    continue;
                }
                if(Char.IsWhiteSpace(character))
                {
                    return false;
                }
                if(Char.IsLetter(character))
                {
                    if(Char.ToUpper(character) == character)
                    {
                        upperCaseCharacter = true;
                        continue;
                    }
                    else
                    {
                        lowerCaseCharacter = true;
                        continue;
                    }
                }
                specialCharacter = true;
            }

            return lowerCaseCharacter && upperCaseCharacter && numberCharacter && specialCharacter;
        }
    }
}
