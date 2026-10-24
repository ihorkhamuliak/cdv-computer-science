using System;

namespace Zad2_4_Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 2: our own conversion, Convert.ToString is used only as a check
            Console.WriteLine("=== Task 2: decimal -> binary ===");
            int number = ReadInt("Enter a non-negative whole number: ", 0, int.MaxValue);
            Console.WriteLine($"{number} in binary:                  {ToBinary(number)}");
            Console.WriteLine($"Check with Convert.ToString(n, 2): {Convert.ToString(number, 2)}");
            Console.WriteLine();

            // Tasks 3 and 4 work on 8 bits (byte), so every bit is visible
            Console.WriteLine("=== Task 3: bit shift (8 bits, byte) ===");
            byte value = (byte)ReadInt("Enter a number from 0 to 255: ", 0, 255);
            int positions = ReadInt("Enter how many positions to move (1-7): ", 1, 7);

            // The result of << is an int, so (byte) cuts it back to 8 bits
            byte shiftedLeft = (byte)(value << positions);
            byte shiftedRight = (byte)(value >> positions);

            Console.WriteLine($"Number         {value,3} = {ToBinary(value, 8)}");
            Console.WriteLine($"Shift left  {positions}: {shiftedLeft,3} = {ToBinary(shiftedLeft, 8)}   (bits pushed out on the left are lost, zeros come in on the right)");
            Console.WriteLine($"Shift right {positions}: {shiftedRight,3} = {ToBinary(shiftedRight, 8)}   (bits pushed out on the right are lost, zeros come in on the left)");
            Console.WriteLine();

            Console.WriteLine("=== Task 4: bit rotation (8 bits, byte) ===");
            byte rotatedLeft = RotateLeft(value, positions);
            byte rotatedRight = RotateRight(value, positions);

            Console.WriteLine($"Number          {value,3} = {ToBinary(value, 8)}");
            Console.WriteLine($"Rotate left  {positions}: {rotatedLeft,3} = {ToBinary(rotatedLeft, 8)}   (bits pushed out on the left come back on the right)");
            Console.WriteLine($"Rotate right {positions}: {rotatedRight,3} = {ToBinary(rotatedRight, 8)}   (bits pushed out on the right come back on the left)");
        }

        // Repeated division by 2: each remainder is the next bit, from right to left.
        // width pads the result with zeros on the left, e.g. 5 -> 00000101 for width 8.
        static string ToBinary(int number, int width = 1)
        {
            string bits = "";
            do
            {
                bits = (number % 2) + bits;
                number /= 2;
            } while (number > 0);
            return bits.PadLeft(width, '0');
        }

        // Rotation = shift + put the lost bits back on the other side
        static byte RotateLeft(byte value, int positions)
        {
            return (byte)((value << positions) | (value >> (8 - positions)));
        }

        static byte RotateRight(byte value, int positions)
        {
            return (byte)((value >> positions) | (value << (8 - positions)));
        }

        static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                    return value;
                Console.WriteLine($"Please enter a whole number from {min} to {max}.");
            }
        }
    }
}
