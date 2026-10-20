namespace LINQ.Models
{
	public class Student
	{
		public string Name { get; set; }
		public int Grade { get; set; }
		public string Major { get; set; }

		public override string ToString()
		{
			return $"Name: {Name}, Grade: {Grade}, Major: {Major}";
		}

	
	}
}
