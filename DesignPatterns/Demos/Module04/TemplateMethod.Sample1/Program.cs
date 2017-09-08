using System;
using System.Data;
using System.Data.OleDb;

namespace TemplateMethod.Sample1 {
	class Program {
		static void Main() {
			DataAccessObject daoCategories = new Categories();
			daoCategories.Run();

			DataAccessObject daoProducts = new Products();
			daoProducts.Run();
		}
	}

	// The 'AbstractClass' abstract class
	abstract class DataAccessObject {
		protected string connectionString;
		protected DataSet dataSet;

		public virtual void Connect() {
			// Make sure mdb is available to app
			connectionString =
				 "provider=Microsoft.JET.OLEDB.4.0; " +
				 "data source=..\\..\\..\\db1.mdb";
		}

		public abstract void Select();
		public abstract void Process();

		virtual public void Disconnect() {
			connectionString = "";
		}

		// The 'Template Method' 
		public void Run() {
			Connect();
			Select();
			Process();
			Disconnect();
		}
	}

	// A 'ConcreteClass' class
	class Categories : DataAccessObject {
		public override void Select() {
			string sql = "select CategoryName from Categories";
			var dataAdapter = new OleDbDataAdapter(
				 sql, connectionString);

			dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Categories");
		}

		public override void Process() {
			Console.WriteLine("Categories ---- ");

			var dataTable = dataSet.Tables["Categories"];
			foreach(DataRow row in dataTable.Rows) {
				Console.WriteLine(row["CategoryName"]);
			}
			Console.WriteLine();
		}
	}

	/// <summary>
	/// A 'ConcreteClass' class
	/// </summary>
	class Products : DataAccessObject {
		public override void Select() {
			string sql = "select ProductName from Products";
			var dataAdapter = new OleDbDataAdapter(
				 sql, connectionString);

			dataSet = new DataSet();
			dataAdapter.Fill(dataSet, "Products");
		}

		public override void Process() {
			Console.WriteLine("Products ---- ");
			var dataTable = dataSet.Tables["Products"];
			foreach(DataRow row in dataTable.Rows) {
				Console.WriteLine(row["ProductName"]);
			}
			Console.WriteLine();
		}
	}
}
