// Problem: Rearrange Array in Alternating Positive and Negative Numbers

// Question:
// Given an array `arr` of positive and negative numbers, rearrange the array such that positive and negative numbers alternate.
// Relative order of elements may be changed. If extra positive or negative numbers exist, they appear at the end.

// Input:
// First line contains size of array `n`
// Next line contains `n` integers (array elements)

// Output:
// Print the array after rearranging in alternating positive and negative order

// Example:
// Input: arr = [1, 2, 3, -4, -1, 4]
// Output: [1, -4, 2, -1, 3, 4]
// Explanation: Positive and negative numbers alternate. Extra positive numbers are at the end.

// Complexity:
// Time Complexity: O(n)  (due to right rotation during placement)
// Space Complexity: O(n)   (in-place rearrangement)

using System;
using System.Collections.Generic;

public class AlternatePosNegCorrect
{
    static void Rearrange(int[] arr)
    {
        var pos = new List<int>();
        var neg = new List<int>();

        // Separate while preserving order
        foreach (var x in arr)
        {
            if (x >= 0) pos.Add(x);
            else neg.Add(x);
        }

        int p = 0, q = 0, i = 0;
        // Start with the group that has more elements to minimize leftovers
        bool pickPos = pos.Count >= neg.Count;

        while (p < pos.Count && q < neg.Count)
        {
            if (pickPos)
            {
                arr[i++] = pos[p++];
            }
            else
            {
                arr[i++] = neg[q++];
            }
            pickPos = !pickPos;
        }

        // Append remaining elements (if any)
        while (p < pos.Count) arr[i++] = pos[p++];
        while (q < neg.Count) arr[i++] = neg[q++];
    }

    public static void Main(string[] args)
    {
        Console.Write("Enter size of array: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Enter element {i+1}: ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Rearrange(arr);

        Console.WriteLine("Array after alternating positive and negative: " + string.Join(" ", arr));
    }
}
