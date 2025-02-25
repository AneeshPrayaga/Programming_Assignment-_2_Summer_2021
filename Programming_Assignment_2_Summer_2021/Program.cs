using System;
using System.Collections.Generic;
using System.Linq;

namespace Programming_Assignment_2_Summer_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1");
            int[] nums1 = { 2, 5, 1, 3, 4, 7 };
            int[] nums2 = { 2, 1, 4, 7 };
            Intersection(nums1, nums2);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] nums = { 0, 1, 0, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            int Lnum = LuckyNumber(ar3);
            if (Lnum == -1)
                Console.WriteLine("Given Array doesn't have any lucky Integer");
            else
                Console.WriteLine("Lucky Integer for given array {0}", Lnum);

            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            Console.WriteLine("Enter the value for n:");
            int n = Int32.Parse(Console.ReadLine());
            int Ma = GenerateNums(n);
            Console.WriteLine("Maximun Element in the Generated Array is {0}", Ma);
            Console.WriteLine();

            //Question 5

            Console.WriteLine("Question 5");
            List<List<string>> cities = new List<List<string>>();
            cities.Add(new List<string>() { "London", "New York" });
            cities.Add(new List<string>() { "New York", "Tampa" });
            cities.Add(new List<string>() { "Delhi", "London" });
            string Dcity = DestCity(cities);
            Console.WriteLine("Destination City for Given Route is : {0}", Dcity);

            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            int[] Nums = { 2, 7, 11, 15 };
            int target_sum = 9;
            targetSum(Nums, target_sum);
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int K = 3;
            RotateArray(arr, K);

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] arr9 = { 5,4,-1,7,8};
            int Ms = MaximumSum(arr9);
            Console.WriteLine("Maximun Sum contiguous subarray {0}", Ms);
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int[] costs = { 10, 15, 20 };
            int minCost = MinCostToClimb(costs);
            Console.WriteLine("Minium cost to climb the top stair {0}", minCost);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        //Given two integer arrays nums1 and nums2, return an array of their intersection.
        //Each element in the result must be unique and you may return the result in any order.
        //Example 1:
        //Input: nums1 = [1,2,2,1], nums2 = [2,2]
        //Output: [2]
        //Example 2:
        //Input: nums1 = [4,9,5], nums2 = [9,4,9,8,4]
        //Output: [9,4]
        //
        /// </summary>

        public static void Intersection(int[] nums1, int[] nums2)
        {
            try
            {
                var Intersection1 = nums2.Intersect(nums2);//get the intersection - meaning only the numbers which are present in both
                foreach (int x in Intersection1)
                {
                    Console.WriteLine(x);//print them
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 2:
        /// <summary>
        //Given a sorted array of distinct integers and a target value, return the index if the target is found.If not, return the index where it would be if it were inserted in order.
        //Note: You must write an algorithm with O(log n) runtime complexity.
        //Example 1:
        //Input: nums = [1, 3, 5, 6], target = 5
        //Output: 2
        //Example 2:
        //Input: nums = [1, 3, 5, 6], target = 2
        //Output: 1
        //Example 3:
        //Input: nums = [1, 3, 5, 6], target = 7
        //Output: 4
        //Example 4:
        //Input: nums = [1, 3, 5, 6], target = 0
        //Output: 0
        /// </summary>

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int min = 0;
                int max = nums.Length - 1;//maximum length of the array
                while (min <= max)
                {
                    int mid = (min + max) / 2;//mid point of array and then it chages accordingly
                                              //Console.WriteLine("my mid is " + mid);
                    if (target == nums[mid])//initial target
                    {
                        return ++mid;//return index on mid with length 1
                    }
                    else if (target < nums[mid])//return second mid
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }

                }
                return max + 1;//if nothing element is not present search the index adn add one
            }
            catch
            {
                throw;
            }
        }


        //Question 3
        /// <summary>
        //Given an array of integers arr, a lucky integer is an integer which has a frequency in the array equal to its value.
        //Return a lucky integer in the array. If there are multiple lucky integers return the largest of them. If there is no lucky integer return -1.
        //Example 1:
        //Input: arr = [2, 2, 3, 4]
        //Output: 2
        //Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        /// </summary>

        private static int LuckyNumber(int[] nums)
        {
            try
            {
                List<int> SortingLucky = new List<int>();
                var myarray = nums.Distinct().ToArray();//get the distinct ones in another array
                int luckycount = 0;//initial count is zero
                Dictionary<int, int> dict = new Dictionary<int, int>();//new dicitionary

                foreach (var c in myarray)//take my array and iterate through distinct ones
                {

                    foreach (var inside in nums)//inside this iterate in all the numbers in num
                    {

                        if (inside == c)//if numbers are equal then increment lucky count
                        {
                            luckycount++;
                        }

                    }

                    dict.Add(c, luckycount);//add the count in the dictionary
                    luckycount = 0;//then lucky count  =0
                }



                foreach (var l in dict)//iterate in dictionary
                {
                    if (l.Key == l.Value)//if key and value are equal then we got our lucky number
                    {
                        SortingLucky.Add(l.Key);//sort it



                    }
                }


                SortingLucky.Sort();//sort it accordingly



                if (SortingLucky.Count != 0)
                {
                    return SortingLucky[SortingLucky.Count - 1];//return the index
                }
                else
                {
                    return -1;//if nothing is there then return  -1 
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 4:
        /// <summary>
        //You are given an integer n.An array nums of length n + 1 is generated in the following way:
        //•	nums[0] = 0
        //•	nums[1] = 1
        //•	nums[2 * i] = nums[i]  when 2 <= 2 * i <= n
        //•	nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n
        // Return the maximum integer in the array nums.

        //Example 1:
        //Input: n = 7
        //Output: 3
        //Explanation: According to the given rules:
        //nums[0] = 0
        //nums[1] = 1
        //nums[(1 * 2) = 2] = nums[1] = 1
        //nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
        //nums[(2 * 2) = 4] = nums[2] = 1
        //nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
        //nums[(3 * 2) = 6] = nums[3] = 2
        //nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
        //Hence, nums = [0, 1, 1, 2, 1, 3, 2, 3], and the maximum is 3.

        /// </summary>
        private static int GenerateNums(int n)
        {
            try
            {
                var myarray = new int[n + 1];//CREATE A NEW ARRAY OF LENGTH  n+1
                myarray[0] = 0;//initial is zero
                myarray[1] = 1;//first one is 1 
                for (int i = 1; i < n + 1; i++)//start iteration
                {
                    if ((i * 2) + 1 >= n + 1 || i * 2 >= n + 1)
                    {
                        break;//if the value exceeds then break
                    }
                    myarray[i * 2] = myarray[i];//then code the rule in this
                    myarray[(i * 2) + 1] = myarray[i] + myarray[i + 1];//second rule



                }
                Array.Sort(myarray);//sort the array
                return myarray[n];//return the last one  

            }
            catch
            {
                throw;
            }

        }

        //Question 5
        /// <summary>
        //You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi.Return the destination city, that is, the city without any path outgoing to another city.
        //It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        //Example 1:
        //Input: paths = [["London", "New York"], ["New York","Lima"], ["Lima","Sao Paulo"]]
        //Output: "Sao Paulo" 
        //Explanation: Starting at "London" city you will reach "Sao Paulo" city which is the destination city.Your trip consist of: "London" -> "New York" -> "Lima" -> "Sao Paulo".
        /// </summary>
        public static string DestCity(List<List<string>> paths)
        {
            try
            {
                List<string> Citylist = new List<string>();//create a new list 

                foreach (var path in paths)//for every city in the list iterate the path
                {
                    Citylist.Add(path[1]);//add it to the path
                }

                foreach (var path in paths)
                {
                    if (Citylist.Contains(path[0]))//if it contains the city which is already in then find it
                    {
                        Citylist.Remove(path[0]);//then remove it
                    }

                }

                return Citylist.Last();//return the final city

            }

            catch (Exception)
            {

                throw;
            }
        }

        //Question 6:
        /// <summary>
        //Given an array of integers numbers that is already sorted in non-decreasing order, find two numbers such that they add up to a specific target number.
        //Print the indices of the two numbers (1-indexed) as an integer array answer of size 2, where 1 <= answer[0] < answer[1] <= numbers.Length.
        //You may not use the same element twice, there will be only one solution for a given array
        //Example 1:
        //Input: numbers = [2,7,11,15], target = 9
        //Output: [1,2]
        //Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.

        /// </summary>
        private static void targetSum(int[] nums, int target)
        {
            try
            {
                for (int i = 0; i < nums.Length; i++)//take the first array
                {

                    for (int j = i + 1; j < nums.Length; j++)//then compare it with all the elements next
                    {

                        if (nums[j] == target - nums[i])//after the subtraction find the answer
                        {


                            Console.WriteLine("{0} {1}", 1 + Array.IndexOf(nums, nums[i]), Array.IndexOf(nums, nums[j]) + 1);//then print the index of all the numbers

                        }
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
                Dictionary<int, List<int>> MyDict = new Dictionary<int, List<int>>();//create a dictionary 
                var scoresOfIds = new List<int>();//a list for scores
                //Console.WriteLine(items.Length);
                for (int i = 0; i < items.Length / 2; i++)//iterate through array
                {
                    //Console.WriteLine("{"+items[i,0]+","+items[i,1]+"}");
                    //Console.WriteLine(i);
                    if (!MyDict.ContainsKey(items[i, 0]))//if no key then add, if there is key go to else
                    {
                        //Console.WriteLine(items[i,0]);
                        scoresOfIds = new List<int>();//create a new list for scores for the first time
                        MyDict.Add(items[i, 0], scoresOfIds);//then add the values
                    }
                    else
                    {
                        scoresOfIds = MyDict[items[i, 0]];//if it already exists then indicate this as the list
                    }
                    scoresOfIds.Add(items[i, 1]);//add the scores
                    MyDict[items[i, 0]] = scoresOfIds;//add it to dictionary
                }


                foreach (var IdScore in MyDict)//iterate through dictionary
                {
                    int Id_Student = IdScore.Key;//take the key
                    List<int> Score_Value = IdScore.Value;//get the values of the list
                    Score_Value.Sort();//sort it
                    Score_Value.Reverse();//descending sort
                    int sum = 0;//initial sum is zero
                    for (int i = 0; i < 5; i++)
                    {
                        //Console.WriteLine(value[i]);
                        sum = sum + Score_Value[i];//add the top 5 scores
                    }

                    Console.WriteLine("[" + Id_Student + "," + sum / 5 + "]");//print them
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 8
        /// <summary>
        //Given an array, rotate the array to the right by k steps, where k is non-negative.
        //Print the Final array after rotation.
        //Example 1:
        //Input: nums = [1, 2, 3, 4, 5, 6, 7], k = 3
        //Output: [5,6,7,1,2,3,4]
        //Explanation:
        //rotate 1 steps to the right: [7,1,2,3,4,5,6]
        //rotate 2 steps to the right: [6,7,1,2,3,4,5]
        //rotate 3 steps to the right: [5,6,7,1,2,3,4]
        //Example 2:
        //Input: nums = [-1,-100,3,99], k = 2
        //Output: [3,99,-1,-100]
        //Explanation: 
        //rotate 1 steps to the right: [99,-1,-100,3]
        //rotate 2 steps to the right: [3,99,-1,-100]
        /// </summary>

        private static void RotateArray(int[] arr, int k)
        {
            try
            {
                int n = arr.Length;//take the length of the array
                k = k % n;//get the reminder to rotate the array

                for (int i = 0; i < n; i++)
                {
                    if (i < k)//if rotation is less then k
                    {

                        // Printing right elements according to i

                        Console.Write(arr[n + i - k] + " ");//print all the elements after the i
                    }
                    else
                    {
                        // 'k' elements
                        Console.Write(arr[i - k] + " ");//all of them before it
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 9
        /// <summary>
        //Given an integer array nums, find the contiguous subarray(containing at least one number) which has the largest sum and return its sum
        //Example 1:
        //Input: nums = [-2,1,-3,4,-1,2,1,-5,4]
        //Output: 6
        //Explanation: [4,-1,2,1] has the largest sum = 6.
        //Example 2:
        //Input: nums = [1]
        //Output: 1
        // Example 3:
        // Input: nums = [5,4,-1,7,8]
        //Output: 23
        /// </summary>

        private static int MaximumSum(int[] arr9)
        {
            try
            {
                int MaximumoftheArray = arr9[0];//take the maximum of teh array and assign it to the first element
                int CurrentMaximum = arr9[0];//take the current maximum and assign it to the first element

                for (int i = 1; i < arr9.Length; i++)//iterate it through loop
                {

                    CurrentMaximum = Math.Max(arr9[i], CurrentMaximum + arr9[i]);//assignment of teh current maximum comparing all the elements
                    MaximumoftheArray = Math.Max(MaximumoftheArray, CurrentMaximum);//checking wirh the current maximum and the first element and loop prodeeds accordingly

                }

                return MaximumoftheArray;

            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        //You are given an integer array cost where cost[i] is the cost of ith step on a staircase.Once you pay the cost, you can either climb one or two steps.
        //You can either start from the step with index 0, or the step with index 1.
        //Return the minimum cost to reach the top of the floor.
        //Example 1:
        //Input: cost = [10, 15, 20]
        //Output: 15
        //Explanation: Cheapest is: start on cost[1], pay that cost, and go to the top.

        /// </summary>

        private static int MinCostToClimb(int[] costs)
        {
            try
            {

                int[] minimumCostToTop = new int[costs.Length + 1];//create a new array with one length grater than the normal array, to reach the last position


                for (int i = 2; i < minimumCostToTop.Length; i++)//check for the elements and then iterate through the array
                {
                    int one_Step = minimumCostToTop[i - 1] + costs[i - 1];//cost for one step
                    int Two_Steps = minimumCostToTop[i - 2] + costs[i - 2];//cost for 2 steps
                    minimumCostToTop[i] = Math.Min(one_Step, Two_Steps);//the get the minimum of the steps
                }


                return minimumCostToTop[minimumCostToTop.Length - 1];//the final element reaches to the top and then we get the cost.

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
