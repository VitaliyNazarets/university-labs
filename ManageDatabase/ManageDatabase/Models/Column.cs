namespace ManageDatabase
{
	public class Column
	{
		public string Name { get; set; }
		public ColumnType ColumnType { get; set; }
		public int Min { get; set; }
		public int Max { get; set; }
		public Column()
		{

		}
		public bool Equals(Column column)
		{
			if (this.Name == column.Name && this.Max == column.Max && this.Min == column.Min && this.ColumnType == column.ColumnType)
				return true;
			return false;
		}
		public Column(string name, ColumnType columnType)
		{
			Name = name;
			ColumnType = columnType;
			if (columnType.Equals(ColumnType.Color))
			{
				Min = 0;
				Max = 255;
			}
		}
		public Column(string name, ColumnType columnType, int min, int max)
		{
			Name = name;
			if (!columnType.Equals(ColumnType.ColorInvl))
				throw new System.InvalidOperationException();
			ColumnType = columnType;
			Min = min < 0 ? 0 : min > 255 ? 255 : min;
			Max = max < min ? min : max > 255 ? 255 : max;
		}
	}
}
