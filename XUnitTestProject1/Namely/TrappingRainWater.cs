using Xunit;
using System;
using System.Collections.Generic;
using FluentAssertions;

namespace Namely
{
  /*https://leetcode.com/problems/trapping-rain-water/
  Given n non-negative integers representing an elevation map where the width of each bar is 1, 
  compute how much water it can trap after raining.
Example 1:
Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. 
  In this case, 6 units of rain water (blue section) are being trapped.
Example 2:
Input: height = [4,2,0,3,2,5]
Output: 9
Constraints:
n == height.length
1 <= n <= 2 * 104
0 <= height[i] <= 105*/
  public class TrappingRainWater
  {
    [Fact]
    public void Test()
    {
      GetUsingBruteForceAndNestedLoops(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }).Should().Be(6);
      GetUsingBruteForceAndNestedLoops(new[] { 4, 2, 0, 3, 2, 5 }).Should().Be(9);

      Get(new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }).Should().Be(6);
      Get(new[] { 4, 2, 0, 3, 2, 5 }).Should().Be(9);
      GetOptimised(new [] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }).Should().Be(6);
      GetOptimised(new [] { 4, 2, 0, 3, 2, 5 }).Should().Be(9);
    }
    /*https://www.enjoyalgorithms.com/blog/trapping-rain-water
    Time Complexity: O(n*n)| space compexility: O(1)*/
    int GetUsingBruteForceAndNestedLoops(int[] height)
    {
      var n = height.Length;
      if (n <= 2)
      {
        return 0;
      }
      int trappedWater = 0;
      for (int i = 0; i < n; i = i + 1)
      {
        int leftMaxHeight = 0, rightMaxHeight = 0;
        for (int k = i; k >= 0; k = k - 1)
        {
          leftMaxHeight = Math.Max(height[k], leftMaxHeight);
        }
        for (int j = i; j < n; j = j + 1)
        {
          rightMaxHeight = Math.Max(height[j], rightMaxHeight);
        }
        trappedWater = trappedWater + Math.Min(leftMaxHeight, rightMaxHeight) - height[i];
      }
      return trappedWater;
    }
    /*https://leetcode.com/problems/trapping-rain-water/discuss/17391/Share-my-short-solution.
    Start check from both side, move the point where wall is lower
    (becuase taller wall may leak water in the other lower side)
    leftmax and rightmax are used to record walls, 
    if the land is lower then the wall means that it can hold water
    if the wall found taller than the max height wall in the other side, stop there
    (because taller wall may leak water in the other lower side). then move the lower side point
    heights: 2,0,1,0,3=>
    leftindex   0 1 2 3 4
    rightindex  4
    leftmax     2
    rightmax    3
    water       0 2 3 5 5
     */
    int GetOptimised(int[] heights)
    {
      int water = 0;
      if (heights.Length < 3)
      {
        return water;
      }
      int leftmax = heights[0];
      int rightmax = heights[heights.Length-1];
      int leftindex = 1;
      int rightindex = heights.Length - 2;
      while(leftindex<=rightindex)
      {
        if(leftmax<=rightmax)
        {
          leftmax = Math.Max(leftmax, heights[leftindex]);
          water= water+leftmax- heights[leftindex];
          leftindex++;
        }
        else
        {
          rightmax = Math.Max(rightmax, heights[rightindex]);
          water = water + rightmax - heights[rightindex];
          rightindex--;
        }
      }
      return water;
    }
    int Get(int[] arr)
    {
      int n = arr.Length;
      // left[i] contains height of tallest bar to theleft of i'th bar including itself
      int[] left = new int[n];
      // Right [i] contains height of tallest bar to the right of ith bar including itself
      int[] right = new int[n];     
      int water = 0;// Initialize result
      left[0] = arr[0];
      for (int i = 1; i < n; i++)
        left[i] = Math.Max(left[i - 1], arr[i]);

      right[n - 1] = arr[n - 1];
      for (int i = n - 2; i >= 0; i--)
        right[i] = Math.Max(right[i + 1], arr[i]);

      // Calculate the accumulated water element by element consider the amount of water on i'th bar, the
      // amount of water accumulated on this particularbar will be equal to min(left[i], right[i]) - arr[i] .
      for (int i = 0; i < n; i++)
        water += Math.Min(left[i], right[i]) - arr[i];
      return water;
    }    
  }
}
