using System;

namespace Labs
{
	/// <summary>
	/// Summary description for Person.
	/// </summary>
	
	public class Person
	{
		private string _name;
		private string _lastName;
		private int _age;
		private string _city;
		private int _index;

		private static int INDEX_COUNTER=0;

		public Person(string name,string lastName,int age,string city)
		{
			_name=name;
			_lastName=lastName;
			_age=age;
			_city=city;	
		
			INDEX_COUNTER++;
			_index=INDEX_COUNTER;
		}

		public string Name
		{
			get			
			{
				return _name;
			}
			set
			{
				_name=value;
			}
		}

		public string LastName
		{
			get			
			{
				return _lastName;
			}
			set
			{
				_lastName=value;
			}
		}

		public int Age
		{
			get			
			{
				return _age;
			}
			set
			{
				_age=value;
			}
		}

		public string City
		{
			get			
			{
				return _city;
			}
			set
			{
				_city=value;
			}
		}

		public int Index
		{
			get			
			{
				return _index;
			}
			set
			{
				_index=value;
			}
		}
	}
}
