	using System;
	using System.Diagnostics;
	using System.Text;
	using System.Reflection;

namespace Scada.Controls
{
	
	/// <summary>
	/// Custom trace listener logging to a file
	/// </summary>
	public class LogFileTraceListener : TextWriterTraceListener { 
	
		#region Constructors
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="name"></param>
		public LogFileTraceListener( System.IO.Stream stream, string name ) :
			base(stream, name) { }
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="stream"></param>
		public LogFileTraceListener( System.IO.Stream stream) : 
			base(stream) { }
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="fileName"></param>
		/// <param name="name"></param>
		public LogFileTraceListener( string fileName, string name ) : 
			base(fileName, name) {	}
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="fileName"></param>
		public LogFileTraceListener( string fileName ) : 
			base(fileName) { }
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="writer"></param>
		/// <param name="name"></param>
		public LogFileTraceListener( System.IO.TextWriter writer, string name ) : 
			base(writer, name) { }
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="writer"></param>
		public LogFileTraceListener( System.IO.TextWriter writer ) : 
			base(writer) { }

		#endregion

		#region Methods
		/// <summary>
		/// Write a message to the stream
		/// </summary>
		/// <param name="message">the sstring to be written</param>
		public override void Write( string message ) 
		{	
			
			base.Write(  message );
		}

		/// <summary>
		/// Write a line of message
		/// </summary>
		/// <param name="message"></param>
		public override void WriteLine( string message ) {	
		 
			base.WriteLine( getPreambleMessage() + message );
		} 

		/// <summary>
		/// Gets the type and method name wherein the trace call is
		/// </summary>
		/// <returns></returns>
		[System.Runtime.CompilerServices.MethodImpl(
			 System.Runtime.CompilerServices.MethodImplOptions.NoInlining )]
		private string getPreambleMessage() {
			
			StringBuilder preamble = new StringBuilder();
			
			StackTrace stackTrace = new StackTrace();
			StackFrame stackFrame;
			MethodBase stackFrameMethod;

			int frameCount = 0;
			string typeName;
			do {
				frameCount++;
				stackFrame	= stackTrace.GetFrame(frameCount);
				stackFrameMethod = stackFrame.GetMethod();
				typeName = stackFrameMethod.ReflectedType.FullName;
			} while ( typeName.StartsWith("System") || typeName.EndsWith("LogFileTraceListener") );
			
			//log DateTime, Namespace, Class and Method Name
			preamble.Append(DateTime.Now.ToString());
			preamble.Append("> ");
			preamble.Append(typeName);
			preamble.Append(".");
			preamble.Append(stackFrameMethod.Name);
			preamble.Append("(...)");
		
			// log parameter types and names
			// but not really interesting unless the actual values of the params would be visible
			/*
			ParameterInfo[] parameters = stackFrameMethod.GetParameters();
			int parameterIndex = 0;
			while( parameterIndex < parameters.Length ) {
				preamble.Append(parameters[parameterIndex].ParameterType.Name);
				preamble.Append(" ");
				preamble.Append(parameters[parameterIndex].Name);
				parameterIndex++;
				if (parameterIndex != parameters.Length ) preamble.Append(", ");
			}
			*/
				
			preamble.Append(" ");

			return preamble.ToString();
		
		}
		#endregion
	}
}
