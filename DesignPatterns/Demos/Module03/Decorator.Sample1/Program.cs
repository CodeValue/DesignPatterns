using System;
using System.Collections.Generic;

namespace Decorator.Sample1 {
	class Program {
		/// <summary>
		/// Entry point into console application.
		/// </summary>
		static void Main() {
			// Create book
			Book book = new Book("Don Box", "Essential COM", 10);
			book.Display();

			// Create video
			Video video = new Video("Spielberg", "Jaws", 23, 92);
			video.Display();

			// Make video borrowable, then borrow and display
			Console.WriteLine("\nMaking video borrowable:");

			Borrowable borrowvideo = new Borrowable(video);
			borrowvideo.BorrowItem("Customer #1");
			borrowvideo.BorrowItem("Customer #2");

			borrowvideo.Display();
		}
	}

	// The 'Component' abstract class
	abstract class LibraryItem {
		private int _numCopies;

		public int NumCopies { get; set; }

		public abstract void Display();
	}

	// The 'ConcreteComponent' class
	class Book : LibraryItem {
		private string _author;
		private string _title;

		// Constructor
		public Book(string author, string title, int numCopies) {
			this._author = author;
			this._title = title;
			this.NumCopies = numCopies;
		}

		public override void Display() {
			Console.WriteLine("\nBook ------ ");
			Console.WriteLine(" Author: {0}", _author);
			Console.WriteLine(" Title: {0}", _title);
			Console.WriteLine(" # Copies: {0}", NumCopies);
		}
	}

	// The 'ConcreteComponent' class
	class Video : LibraryItem {
		private string _director;
		private string _title;
		private int _playTime;

		// Constructor
		public Video(string director, string title,
			 int numCopies, int playTime) {
			this._director = director;
			this._title = title;
			this.NumCopies = numCopies;
			this._playTime = playTime;
		}

		public override void Display() {
			Console.WriteLine("\nVideo ----- ");
			Console.WriteLine(" Director: {0}", _director);
			Console.WriteLine(" Title: {0}", _title);
			Console.WriteLine(" # Copies: {0}", NumCopies);
			Console.WriteLine(" Playtime: {0}\n", _playTime);
		}
	}

	// The 'Decorator' abstract class
	abstract class Decorator : LibraryItem {
		protected LibraryItem libraryItem;

		// Constructor
		public Decorator(LibraryItem libraryItem) {
			this.libraryItem = libraryItem;
		}

		public override void Display() {
			libraryItem.Display();
		}
	}

	// The 'ConcreteDecorator' class
	class Borrowable : Decorator {
		protected List<string> borrowers = new List<string>();

		// Constructor
		public Borrowable(LibraryItem libraryItem)
			: base(libraryItem) {
		}

		public void BorrowItem(string name) {
			borrowers.Add(name);
			libraryItem.NumCopies--;
		}

		public void ReturnItem(string name) {
			borrowers.Remove(name);
			libraryItem.NumCopies++;
		}

		public override void Display() {
			base.Display();

			foreach(string borrower in borrowers) {
				Console.WriteLine(" borrower: " + borrower);
			}
		}
	}
}
