public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN / PROCESS:
        // 1. Create a new array of doubles with the size equal to 'length'.
        // 2. Use a loop that runs from index 0 up to length - 1.
        // 3. For each index i, compute the (i + 1)-th multiple of 'number':
        //      multiple = number * (i + 1)
        // 4. Store this multiple in the array at the position i.
        // 5. After the loop finishes, return the filled array.
        
        // Step 1: Create the array
        double[] result = new double[length];

        // Step 2-4: Fill the array with multiples of 'number'
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1); 
        }

        // Step 5: Return the array
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
