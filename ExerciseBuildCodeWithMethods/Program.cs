/*
if ipAddress consists of 4 numbers
and
if each ipAddress number has no leading zeroes
and
if each ipAddress number is in range 0 - 255

then ipAddress is valid

else ipAddress is invalid
*/

// my solution
void ParseValidIPAddress(string ip)
{
    if (ip == null)
    {
        return;
    }

    string[] splitString = ip.Split(".");

    if (splitString.Length != 4)
    {
        Console.WriteLine("Not a valid IPV4 Address Format");
        return;
    }

    int[] octets = new int[4];

    for (int i = 0; i < splitString.Length; i++)
    {

        // Before parsing check if the string does not have 0 in the beginning
        if (splitString[i][0] == '0' && splitString[i].Length > 1)
        {
            Console.WriteLine("The IP Address must not have leading 0 - ");
            return;
        }

        if (!int.TryParse(splitString[i], out int validOctet))
        {
            Console.WriteLine("Not a valid IPV4 Octet");
            return;
        }

        // Check leading octet if 0
        if (i == 0)
        {
            if (validOctet == 0)
            {
                Console.WriteLine("Leading Data cant be 0");
                return;
            }
        }

        if (validOctet >= 0 && validOctet < 256)
        {
            octets[i] = validOctet;
        }
        else
        {
            Console.WriteLine($"The Octet Value is not a valid value : {validOctet}");
            return;
        }
    }
    string IPAddressValue = string.Join(".", octets.Select(x => x.ToString()));
    Console.WriteLine($"The entered IP Address {IPAddressValue}");
}


// ParseValidIPAddress("10.1.1.20");
// ParseValidIPAddress("10.4.a.4");
// ParseValidIPAddress("10.1.4.a.4");
// ParseValidIPAddress("123123");
// ParseValidIPAddress("197.0.1.23");
// ParseValidIPAddress("197.013.255");

// Their Solution



string[] ipv4Input = { "107.31.1.5", "255.0.0.255", "555..0.555", "255...255" };
bool validLength = false;
bool validZeroes = false;
bool validRange = false;

foreach (string ipIn in ipv4Input)
{
    string[] address = ipIn.Split(".", StringSplitOptions.RemoveEmptyEntries);

    void ValidateLength()
    {
        validLength = address.Length == 4;
    };

    void ValidateZeroes()
    {
        foreach (string number in address)
        {
            if (number.Length > 1 && number.StartsWith("0"))
            {
                validZeroes = false;
                return;
            }
        }
        validZeroes = true;
    }
    void ValidateRange()
    {
        foreach (string number in address)
        {
            int value = int.Parse(number);
            if (value < 0 || value > 255)
            {
                validRange = false;
                return;
            }
        }
        validRange = true;
    }

    ValidateLength();
    ValidateZeroes();
    ValidateRange();

    if (validLength && validZeroes && validRange)
    {
        Console.WriteLine($"ip is a valid IPv4 address");
    }
    else
    {
        Console.WriteLine($"ip is an invalid IPv4 address");
    }
};