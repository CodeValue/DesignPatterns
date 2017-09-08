using System;
using System.Collections.Generic;

namespace Strategy.Sample1 {
	class Program {
		static void Main() {
			// Two contexts following different strategies
			var studentRecords = new SortedList() {
                new Student{ Name = "Homer", Id = "655-00-2944" },
                new Student{ Name = "Marge", Id = "760-94-9844" },
                new Student{ Name = "Bart", Id = "154-33-2009" },
                new Student{ Name = "Lisa", Id = "487-43-1665" },
                new Student{ Name = "Maggie", Id = "133-98-8399" },
         };

			studentRecords.SortStrategy = new QuickSort();
			studentRecords.SortStudents();

			studentRecords.SortStrategy = new ShellSort();
			studentRecords.SortStudents();

			studentRecords.SortStrategy = new MergeSort();
			studentRecords.SortStudents();
		}
	}

	// The 'Strategy' interface
	interface ISortStrategy {
		void Sort(IList<Student> list);
	}

	// A 'ConcreteStrategy' class
	class QuickSort : ISortStrategy {
		public void Sort(IList<Student> list) {
			// Call overloaded Sort
			Sort(list, 0, list.Count - 1);
			Console.WriteLine("QuickSorted list ");
		}

		// Recursively sort
		private void Sort(IList<Student> list, int left, int right) {
			int lhold = left;
			int rhold = right;

			// Use a random pivot
			var random = new Random();
			int pivot = random.Next(left, right);
			Swap(list, pivot, left);
			pivot = left;
			left++;

			while(right >= left) {
				int compareleft = list[left].Name.CompareTo(list[pivot].Name);
				int compareright = list[right].Name.CompareTo(list[pivot].Name);

				if((compareleft >= 0) && (compareright < 0)) {
					Swap(list, left, right);
				}
				else {
					if(compareleft >= 0) {
						right--;
					}
					else {
						if(compareright < 0) {
							left++;
						}
						else {
							right--;
							left++;
						}
					}
				}
			}
			Swap(list, pivot, right);
			pivot = right;

			if(pivot > lhold) Sort(list, lhold, pivot);
			if(rhold > pivot + 1) Sort(list, pivot + 1, rhold);
		}

		// Swap helper function
		private void Swap(IList<Student> list, int left, int right) {
			var temp = list[right];
			list[right] = list[left];
			list[left] = temp;
		}
	}

	// A 'ConcreteStrategy' class
	class ShellSort : ISortStrategy {
		public void Sort(IList<Student> list) {
			// ShellSort();  not-implemented
			Console.WriteLine("ShellSorted list ");
		}
	}

	// A 'ConcreteStrategy' class
	class MergeSort : ISortStrategy {
		public void Sort(IList<Student> list) {
			// MergeSort(); not-implemented
			Console.WriteLine("MergeSorted list ");
		}
	}

	// The 'Context' class
	class SortedList : List<Student> {
		// Sets sort strategy
		public ISortStrategy SortStrategy { get; set; }

		// Perform sort
		public void SortStudents() {
			SortStrategy.Sort(this);

			// Display sort results
			foreach(var student in this) {
				Console.WriteLine(" " + student.Name);
			}
			Console.WriteLine();
		}
	}

	// Represents a student
	class Student {
		public string Name { get; set; }
		public string Id { get; set; }
	}
}
