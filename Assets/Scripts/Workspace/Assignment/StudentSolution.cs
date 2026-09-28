using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assignment
{
    public class StudentSolution : IAssignment
    {
        #region Lecture

        // 1. Selection Sort - เรียงจากน้อยไปมาก
        public int[] LCT01_SelectionSortAscending(int[] numbers)
        {
            if (numbers == null) return null;

            // คัดลอก array เพื่อไม่ให้กระทบข้อมูลเดิม
            int[] arr = (int[])numbers.Clone();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int minIndex = i;

                // หาตำแหน่งของค่าน้อยที่สุดในส่วนที่เหลือ
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // สลับค่าน้อยสุดมาไว้ข้างหน้า
                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            return arr;
        }

        // 2. Bubble Sort - เรียงจากน้อยไปมาก
        public int[] LCT02_BubbleSortAscending(int[] numbers)
        {
            if (numbers == null) return null;

            int[] arr = (int[])numbers.Clone();
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                // เปรียบเทียบคู่ข้างเคียง
                for (int j = 0; j < n - i - 1; j++)
                {
                    // ถ้าตัวซ้ายมากกว่าตัวขวา ให้สลับที่กัน
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return arr;
        }

        // 3. Insertion Sort - เรียงจากน้อยไปมาก
        public int[] LCT03_InsertionSortAscending(int[] numbers)
        {
            if (numbers == null) return null;

            int[] arr = (int[])numbers.Clone();

            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                // ขยับค่าที่มากกว่า key ไปทางขวา
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                // แทรก key ลงในตำแหน่งที่ถูกต้อง
                arr[j + 1] = key;
            }

            return arr;
        }

        #endregion

        #region Assignment

        // AS01: Selection Sort - เรียงจากมากไปน้อย (เหมือนจัดอันดับคะแนน)
        public int[] AS01_SelectionSortDescending(int[] numbers)
        {
            if (numbers == null) return null;

            int[] arr = (int[])numbers.Clone();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int maxIndex = i;

                // หาตำแหน่งของค่ามากที่สุดในส่วนที่เหลือ
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] > arr[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                // สลับค่ามากสุดมาไว้ข้างหน้า
                int temp = arr[i];
                arr[i] = arr[maxIndex];
                arr[maxIndex] = temp;
            }

            return arr;
        }

        // AS02: Bubble Sort - เรียงจากมากไปน้อย
        public int[] AS02_BubbleSortDescending(int[] numbers)
        {
            if (numbers == null) return null;

            int[] arr = (int[])numbers.Clone();
            int n = arr.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // ถ้าตัวซ้ายน้อยกว่าตัวขวา ให้สลับเพื่อให้ค่ามากไปอยู่ด้านหน้า
                    if (arr[j] < arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            return arr;
        }

        // AS03: Insertion Sort - เรียงจากมากไปน้อย
        public int[] AS03_InsertionSortDescending(int[] numbers)
        {
            if (numbers == null) return null;

            int[] arr = (int[])numbers.Clone();

            for (int i = 1; i < arr.Length; i++)
            {
                int key = arr[i];
                int j = i - 1;

                // ขยับค่าที่น้อยกว่า key ไปทางขวา
                while (j >= 0 && arr[j] < key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                // แทรก key ลงในตำแหน่งที่ถูกต้อง
                arr[j + 1] = key;
            }

            return arr;
        }

        // AS04: หาตัวเลขที่มีค่ามากเป็นอันดับสอง (ข้ามค่าซ้ำ)
        public int AS04_FindTheSecondLargestNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;
            if (numbers.Length == 1) return numbers[0];

            // เรียงลำดับจากมากไปน้อย
            int[] sorted = (int[])numbers.Clone();
            Array.Sort(sorted);
            Array.Reverse(sorted);

            int max = sorted[0];

            // หาค่าแรกที่น้อยกว่าค่าสูงสุด
            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i] < max)
                {
                    return sorted[i];
                }
            }

            return max;
        }

        #endregion

        #region Extra

        // EX01: หาความยาวของชุดตัวเลขที่เรียงติดต่อกันที่ยาวที่สุด
        public int EX01_FindLongestConsecutiveSequence(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;
            if (numbers.Length == 1) return 1;

            // เรียงลำดับจากน้อยไปมาก
            int[] sorted = (int[])numbers.Clone();
            Array.Sort(sorted);

            int maxStreak = 1;
            int currentStreak = 1;

            for (int i = 1; i < sorted.Length; i++)
            {
                // ถ้าค่าซ้ำกันให้ข้ามไป
                if (sorted[i] == sorted[i - 1])
                {
                    continue;
                }

                // ถ้าตัวปัจจุบันมากกว่าตัวก่อนหน้าอยู่ 1 แสดงว่าเรียงต่อกัน
                if (sorted[i] == sorted[i - 1] + 1)
                {
                    currentStreak++;
                }
                else
                {
                    // ไม่ต่อเนื่อง รีเซ็ตนับใหม่
                    currentStreak = 1;
                }

                if (currentStreak > maxStreak)
                {
                    maxStreak = currentStreak;
                }
            }

            return maxStreak;
        }

        #endregion
    }
}
