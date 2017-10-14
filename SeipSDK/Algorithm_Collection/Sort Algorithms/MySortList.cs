using System;
using System.Collections.Generic;

namespace Algorithm_Collection.Sort_Algorithms
{
    public class MySortList<T> : List<T> where T : IComparable<T>
    {

        private bool sorted = false;
        private int combSortGap;
        private const double combSortShrink = 1.3;

        public void StupidSort()
        {
            int position = 0;
            while (position < Count)
            {
                if (position == 0 || this[position].CompareTo(this[position - 1]) >= 0)
                {
                    position += 1;
                }
                else
                {
                    SwapElements(position, position - 1);
                    position -= 1;
                }
            }
        }

        public void QuickSort(int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                int pivot = SplitList(leftIndex, rightIndex);
                QuickSort(leftIndex, pivot - 1);
                QuickSort(pivot + 1, rightIndex);
            }
        }

        public void CombSort()
        {
            combSortGap = Count;
            while (!sorted)
            {
                // Update the combSortGap value for a next comb
                combSortGap = (int)Math.Floor(combSortGap / combSortShrink);
                if (combSortGap > 1)
                {
                    sorted = false; // We are never sorted as long as combSortGap > 1
                }
                else
                {
                    combSortGap = 1;
                    sorted = true; // If there are no swaps this pass, we are done
                }

                // A single "comb" over the input list
                int i = 0;
                while (i + combSortGap < Count)
                {   // See Shell sort for a similar idea
                    if (this[i].CompareTo(this[i + combSortGap]) > 0)
                    {
                        SwapElements(i, i + combSortGap);
                        sorted = false;
                    }
                    i++;
                }
            }
        }

        /// <summary>
        /// Run a SelectionSort Algorithm
        /// Complexity: O(n^2)
        /// /// </summary>
        public void SelectionSort()
        {
            int min = -1;
            for (int i = 0; i < Count - 1; i++)
            {
                min = i;
                for (int k = i + 1; k < Count; k++)
                {
                    if (this[min].CompareTo(this[k]) > 0)
                        min = k;
                }
                SwapElements(i, min);
            }
        }

        /// <summary>
        /// Runs a Insertion sort Algorithm
        /// Minimal Complexity: O(2(n-1))
        /// Maximal Complexity: O(n^2)
        /// </summary>
        public void InsertionSort()
        {
            for (int i = 1; i < Count; i++)
            {
                T t = this[i];
                int j = i;
                while (j > 0 && this[j - 1].CompareTo(t) > 0)
                {
                    this[j] = this[j - 1];
                    j--;
                }
                this[j] = t;
            }
        }


        public void BubbleSort()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                sorted = true;
                for (int k = 1; k <= i; k++)
                {
                    if (this[k - 1].CompareTo(this[k]) > 0)
                    {
                        sorted = false;
                        SwapElements(k - 1, k);
                    }
                }
                if (sorted)
                    break;
            }
        }

        /// <summary>
        /// Splits the for the pivot Element
        /// Is used for the QuickSort
        /// </summary>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        private int SplitList(int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            //Starte mit j links vom Pivotelement
            int j = rightIndex - 1;
            T pivot = this[rightIndex];

            do
            {
                //Suche von links ein Element, welches größer als das Pivotelement ist
                while (this[i].CompareTo(pivot) <= 0 && i < rightIndex)
                    i += 1;

                //Suche von rechts ein Element, welches kleiner als das Pivotelement ist
                while (this[j].CompareTo(pivot) >= 0 && j > leftIndex)
                    j -= 1;

                if (i < j)
                {
                    // tausche this[i] mit this[j]
                    SwapElements(i, j);                    
                }

            } while (i < j);
            //solange i an j nicht vorbeigelaufen ist 

            // Tausche Pivotelement (this[rechts]) mit neuer endgültiger Position (this[i])

            if (this[i].CompareTo(pivot) > 0)
            {
                // tausche this[i] mit this[rechts]
                SwapElements(i, rightIndex);
            }
            return i; // gib die Position des Pivotelements zurück
        }

        private void SwapElements(int i, int j)
        {
            T temp = this[j];
            this[j] = this[i];
            this[i] = temp;
        }

        /// <summary>
        /// Checks if a List is Sorted
        /// </summary>
        /// <returns></returns>
        public bool IsSorted()
        {
            for (int i = 1; i < Count; i++)
            {
                if (this[i - 1].CompareTo(this[i]) > 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
