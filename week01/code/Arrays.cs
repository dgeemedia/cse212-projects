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
        // PLAN 
        // 1. Create an array called result whose size is equal to `length`.
        // 2. Loop through every index i from 0 to length – 1:
        //      a. The multiple we need on this iteration is (i + 1) × number
        //         because the first multiple is number × 1, the second is number × 2, etc.
        //      b. Store that calculated value in result[i].
        // 3. After the loop finishes, return the populated result array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

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
        // PLAN
        // 1. Handle edge cases:
        //      • If the list is empty, there is nothing to rotate → exit.
        // 2. Reduce amount so it is within the list bounds:
        //      • amount = amount mod data.Count  (rotating by the list’s exact length
        //        or multiples thereof produces the same list).
        // 3. If the normalized amount is zero, the list is already in the desired state → exit.
        // 4. Split the list into two logical slices:
        //      *tail  = last  amount  elements  (indices Count – amount … Count – 1)
        //      *head  = first Count – amount elements (indices 0 … Count – amount – 1)
        // 5. Clear the original list so we can rebuild it in rotated order.
        // 6. Append the tail slice first, followed by the head slice.
        //    The list is now rotated to the right by `amount`.

        if (data.Count == 0) return;        // Step 1
        amount %= data.Count;               // Step 2
        if (amount == 0) return;            // Step 3

        // Step 4
        List<int> tail = data.GetRange(data.Count - amount, amount);  // last part
        List<int> head = data.GetRange(0, data.Count - amount);       // remaining front part

        // Step 5‑6
        data.Clear();
        data.AddRange(tail);  // moved to first
        data.AddRange(head);  // rest follows
    }
}
