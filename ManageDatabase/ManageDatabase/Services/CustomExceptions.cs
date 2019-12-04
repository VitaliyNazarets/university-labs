using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ManageDatabase
{
	[Serializable]
	public class NotEqualsColumnsException : Exception
	{
		public NotEqualsColumnsException() : base()
		{

		}
		public NotEqualsColumnsException(string message)
			: base(message)
		{
		}
		public NotEqualsColumnsException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
		public NotEqualsColumnsException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	[Serializable]
	public class NotSupportedTypeException : Exception
	{
		public NotSupportedTypeException() : base()
		{

		}
		public NotSupportedTypeException(string message)
			: base(message)
		{
		}
		public NotSupportedTypeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
		public NotSupportedTypeException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	[Serializable]
	public class RepetableNameException : Exception
	{
		public RepetableNameException() : base()
		{

		}
		public RepetableNameException(string message)
			: base(message)
		{
		}
		public RepetableNameException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
		public RepetableNameException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
